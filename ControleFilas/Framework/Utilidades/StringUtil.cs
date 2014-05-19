using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Comum.Framework
{
    public class StringUtil
    {
        public static bool PossuiNumeros(string valor)
        {
            Regex regEx = new Regex("[0-9]");

            return regEx.IsMatch(valor);
        }

        public static bool PossuiCaracteresEspeciais(string valor)
        {
            bool possuiCaracteresEspeciais = false;
            char[] caracteres = new char[] { '"', '\'', '!', '@', '#', '$', '%', '¨', '&', '*', '(', ')', '-', '_', '=', '+',
                '{', '}', '`', '´', '^', '~', '/', '?', ':', '<', '>', '\\', ',',  '/', '+', '-', '¹', '²', '³', '£', '¢',
                '¬', '§', 'ª', 'º', '°', '|', '[', ']' };
            List<char> listCaracteres = new List<char>(caracteres);

            foreach (char caracter in valor)
            {
                if (listCaracteres.Contains(caracter))
                {
                    possuiCaracteresEspeciais = true;
                    break;
                }
            }

            return possuiCaracteresEspeciais;
        }

        public static bool PossuiAcentos(string valor)
        {
            Regex regEx = new Regex("[âÂáÁàÀãÃêÊéÉèÈíÍîÎìÌôÔóÓõÕòÒûÛúÚùÙ]");

            return regEx.IsMatch(valor);
        }

        public static bool CaixaBaixa(string valor)
        {
            bool caixaBaixa = true;

            foreach (char caracter in valor)
            {
                if (char.IsUpper(caracter))
                    caixaBaixa = false;
            }

            return caixaBaixa;
        }
    }
}
