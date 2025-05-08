using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    public partial class frmConfigFert : Form
    {
        String action;
        PropriedadeFert propfert;

        public frmConfigFert()
        {
            InitializeComponent();

            //cbY.SelectedIndex = 0;
            //txtPrem.Enabled = false;
            //txtVa.Enabled = false;
            //txtCtcPh7.Enabled = false;

            propfert = new PropriedadeFert();

            if (propfert.carregarDados())
            {
                txtCtcEfetiva.Text = propfert.getCtcEfetiva().ToString();
                txtAl3.Text = propfert.getAL3().ToString();
                txtCa2Mg2.Text = propfert.getCa2Mg2().ToString();                
                txtVa.Text = propfert.getVa().ToString();
                txtCtcPh7.Text = propfert.getCtcPh7().ToString();
                
                cbY.SelectedIndex = propfert.getEstimaY();
                
                txtArg.Text = propfert.getArg().ToString();
                txtPrem.Text = propfert.getPrem().ToString();
                txtSc.Text = propfert.getSc().ToString();
                txtPf.Text = propfert.getPf().ToString();
                txtPrnt.Text = propfert.getPrnt().ToString();

                cbProdutividade.SelectedIndex = propfert.getProdutividade();

                txtNFoliar.Text = propfert.getNFoliar().ToString();

                if (propfert.getAnaliseFoliar() == 0)
                {
                    ckAnaliseFoliar.Checked = true;
                }
                else
                {
                    ckAnaliseFoliar.Checked = false;
                }

                txtKSolo.Text = propfert.getKSolo().ToString();
                txtPSolo.Text = propfert.getPSolo().ToString();
                /*txtNutAgua.Text = propfert.getNutAgua().ToString();
                txtNutFert.Text = propfert.getNutFert().ToString();
                txtEficFert.Text = propfert.getEficFert().ToString();
                txtAreaFert.Text = propfert.getAreaFert().ToString();
                txtNumSetores.Text = propfert.getNumSetores().ToString();
                txtAreaSetor.Text = propfert.getAreaSetor().ToString();
                txtNumDias.Text = propfert.getNumDias().ToString();
                txtFreqFert.Text = propfert.getFreqFert().ToString();
                txtFertPeriodo.Text = propfert.getFertPeriodo().ToString();
                txtConcentraAgua.Text = propfert.getConcentraAgua().ToString();
                txtTaxaInj.Text = propfert.getTaxaInj().ToString();
                txtTempoFert.Text = propfert.getTempoFert().ToString();
                txtConcentraFertSol.Text = propfert.getConcentraFertSol().ToString();
                txtVolumeAgua.Text = propfert.getVolumeAgua().ToString();
                txtVolumeFert.Text = propfert.getVolumeFert().ToString();
                txtMassaFert.Text = propfert.getMassaFert().ToString();*/
                
                /*if (propfert.getEstimaNc() == 0)
                {
                    rbEstimaNeut.Checked = true;
                }
                else
                {
                    rbEstimaSat.Checked = true;
                }*/                

                if (propfert.getEstimaPSolo() == 0)
                {
                    rbEstimaArg.Checked = true;
                }
                else
                {
                    rbEstimaPrem.Checked = true;
                }

                action = "update";
            }
            else
            {
                action = "insert";
            } 
        }

        private void frmConfigFert_Load(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //VERIFICAÇÃO DOS CAMPOS PREENCHIDOS.
            
            if (txtVa.Text == "") {
                MessageBox.Show("A saturação por bases (Va) deve ser informada.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            //if (rbEstimaNeut.Checked)
            if (Convert.ToSingle(txtVa.Text) > 50)
            {
                if ((txtCtcEfetiva.Text == "") || (txtAl3.Text == "") || (txtCa2Mg2.Text == "") || (cbY.SelectedIndex == -1))
                {                    
                    MessageBox.Show("Verifique os dados da necessidade de calagem.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbY.SelectedIndex == 0)
                    if (txtArg.Text == "")
                    {                        
                        MessageBox.Show("O método selecionado para o cálculo de Y requer que o teor de argila no solo seja informado.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                
                if (cbY.SelectedIndex == 1)
                    if (txtPrem.Text == "")
                    {                        
                        MessageBox.Show("O método selecionado para o cálculo de Y requer que o valor de fósforo remanescente seja informado.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }                
            }else // txtVa <= 50
            
            //if (rbEstimaSat.Checked)            
            {
                if (txtCtcPh7.Text == "")
                {                    
                    MessageBox.Show("Verifique os dados da necessidade de calagem.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
            }

            if ((txtSc.Text == "") || (txtPf.Text == "") || (txtPrnt.Text == ""))
            {                
                MessageBox.Show("Verifique os dados da quantidade de calcário.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbEstimaArg.Checked)
                if (txtArg.Text == "")
                {                        
                        MessageBox.Show("O método selecionado para a estimativa de P requer que o teor de argila no solo seja informado.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }            
        
            if (ckAnaliseFoliar.Checked == false)
                if (txtNFoliar.Text == "")
                {
                    MessageBox.Show("Informe o teor de N foliar.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            
            if ((txtKSolo.Text == "") || (txtPSolo.Text == "") || (cbProdutividade.SelectedIndex == -1))
            {
                MessageBox.Show("Verifique os dados de nutrientes.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbEstimaPrem.Checked)
                if (txtPrem.Text == "")
                {
                    MessageBox.Show("O método selecionado para a estimativa de P requer que o valor de fósforo remanescente seja informado.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    
            //FIM DA VERIFICAÇÃO DOS CAMPOS PREENCHIDOS.            

            //if (rbEstimaNeut.Checked)
            if (Convert.ToSingle(txtVa.Text) > 50)
                propfert.setEstimaNc(0);
            else
                propfert.setEstimaNc(1);
            
            if (txtCtcEfetiva.Text == "")
                propfert.setCtcEfetiva(0);
            else
                propfert.setCtcEfetiva(Convert.ToSingle(txtCtcEfetiva.Text));

            if (txtAl3.Text == "")
                propfert.setAl3(0);
            else
                propfert.setAl3(Convert.ToSingle(txtAl3.Text));

            if (txtCa2Mg2.Text == "")
                propfert.setCa2Mg2(0);
            else
                propfert.setCa2Mg2(Convert.ToSingle(txtCa2Mg2.Text));

            propfert.setEstimaY(cbY.SelectedIndex);
            
            if (txtArg.Text == "")
                propfert.setArg(0);
            else
                propfert.setArg(Convert.ToSingle(txtArg.Text));

            if (txtPrem.Text == "")
                propfert.setPrem(0);
            else
                propfert.setPrem(Convert.ToSingle(txtPrem.Text));

            if (txtVa.Text == "")
                propfert.setVa(0);
            else
                propfert.setVa(Convert.ToSingle(txtVa.Text));

            if (txtCtcPh7.Text == "")
                propfert.setCtcPh7(0);
            else
                propfert.setCtcPh7(Convert.ToSingle(txtCtcPh7.Text));                
                
            propfert.setSc(Convert.ToSingle(txtSc.Text));
            propfert.setPf(Convert.ToSingle(txtPf.Text));
            propfert.setPrnt(Convert.ToSingle(txtPrnt.Text));

            propfert.setProdutividade(cbProdutividade.SelectedIndex);

            if (txtNFoliar.Text == "")
                propfert.setNFoliar(0);
            else
                propfert.setNFoliar(Convert.ToSingle(txtNFoliar.Text));

            if (ckAnaliseFoliar.Checked)
                propfert.setAnaliseFoliar(0);
            else
                propfert.setAnaliseFoliar(1);

            propfert.setKSolo(Convert.ToSingle(txtKSolo.Text));
            propfert.setPSolo(Convert.ToSingle(txtPSolo.Text));

            if (rbEstimaArg.Checked)
                propfert.setEstimaPSolo(0);
            else
                propfert.setEstimaPSolo(1);

            propfert.setNutAgua(0);
            propfert.setNutFert(0);
            propfert.setEficFert(0);
            propfert.setAreaFert(0);
            propfert.setNumSetores(0);
            propfert.setAreaSetor(0);
            propfert.setNumDias(0);
            propfert.setFreqFert(0);
            propfert.setFertPeriodo(0);
            propfert.setConcentraAgua(0);
            propfert.setTaxaInj(0);
            propfert.setTempoFert(0);
            propfert.setConcentraFertSol(0);
            propfert.setVolumeAgua(0);
            propfert.setVolumeFert(0);
            propfert.setMassaFert(0);

            /*propfert.setNutAgua(Convert.ToSingle(txtNutAgua.Text));
            propfert.setNutFert(Convert.ToSingle(txtNutFert.Text));
            propfert.setEficFert(Convert.ToSingle(txtEficFert.Text));
            propfert.setAreaFert(Convert.ToSingle(txtAreaFert.Text));
            propfert.setNumSetores(Convert.ToInt32(txtNumSetores.Text));
            propfert.setAreaSetor(Convert.ToSingle(txtAreaSetor.Text));
            propfert.setNumDias(Convert.ToInt32(txtNumDias.Text));
            propfert.setFreqFert(Convert.ToInt32(txtFreqFert.Text));
            propfert.setFertPeriodo(Convert.ToSingle(txtFertPeriodo.Text));
            propfert.setConcentraAgua(Convert.ToSingle(txtConcentraAgua.Text));
            propfert.setTaxaInj(Convert.ToSingle(txtTaxaInj.Text));
            propfert.setTempoFert(Convert.ToSingle(txtTempoFert.Text));
            propfert.setConcentraFertSol(Convert.ToSingle(txtConcentraFertSol.Text));
            propfert.setVolumeAgua(Convert.ToSingle(txtVolumeAgua.Text));
            propfert.setVolumeFert(Convert.ToSingle(txtVolumeFert.Text));
            propfert.setMassaFert(Convert.ToSingle(txtMassaFert.Text));*/

            if (action == "insert")
            {
                if (propfert.inserir())
                {
                    action = "update";
                }
            }
            else
            {
                propfert.alterar();
            }            
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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cbY.SelectedIndex == 0)
            {
                txtArg.Enabled = true;
                txtPrem.Enabled = false;
            }
            else
            {
                txtArg.Enabled = false;
                txtPrem.Enabled = true;
            }*/
        }

        private void pgCalagem_Click(object sender, EventArgs e)
        {

        }

        private void rbEstimaNeut_CheckedChanged(object sender, EventArgs e)
        {
            /*txtCtcEfetiva.Enabled = true;
            txtAl3.Enabled = true;
            txtCa2Mg2.Enabled = true;
            cbY.Enabled = true;
            txtVa.Enabled = false;
            txtCtcPh7.Enabled = false;*/
        }

        private void rbEstimaSat_CheckedChanged(object sender, EventArgs e)
        {
            /*txtCtcEfetiva.Enabled = false;
            txtAl3.Enabled = false;
            txtCa2Mg2.Enabled = false;            
            cbY.Enabled = false;            
            txtVa.Enabled = true;
            txtCtcPh7.Enabled = true;*/
        }

        private void cbY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbProdutividade_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtCtcEfetiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtCtcEfetiva_Leave(object sender, EventArgs e)
        {
            validaFlut(txtCtcEfetiva);
        }

        private void txtAl3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtAl3_Leave(object sender, EventArgs e)
        {
            validaFlut(txtAl3);
        }

        private void txtCa2Mg2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtCa2Mg2_Leave(object sender, EventArgs e)
        {
            validaFlut(txtCa2Mg2);
        }

        private void txtArg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtArg_Leave(object sender, EventArgs e)
        {
            validaFlut(txtArg);
        }

        private void txtPrem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtPrem_Leave(object sender, EventArgs e)
        {
            validaFlut(txtPrem);
        }

        private void txtVa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);            
        }

        private void txtVa_Leave(object sender, EventArgs e)
        {
            validaFlut(txtVa);
        }

        private void txtCtcPh7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtCtcPh7_Leave(object sender, EventArgs e)
        {
            validaFlut(txtCtcPh7);
        }

        private void txtSc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtSc_Leave(object sender, EventArgs e)
        {
            validaFlut(txtSc);
        }

        private void txtPf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtPf_Leave(object sender, EventArgs e)
        {
            validaFlut(txtPf);
        }

        private void txtPrnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtPrnt_Leave(object sender, EventArgs e)
        {
            validaFlut(txtPrnt);
        }

        private void txtNFoliar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtNFoliar_Leave(object sender, EventArgs e)
        {
            validaFlut(txtNFoliar);
        }

        private void txtKSolo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtKSolo_Leave(object sender, EventArgs e)
        {
            validaFlut(txtKSolo);
        }

        private void txtPSolo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = validaFlutKey(e);
        }

        private void txtPSolo_Leave(object sender, EventArgs e)
        {
            validaFlut(txtPSolo);
        }

        private void pgFert_Click(object sender, EventArgs e)
        {

        }

        private void frmConfigFert_Shown(object sender, EventArgs e)
        {
            
        }

        private void ckAnaliseFoliar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAnaliseFoliar.Checked)
            {
                txtNFoliar.Text = "";
                txtNFoliar.Enabled = false;
            }
            else
                txtNFoliar.Enabled = true;
        }

        private void btnConsolidados_Click(object sender, EventArgs e)
        {
            PropriedadeFert propfert = new PropriedadeFert();
            if (propfert.carregarDados())
            {
                frmConsolidaFert frm = new frmConsolidaFert();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("É necessário informar as configurações de calagem e adubação.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtVa_TextChanged(object sender, EventArgs e)
        {
            Single va = 0;

            if (txtVa.Text != "")
            {
                va = Convert.ToSingle(txtVa.Text);
            }

            /*if (txtVa.Text == "")
                labelEstimaNC.Text = "Estimativa da NC - informe o valor da saturação por bases atual do solo.";*/

            if (va <= 50)
                {
                    txtCtcEfetiva.Enabled = false;
                    txtAl3.Enabled = false;
                    txtCa2Mg2.Enabled = false;                    
                    cbY.Enabled = false;
                    //txtVa.Enabled = true;
                    txtCtcPh7.Enabled = true;
                    labelEstimaNC.Text = "NC estimada pelo método da saturação por bases.";
                }
                else
                {
                    txtCtcEfetiva.Enabled = true;
                    txtAl3.Enabled = true;
                    txtCa2Mg2.Enabled = true;
                    cbY.Enabled = true;        
                    //txtVa.Enabled = false;
                    txtCtcPh7.Enabled = false;
                    labelEstimaNC.Text = "NC estimada pelo método de neutralização da acidez trocável e da elevação dos teores de Cálcio e Magnésio trocáveis.";
                }                    
        }

        private void txtVa_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtVa.Text == "")
                //labelEstimaNC.Text = "Estimativa da NC - informe o valor da saturação por bases atual do solo.";
                labelEstimaNC.Text = "";
        }
    }
}
