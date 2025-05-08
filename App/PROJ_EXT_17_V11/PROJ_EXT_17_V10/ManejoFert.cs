using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJ_EXT_17_V10
{
    class ManejoFert
    {
        private PropriedadeFert propfert;        
        
        private const double X = 3.5;   //EXIGÊNCIA DAS CULTURAS EM CA2+ E MG2+
        private const double VE = 60;   //SATURAÇÃO POR BASES ESPERADA
        private const double MT = 25;   //MÁXIMA SATURAÇÃO DE AL3+ TOLERADA NA CULTURA
        
        public void setPropFert(PropriedadeFert propfert)
        {
            this.propfert = propfert;
        }
        
        //VALOR VARIÁVEL EM FUNÇÃO DA CAPACIDADE DE TAMPÃO DA ACIDEZ DO SOLO, ADIMENSIONAL.
        public double y()
        {
            //ESTIMATIVA DE ACORDO COM A TEXTURA DO SOLO, SENDO CONSIDERADO O TEOR DE ARGILA.
            if (this.propfert.getEstimaY() == 0)
            {
                return 0.0302 + 0.06532 * propfert.getArg() - 0.000257 * Math.Pow(propfert.getArg(), 2);
            }
            //DE ACORDO COM O TEOR DE FÓSFORO REMANESCENTE.
            else if (this.propfert.getEstimaY() == 1) 
            {
                return 4.002 - 0.125901 * propfert.getPrem() + 0.001205 * Math.Pow(propfert.getPrem(), 2) - 0.00000362 * Math.Pow(propfert.getPrem(), 3);
            }
            return 0;
        }

        //NECESSIDADE DE CALAGEM
        public double nc()
        {
            //MÉTODO DE NEUTRALIZAÇÃO DA ACIDEZ TROCÁVEL
            if (propfert.getEstimaNc() == 0) 
            {
                return this.y() * (propfert.getAL3() - (MT * propfert.getCtcEfetiva() / 100)) + (X - (propfert.getCa2Mg2()));
            }
            //MÉTODO DA SATURAÇÃO POR BASES
            else if (propfert.getEstimaNc() == 1) 
            {
                return propfert.getCtcPh7() * (VE - propfert.getVa()) / 100;
            }
            return 0;
        }

        //QUANTIDADE DE CALCÁRIO
        public double qc()
        {
            return this.nc() * propfert.getSc() / 100 * propfert.getPf() / 20 * 100 / propfert.getPrnt();
        }

        //DOSE DE N
        public double doseN()
        {
            //PRODUTIVIDADE <20 
            if (propfert.getProdutividade() == 0)
            {
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 200;
                else if (propfert.getNFoliar() < 2.5)
                    return 200;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 140;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 80;
            }
            //PRODUTIVIDADE 20-30
            else if (propfert.getProdutividade() == 1)
            {                
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 250;
                else if (propfert.getNFoliar() < 2.5)
                    return 250;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 175;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 110;
            }
            //PRODUTIVIDADE 30-40
            else if (propfert.getProdutividade() == 2)
            {
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 300;
                else if (propfert.getNFoliar() < 2.5)
                    return 300;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 220;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 140;
            }
            //PRODUTIVIDADE 40-50
            else if (propfert.getProdutividade() == 3)
            {
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 350;
                else if (propfert.getNFoliar() < 2.5)
                    return 350;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 260;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 170;
            }
            //PRODUTIVIDADE 50-60
            else if (propfert.getProdutividade() == 4)
            {
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 400;
                else if (propfert.getNFoliar() < 2.5)
                    return 400;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 300;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 200;
            }
            //PRODUTIVIDADE >60
            else if (propfert.getProdutividade() == 5)
            {
                if (propfert.getAnaliseFoliar() == 0) //NÃO HÁ ANÁLISE FOLIAR
                    return 450;
                else if (propfert.getNFoliar() < 2.5)
                    return 450;
                else if ((propfert.getNFoliar() >= 2.6) && (propfert.getNFoliar() <= 3))
                    return 340;
                else if ((propfert.getNFoliar() >= 3.1) && (propfert.getNFoliar() <= 3.5))
                    return 230;
            }
            return 0;
        }

        //DOSE DE K
        public double doseK()
        {
            //PRODUTIVIDADE <20
            if (propfert.getProdutividade() == 0)
            {
                if (propfert.getKSolo() < 60)
                    return 200;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 150;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 100;
                else if (propfert.getKSolo() > 200)
                    return 0;
            }
            //PRODUTIVIDADE 20-30
            else if (propfert.getProdutividade() == 1)
            {
                if (propfert.getKSolo() < 60)
                    return 250;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 190;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 125;
                else if (propfert.getKSolo() > 200)
                    return 0;
            }
            //PRODUTIVIDADE 30-40
            else if (propfert.getProdutividade() == 2)
            {
                if (propfert.getKSolo() < 60)
                    return 300;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 225;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 150;
                else if (propfert.getKSolo() > 200)
                    return 0;
            }
            //PRODUTIVIDADE 40-50
            else if (propfert.getProdutividade() == 3)
            {
                if (propfert.getKSolo() < 60)
                    return 350;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 260;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 175;
                else if (propfert.getKSolo() > 200)
                    return 50;
            }
            //PRODUTIVIDADE 50-60
            else if (propfert.getProdutividade() == 4)
            {
                if (propfert.getKSolo() < 60)
                    return 400;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 300;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 200;
                else if (propfert.getKSolo() > 200)
                    return 75;
            }
            //PRODUTIVIDADE >60
            else if (propfert.getProdutividade() == 5)
            {
                if (propfert.getKSolo() < 60)
                    return 450;
                else if ((propfert.getKSolo() >= 61) && (propfert.getKSolo() <= 120))
                    return 400;
                else if ((propfert.getKSolo() >= 121) && (propfert.getKSolo() <= 200))
                    return 225;
                else if (propfert.getKSolo() > 200)
                    return 100;
            }
            return 0;
        }

        //DOSE DE P
        public double doseP()
        {
            //PRODUTIVIDADE <20
            if (propfert.getProdutividade() == 0)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 0)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 30;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 20;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 10;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 30;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 20;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 10;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 0;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 30;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 20;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 10;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 0;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 30;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 20;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 10;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 0;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 30;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 20;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 10;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 0;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 30;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 10;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 0;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 30;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 20;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 10;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 0;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 30;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 10;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 0;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 30;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 20;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 10;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 0;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 30;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 20;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 10;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    } 
                }
            }
            //PRODUTIVIDADE 20-30
            else if (propfert.getProdutividade() == 1)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 0)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 40;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 30;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 40;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 30;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 20;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 0;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 40;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 30;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 20;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 0;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 40;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 30;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 20;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 0;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 40;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 30;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 0;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 40;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 20;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 0;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 40;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 30;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 0;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 40;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 20;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 0;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 40;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 30;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 20;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 0;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 40;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 30;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 20;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    }
                }    
            }
            //PRODUTIVIDADE 30-40
            else if (propfert.getProdutividade() == 2)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 1)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 50;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 40;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 25;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 50;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 40;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 25;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 0;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 50;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 40;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 25;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 0;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 50;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 40;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 25;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 0;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 50;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 40;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 25;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 0;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 50;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 25;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 0;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 50;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 40;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 25;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 0;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 50;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 25;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 0;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 50;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 40;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 25;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 0;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 50;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 40;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 25;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 0;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    }
                }
            }
            //PRODUTIVIDADE 40-50
            if (propfert.getProdutividade() == 3)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 0)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 60;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 50;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 15;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 60;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 50;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 30;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 15;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 60;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 50;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 30;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 15;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 60;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 50;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 30;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 15;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 60;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 50;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 15;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 60;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 50;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 30;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 15;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 60;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 50;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 15;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 60;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 50;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 30;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 15;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 60;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 50;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 30;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 15;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 60;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 50;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 30;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 15;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    }
                }
            }
            //PRODUTIVIDADE 50-60
            else if (propfert.getProdutividade() == 4)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 0)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 70;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 55;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 35;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 18;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 70;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 55;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 35;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 18;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 70;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 55;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 35;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 18;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 70;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 55;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 35;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 18;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 70;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 55;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 35;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 18;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 70;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 55;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 35;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 18;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 70;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 55;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 35;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 18;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 70;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 55;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 35;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 18;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 70;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 55;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 35;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 18;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 70;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 55;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 35;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 18;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    }
                }
            }
            //PRODUTIVIDADE >60
            if (propfert.getProdutividade() == 5)
            {
                //ARGILA
                if (propfert.getEstimaPSolo() == 0)
                {
                    //ARGILA 0-15
                    if ((propfert.getArg() >= 0) && (propfert.getArg() <= 15))
                    {
                        if (propfert.getPSolo() < 7.5)
                            return 80;
                        else if ((propfert.getPSolo() >= 7.5) && (propfert.getPSolo() <= 15))
                            return 60;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 20;
                        else if (propfert.getPSolo() > 33.8)
                            return 0;
                    }
                    //ARGILA 15-35
                    else if ((propfert.getArg() >= 15.1) && (propfert.getArg() <= 35))
                    {
                        if (propfert.getPSolo() < 5)
                            return 80;
                        else if ((propfert.getPSolo() >= 5.1) && (propfert.getPSolo() <= 9))
                            return 60;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 15))
                            return 40;
                        else if ((propfert.getPSolo() >= 15.1) && (propfert.getPSolo() <= 22.5))
                            return 20;
                        else if (propfert.getPSolo() > 22.5)
                            return 0;
                    }
                    //ARGILA 35-60
                    else if ((propfert.getArg() >= 35.1) && (propfert.getArg() <= 60))
                    {
                        if (propfert.getPSolo() < 3)
                            return 80;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 6))
                            return 60;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 40;
                        else if ((propfert.getPSolo() >= 9.1) && (propfert.getPSolo() <= 13.5))
                            return 20;
                        else if (propfert.getPSolo() > 13.5)
                            return 0;
                    }
                    //ARGILA 60-100
                    else if ((propfert.getArg() >= 60.1) && (propfert.getArg() <= 100))
                    {
                        if (propfert.getPSolo() < 1.9)
                            return 80;
                        else if ((propfert.getPSolo() >= 2) && (propfert.getPSolo() <= 4))
                            return 60;
                        else if ((propfert.getPSolo() >= 4.1) && (propfert.getPSolo() <= 6))
                            return 40;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 9))
                            return 20;
                        else if (propfert.getPSolo() > 9)
                            return 0;
                    }
                }
                //PREM
                else if (propfert.getEstimaPSolo() == 1)
                {
                    //PREM 0-4  
                    if ((propfert.getPrem() >= 0) && (propfert.getPrem() <= 4))
                    {
                        if (propfert.getPSolo() < 2.3)
                            return 80;
                        else if ((propfert.getPSolo() >= 2.4) && (propfert.getPSolo() <= 3.2))
                            return 60;
                        else if ((propfert.getPSolo() >= 3.3) && (propfert.getPSolo() <= 4.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.8))
                            return 20;
                        else if (propfert.getPSolo() >= 6.8)
                            return 0;
                    }
                    //PREM 4-10  
                    else if ((propfert.getPrem() >= 4.1) && (propfert.getPrem() <= 10))
                    {
                        if (propfert.getPSolo() < 3)
                            return 80;
                        else if ((propfert.getPSolo() >= 3.1) && (propfert.getPSolo() <= 4.5))
                            return 60;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 40;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 9.4))
                            return 20;
                        else if (propfert.getPSolo() >= 9.4)
                            return 0;
                    }
                    //PREM 10-19  
                    else if ((propfert.getPrem() >= 10.1) && (propfert.getPrem() <= 19))
                    {
                        if (propfert.getPSolo() < 4.5)
                            return 80;
                        else if ((propfert.getPSolo() >= 4.6) && (propfert.getPSolo() <= 6.2))
                            return 60;
                        else if ((propfert.getPSolo() >= 6.3) && (propfert.getPSolo() <= 8.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 13.1))
                            return 20;
                        else if (propfert.getPSolo() >= 13.1)
                            return 0;
                    }
                    //PREM 19-30  
                    else if ((propfert.getPrem() >= 20) && (propfert.getPrem() <= 30))
                    {
                        if (propfert.getPSolo() < 6)
                            return 80;
                        else if ((propfert.getPSolo() >= 6.1) && (propfert.getPSolo() <= 8.5))
                            return 60;
                        else if ((propfert.getPSolo() >= 8.6) && (propfert.getPSolo() <= 11.9))
                            return 40;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 18))
                            return 20;
                        else if (propfert.getPSolo() >= 18)
                            return 0;
                    }
                    //PREM 30-44  
                    else if ((propfert.getPrem() >= 31) && (propfert.getPrem() <= 44))
                    {
                        if (propfert.getPSolo() < 8.3)
                            return 80;
                        else if ((propfert.getPSolo() >= 8.4) && (propfert.getPSolo() <= 11.9))
                            return 60;
                        else if ((propfert.getPSolo() >= 12) && (propfert.getPSolo() <= 16.4))
                            return 40;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 24.8))
                            return 20;
                        else if (propfert.getPSolo() >= 24.8)
                            return 0;
                    }
                    //PREM 44-60  
                    else if ((propfert.getPrem() >= 45) && (propfert.getPrem() <= 60))
                    {
                        if (propfert.getPSolo() < 11.3)
                            return 80;
                        else if ((propfert.getPSolo() >= 11.4) && (propfert.getPSolo() <= 16.4))
                            return 60;
                        else if ((propfert.getPSolo() >= 16.5) && (propfert.getPSolo() <= 22.5))
                            return 40;
                        else if ((propfert.getPSolo() >= 22.6) && (propfert.getPSolo() <= 33.8))
                            return 20;
                        else if (propfert.getPSolo() >= 33.8)
                            return 0;
                    }//FECHA FAIXA PREM
                }//FECHA ESTIMATIVA PSOLO (ARG/PREM)    
            }//FECHA FAIXA PRODUTIVIDADE
            return 0;
        }//FECHA MÉTODO
    }
}