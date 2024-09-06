using HumbertoML.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.ActivationFunctions
{
    public static class Functions
    {
        public static readonly LeakyReLUFunction LeakyReLU = new LeakyReLUFunction();
        public static readonly ReLUFunction ReLU = new ReLUFunction();
        public static readonly SigmoidFunction Sigmoid = new SigmoidFunction();
        public static readonly SoftMaxFunction SoftMax = new SoftMaxFunction();
        public static readonly TanHFucntion TanhFucntion = new TanHFucntion();
    }
}
