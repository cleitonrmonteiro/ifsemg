namespace PROJ_EXT_17_V10
{
    partial class frmClimaDiario
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
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDtManejo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChuva = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnConsolidados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(294, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "°C";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(294, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "°C";
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(200, 87);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(82, 20);
            this.txtTempMin.TabIndex = 2;
            this.txtTempMin.Leave += new System.EventHandler(this.txtTempMin_Leave);
            this.txtTempMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempMin_KeyPress);
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(200, 59);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(82, 20);
            this.txtTempMax.TabIndex = 1;
            this.txtTempMax.Leave += new System.EventHandler(this.txtTempMax_Leave);
            this.txtTempMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTempMax_KeyPress);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(89, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Temperatura mínima";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(89, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 13);
            this.label23.TabIndex = 27;
            this.label23.Text = "Temperatura máxima";
            // 
            // txtDtManejo
            // 
            this.txtDtManejo.Enabled = false;
            this.txtDtManejo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtManejo.Location = new System.Drawing.Point(200, 33);
            this.txtDtManejo.Name = "txtDtManejo";
            this.txtDtManejo.Size = new System.Drawing.Size(82, 20);
            this.txtDtManejo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Chuva";
            // 
            // txtChuva
            // 
            this.txtChuva.Location = new System.Drawing.Point(200, 116);
            this.txtChuva.Name = "txtChuva";
            this.txtChuva.Size = new System.Drawing.Size(82, 20);
            this.txtChuva.TabIndex = 3;
            this.txtChuva.Leave += new System.EventHandler(this.txtChuva_Leave);
            this.txtChuva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChuva_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "mm";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(12, 163);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 4;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnConsolidados
            // 
            this.btnConsolidados.Location = new System.Drawing.Point(92, 163);
            this.btnConsolidados.Name = "btnConsolidados";
            this.btnConsolidados.Size = new System.Drawing.Size(112, 23);
            this.btnConsolidados.TabIndex = 38;
            this.btnConsolidados.Text = "Dados consolidados";
            this.btnConsolidados.UseVisualStyleBackColor = true;
            this.btnConsolidados.Click += new System.EventHandler(this.btnConsolidados_Click);
            // 
            // frmClimaDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 198);
            this.Controls.Add(this.btnConsolidados);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChuva);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDtManejo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTempMin);
            this.Controls.Add(this.txtTempMax);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmClimaDiario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Temperratura Diária";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTempDiaria_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTempMin;
        private System.Windows.Forms.TextBox txtTempMax;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDtManejo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChuva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnConsolidados;
    }
}