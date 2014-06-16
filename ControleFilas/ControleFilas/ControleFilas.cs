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
            Simulacao simulacaoChegada = new Simulacao();
            Simulacao simulacaoSaida = new Simulacao();
            List<Elemento> listElementosSaida = new List<Elemento>();
            List<Elemento> listElementosEntrada = new List<Elemento>();

            if (String.IsNullOrWhiteSpace(cmb_ServindoChegada.Text))
                cmb_ServindoChegada.Text = "Cauchy";

            if (String.IsNullOrWhiteSpace(cmb_ServindoAtendimento.Text))
                cmb_ServindoAtendimento.Text = "Cauchy";

            if (String.IsNullOrWhiteSpace(cmb_PagandoChegada.Text))
                cmb_PagandoChegada.Text = "Cauchy";

            if (String.IsNullOrWhiteSpace(cmb_PagandoAtendimento.Text))
                cmb_PagandoAtendimento.Text = "Cauchy";

            if (!String.IsNullOrWhiteSpace(this.txtBoxNrElementosServir.Text) && !String.IsNullOrWhiteSpace(this.txtBoxServirNrServidores.Text))
            {
                //Simular Chegada
                listElementosEntrada = simulacaoChegada.Simular(
                    Convert.ToInt32(this.txtBoxNrElementosServir.Text.Trim()), 
                    Convert.ToInt32(this.txtBoxServirNrServidores.Text.Trim()),
                    (TypeDistribution)Enum.Parse(typeof(TypeDistribution), cmb_ServindoChegada.Text), 
                    (TypeDistribution)Enum.Parse(typeof(TypeDistribution), cmb_ServindoAtendimento.Text),
                    TypeService.Lunch);

                ExibirDados dadosEntrada = new ExibirDados(listElementosEntrada, "Showing Data - Getting Food System");
                dadosEntrada.Show();
            }

            if (!String.IsNullOrWhiteSpace(this.txtBoxNrElementosPagar.Text) && !String.IsNullOrWhiteSpace(this.txtBoxPagarNrServidores.Text))
            {
                //Simular Saída
                listElementosSaida = simulacaoSaida.Simular(
                    Convert.ToInt32(this.txtBoxNrElementosPagar.Text.Trim()),
                    Convert.ToInt32(this.txtBoxPagarNrServidores.Text.Trim()),
                    (TypeDistribution)Enum.Parse(typeof(TypeDistribution), cmb_PagandoChegada.Text),
                    (TypeDistribution)Enum.Parse(typeof(TypeDistribution), cmb_PagandoAtendimento.Text),
                    TypeService.Payment);

                ExibirDados dadosSistema = new ExibirDados(listElementosSaida, "Showing Data - Paying System");
                dadosSistema.Show();
            }

            if (this.txtBoxNrElementosServir.Text == this.txtBoxNrElementosPagar.Text)
            {
                ExibirDadosCompletos dadosCompleto = new ExibirDadosCompletos(listElementosEntrada, listElementosSaida, Convert.ToInt32(txtBoxConstanteComer.Text.Trim()), "Showing Data - Complete System");
                dadosCompleto.Show();
            }

            
        }

        private void lblServindo_Click(object sender, EventArgs e)
        {

        }
    }
}
