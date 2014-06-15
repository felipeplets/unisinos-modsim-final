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
        private List<Elemento> _elementosServir;
        private List<Elemento> _elementosPagar;
        private double _tempoMedioTotal;
        private double _tempoMedioFila;

        public ExibirDadosCompletos()
        {
            InitializeComponent();
        }

        public ExibirDadosCompletos(List<Elemento> elementosServir, List<Elemento> elementosPagar, int constanteTempoComer, string titulo)
        {
            InitializeComponent();
            _elementosServir = elementosServir;

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

            _tempoMedioTotal = _tempoMedioTotal / _elementosServir.Count;
            _tempoMedioFila = _tempoMedioFila / _elementosServir.Count;
            
            // Exibir dados na tela
            exibindoDadosCompletos.DataSource = ElementoTotalConverter.ConverterParaListElementoTotal(elementosServir, elementosPagar, constanteTempoComer);
            labelTempoMedioGastoFilaCompleto.Text = _tempoMedioFila.ToString("#,##0.000") + " " + " minutos";
            labelTempoMedioTotalCompleto.Text = _tempoMedioTotal.ToString("#,##0.000") + " " + " minutos";
            labelTituloCompleto.Text = titulo;
        }

        private void ExibirDados_Load(object sender, EventArgs e)
        {

        }
    }
}
