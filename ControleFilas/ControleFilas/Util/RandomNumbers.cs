using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;
using ControleFilas.Enumerator;

namespace ControleFilas.Util
{
    public class RandomNumbers : Random
    {
        public RandomNumbers(int seed) : base(seed) { }

        public float NextDoubleLogNormal()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }

        public float NextDoubleLogLogistic()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }

        public float NextDoubleExponential()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }

        public float NextDoubleGamma()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }

        public float NextDoubleWeibull()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }

        public float NextDoubleNormal()
        {
            Double d = base.NextDouble() * (1 - 0) + 0;
            return float.Parse(d.ToString());

            //long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks);
            //int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));
            //Random r = new Random(seed);
            //Double d = r.Next(0, 1); 
            //return float.Parse(d.ToString());
        }
    }

    public class RandomNumbersDistribuitions
    {
        private Distribution _distribution;
        private TypeDistribution _typeDistribuition;

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
