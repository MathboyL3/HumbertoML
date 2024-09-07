using HumbertoML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML
{
    public class SoftMaxFunction : IActivationFunction
    {

        public float[] Activate(float[] args)
        {
            float maxVal = args.Max();
            float[] expValues = args.Select(v => MathF.Exp(v - maxVal)).ToArray();
            float sumExp = expValues.Sum();
            float[] softmaxValues = expValues.Select(v => v / sumExp).ToArray();
            return softmaxValues;
        }

        public void ActivateT(float[] args)
        {
            float maxVal = args.Max();
            for(int i = 0; i < args.Length; i++)
                args[i] = MathF.Exp(args[i] - maxVal);
            
            float sumExp = args.Sum();

            for (int i = 0; i < args.Length; i++)
                args[i] /= sumExp;
        }
    }
}
