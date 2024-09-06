using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.Interfaces
{
    public interface IDeactivationFunction
    {
        float[] Deactivate(float[] args);
        void DeactivateT(float[] args);
    }
}
