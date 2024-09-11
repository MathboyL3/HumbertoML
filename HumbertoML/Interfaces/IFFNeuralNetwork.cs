namespace HumbertoML.Interfaces
{
    public interface IFFNeuralNetwork : INeuralNet
    {
        float[] Feed(float[] args);
    }
}
