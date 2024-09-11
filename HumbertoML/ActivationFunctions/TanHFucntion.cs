using HumbertoML.Interfaces;

namespace HumbertoML.ActivationFunctions
{
    public class TanHFucntion : BaseAcDcFunction, IActivationFunction, IDeactivationFunction, IActivationDeactiviationFunction
    {
        public override float Activate(float val)
        {
            return MathF.Tanh(val);
        }

        public override float Deactivate(float val)
        {
            return 1.0f - val * val;
        }
    }
}
