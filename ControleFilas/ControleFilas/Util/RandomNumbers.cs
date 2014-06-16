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

        public RandomNumbersDistribuitions(TypeDistribution distribuition, TypeService typeService, TypeMoment typeMoment)
        {
            _typeDistribuition = distribuition;

            switch (distribuition)
            {
                case TypeDistribution.Cauchy:
                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new CauchyDistribution(12.412d, 14.421d);
                        }
                        else
                        {
                            _distribution = new CauchyDistribution(21.866d, 157.03d);
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new CauchyDistribution(14.196d, 17.866d);
                        }
                        else
                        {
                            _distribution = new CauchyDistribution(4.7784d, 20.582d);
                        }
                    }

                    break;
                case TypeDistribution.Laplace:

                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new LaplaceDistribution(0.04891d, 31d);
                        }
                        else
                        {
                            _distribution = new LaplaceDistribution(0.02936d, 164.88d);
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new LaplaceDistribution(0.02703d, 33.5d);
                        }
                        else
                        {
                            _distribution = new LaplaceDistribution(0.07365d, 28.5d);
                        }
                    }

                    break;

                case TypeDistribution.LogNormal:

                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            LognormalDistribution distribution = new LognormalDistribution();
                            distribution.Mu = 1.0886d;
                            distribution.Sigma = 3.0087d;
                            _distribution = distribution;
                        }
                        else
                        {
                            LognormalDistribution distribution = new LognormalDistribution();
                            distribution.Mu = 0.31672d;
                            distribution.Sigma = 5.0589d;
                            _distribution = distribution;
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            LognormalDistribution distribution = new LognormalDistribution();
                            distribution.Mu = 1.2223d;
                            distribution.Sigma = 2.8666d;
                            _distribution = distribution;
                        }
                        else
                        {
                            LognormalDistribution distribution = new LognormalDistribution();
                            distribution.Mu = 0.55395d;
                            distribution.Sigma = 3.1808d;
                            _distribution = distribution;
                        }
                    }

                    

                    break;

                case TypeDistribution.Normal:
                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new NormalDistribution(28.914d, 31d);
                        }
                        else
                        {
                            _distribution = new NormalDistribution(48.164d, 164.88d);
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new NormalDistribution(52.323d, 33.5);
                        }
                        else
                        {
                            _distribution = new NormalDistribution(19.202d, 28.5d);
                        }
                    }

                    break;

                case TypeDistribution.Gamma:
                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new GammaDistribution(1.1751d, 27.932d);
                        }
                        else
                        {
                            _distribution = new GammaDistribution(11.718d, 14.07d);
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new GammaDistribution(0.84625d, 41.67d);
                        }
                        else
                        {
                            _distribution = new GammaDistribution(2.203d, 12.937d);
                        }
                    }

                    break;


                case TypeDistribution.Weibull:
                    // Caso o sistema seja o servindo para o almoço
                    if (typeService == TypeService.Lunch)
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new WeibullDistribution(0.53129d, 30.011d);
                        }
                        else
                        {
                            _distribution = new WeibullDistribution(3.2768d, 181.76d);
                        }
                    }
                    // Caso o sistema seja pagando o almoço
                    else
                    {
                        if (typeMoment == TypeMoment.ArrivalTime)
                        {
                            _distribution = new WeibullDistribution(0.85626d, 32.101d);
                        }
                        else
                        {
                            _distribution = new WeibullDistribution(1.964d, 30.199d);
                        }
                    }

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
