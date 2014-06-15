using ControleFilas.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFilas
{
    public partial class ExibirDados : Form
    {
        private List<Elemento> _elementos;
        private float _tempoMedioTotal;
        private float _tempoMedioFila;

        public ExibirDados()
        {
            InitializeComponent();
        }

        public ExibirDados(List<Elemento> elementos, string titulo)
        {
            InitializeComponent();
            _elementos = elementos;

            foreach (Elemento item in elementos)
            {
                _tempoMedioTotal += item.TempoTotal;
                _tempoMedioFila += item.TempoFila;
            }

            _tempoMedioTotal = _tempoMedioTotal / _elementos.Count;
            _tempoMedioFila = _tempoMedioFila / _elementos.Count;
            
            // Exibir dados na tela
            exibindoDados.DataSource = elementos;
            labelTempoMedioGastoFila.Text = _tempoMedioFila.ToString("#,##0.000") + " " + " minutos";
            labelTempoMedioTotal.Text = _tempoMedioTotal.ToString("#,##0.000") + " " + " minutos";
            labelTitulo.Text = titulo;
        }
    }
}
