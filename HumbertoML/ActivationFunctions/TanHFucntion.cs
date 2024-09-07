using HumbertoML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.ActivationFunctions
{
    public class TanHFucntion : IActivationFunction, IDeactivationFunction, IActivationDeactiviationFunction
    {
        private float Activate(float val)
        {
            return MathF.Tanh(val);
        }
        public float[] Activate(float[] args)
        {
            float[] result = new float[args.Length];
            for (int i = 0; i < args.Length; i++)
                result[i] = Activate(args[i]);

            return result;
        }

        public void ActivateT(float[] args)
        {
            for (int i = 0; i < args.Length; i++)
                args[i] = Activate(args[i]);
        }

        private float Deactivate(float val)
        {
            return 1.0f - val * val;
        }

        public float[] Deactivate(float[] args)
        {
            float[] result = new float[args.Length];
            for (int i = 0; i < args.Length; i++)
                result[i] = Deactivate(args[i]);

            return result;
        }

        public void DeactivateT(float[] args)
        {
            for (int i = 0; i < args.Length; i++)
                args[i] = Deactivate(args[i]);
        }
    }
}
