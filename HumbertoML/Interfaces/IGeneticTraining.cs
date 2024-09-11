using HumbertoML.Training;
namespace HumbertoML.Interfaces
{
    public interface IGeneticTraining<T> where T : IGeneticNN
    {
        IGeneticTraining<T> SetErrorThreshold(float error);
        IGeneticTraining<T> SetTestingSet(TrainingSet[] trainingSet, float batchPercentage);
        IGeneticTraining<T> SetConfiguration(params object[] parameters);
        IGeneticTraining<T> DefineFitFunction(Func<float[], float> func);
        IGeneticNN Train(bool debug = false);

    }


}
