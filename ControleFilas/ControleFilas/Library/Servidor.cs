using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFilas.Library
{
    public class Servidor
    {
        public int Indice { get; set; }
        public List<Elemento> Elementos { get; set; }

        public Servidor()
        {
            Elementos = new List<Elemento>();
        }
    }
}
