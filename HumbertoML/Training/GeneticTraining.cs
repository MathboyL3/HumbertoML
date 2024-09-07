using HumbertoML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Training
{
    public class GeneticTraining<T> : IGeneticTraining<T> where T : IGeneticNN
    {
        public int _populationSize { get; private set; }
        public int _maxGenerations { get; private set; }
        public float _mutationChance { get; private set; }
        public float _mutationPercentage { get; private set; }

        public List<(float[] labels, float[] data)> _trainingSet { get; private set; }
        public int _trainingSetSize { get; private set; }
        public float _trainingBatchPercentage { get; private set; }
        public int _totalBatches { get; private set; }

        public object[] _defaultNNParameters { get; private set; }

        public T[] _population { get; private set; }

        public float _errorThreshold { get; private set; }

        public Func<float[], float> _fitFunction { get; private set; }
        public Func<float, bool> _stopFunciton { get; private set; }

        public GeneticTraining(int populationSize, int maxGenerations, float mutationAmount, float mutationChance) {
            _populationSize = populationSize;
            _maxGenerations = maxGenerations;
            _mutationChance = mutationChance;
            _mutationPercentage = mutationAmount;

            _fitFunction = x =>
            {
                var med = x.Sum() / x.Length;
                return 1f - MathF.Tanh(med) * 2;
            };

            _stopFunciton = x =>
            {
                return 1f - x < _errorThreshold;
            };
        }

        public IGeneticTraining<T> SetErrorThreshold(float error)
        {
            _errorThreshold = error;
            return this;
        }

        public IGeneticTraining<T> SetTestingSet(TrainingSet[] trainingSet, float batchPercentage)
        {
            _trainingSet = new();

            for(int i = 0; i < trainingSet.Length; i++)
            {
                var set = trainingSet[i];
                foreach(var s in set.Set)
                    _trainingSet.Add((set.Label, s));
            }

            _trainingSetSize = trainingSet.Sum(x => x.Set.Length);
            _trainingBatchPercentage = batchPercentage;
            _totalBatches = (int)Math.Floor(_trainingSetSize * _trainingBatchPercentage);
            return this;
        }
               
        public IGeneticTraining<T> SetConfiguration(params object[] parameters)
        {
            _defaultNNParameters = parameters;
            return this;
        }
               
        public IGeneticTraining<T> DefineFitFunction(Func<float[], float> func)
        {
            _fitFunction = func;
            return this;
        }

        private void SetupPopulation()
        {
            _population = new T[_populationSize];

            Parallel.For(0, _populationSize, x =>
            {
                _population[x] = (T)Activator.CreateInstance(typeof(T), _defaultNNParameters);
            });
        }


        public IGeneticNN Train(bool debug = false)
        {
            Console.WriteLine("Iniciando população...");
            SetupPopulation();
            Console.WriteLine("População iniciada");


            var scores = new (int index, float score)[_populationSize];

            for (int i = 0; i < _maxGenerations; i++)
            {
                Console.WriteLine($"Treinando Gen: {i + 1}/{_maxGenerations}... ");
                
                scores = TrainIteration();

                for (int k = 0; k < scores.Length; k++)
                    if (_stopFunciton?.Invoke(scores[k].score) ?? false)
                        return _population[scores[k].index];

                Console.WriteLine($"Best score: {scores[0].score}");
                Console.WriteLine($"Mutating and repopulating...");
                Mutate(scores);
                Console.WriteLine($"Completed...");
            }

            return _population[scores[0].index];
        }

        private void Mutate((int index, float scores)[] values)
        {
            var half = _populationSize / 2;
            for (int k = 0; k < half; k++)
            {
                var index = values[k].index;
                var indexHalf = values[k + half].index;

                _population[indexHalf] = (T)_population[index].Clone();
                //_population[index].Mutate(_mutationPercentage, _mutationChance);
                _population[indexHalf].Mutate(_mutationPercentage, _mutationChance);
            }
        }

        private (int index, float score)[] TrainIteration()
        {
            (int index, float score)[] scores = new (int, float)[_populationSize];

            var setIndexes = GetRadomSets();
            var popSize = _populationSize;
            for (int i = 0; i < _totalBatches; i++)
            {
                var set = _trainingSet[setIndexes[i]];

                Console.Write($"Batches {i+1}/{_totalBatches}\r");

                Parallel.For(0, popSize, k =>
                {
                    var nn = _population[k];
                    var result = nn.GetResult(set.data);
                    var error = GetError(set.labels, result);
                    scores[k].index = k;
                    scores[k].score += _fitFunction?.Invoke(error) ?? 0;
                });

                //for(int k = 0; k < _populationSize; k++)
                //{
                //    var nn = _population[k];
                //    var result = nn.GetResult(set.data);
                //    var error = GetError(set.labels, result);
                //    scores[k].index = k;
                //    scores[k].score += _fitFunction?.Invoke(error) ?? 0;
                //}
            }
            Console.WriteLine();

            return scores.Select(x => (x.index, x.score / _totalBatches)).OrderByDescending(x => x.Item2).ToArray();
        }

        private float[] GetError(float[] expected, float[] data)
        {
            float[] error = new float[expected.Length];

            for(int i = 0; i < expected.Length; i++)
                error[i] = Math.Abs(data[i] - expected[i]);

            return error;
        }

        private int[] GetRadomSets()
        {
            var indexes = Enumerable.Range(0, _trainingSetSize).ToList();
            var chosenIndexes = new int[_totalBatches];

            for (int i = 0; i < _totalBatches; i++)
                chosenIndexes[i] = indexes[Random.Shared.Next(0, indexes.Count)];

            return chosenIndexes;
        }

    }
}
