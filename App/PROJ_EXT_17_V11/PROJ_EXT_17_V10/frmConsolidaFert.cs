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
    public partial class frmConsolidaFert : Form
    {
        //private String label_nc;
        private String label_qc;
        private String label_dosen;
        private String label_dosek;
        private String label_dosep;
        
        public frmConsolidaFert()
        {
            InitializeComponent();

            PropriedadeFert propfert = new PropriedadeFert();
            propfert.carregarDados();

            ManejoFert manejofert = new ManejoFert();
            manejofert.setPropFert(propfert);

            //this.label_nc = String.Format("{0:0.00}", manejofert.nc()) + " t/ha";
            this.label_qc = String.Format("{0:0.00}", manejofert.qc()) + " t/ha";
            this.label_dosen = String.Format("{0:0.00}", manejofert.doseN()) + " kg/ha/ano";
            this.label_dosek = String.Format("{0:0.00}", manejofert.doseK()) + " kg/ha/ano";
            this.label_dosep = String.Format("{0:0.00}", manejofert.doseP()) + " kg/ha/ano";

            //labelNC.Text = this.label_nc;
            labelCalc.Text = this.label_qc;
            labelN.Text = this.label_dosen;
            labelK.Text = this.label_dosek;
            labelP.Text = this.label_dosep; 
        }

        private void buttonRegistra_Click(object sender, EventArgs e)
        {

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
            vpage.AddCB_MM(50, new RepString(fp_Title, "Relatório de Adubação"));
            fp_Title.rSizeMM = 3;
            vpage.AddCB_MM(56, new RepString(fp_Title, DateTime.Now.ToString("dd/MM/yyyy")));
            
            /*vpage.AddLT_MM(25, 70, new RepString(fp_Body, "Necessidade de Calagem:"));
            vpage.AddLT_MM(100, 70, new RepString(fp_Body, this.label_nc));*/
            vpage.AddLT_MM(25, 70, new RepString(fp_Body, "Quantidade de Calcário:"));
            vpage.AddLT_MM(100, 70, new RepString(fp_Body, this.label_qc));
            vpage.AddLT_MM(25, 78, new RepString(fp_Body, "Quantidade N:"));
            vpage.AddLT_MM(100, 78, new RepString(fp_Body, this.label_dosen));
            vpage.AddLT_MM(25, 86, new RepString(fp_Body, "Quantidade K"));
            vpage.AddLT_MM(50.5, 87, new RepString(fp_Body, "2"));
            vpage.AddLT_MM(53, 86, new RepString(fp_Body, "O:"));
            vpage.AddLT_MM(100, 86, new RepString(fp_Body, this.label_dosek));
            vpage.AddLT_MM(25, 94, new RepString(fp_Body, "Quantidade P"));
            vpage.AddLT_MM(50.5, 95, new RepString(fp_Body, "2"));
            vpage.AddLT_MM(53, 94, new RepString(fp_Body, "O"));
            vpage.AddLT_MM(56, 95, new RepString(fp_Body, "5:"));
            vpage.AddLT_MM(100, 94, new RepString(fp_Body, this.label_dosep));

            RT.ViewPDF(vpdf, "report_aduba.pdf"); 
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
