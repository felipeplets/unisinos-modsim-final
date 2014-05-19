using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace Ecosistemas.Framework
{
    /// <summary>
    /// Assinatura dos m�todos de valida��o.
    /// </summary>
    public interface IValidacao
    {
        /// <summary>
        /// Valida se o objeto pode ser inserido.
        /// </summary>
        string ValidarInsercao();

        /// <summary>
        /// Valida se o objeto pode ser atualizado.
        /// </summary>
        string ValidarAtualizacao();

        /// <summary>
        /// Valida se o objeto pode ser exclu�do
        /// </summary>
        string ValidarExclusao();

        /// <summary>
        /// Valida tamanho de campos e campos obrigat�rios.
        /// </summary>
        string Validar();
    }
}
