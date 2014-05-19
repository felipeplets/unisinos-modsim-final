using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecosistemas.Framework
{
    /// <summary>
    /// Interface que pode ser utilizada por classes que realizam a validação de documentos.
    /// </summary>
    public interface IValidador
    {
        bool Validar(string valor);
    }
}
