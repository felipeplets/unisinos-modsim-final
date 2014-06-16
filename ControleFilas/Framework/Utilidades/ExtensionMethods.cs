using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comum.Framework;

namespace System
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Método de extensão da classe DateTime que calcula a diferença em anos com a data final passada por parâmetro.
        /// </summary>
        /// <param name="inicialDate"></param>
        /// <param name="finalDate"></param>
        /// <returns></returns>
        public static int YearDifference(this DateTime inicialDate, DateTime finalDate)
        {
            return DateUtil.CalcularDiferencaAno(inicialDate, finalDate);
        }

        /// <summary>
        /// Método de extensão que soma todas as posições do array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Sum(this int[] array)
        {
            return ArrayUtil.Somar(array);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, TSource, bool> comparer)
        {
            return enumerable.Distinct(new LambdaComparer<TSource>(comparer));
        }

        //public static IEnumerable<TSource> Contains<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, TSource, bool> comparer)
        //{
        //    return enumerable.Contains(new LambdaComparer<TSource>(comparer));
        //}

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
        {
            return first.Except(second, new LambdaComparer<TSource>(comparer));
        }
    }
}
