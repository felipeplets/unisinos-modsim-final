using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comum.Framework
{
    /// <summary>
    /// Classe validadora de RG.
    /// </summary>
    public class ValidadorRg : IValidador
    {
        /// <summary>
        /// Valida o RG passado por parâmetro.
        /// </summary>
        /// <param name="valor">RG a ser validado.</param>
        /// <returns>True se o RG for válido e false se for inválido.</returns>
        public bool Validar(string valor)
        {
            return Validacao.ValidarRG(valor);
        }
    }
}
