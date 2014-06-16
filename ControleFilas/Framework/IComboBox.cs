using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace Comum.Framework
{
    public interface IComboBox<T>
    {
        void CarregarControle(string pstTexto);

        T ObjetoSelecionado
        {
            get;
            set;
        }

        string TextoSelecionado
        {
            get;
        }

        string ValorSelecionado
        {
            get;
        }

        Unit Width
        {
            get;
            set;
        }

        bool Enabled
        {
            get;
            set;
        }

        bool Obrigatorio
        {
            get;
            set;
        }
    }
}
