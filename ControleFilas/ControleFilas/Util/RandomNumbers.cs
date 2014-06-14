using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
