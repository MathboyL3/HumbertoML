using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Interfaces
{
    public interface IBackPropagateNNLayer
    {
        float[] Tunning(float[] inputs, float[] output, float[] error, float learningRate);
    }
}
