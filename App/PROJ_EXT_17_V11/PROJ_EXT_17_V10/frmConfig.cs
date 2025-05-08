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
    public partial class frmConfig : Form
    {
        String action;
        Propriedade propriedade;
        
        public frmConfig()
        {
            InitializeComponent();

            propriedade = new Propriedade();

            if (propriedade.carregarDados())
            {   
                txtPropriedade.Text = propriedade.getNmPropriedade();
                txtProprietario.Text = propriedade.getNmProprietario();
                txtRespTec.Text = propriedade.getRespTecnico();
                cbIdade.SelectedIndex = propriedade.getIdade();
                txtEntreLinhas.Text = propriedade.getEntreLinhas().ToString();
                txtEntrePlantas.Text = propriedade.getEntrePlanstas().ToString();
                txtPAS.Text = propriedade.getPas().ToString();
                txtCapacidade.Text = propriedade.getCapacidadeCampo().ToString();
                txtMurcha.Text = propriedade.getPontoMurcha().ToString();
                txtDensidade.Text = propriedade.getDensidadeAparente().ToString();
                txtTempMax.Text = propriedade.getTempMax().ToString();
                txtTempMin.Text = propriedade.getTempMin().ToString();
                txtMolhada.Text = propriedade.getAreaMolhada().ToString();
                txtVazao.Text = propriedade.getVazaoEmissor().ToString();
                txtEntreEmissores.Text = propriedade.getEntreEmissores().ToString();
                txtEmissoresPlanta.Text = propriedade.getEmissoresPlanta().ToString();
                txtEficiencia.Text = propriedade.getEficiencia().ToString();

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
            if ((txtPropriedade.Text == "") || (txtProprietario.Text == "") || (txtRespTec.Text == "") || (cbIdade.SelectedIndex == -1) || (txtEntreLinhas.Text == "") || (txtEntrePlantas.Text == "") || (txtPAS.Text == "") || (txtCapacidade.Text == "") || (txtMurcha.Text == "") || (txtDensidade.Text == "") || (txtTempMax.Text == "") || (txtTempMin.Text == "") || (txtMolhada.Text == "") || (txtVazao.Text == "") || (txtEntreEmissores.Text == "") || (txtEmissoresPlanta.Text == "") || (txtEficiencia.Text == ""))
            {
                MessageBox.Show("Todos os dados devem ser informados.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                propriedade.setNmPropriedade(txtPropriedade.Text);
                propriedade.setNmProprietario(txtProprietario.Text);
                propriedade.setRespTecnico(txtRespTec.Text);
                propriedade.setIdade(cbIdade.SelectedIndex);
                propriedade.setEntreLinhas(Convert.ToSingle(txtEntreLinhas.Text));
                propriedade.setEntrePlanstas(Convert.ToSingle(txtEntrePlantas.Text));
                propriedade.setPas(Convert.ToSingle(txtPAS.Text));
                propriedade.setCapacidadeCampo(Convert.ToSingle(txtCapacidade.Text));
                propriedade.setPontoMurcha(Convert.ToSingle(txtMurcha.Text));
                propriedade.setDensidadeAparente(Convert.ToSingle(txtDensidade.Text));
                propriedade.setTempMax(Convert.ToSingle(txtTempMax.Text));
                propriedade.setTempMin(Convert.ToSingle(txtTempMin.Text));
                propriedade.setAreaMolhada(Convert.ToSingle(txtMolhada.Text));
                propriedade.setVazaoEmissor(Convert.ToSingle(txtVazao.Text));
                propriedade.setEntreEmissores(Convert.ToSingle(txtEntreEmissores.Text));
                propriedade.setEmissoresPlanta(Convert.ToInt32(txtEmissoresPlanta.Text));
                propriedade.setEficiencia(Convert.ToSingle(txtEficiencia.Text));                

                if (action == "insert")
                {
                    if (propriedade.inserir())
                    {
                        action = "update";
                    }
                }
                else
                {
                    propriedade.alterar();
                }                 
            }
        }
        
        private void frmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {              
            
        }                  

        //MÉTODO PARA VALIDAÇÃO DE TECLAS EM VALORES "INTEIROS" (SOMENTE NÚMEROS).        
        private Boolean validaIntKey(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
                return true;
            return false;
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
                //MessageBox.Show("ERRO: " + ex.ToString());
                MessageBox.Show("Valor incorreto.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = "";
            }            
        }

        private void txtEntreLinhas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtEntreLinhas_Leave(object sender, EventArgs e)
        {
            validaFlut(txtEntreLinhas);
        }

        private void txtEntrePlantas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtEntrePlantas_Leave(object sender, EventArgs e)
        {
            validaFlut(txtEntrePlantas);
        }

        private void txtPAS_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtPAS_Leave(object sender, EventArgs e)
        {
            validaFlut(txtPAS);
        }

        private void txtCapacidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtCapacidade_Leave(object sender, EventArgs e)
        {
            validaFlut(txtCapacidade);
        }

        private void txtMurcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtMurcha_Leave(object sender, EventArgs e)
        {
            validaFlut(txtMurcha);
        }

        private void txtDensidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtDensidade_Leave(object sender, EventArgs e)
        {
            validaFlut(txtDensidade);
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

        private void txtMolhada_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtMolhada_Leave(object sender, EventArgs e)
        {
            validaFlut(txtMolhada);
        }

        private void txtVazao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtVazao_Leave(object sender, EventArgs e)
        {
            validaFlut(txtVazao);
        }

        private void txtEntreEmissores_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtEntreEmissores_Leave(object sender, EventArgs e)
        {
            validaFlut(txtEntreEmissores);
        }
        
        private void txtEmissoresPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaIntKey(e);
        }

        private void txtEficiencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtEficiencia_Leave(object sender, EventArgs e)
        {
            validaFlut(txtEficiencia);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPropriedade.Clear(); //PROPRIEDADE
            txtProprietario.Clear();
            txtRespTec.Clear();
            cbIdade.Text = ""; //CULTURA
            txtEntreLinhas.Clear();
            txtEntrePlantas.Clear();
            txtPAS.Clear();
            txtCapacidade.Clear(); //SOLO
            txtMurcha.Clear();
            txtDensidade.Clear();
            txtTempMax.Clear(); //CLIMA
            txtTempMin.Clear();
            txtMolhada.Clear(); //SISTEMA DE IRRIGAÇÃO
            txtVazao.Clear();
            txtEntreEmissores.Clear();
            txtEmissoresPlanta.Clear();
            txtEficiencia.Clear();            
        }               
    }
}
