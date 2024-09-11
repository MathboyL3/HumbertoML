namespace HumbertoML.ActivationFunctions
{
    public static class Functions
    {
        public static readonly LeakyReLUFunction LeakyReLU = new LeakyReLUFunction();
        public static readonly ReLUFunction ReLU = new ReLUFunction();
        public static readonly SigmoidFunction Sigmoid = new SigmoidFunction();
        public static readonly SoftMaxFunction SoftMax = new SoftMaxFunction();
        public static readonly TanHFucntion Tanh = new TanHFucntion();
        public static readonly LinearFunction Linear = new LinearFunction();
        public static readonly SoftPlusFunction SoftPlus = new SoftPlusFunction();
    }
}
