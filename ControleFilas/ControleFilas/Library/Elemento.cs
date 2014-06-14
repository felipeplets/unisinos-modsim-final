using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFilas.Library
{
    public class Elemento
    {
        public int Indice { get; set; }
        public float InstanteChegada { get; set; }
        public float TempoAtendimento { get; set; }
        public float EntradaAtendimento { get; set; }
        public float SaidaAtendimento { get; set; }
        public float TempoFila { get; set; }
        public float TempoTotal { get; set; }
    }
}
