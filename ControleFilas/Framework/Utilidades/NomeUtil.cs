using System;
using System.Collections.Generic;
using System.Text;

namespace Ecosistemas.Framework
{
    public class NomeUtil
    {
        public static bool PossuiAbreviacao(string nome)
        {
            return nome.Contains(".");
        }

        public static bool PossuiAbreviacaoSemPonto(string nome)
        {
            bool retorno = false;
            string[] partes = nome.Split(' ');
            foreach (string parte in partes)
            {
                if (parte.Length == 1)
                    retorno = true;
            }

            return retorno;
        }

        public static bool PossuiSobrenome(string nome)
        {
            return nome.Contains(" ");
        }
    }
}
