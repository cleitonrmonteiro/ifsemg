using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    public partial class frmClimaDiario : Form
    {
        String action;                
        Manejo manejo;
        
        public frmClimaDiario()
        {
            InitializeComponent();
                       
            manejo = new Manejo();            
            
            if (manejo.carregarDados())
            {                   
                txtDtManejo.Text = manejo.getDtManejo().ToString("dd/MM/yyyy");
                txtTempMax.Text = manejo.getTempMax().ToString();
                txtTempMin.Text = manejo.getTempMin().ToString();
                txtChuva.Text = manejo.getChuva().ToString();
                
                action = "update";
            }
            else
            {
                action = "insert";
            }           
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //VERIFICAÇÃO DOS CAMPOS PREENCHIDOS.
            if ((txtTempMax.Text == "") || (txtTempMin.Text == "") || (txtChuva.Text == ""))
            {
                MessageBox.Show("Todos os dados devem ser informados.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {                
                manejo.setTempMax(Convert.ToSingle(txtTempMax.Text));
                manejo.setTempMin(Convert.ToSingle(txtTempMin.Text));
                manejo.setChuva(Convert.ToSingle(txtChuva.Text));                

                Propriedade propriedade = new Propriedade();
                propriedade.carregarDados();
                manejo.setPropriedade(propriedade);

                if (action == "insert")
                {
                    if (manejo.inserirClima())
                    {
                        action = "update";
                    }
                }
                else
                {
                    manejo.alterarClima();
                }                
            }
        }

        private void frmTempDiaria_FormClosed(object sender, FormClosedEventArgs e)
        {            
        }

        //MÉTODO PARA VALIDAÇÃO DE TECLAS EM VALORES "PONTO FLUTUANTES" (SOMENTE NÚMEROS, BACKSPACE E ",").        
        private Boolean validaFlutKey(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
                return true;
            return false;
        }

        //MÉTODO PARA VALIDAÇÃO DE VALORES "PONTO FLUTUANTES".        
        private void validaFlut(TextBox txt)
        {
            try
            {
                if (txt.Text != "")
                    Convert.ToDouble(txt.Text);
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Valor incorreto.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = "";
            }
        }

        private void txtTempMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtTempMax_Leave(object sender, EventArgs e)
        {
            validaFlut(txtTempMax);
        }

        private void txtTempMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtTempMin_Leave(object sender, EventArgs e)
        {
            validaFlut(txtTempMin);
        }

        private void txtChuva_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtChuva_Leave(object sender, EventArgs e)
        {
            validaFlut(txtChuva);
        }

        private void btnConsolidados_Click(object sender, EventArgs e)
        {
            Manejo manejo = new Manejo();
            if (manejo.carregarDados())
            {
                frmConsolida frm = new frmConsolida();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("É necessário informar o clima do dia.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }              
    }
}
