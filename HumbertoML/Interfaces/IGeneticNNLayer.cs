namespace HumbertoML.Interfaces
{
    public interface IGeneticNNLayer
    {
        void Mutate(float mutationPercentage, float mutationChance);
        IGeneticNNLayer Clone();
    }
}