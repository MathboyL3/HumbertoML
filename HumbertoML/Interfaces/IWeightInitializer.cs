namespace HumbertoML.Interfaces
{
    public interface IWeightInitializer
    {
        public float[][] GetWeights(int inputs, int outputs);
    }
}
