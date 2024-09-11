namespace HumbertoML.Interfaces
{
    public interface IActivationFunction
    {
        /// <summary>
        /// This method allocates a new array for the result
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        float[] Activate(float[] args);

        /// <summary>
        /// This method alters the parameter array directly, no allocations needed
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        void ActivateT(float[] args);
    }
}
