using System;
using System.Collections.Generic;
using System.Text;

namespace Comum.Framework
{
    public class TratamentoExcessao
    {
        public static string RetornarMensagemExcecao(Exception poException, string stRetorno)
        {
            stRetorno += (string.IsNullOrEmpty(stRetorno)) ? poException.Message : "\n" + poException.Message;

            if (poException.InnerException != null)
                stRetorno = TratamentoExcessao.RetornarMensagemExcecao(poException.InnerException, stRetorno);

            return stRetorno;
        }
    }
}
