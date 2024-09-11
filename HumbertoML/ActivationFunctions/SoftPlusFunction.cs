using HumbertoML.Interfaces;

namespace HumbertoML.ActivationFunctions
{
    public class SoftPlusFunction : BaseAcDcFunction, IActivationDeactiviationFunction
    {
        public override float Activate(float val)
        {
            return MathF.Log(1 + MathF.Exp(val), MathF.E);
        }

        public override float Deactivate(float val)
        {
            return 1 / 1 + MathF.Exp(-val);
        }
    }
}
