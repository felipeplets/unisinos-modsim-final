using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comum.Framework
{
    public class ArrayUtil
    {
        /// <summary>
        /// Soma todos os valores do array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Somar(int[] array)
        {
            int soma = 0;

            foreach (int valor in array)
                soma += valor;

            return soma;
        }
    }
}
