using System;
using System.Collections.Generic;
using System.Text;
using FluorineFx;
using NHibernate.Criterion;

namespace Comum.Framework
{
    [RemotingService]
    public class Ordenacao
    {
        private string stPropriedade;
        private string stTipo;

        public Ordenacao()
        {
 
        }

        public Ordenacao(string pstPropriedade, string pstTipo)
        {
            this.stPropriedade = pstPropriedade;
            this.stTipo = pstTipo;
        }

        public static Order[] Converter(List<Ordenacao> loOrdenacao)
        {
            List<Order> loOrder = new List<Order>();

            if (loOrdenacao != null)
            {
                foreach (Ordenacao ordenacao in loOrdenacao)
                {
                    if (ordenacao != null && !string.IsNullOrEmpty(ordenacao.stPropriedade) && !string.IsNullOrEmpty(ordenacao.stTipo))
                    {
                        if (ordenacao.stTipo.ToLower() == "asc")
                            loOrder.Add(Order.Asc(ordenacao.stPropriedade));
                        else
                            loOrder.Add(Order.Desc(ordenacao.stPropriedade));
                    }
                }
            }

            return loOrder.ToArray();
        }

        public string Tipo
        {
            get { return stTipo; }
            set { stTipo = value; }
        }

        public string Propriedade
        {
            get { return stPropriedade; }
            set { stPropriedade = value; }
        }
    }
}
