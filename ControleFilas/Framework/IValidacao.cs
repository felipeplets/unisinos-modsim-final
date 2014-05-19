using System;
using System.Collections.Generic;
using System.Text;
using Castle.ActiveRecord;

namespace Ecosistemas.Framework
{
    /// <summary>
    /// Assinatura dos métodos de validação.
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
        /// Valida se o objeto pode ser excluído
        /// </summary>
        string ValidarExclusao();

        /// <summary>
        /// Valida tamanho de campos e campos obrigatórios.
        /// </summary>
        string Validar();
    }
}
