namespace HumbertoML.Interfaces
{
    public interface IBackPropagateNNLayer
    {
        float[] Tunning(float[] inputs, float[] output, float[] error, float learningRate);
    }
}
