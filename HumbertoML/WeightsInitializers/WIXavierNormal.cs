using HumbertoML.Interfaces;
using HumbertoML.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.WeightsInitializers
{
    public class WIXavierNormal : IWeightInitializer
    {
        public float[][] GetWeights(int inputs, int outputs)
        {
            var rnd = Random.Shared;
            float stddev = MathF.Sqrt(2f / (inputs + outputs));
            float[][] weights = new float[outputs][];
            for (int i = 0; i < outputs; i++)
            {
                weights[i] = new float[inputs];
                for (int j = 0; j < inputs; j++)
                    weights[i][j] = Utils.GenerateGaussian(rnd, 0, stddev);
            }
            return weights;
        }

    }
}
