using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Root.Reports;

namespace PROJ_EXT_17_V10
{
    public partial class frmConsolida : Form
    {
        private String label_quando;
        private String label_quanto;
        private String label_tempo;
        private String label_ultima;
        private String label_prox;

        public frmConsolida()
        {
            InitializeComponent();
            this.obterDados();            
        }

        private void buttonRegistra_Click(object sender, EventArgs e)
        {
            Propriedade propriedade = new Propriedade();
            propriedade.carregarDados();

            Manejo manejo = new Manejo();
            manejo.carregarDados();
            manejo.setPropriedade(propriedade);

            if (manejo.ultimaIrrigaIsDay())
            {
                MessageBox.Show("Irrigação já registrada para esta data.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Deseja realmente registrar a irirgação?\nOs dados de clima não poderão ser mais alterados para esta data.", "IFSudesteMG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    manejo.registrarIrrigacao();
                    this.obterDados();
                }
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfFormatter pf = new PdfFormatter();

            /*pf.sTitle = "PDF Sample";
            pf.sAuthor = "Otto Mayer, mot@root.ch";
            pf.sSubject = "Sample of some PDF features";
            pf.sKeywords = "Sample PDF RSF";
            pf.sCreator = "RSF Sample Application";
            pf.dt_CreationDate = new DateTime(2002, 8, 15, 0, 0, 0, 0);
            pf.pageLayout = PageLayout.TwoColumnLeft;
            pf.bHideToolBar = true;
            pf.bHideMenubar = false;
            pf.bHideWindowUI = true;
            pf.bFitWindow = true;*/
            pf.bCenterWindow = true;
            pf.bDisplayDocTitle = true;

            Report vpdf = new Report(pf);

            FontDef fd = new FontDef(vpdf, "Helvetica");
            FontProp fp_Title = new FontPropMM(fd, 4);
            FontProp fp_Body = new FontPropMM(fd, 3);

            fp_Title.bBold = true;

            Page vpage = new Page(vpdf);
            vpage.AddCB_MM(20, new RepString(fp_Title, "Instituto Federal Sudeste de Minas Gerais"));
            fp_Title.rSizeMM = 3;
            vpage.AddCB_MM(26, new RepString(fp_Title, "Campus Manhuaçu"));
            fp_Title.bUnderline = true;
            vpage.AddCB_MM(32, new RepString(fp_Title, "www.manhuacu.ifsudestemg.edu.br"));
            fp_Title.bUnderline = false;
            fp_Title.rSizeMM = 6;
            vpage.AddCB_MM(50, new RepString(fp_Title, "Relatório de Irrigação"));
            fp_Title.rSizeMM = 3;
            vpage.AddCB_MM(56, new RepString(fp_Title, DateTime.Now.ToString("dd/MM/yyyy")));

            vpage.AddLT_MM(25, 70, new RepString(fp_Body, "Irrigar:"));
            vpage.AddLT_MM(100, 70, new RepString(fp_Body, this.label_quando));
            vpage.AddLT_MM(25, 78, new RepString(fp_Body, "Aplicar:"));
            vpage.AddLT_MM(100, 78, new RepString(fp_Body, this.label_quanto));
            vpage.AddLT_MM(25, 86, new RepString(fp_Body, "Durante:"));
            vpage.AddLT_MM(100, 86, new RepString(fp_Body, this.label_tempo));
            vpage.AddLT_MM(25, 94, new RepString(fp_Body, "Última Irrigação:"));
            vpage.AddLT_MM(100, 94, new RepString(fp_Body, this.label_ultima));
            vpage.AddLT_MM(25, 102, new RepString(fp_Body, "Próxima Irrigação:"));
            vpage.AddLT_MM(100, 102, new RepString(fp_Body, this.label_prox));

            RT.ViewPDF(vpdf, "report_irriga.pdf");            
        }

        private void frmConsolida_Load(object sender, EventArgs e)
        {

        }

        public void obterDados()
        {
            Propriedade propriedade = new Propriedade();
            propriedade.carregarDados();

            Manejo manejo = new Manejo();
            manejo.carregarDados();
            manejo.setPropriedade(propriedade);

            this.label_quando = "A cada " + String.Format("{0:0}", manejo.tr()) + " dias.";
            this.label_quanto = String.Format("{0:0.00}", manejo.qtdAplic()) + " mm.";
            this.label_tempo = manejo.formataQtdTempo();

            labelQuando.Text = this.label_quando;
            labelQuanto.Text = this.label_quanto;
            labelPorQuanto.Text = this.label_tempo;

            if (manejo.ultimaIrrigacao())
            {
                this.label_ultima = manejo.getUltimaIrriga().ToString("dd/MM/yyyy");
                this.label_prox = manejo.getUltimaIrriga().AddDays(Convert.ToInt32(manejo.tr())).ToString("dd/MM/yyyy");
            }
            else
            {
                this.label_ultima = "-";
                this.label_prox = "-";
            }
            labelData.Text = this.label_ultima;
            labelDataIrrigacao.Text = this.label_prox;
        }

    }
}
