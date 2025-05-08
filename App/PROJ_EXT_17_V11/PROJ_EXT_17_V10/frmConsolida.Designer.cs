namespace PROJ_EXT_17_V10
{
    partial class frmConsolida
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
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRegistra = new System.Windows.Forms.Button();
            this.labelDataIrrigacao = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelQuando = new System.Windows.Forms.Label();
            this.labelQuanto = new System.Windows.Forms.Label();
            this.labelPorQuanto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = "Imprimir Relatório";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonRegistra
            // 
            this.buttonRegistra.Location = new System.Drawing.Point(63, 235);
            this.buttonRegistra.Name = "buttonRegistra";
            this.buttonRegistra.Size = new System.Drawing.Size(117, 23);
            this.buttonRegistra.TabIndex = 26;
            this.buttonRegistra.Text = "Registrar Irrigação";
            this.buttonRegistra.UseVisualStyleBackColor = true;
            this.buttonRegistra.Click += new System.EventHandler(this.buttonRegistra_Click);
            // 
            // labelDataIrrigacao
            // 
            this.labelDataIrrigacao.AutoSize = true;
            this.labelDataIrrigacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataIrrigacao.ForeColor = System.Drawing.Color.DarkRed;
            this.labelDataIrrigacao.Location = new System.Drawing.Point(225, 106);
            this.labelDataIrrigacao.Name = "labelDataIrrigacao";
            this.labelDataIrrigacao.Size = new System.Drawing.Size(111, 20);
            this.labelDataIrrigacao.TabIndex = 49;
            this.labelDataIrrigacao.Text = "DD/MM/AAAA";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.ForeColor = System.Drawing.Color.DarkRed;
            this.labelData.Location = new System.Drawing.Point(225, 71);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(111, 20);
            this.labelData.TabIndex = 48;
            this.labelData.Text = "DD/MM/AAAA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(25, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 20);
            this.label9.TabIndex = 47;
            this.label9.Text = "Próxima irrigação prevista:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(95, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "Última irrigação:";
            // 
            // labelQuando
            // 
            this.labelQuando.AutoSize = true;
            this.labelQuando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuando.ForeColor = System.Drawing.Color.DarkRed;
            this.labelQuando.Location = new System.Drawing.Point(225, 36);
            this.labelQuando.Name = "labelQuando";
            this.labelQuando.Size = new System.Drawing.Size(55, 20);
            this.labelQuando.TabIndex = 44;
            this.labelQuando.Text = "0 dias.";
            // 
            // labelQuanto
            // 
            this.labelQuanto.AutoSize = true;
            this.labelQuanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuanto.ForeColor = System.Drawing.Color.DarkRed;
            this.labelQuanto.Location = new System.Drawing.Point(225, 141);
            this.labelQuanto.Name = "labelQuanto";
            this.labelQuanto.Size = new System.Drawing.Size(65, 20);
            this.labelQuanto.TabIndex = 43;
            this.labelQuanto.Text = "0,0 mm.";
            // 
            // labelPorQuanto
            // 
            this.labelPorQuanto.AutoSize = true;
            this.labelPorQuanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorQuanto.ForeColor = System.Drawing.Color.DarkRed;
            this.labelPorQuanto.Location = new System.Drawing.Point(225, 176);
            this.labelPorQuanto.Name = "labelPorQuanto";
            this.labelPorQuanto.Size = new System.Drawing.Size(100, 20);
            this.labelPorQuanto.TabIndex = 42;
            this.labelPorQuanto.Text = "00h e 00min.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(72, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Por quanto tempo?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(96, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Quanto aplicar?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(99, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Quando irrigar?";
            // 
            // frmConsolida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 270);
            this.Controls.Add(this.labelDataIrrigacao);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelQuando);
            this.Controls.Add(this.labelQuanto);
            this.Controls.Add(this.labelPorQuanto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonRegistra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConsolida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes da Irrigação";
            this.Load += new System.EventHandler(this.frmConsolida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRegistra;
        private System.Windows.Forms.Label labelDataIrrigacao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelQuando;
        private System.Windows.Forms.Label labelQuanto;
        private System.Windows.Forms.Label labelPorQuanto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}