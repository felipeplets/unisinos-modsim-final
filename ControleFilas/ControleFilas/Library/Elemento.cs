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
        public double InstanteChegada { get; set; }
        public double TempoAtendimento { get; set; }
        public double EntradaAtendimento { get; set; }
        public double SaidaAtendimento { get; set; }
        public double TempoFila { get; set; }
        public double TempoTotal { get; set; }
    }
}
