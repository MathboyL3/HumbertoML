using HumbertoML.Interfaces;
namespace HumbertoML.ActivationFunctions
{
    public abstract class BaseAcDcFunction : IActivationDeactiviationFunction
    {
        public abstract float Activate(float val);

        public abstract float Deactivate(float val);

        public virtual float[] Activate(float[] args)
        {
            float[] result = new float[args.Length];
            for (int i = 0; i < args.Length; i++)
                result[i] = Activate(args[i]);

            return result;
        }

        public virtual void ActivateT(float[] args)
        {
            for (int i = 0; i < args.Length; i++)
                args[i] = Activate(args[i]);
        }

        public virtual float[] Deactivate(float[] args)
        {
            float[] result = new float[args.Length];
            for (int i = 0; i < args.Length; i++)
                result[i] = Deactivate(args[i]);

            return result;
        }

        public virtual void DeactivateT(float[] args)
        {
            for (int i = 0; i < args.Length; i++)
                args[i] = Deactivate(args[i]);
        }
    }
}
