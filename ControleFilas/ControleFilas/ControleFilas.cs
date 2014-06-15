using ControleFilas.BusinessLogic;
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
        }

        private void ControleFilas_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Simular Chegada
            Simulacao simulacaoChegada = new Simulacao();
            List<Elemento> listElementosEntrada = simulacaoChegada.Simular(Convert.ToInt32(this.txtBoxNrElementosServir.Text.Trim()), Convert.ToInt32(this.txtBoxServirNrServidores.Text.Trim()));

            //Simular Saída
            Simulacao simulacaoSaida = new Simulacao();
            List<Elemento> listElementosSaida = simulacaoSaida.Simular(Convert.ToInt32(this.txtBoxNrElementosPagar.Text.Trim()), Convert.ToInt32(this.txtBoxPagarNrServidores.Text.Trim()));

            ExibirDados dadosEntrada = new ExibirDados(listElementosEntrada, "Exibir dados - Sistema para se servir");
            dadosEntrada.Show();

            ExibirDados dadosSistema = new ExibirDados(listElementosSaida, "Exibir dados - Sistema para pagar");
            dadosSistema.Show();
        }
    }
}
