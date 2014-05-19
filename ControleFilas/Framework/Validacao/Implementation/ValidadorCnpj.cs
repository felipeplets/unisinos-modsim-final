using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comum.Framework
{
    public class ValidadorCnpj : IValidador
    {
        /// <summary>
        /// Valida o CNPJ passado por parâmetro.
        /// </summary>
        /// <param name="valor">CNPJ a ser validado.</param>
        /// <returns>True se o CNPJ for válido e false se for inválido.</returns>
        public bool Validar(string valor)
        {
            return Validacao.ValidarCNPJ(valor);
        }
    }
}
