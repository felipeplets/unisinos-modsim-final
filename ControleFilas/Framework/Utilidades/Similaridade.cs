using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Utilidades
{
    class Similaridade
    {

        public string soundex(string ptexto)
        {
            string resultado = "";
            string texto = "";
            int i = 0;
            int iValorSoundex = 0;
            int valorPrimeiraLetra = 0;
            string sound = "";

            texto = ptexto.ToUpper();
            resultado = texto.Substring(0, 1);
            valorPrimeiraLetra = valorSoundex(resultado);
            for (i = 1; i < texto.Length; i++)
            {
                iValorSoundex = valorSoundex(texto.Substring(i, 1));

                if (iValorSoundex != 0 && valorPrimeiraLetra != iValorSoundex)
                    resultado = resultado + iValorSoundex.ToString();
                valorPrimeiraLetra = iValorSoundex;
                iValorSoundex = 0;
            }

            if (resultado.Length < 4)
            {
                int numeroZeros = 4 - resultado.Length;
                string zeros = "";
                for (int k = 0; k < numeroZeros; k++)
                {
                    zeros = zeros + "0";
                }
                sound = resultado + zeros;
            }
            else
            {
                sound = resultado.Substring(0, 4);
            }
            return sound;

        }

        public int valorSoundex(string pCaracter)
        {
            int valor = 0;
            switch (pCaracter)
            {
                case "B":
                case "F":
                case "P":
                case "V":
                    valor = 1;
                    break;
                case "C":
                case "G":
                case "J":
                case "K":
                case "Q":
                case "S":
                case "X":
                case "Z":
                    valor = 2;
                    break;
                case "D":
                case "T":
                    valor = 3;
                    break;
                case "L":
                    valor = 4;
                    break;
                case "M":
                case "N":
                    valor = 5;
                    break;
                case "R":
                    valor = 6;
                    break;
            }
            return valor;
        }

        public int similidaridadeDatas(string primeiraPalavra, string segundaPalavra)
        {
            int custo = 0;
            int min1 = 0;
            int min2 = 0;
            int min3 = 0;
            int i = 0;
            int j = 0;
            int[,] matriz;
            primeiraPalavra = primeiraPalavra.ToUpper();
            segundaPalavra = segundaPalavra.ToUpper();
            if (primeiraPalavra.Length == 0)
                return segundaPalavra.Length;

            if (segundaPalavra.Length == 0)
                return primeiraPalavra.Length;

            matriz = new int[primeiraPalavra.Length + 1, segundaPalavra.Length + 1];

            for (i = 0; i <= primeiraPalavra.Length; i++)
            {
                matriz[i, 0] = i;
            }

            for (j = 0; j <= segundaPalavra.Length; j++)
            {
                matriz[0, j] = j;
            }

            for (i = 1; i <= primeiraPalavra.Length; i++)
            {
                for (j = 1; j <= segundaPalavra.Length; j++)
                {
                    if (primeiraPalavra.Substring(i - 1, 1) == segundaPalavra.Substring(j - 1, 1))
                        custo = 0;
                    else
                        custo = 1;

                    min1 = matriz[i - 1, j] + 1;
                    min2 = matriz[i, j - 1] + 1;
                    min3 = matriz[i - 1, j - 1] + custo;

                    matriz[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return matriz[primeiraPalavra.Length, segundaPalavra.Length];
        }
    }
}
