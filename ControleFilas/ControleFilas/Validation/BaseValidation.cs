using Ecosistemas.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFilas.Validation
{
    public partial class BaseValidation : IValidacao
    {
        public virtual string ValidarInsercao()
        {
            return "";
        }

        public virtual string ValidarAtualizacao()
        {
            return "";
        }

        public virtual string ValidarExclusao()
        {
            return "";
        }

        public virtual string Validar()
        {
            return "";
        }
    }
}
