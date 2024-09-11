using HumbertoML.Interfaces;

namespace HumbertoML.ActivationFunctions
{
    public class LinearFunction : BaseAcDcFunction, IActivationDeactiviationFunction
    {
        public override float Activate(float val)
        {
            return val;
        }

        public override float Deactivate(float val)
        {
            return 1;
        }
    }
}
