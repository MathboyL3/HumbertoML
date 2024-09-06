using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Training
{
    public class TrainingSet
    {
        public TrainingSet(float[][] set, float[] labels)
        {
            Set = set;
            Label = labels;
        }

        public float[][] Set {  get; set; }
        public float[] Label {  get; set; }
    }
}
