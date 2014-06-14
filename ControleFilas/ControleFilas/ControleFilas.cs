using ControleFilas.BusinessLogic;
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
            Simulacao simulacao = new Simulacao();
            simulacao.Simular(Convert.ToInt32(this.txtBoxNrElementos.Text.Trim()), 2);
        }
    }
}
