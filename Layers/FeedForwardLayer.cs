using HumbertoML.Interfaces;
using HumbertoML.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Layers
{
    public struct FeedForwardLayer : IFeedForwardLayer, IGeneticNNLayer, IBackPropagateNNLayer
    {
        public float[] _bias {  get; set; }
        public float[][] _weights { get; set; }

        public int _inputSize { get; set; }
        public int _outputSize { get; set; }

        public IActivationDeactiviationFunction _activationFunction { get; set; }

        public FeedForwardLayer()
        {

        }

        public FeedForwardLayer(int inputSize, int outputSize, IActivationDeactiviationFunction functions)
        {
            _inputSize = inputSize;
            _outputSize = outputSize;

            _activationFunction = functions;

            _bias = new float[outputSize];
            //for (int i = 0; i < outputSize; i++)
            //    _bias[i] = 0.1;

            //_bias = Utils.GetRandoms(outputSize);

            _weights = new float[outputSize][];

            //for(int i = 0; i < outputSize; i++)
            //    _weights[i] = Utils.GetRandoms(inputSize);


            float variance = MathF.Sqrt(6.0f / (inputSize + outputSize));

            for (int i = 0; i < outputSize; i++)
            {
                _weights[i] = new float[inputSize];
                for (int j = 0; j < inputSize; j++)
                {
                    // Xavier initialization using a uniform distribution
                    _weights[i][j] = (float)(Random.Shared.NextSingle() * 2 * variance - variance);
                }
            }
        }


        public float[] FeedFoward(float[] args)
        {
            float[] result = new float[_outputSize];

            var iSize = _inputSize; // local caching
            var weightsSpan = _weights.AsSpan(); // local caching

            for (int i = 0; i < _outputSize; i++)
            {
                float r = 0;
                var ws = weightsSpan[i].AsSpan(); // local caching
                for (int k = 0; k < iSize; k++)
                    r += args[k] * ws[k];

                result[i] = r + _bias[i];
            }

            _activationFunction.ActivateT(result);
            return result;
        }

        public void Mutate(float mutationPercentage, float mutationChance)
        {
            for(int i = 0; i < _bias.Length; i++)
            {
                var rnd = Random.Shared.NextSingle();
                if (rnd >= mutationChance) continue;

                float randomPercentage = (Random.Shared.NextSingle() * 2 - 1) * mutationPercentage;

                _bias[i] *= 1f + randomPercentage / 100f;
            }

            for (int i = 0; i < _bias.Length; i++)
            {
                for (int k = 0; k < _weights[i].Length; k++)
                {
                    var rnd2 = Random.Shared.NextSingle();
                    if (rnd2 >= mutationChance) continue;

                    float randomPercentage2 = (Random.Shared.NextSingle() * 2 - 1) * mutationPercentage;

                    _weights[i][k] *= 1f + randomPercentage2 / 100f;
                }
            }

            
        }

        public IGeneticNNLayer Clone()
        {
            var result = new FeedForwardLayer();
            result._bias = new float[_bias.Length];
            _bias.CopyTo(result._bias, 0);

            result._activationFunction = _activationFunction;
            
            result._outputSize = _outputSize;
            result._inputSize = _inputSize;

            result._weights = new float[_weights.Length][];

            for (int i = 0; i < _weights.Length; i++)
            {
                result._weights[i] = new float[_weights[i].Length];
                _weights[i].CopyTo(result._weights[i], 0);
            }

            return result;
        }

        public float[] Tunning(float[] inputs, float[] output, float[] error, float learningRate)
        {
            var gradient = _activationFunction.Deactivate(output);

            for (int i = 0; i < gradient.Length; i++)
                gradient[i] *= error[i] * learningRate;

            var inputSize = _inputSize;
            var outputSize = _outputSize;

            var cacheBias = _bias.AsSpan();
            var cacheWeights = _weights.AsSpan();

            var hError = new float[inputSize];
            

            for (int k = 0; k < outputSize; k++)
            {
                var cw = cacheWeights[k].AsSpan();
                for (int i = 0; i < inputSize; i++)
                    hError[i] += cw[i] * error[k];
            }

            for (int i = 0; i < outputSize; i++)
            {
                var cw = cacheWeights[i].AsSpan();
                for (int k = 0; k < inputSize; k++)
                    cw[k] += inputs[k] * gradient[i];
            }

            for (int i = 0; i < outputSize; i++)
                cacheBias[i] += gradient[i];

            //float momentum = 0.9;
            //float[][] velocity = new float[_outputSize][];

            //for (int i = 0; i < _outputSize; i++)
            //{
            //    velocity[i] = new float[_inputSize];
            //}

            //for (int i = 0; i < _outputSize; i++)
            //{
            //    for (int j = 0; j < _inputSize; j++)
            //    {
            //        velocity[i][j] = momentum * velocity[i][j] + learningRate * gradient[i] * inputs[j];
            //        _weights[i][j] += velocity[i][j];
            //    }
            //}

            return hError;
        }
    }
}
