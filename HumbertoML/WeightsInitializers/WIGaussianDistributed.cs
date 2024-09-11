using HumbertoML.Interfaces;
using HumbertoML.Utility;

namespace HumbertoML.WeightsInitializers
{
    public class WIGaussianDistributed : IWeightInitializer
    {

        public float[][] GetWeights(int inputs, int outputs)
        {
            var rnd = Random.Shared;
            float[][] weights = new float[outputs][];
            for (int i = 0; i < outputs; i++)
            {
                weights[i] = new float[inputs];
                for (int j = 0; j < inputs; j++)
                    weights[i][j] = Utils.GenerateGaussian(rnd, 0, 1);
            }
            return weights;
        }
    }
}
