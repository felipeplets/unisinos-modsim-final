using ControleFilas.Converter;
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
    public partial class ExibirDadosCompletos : Form
    {
        private double _tempoMedioTotal;
        private double _tempoMedioFila;

        public ExibirDadosCompletos()
        {
            InitializeComponent();
        }

        public ExibirDadosCompletos(List<Elemento> elementosServir, List<Elemento> elementosPagar, int constanteTempoComer, string titulo)
        {
            InitializeComponent();
            
            foreach (Elemento item in elementosServir)
            {
                _tempoMedioTotal += item.TempoTotal;
                _tempoMedioFila += item.TempoFila;
            }

            foreach (Elemento item in elementosPagar)
            {
                _tempoMedioTotal += item.TempoTotal;
                _tempoMedioFila += item.TempoFila;
            }

            _tempoMedioTotal = _tempoMedioTotal / elementosServir.Count;
            _tempoMedioFila = _tempoMedioFila / elementosServir.Count;
            
            // Exibir dados na tela
            exibindoDadosCompletos.DataSource = ElementoTotalConverter.ConverterParaListElementoTotal(elementosServir, elementosPagar, constanteTempoComer);
            labelTempoMedioGastoFilaCompleto.Text = _tempoMedioFila.ToString("#,##0.000"); // +" " + " segundos";
            labelTempoMedioTotalCompleto.Text = _tempoMedioTotal.ToString("#,##0.000"); // +" " + " segundos";
            labelTituloCompleto.Text = titulo;
        }

        private void ExibirDados_Load(object sender, EventArgs e)
        {

        }
    }
}
