using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;
using ControleFilas.Enumerator;

namespace ControleFilas.Util
{
    public class RandomNumbersDistribuitions
    {
        private Distribution _distribution;
        private TypeDistribution _typeDistribuition;

        public static TypeDistribution GetDistribution(int distribution)
        {
            switch (distribution)
	        {
                case 1:
                    return TypeDistribution.Cauchy;

		        default:
                    return TypeDistribution.Normal;
	        }
        }

        public RandomNumbersDistribuitions(TypeDistribution distribuition)
        {
            _typeDistribuition = distribuition;

            switch (distribuition)
            {
                case TypeDistribution.Cauchy:

                    _distribution = new CauchyDistribution();

                    break;
                case TypeDistribution.Laplace:

                    _distribution = new LaplaceDistribution();

                    break;
                case TypeDistribution.Pareto:

                    _distribution = new ParetoDistribution();
                    
                    break;
                case TypeDistribution.LogNormal:

                    _distribution = new LognormalDistribution();

                    break;

                case TypeDistribution.Normal:

                    _distribution = new NormalDistribution();

                    break;
            }
        }

        public double NextDouble()
        {
            double number = _distribution.NextDouble();
            if (number < 0)
            {
                return number * -1;
            }
            return number;
        }
    }
}
