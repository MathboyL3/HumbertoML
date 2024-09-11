using HumbertoML.Interfaces;

namespace HumbertoML.ActivationFunctions
{
    public class LeakyReLUFunction : BaseAcDcFunction, IActivationFunction, IDeactivationFunction, IActivationDeactiviationFunction
    {
        private float leaky = 0.01f;

        public override float Activate(float val)
        {
            return val < 0 ? val * leaky : val;
        }

        public override float Deactivate(float val)
        {
            return val < 0 ? leaky : 1;
        }

    }
}
