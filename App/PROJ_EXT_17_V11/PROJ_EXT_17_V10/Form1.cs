using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();            
        }

        private void propriedadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void culturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void soloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void climaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sistemaDeIrrigaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {                       
            Application.Exit();
        }

        private void quandoIrrigarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            if (propriedade.carregarDados())
            {
                Manejo manejo = new Manejo();
                manejo.carregarDados();

                if (manejo.ultimaIrrigaIsDay())
                {
                    MessageBox.Show("Não é possível alterar os dados de clima.\nIrrigação já registrada para esta data.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    frmClimaDiario frm = new frmClimaDiario();
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("É necessário configurar a propriedade.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        
        }

        private void temperaturaDiáriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void consolidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void qUANTOIrrigarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void porQuantoTEMPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void análiseDeSoloToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void registrarIrrigaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void propriedadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.tabConfig.SelectedIndex = 0; //PROPRIEDADE
            frm.ShowDialog();
            //new frmConfig().ShowDialog(this);
        }

        private void culturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.tabConfig.SelectedIndex = 1; //CULTURA
            frm.ShowDialog();            
        }

        private void soloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.tabConfig.SelectedIndex = 2; //SOLO
            frm.ShowDialog();            
        }

        private void climaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.tabConfig.SelectedIndex = 3; //CLIMA
            frm.ShowDialog();            
        }

        private void sistemaDeIrrigaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.tabConfig.SelectedIndex = 4; //SISTEMA IRRIGAÇÃO
            frm.ShowDialog();            
        }

        private void necessidadeDeCalagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quantidadeDeCalcárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        
        }

        private void nutrientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        
        }

        private void aplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       
        }

        private void sistemaDeInjeçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        
        }

        private void qUANDOIrrigarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            propriedade.carregarDados();

            Manejo manejo = new Manejo();
            if (manejo.carregarDados())
            {
                manejo.setPropriedade(propriedade);
                MessageBox.Show("IRRIGAR A CADA: " + String.Format("{0:0}", manejo.tr()) + " DIA(S).", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("É necessário informar o clima do dia.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void qUANTOIrrigarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            propriedade.carregarDados();

            Manejo manejo = new Manejo();
            if (manejo.carregarDados())
            {
                manejo.setPropriedade(propriedade);
                MessageBox.Show("APLICAR: " + String.Format("{0:0.00}", manejo.qtdAplic()) + " mm.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("É necessário informar o clima do dia.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void porQuantoTEMPOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            propriedade.carregarDados();

            Manejo manejo = new Manejo();
            if (manejo.carregarDados())
            {
                manejo.setPropriedade(propriedade);
                MessageBox.Show("TEMPO DE APLICAÇÃO: " + manejo.formataQtdTempo(), "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("É necessário informar o clima do dia.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void climaDiárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            if (propriedade.carregarDados())
            {
                Manejo manejo = new Manejo();
                manejo.carregarDados();

                if (manejo.ultimaIrrigaIsDay())
                {
                    MessageBox.Show("Não é possível alterar so dados de clima.\nIrrigação já registrada para esta data.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    frmClimaDiario frm = new frmClimaDiario();
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("É necessário configurar a propriedade.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        private void registrarIrrigaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manejo manejo = new Manejo();
            if (manejo.carregarDados())
            {
                Propriedade propriedade = new Propriedade();
                propriedade.carregarDados();
                manejo.setPropriedade(propriedade);
                if (manejo.ultimaIrrigaIsDay())
                {
                    MessageBox.Show("Irrigação já registrada para esta data.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Deseja realmente registrar a irirgação?\nOs dados de clima não poderão ser mais alterados para esta data.", "IFSudesteMG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        manejo.registrarIrrigacao();
                }
            }
            else
                MessageBox.Show("É necessário informar o clima do dia.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dadosConsolidadosToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Propriedade prop = new Propriedade();
            Manejo manejo = new Manejo();
            if (prop.carregarDados())
                if (!manejo.carregarDados())
                    if (MessageBox.Show("Os dados de clima não foram informados para esta data.\nDeseja informá-los agora?", "IFSudesteMG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmClimaDiario frm = new frmClimaDiario();
                        frm.ShowDialog();
                    }
        }

        private void dadosConsolidadosToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void quantidadeDeCalcárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfigFert frm = new frmConfigFert();
            frm.tabConfig.SelectedIndex = 0; //QUANTIDADE DE CALCÁRIO
            frm.ShowDialog();
        }

        private void nutrientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfigFert frm = new frmConfigFert();
            frm.tabConfig.SelectedIndex = 1; //NUTRIENTES
            frm.ShowDialog();
        }

        private void aplicaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConfigFert1 frm = new frmConfigFert1();
            frm.tabConfig.SelectedIndex = 0; //APLICAÇÃO
            frm.ShowDialog(); 
        }

        private void soluçãoInjetadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigFert1 frm = new frmConfigFert1();
            frm.tabConfig.SelectedIndex = 1; //SOLUÇÃO INJETADA
            frm.ShowDialog();
        }

        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void equipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeam frm = new frmTeam();
            frm.ShowDialog();
        }        
    }
}
