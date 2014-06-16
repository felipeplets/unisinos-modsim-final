namespace ControleFilas
{
    partial class ExibirDadosCompletos
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
            this.exibindoDadosCompletos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTempoMedioTotalCompleto = new System.Windows.Forms.Label();
            this.labelTempoMedioGastoFilaCompleto = new System.Windows.Forms.Label();
            this.labelTituloCompleto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exibindoDadosCompletos)).BeginInit();
            this.SuspendLayout();
            // 
            // exibindoDadosCompletos
            // 
            this.exibindoDadosCompletos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exibindoDadosCompletos.Location = new System.Drawing.Point(12, 41);
            this.exibindoDadosCompletos.Name = "exibindoDadosCompletos";
            this.exibindoDadosCompletos.Size = new System.Drawing.Size(825, 238);
            this.exibindoDadosCompletos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Average Total Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Average time in queue:";
            // 
            // labelTempoMedioTotalCompleto
            // 
            this.labelTempoMedioTotalCompleto.AutoSize = true;
            this.labelTempoMedioTotalCompleto.Location = new System.Drawing.Point(118, 299);
            this.labelTempoMedioTotalCompleto.Name = "labelTempoMedioTotalCompleto";
            this.labelTempoMedioTotalCompleto.Size = new System.Drawing.Size(29, 13);
            this.labelTempoMedioTotalCompleto.TabIndex = 3;
            this.labelTempoMedioTotalCompleto.Text = "label";
            // 
            // labelTempoMedioGastoFilaCompleto
            // 
            this.labelTempoMedioGastoFilaCompleto.AutoSize = true;
            this.labelTempoMedioGastoFilaCompleto.Location = new System.Drawing.Point(471, 299);
            this.labelTempoMedioGastoFilaCompleto.Name = "labelTempoMedioGastoFilaCompleto";
            this.labelTempoMedioGastoFilaCompleto.Size = new System.Drawing.Size(29, 13);
            this.labelTempoMedioGastoFilaCompleto.TabIndex = 4;
            this.labelTempoMedioGastoFilaCompleto.Text = "label";
            // 
            // labelTituloCompleto
            // 
            this.labelTituloCompleto.AutoSize = true;
            this.labelTituloCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloCompleto.Location = new System.Drawing.Point(17, 13);
            this.labelTituloCompleto.Name = "labelTituloCompleto";
            this.labelTituloCompleto.Size = new System.Drawing.Size(43, 15);
            this.labelTituloCompleto.TabIndex = 5;
            this.labelTituloCompleto.Text = "Titulo";
            // 
            // ExibirDadosCompletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 332);
            this.Controls.Add(this.labelTituloCompleto);
            this.Controls.Add(this.labelTempoMedioGastoFilaCompleto);
            this.Controls.Add(this.labelTempoMedioTotalCompleto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exibindoDadosCompletos);
            this.Name = "ExibirDadosCompletos";
            this.Text = "Showing Complete Data";
            this.Load += new System.EventHandler(this.ExibirDados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exibindoDadosCompletos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView exibindoDadosCompletos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTempoMedioTotalCompleto;
        private System.Windows.Forms.Label labelTempoMedioGastoFilaCompleto;
        private System.Windows.Forms.Label labelTituloCompleto;
    }
}