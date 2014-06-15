using ControleFilas.BusinessLogic;
using ControleFilas.Enumerator;
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
    public partial class ControleFilas : Form
    {
        public ControleFilas()
        {
            InitializeComponent();
            lblProgress.Visible = false;
        }

        private void ControleFilas_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Simular Chegada
            Simulacao simulacaoChegada = new Simulacao();
            List<Elemento> listElementosEntrada = simulacaoChegada.Simular(
                Convert.ToInt32(this.txtBoxNrElementosServir.Text.Trim()), 
                Convert.ToInt32(this.txtBoxServirNrServidores.Text.Trim()),
                TypeDistribution.Cauchy);

            //Simular Saída
            Simulacao simulacaoSaida = new Simulacao();
            List<Elemento> listElementosSaida = simulacaoSaida.Simular(
                Convert.ToInt32(this.txtBoxNrElementosPagar.Text.Trim()), 
                Convert.ToInt32(this.txtBoxPagarNrServidores.Text.Trim()),
                TypeDistribution.Cauchy);

            ExibirDados dadosEntrada = new ExibirDados(listElementosEntrada, "Exibir Dados - Sistema para Servir");
            dadosEntrada.Show();

            ExibirDados dadosSistema = new ExibirDados(listElementosSaida, "Exibir Dados - Sistema para Pagar");
            dadosSistema.Show();

            ExibirDadosCompletos dadosCompleto = new ExibirDadosCompletos(listElementosEntrada, listElementosSaida, Convert.ToInt32(txtBoxConstanteComer.Text.Trim()), "Exibir Dados - Sistema Completo");
            dadosCompleto.Show();
        }
    }
}
