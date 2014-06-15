namespace ControleFilas
{
    partial class ControleFilas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtBoxNrElementosServir = new System.Windows.Forms.TextBox();
            this.txtBoxServicoChegada = new System.Windows.Forms.TextBox();
            this.txtBoxServicoAtendimento = new System.Windows.Forms.TextBox();
            this.txtBoxNrElementosPagar = new System.Windows.Forms.TextBox();
            this.txtBoxPagarChegada = new System.Windows.Forms.TextBox();
            this.txtBoxPagarAtendimento = new System.Windows.Forms.TextBox();
            this.lblServirSimulacoes = new System.Windows.Forms.Label();
            this.lblServirChegada = new System.Windows.Forms.Label();
            this.lblServirAtendimento = new System.Windows.Forms.Label();
            this.lblPagarChegada = new System.Windows.Forms.Label();
            this.lblPagarSimulacoes = new System.Windows.Forms.Label();
            this.lblPagarAtendimento = new System.Windows.Forms.Label();
            this.lblServindo = new System.Windows.Forms.Label();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.lblPagarNrServidores = new System.Windows.Forms.Label();
            this.txtBoxPagarNrServidores = new System.Windows.Forms.TextBox();
            this.lblServirNrServidores = new System.Windows.Forms.Label();
            this.txtBoxServirNrServidores = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(12, 281);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(260, 23);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Simular";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtBoxNrElementosServir
            // 
            this.txtBoxNrElementosServir.Location = new System.Drawing.Point(172, 29);
            this.txtBoxNrElementosServir.Name = "txtBoxNrElementosServir";
            this.txtBoxNrElementosServir.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNrElementosServir.TabIndex = 1;
            // 
            // txtBoxServicoChegada
            // 
            this.txtBoxServicoChegada.Location = new System.Drawing.Point(172, 55);
            this.txtBoxServicoChegada.Name = "txtBoxServicoChegada";
            this.txtBoxServicoChegada.Size = new System.Drawing.Size(100, 20);
            this.txtBoxServicoChegada.TabIndex = 2;
            // 
            // txtBoxServicoAtendimento
            // 
            this.txtBoxServicoAtendimento.Location = new System.Drawing.Point(172, 81);
            this.txtBoxServicoAtendimento.Name = "txtBoxServicoAtendimento";
            this.txtBoxServicoAtendimento.Size = new System.Drawing.Size(100, 20);
            this.txtBoxServicoAtendimento.TabIndex = 3;
            // 
            // txtBoxNrElementosPagar
            // 
            this.txtBoxNrElementosPagar.Location = new System.Drawing.Point(172, 163);
            this.txtBoxNrElementosPagar.Name = "txtBoxNrElementosPagar";
            this.txtBoxNrElementosPagar.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNrElementosPagar.TabIndex = 4;
            // 
            // txtBoxPagarChegada
            // 
            this.txtBoxPagarChegada.Location = new System.Drawing.Point(172, 189);
            this.txtBoxPagarChegada.Name = "txtBoxPagarChegada";
            this.txtBoxPagarChegada.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPagarChegada.TabIndex = 5;
            // 
            // txtBoxPagarAtendimento
            // 
            this.txtBoxPagarAtendimento.Location = new System.Drawing.Point(172, 215);
            this.txtBoxPagarAtendimento.Name = "txtBoxPagarAtendimento";
            this.txtBoxPagarAtendimento.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPagarAtendimento.TabIndex = 6;
            // 
            // lblServirSimulacoes
            // 
            this.lblServirSimulacoes.AutoSize = true;
            this.lblServirSimulacoes.Location = new System.Drawing.Point(52, 32);
            this.lblServirSimulacoes.Name = "lblServirSimulacoes";
            this.lblServirSimulacoes.Size = new System.Drawing.Size(119, 13);
            this.lblServirSimulacoes.TabIndex = 7;
            this.lblServirSimulacoes.Text = "Número de Simulações:";
            // 
            // lblServirChegada
            // 
            this.lblServirChegada.AutoSize = true;
            this.lblServirChegada.Location = new System.Drawing.Point(75, 58);
            this.lblServirChegada.Name = "lblServirChegada";
            this.lblServirChegada.Size = new System.Drawing.Size(95, 13);
            this.lblServirChegada.TabIndex = 8;
            this.lblServirChegada.Text = "Taxa de Chegada:";
            // 
            // lblServirAtendimento
            // 
            this.lblServirAtendimento.AutoSize = true;
            this.lblServirAtendimento.Location = new System.Drawing.Point(58, 84);
            this.lblServirAtendimento.Name = "lblServirAtendimento";
            this.lblServirAtendimento.Size = new System.Drawing.Size(111, 13);
            this.lblServirAtendimento.TabIndex = 9;
            this.lblServirAtendimento.Text = "Taxa de Atendimento:";
            // 
            // lblPagarChegada
            // 
            this.lblPagarChegada.AutoSize = true;
            this.lblPagarChegada.Location = new System.Drawing.Point(75, 192);
            this.lblPagarChegada.Name = "lblPagarChegada";
            this.lblPagarChegada.Size = new System.Drawing.Size(95, 13);
            this.lblPagarChegada.TabIndex = 11;
            this.lblPagarChegada.Text = "Taxa de Chegada:";
            // 
            // lblPagarSimulacoes
            // 
            this.lblPagarSimulacoes.AutoSize = true;
            this.lblPagarSimulacoes.Location = new System.Drawing.Point(50, 166);
            this.lblPagarSimulacoes.Name = "lblPagarSimulacoes";
            this.lblPagarSimulacoes.Size = new System.Drawing.Size(119, 13);
            this.lblPagarSimulacoes.TabIndex = 10;
            this.lblPagarSimulacoes.Text = "Número de Simulações:";
            // 
            // lblPagarAtendimento
            // 
            this.lblPagarAtendimento.AutoSize = true;
            this.lblPagarAtendimento.Location = new System.Drawing.Point(60, 218);
            this.lblPagarAtendimento.Name = "lblPagarAtendimento";
            this.lblPagarAtendimento.Size = new System.Drawing.Size(111, 13);
            this.lblPagarAtendimento.TabIndex = 14;
            this.lblPagarAtendimento.Text = "Taxa de Atendimento:";
            // 
            // lblServindo
            // 
            this.lblServindo.AutoSize = true;
            this.lblServindo.Location = new System.Drawing.Point(12, 9);
            this.lblServindo.Name = "lblServindo";
            this.lblServindo.Size = new System.Drawing.Size(49, 13);
            this.lblServindo.TabIndex = 16;
            this.lblServindo.Text = "Servindo";
            // 
            // lblPagamento
            // 
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Location = new System.Drawing.Point(12, 146);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(61, 13);
            this.lblPagamento.TabIndex = 15;
            this.lblPagamento.Text = "Pagamento";
            // 
            // lblPagarNrServidores
            // 
            this.lblPagarNrServidores.AutoSize = true;
            this.lblPagarNrServidores.Location = new System.Drawing.Point(55, 246);
            this.lblPagarNrServidores.Name = "lblPagarNrServidores";
            this.lblPagarNrServidores.Size = new System.Drawing.Size(115, 13);
            this.lblPagarNrServidores.TabIndex = 18;
            this.lblPagarNrServidores.Text = "Número de Servidores:";
            // 
            // txtBoxPagarNrServidores
            // 
            this.txtBoxPagarNrServidores.Location = new System.Drawing.Point(171, 243);
            this.txtBoxPagarNrServidores.Name = "txtBoxPagarNrServidores";
            this.txtBoxPagarNrServidores.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPagarNrServidores.TabIndex = 17;
            // 
            // lblServirNrServidores
            // 
            this.lblServirNrServidores.AutoSize = true;
            this.lblServirNrServidores.Location = new System.Drawing.Point(53, 112);
            this.lblServirNrServidores.Name = "lblServirNrServidores";
            this.lblServirNrServidores.Size = new System.Drawing.Size(115, 13);
            this.lblServirNrServidores.TabIndex = 20;
            this.lblServirNrServidores.Text = "Número de Servidores:";
            // 
            // txtBoxServirNrServidores
            // 
            this.txtBoxServirNrServidores.Location = new System.Drawing.Point(171, 109);
            this.txtBoxServirNrServidores.Name = "txtBoxServirNrServidores";
            this.txtBoxServirNrServidores.Size = new System.Drawing.Size(100, 20);
            this.txtBoxServirNrServidores.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Legendas Distribuições";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "- Cauchy = 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "- Gen. Pareto = 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "- Hypersecant = 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "- Laplace = 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "- Cauchy = 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "- Fatigue Life = 5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "- Burr = 6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "- Pearson 5 = 7";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Legendas Distribuições";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(289, 285);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(62, 13);
            this.lblProgress.TabIndex = 31;
            this.lblProgress.Text = "Carregando";
            // 
            // ControleFilas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 315);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblServirNrServidores);
            this.Controls.Add(this.txtBoxServirNrServidores);
            this.Controls.Add(this.lblPagarNrServidores);
            this.Controls.Add(this.txtBoxPagarNrServidores);
            this.Controls.Add(this.lblServindo);
            this.Controls.Add(this.lblPagamento);
            this.Controls.Add(this.lblPagarAtendimento);
            this.Controls.Add(this.lblPagarChegada);
            this.Controls.Add(this.lblPagarSimulacoes);
            this.Controls.Add(this.lblServirAtendimento);
            this.Controls.Add(this.lblServirChegada);
            this.Controls.Add(this.lblServirSimulacoes);
            this.Controls.Add(this.txtBoxPagarAtendimento);
            this.Controls.Add(this.txtBoxPagarChegada);
            this.Controls.Add(this.txtBoxNrElementosPagar);
            this.Controls.Add(this.txtBoxServicoAtendimento);
            this.Controls.Add(this.txtBoxServicoChegada);
            this.Controls.Add(this.txtBoxNrElementosServir);
            this.Controls.Add(this.btnIniciar);
            this.Name = "ControleFilas";
            this.Text = "Controle Filas";
            this.Load += new System.EventHandler(this.ControleFilas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtBoxNrElementosServir;
        private System.Windows.Forms.TextBox txtBoxServicoChegada;
        private System.Windows.Forms.TextBox txtBoxServicoAtendimento;
        private System.Windows.Forms.TextBox txtBoxNrElementosPagar;
        private System.Windows.Forms.TextBox txtBoxPagarChegada;
        private System.Windows.Forms.TextBox txtBoxPagarAtendimento;
        private System.Windows.Forms.Label lblServirSimulacoes;
        private System.Windows.Forms.Label lblServirChegada;
        private System.Windows.Forms.Label lblServirAtendimento;
        private System.Windows.Forms.Label lblPagarChegada;
        private System.Windows.Forms.Label lblPagarSimulacoes;
        private System.Windows.Forms.Label lblPagarAtendimento;
        private System.Windows.Forms.Label lblServindo;
        private System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.Label lblPagarNrServidores;
        private System.Windows.Forms.TextBox txtBoxPagarNrServidores;
        private System.Windows.Forms.Label lblServirNrServidores;
        private System.Windows.Forms.TextBox txtBoxServirNrServidores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblProgress;
    }
}

