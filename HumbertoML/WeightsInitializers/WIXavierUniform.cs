using HumbertoML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.WeightsInitializers
{
    public class WIXavierUniform : IWeightInitializer
    {
        public float[][] GetWeights(int inputs, int outputs)
        {
            var random = Random.Shared;
            float limit = MathF.Sqrt(6f / (inputs + outputs));
            float[][] weights = new float[outputs][];
            for(int i = 0; i < outputs; i++)
            {
                weights[i] = new float[inputs];
                for(int k = 0; k < inputs; k++)
                    weights[i][k] = (random.NextSingle() * 2f * limit) - limit;
            }
            return weights;
        }
    }
}
