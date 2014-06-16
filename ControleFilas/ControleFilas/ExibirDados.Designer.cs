namespace ControleFilas
{
    partial class ExibirDados
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
            this.exibindoDados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTempoMedioTotal = new System.Windows.Forms.Label();
            this.labelTempoMedioGastoFila = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exibindoDados)).BeginInit();
            this.SuspendLayout();
            // 
            // exibindoDados
            // 
            this.exibindoDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exibindoDados.Location = new System.Drawing.Point(12, 41);
            this.exibindoDados.Name = "exibindoDados";
            this.exibindoDados.Size = new System.Drawing.Size(823, 238);
            this.exibindoDados.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 299);
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
            // labelTempoMedioTotal
            // 
            this.labelTempoMedioTotal.AutoSize = true;
            this.labelTempoMedioTotal.Location = new System.Drawing.Point(118, 299);
            this.labelTempoMedioTotal.Name = "labelTempoMedioTotal";
            this.labelTempoMedioTotal.Size = new System.Drawing.Size(29, 13);
            this.labelTempoMedioTotal.TabIndex = 3;
            this.labelTempoMedioTotal.Text = "label";
            // 
            // labelTempoMedioGastoFila
            // 
            this.labelTempoMedioGastoFila.AutoSize = true;
            this.labelTempoMedioGastoFila.Location = new System.Drawing.Point(471, 299);
            this.labelTempoMedioGastoFila.Name = "labelTempoMedioGastoFila";
            this.labelTempoMedioGastoFila.Size = new System.Drawing.Size(29, 13);
            this.labelTempoMedioGastoFila.TabIndex = 4;
            this.labelTempoMedioGastoFila.Text = "label";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(17, 13);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(43, 15);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "Titulo";
            // 
            // ExibirDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 332);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelTempoMedioGastoFila);
            this.Controls.Add(this.labelTempoMedioTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exibindoDados);
            this.Name = "ExibirDados";
            this.Text = "Showing Data";
            this.Load += new System.EventHandler(this.ExibirDados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exibindoDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView exibindoDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTempoMedioTotal;
        private System.Windows.Forms.Label labelTempoMedioGastoFila;
        private System.Windows.Forms.Label labelTitulo;
    }
}