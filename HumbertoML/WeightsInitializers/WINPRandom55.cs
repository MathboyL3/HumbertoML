using HumbertoML.Interfaces;

namespace HumbertoML.WeightsInitializers
{
    //WeightsInitializerNegativePositiveRandom from -5 to 5
    public class WINPRandom55 : IWeightInitializer
    {
        public float[][] GetWeights(int inputs, int outputs)
        {
            var rand = Random.Shared;
            var weights = new float[outputs][];
            for (int i = 0; i < outputs; i++)
            {
                weights[i] = new float[inputs];
                for (int k = 0; k < inputs; k++)
                    weights[i][k] = rand.NextSingle() * 10 - 5;
            }

            return weights;
        }
    }
}
