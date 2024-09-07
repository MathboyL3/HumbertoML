namespace HumbertoML.Interfaces
{
    public interface IGeneticNN
    {
        void Mutate(float mutationPercentage, float mutationChance);

        float[] GetResult(float[] args);

        IGeneticNN Clone();
    }
}