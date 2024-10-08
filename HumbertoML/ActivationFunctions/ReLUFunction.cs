﻿using HumbertoML.Interfaces;

namespace HumbertoML.ActivationFunctions
{
    public class ReLUFunction : BaseAcDcFunction, IActivationFunction, IDeactivationFunction, IActivationDeactiviationFunction
    {
        public override float Activate(float val)
        {
            return Math.Max(0, val);
        }
        public override float Deactivate(float val)
        {
            return val < 0 ? 0 : 1;
        }
    }
}
