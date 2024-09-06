using HumbertoML.ActivationFunctions;
using HumbertoML.Interfaces;
using HumbertoML.Layers;
using HumbertoML.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.NeuralNets
{
    public class FeedForwardNet : IFFNeuralNetwork, IGeneticNN, IBackPropagateNN
    {
        public int[] _configuration { get; set; }

        public IFeedForwardLayer[] _layers { get; set; }

        public IActivationFunction _activationFunction { get; set; }

        public FeedForwardNet() { }

        public FeedForwardNet(int[] layerSizeConfiguration, IActivationDeactiviationFunction layerFunction = null, IActivationFunction resultsFunction = null)
        {
            _configuration = layerSizeConfiguration;

            _activationFunction = resultsFunction;

            _layers = new IFeedForwardLayer[layerSizeConfiguration.Length - 1];

            for (int i = 0; i < _layers.Length; i++)
                _layers[i] = new FeedForwardLayer(layerSizeConfiguration[i], layerSizeConfiguration[i+1], layerFunction ?? new SigmoidFunction());
        }

        public float[] Feed(float[] args)
        {
            var argsCopy = new float[args.Length];
            Array.Copy(args, argsCopy, args.Length);

            var layers = _layers.AsSpan();

            for(int i = 0; i < layers.Length; i++)
                argsCopy = layers[i].FeedFoward(argsCopy);

            _activationFunction?.ActivateT(argsCopy);

            return argsCopy;
        }

        public float[] GetResult(float[] args)
        {
            return Feed(args);
        }

        public void Mutate(float mutationPercentage, float mutationChance)
        {
            foreach(var layer in _layers)
                ((IGeneticNNLayer)layer).Mutate(mutationPercentage, mutationChance);
        }


        public IGeneticNN Clone()
        {
            var net = new FeedForwardNet();

            net._configuration = _configuration;
            net._activationFunction = _activationFunction;
            net._layers = new IFeedForwardLayer[_layers.Length];
            
            for(int i = 0; i < _layers.Length; i++)
                net._layers[i] = (IFeedForwardLayer)((IGeneticNNLayer)_layers[i]).Clone();

            return net;
        }


        public void TrainSingleData(TrainingSet[] data, int iterations, float learningRate)
        {
            List<(float[] data, float[] label)> labeledData = new(data.Select(x => x.Set.Length).Sum());

            foreach (var d in data)
                foreach (var s in d.Set)
                    labeledData.Add((s, d.Label));

            for (int i = 0; i < iterations; i++)
            {
                var set = labeledData[Random.Shared.Next(0, labeledData.Count)];
                Train(set.data, set.label, learningRate);
            }
        }

        public void TrainCompleteData(TrainingSet[] data, int iterations, float learningRate)
        {

            List<(float[] data, float[] label)> labeledData = new (data.Select(x => x.Set.Length).Sum());

            foreach(var d in data)
                foreach (var s in d.Set)
                    labeledData.Add((s, d.Label));

            for(int i = 0; i < iterations; i++)
            {
                labeledData = labeledData.OrderBy(x => Random.Shared.Next()).ToList();
                //Console.WriteLine($"Iteration {i + 1}/{iterations}         \r");

                for (int k = 0; k < labeledData.Count; k++)
                {
                    var set = labeledData[k];
                    Train(set.data, set.label, learningRate);
                }
            }
        }

        private void Train(float[] data, float[] label, float learningRate)
        {
            var layers = _layers.AsSpan();

            var error = new float[((FeedForwardLayer)layers[layers.Length - 1])._outputSize];
            List<float[]> dataFlow = new(layers.Length + 1) { data };

            for (int i = 0; i < layers.Length; i++)
                dataFlow.Add(layers[i].FeedFoward(dataFlow.Last().ToArray()));

            var output = dataFlow.Last();

            for (int i = 0; i < output.Length; i++)
                error[i] += label[i] - output[i];

            for (int i = layers.Length - 1; i >= 0; i--)
                error = ((IBackPropagateNNLayer)layers[i]).Tunning(dataFlow[i], dataFlow[i + 1], error, learningRate);
        }
    }
}
