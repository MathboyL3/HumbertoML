using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumbertoML.WeightsInitializers
{
    public static class WInitializers
    {
        public static WIGaussianDistributed WIGaussianDistributed = new WIGaussianDistributed();
        
        public static WIKaimingNormal WIKaimingNormal = new WIKaimingNormal();
        public static WIKaimingUniform WIKaimingUniform = new WIKaimingUniform();
        
        public static WIXavierNormal WIXavierNormal = new WIXavierNormal();
        public static WIXavierUniform WIXavierUniform = new WIXavierUniform();
        
        public static WINPRandom11 WINPRandom11 = new WINPRandom11();
        public static WINPRandom55 WINPRandom55 = new WINPRandom55();
        
        public static WIPositiveRandom01 WIPositiveRandom01 = new WIPositiveRandom01();
        public static WIPositiveRandom05 WIPositiveRandom05 = new WIPositiveRandom05();
    }
}
