using HumbertoML.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Interfaces
{
    public interface IBackPropagateNN
    {
        void TrainCompleteData(TrainingSet[] data, int iterations, float learningRate);
    }
}
