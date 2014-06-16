using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comum.Framework
{
    public class DateUtil
    {
        /// <summary>
        /// Calcula a diferença entre datas
        /// </summary>
        /// <param name="dtInicial"></param>
        /// <param name="dtFinal"></param>
        /// <returns></returns>
        public static string CalcularDiferencaData(DateTime dtInicial, DateTime dtFinal)
        {
            int years = 0;
            int months = 0;
            int days = 0;

            DateTime tmpMyDOB = new DateTime(dtInicial.Year, dtInicial.Month, 1);

            DateTime tmpFutureDate = new DateTime(dtFinal.Year, dtFinal.Month, 1);

            while (tmpMyDOB.AddYears(years).AddMonths(months) < tmpFutureDate)
            {
                months++;
                if (months > 12)
                {
                    years++;
                    months = months - 12;
                }
            }

            if (dtFinal.Day >= dtInicial.Day)
            {
                days = days + dtFinal.Day - dtInicial.Day;
            }
            else
            {
                months--;
                if (months < 0)
                {
                    years--;
                    months = months + 12;
                }
                days = days + (DateTime.DaysInMonth(dtFinal.AddMonths(-1).Year, dtFinal.AddMonths(-1).Month) + dtFinal.Day) - dtInicial.Day;

            }

            //add an extra day if the dob is a leap day
            if (DateTime.IsLeapYear(dtInicial.Year) && dtInicial.Month == 2 && dtInicial.Day == 29)
            {
                //but only if the future date is less than 1st March
                if (dtFinal >= new DateTime(dtFinal.Year, 3, 1))
                    days++;
            }

            return years + ":" + months + ":" + days;
        }

        /// <summary>
        /// Calcula a diferença entre dois anos
        /// </summary>
        /// <param name="dtInicial"></param>
        /// <param name="dtFinal"></param>
        /// <returns></returns>
        public static int CalcularDiferencaAno(DateTime dtInicial, DateTime dtFinal)
        {
            return Convert.ToInt32(DateUtil.CalcularDiferencaData(dtInicial, dtFinal).Split(':')[0]);
        }

        public static string RetornarIdade(DateTime? dtNascimento)
        {
            string idade = string.Empty;

            if (dtNascimento.HasValue)
            {
                string[] retorno = DateUtil.CalcularDiferencaData(dtNascimento.Value, DateTime.Now).Split(':');

                idade = string.Format("{0} ano(s), {1} mes(es), {2} dia(s)", retorno[0], retorno[1], retorno[2]);
            }

            return idade;
        }
    }
}
