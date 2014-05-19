using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecosistemas.Framework
{
    /// <summary>
    /// Classe validadora de CPF
    /// </summary>
    public class ValidadorCpf : IValidador
    {
        /// <summary>
        /// Valida o Cpf passado por parâmetro.
        /// </summary>
        /// <param name="valor">CPF a ser validado.</param>
        /// <returns>True se o CPF for válido e false se for inválido.</returns>
        public bool Validar(string valor)
        {
            return Validacao.ValidarCPF(valor);
        }
    }
}
