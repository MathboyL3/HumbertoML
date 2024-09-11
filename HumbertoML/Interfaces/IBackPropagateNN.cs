using HumbertoML.Training;

namespace HumbertoML.Interfaces
{
    public interface IBackPropagateNN
    {
        void TrainCompleteData(TrainingSet[] data, int iterations, float learningRate);
    }
}
