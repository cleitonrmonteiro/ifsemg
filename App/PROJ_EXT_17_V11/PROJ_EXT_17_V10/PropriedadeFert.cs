using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    class PropriedadeFert
    {
        private float ctcefetiva;       //t
        private float al3;              //ACIDEZ TROCÁVEL
        private float ca2mg2;           //TEORES DE CÁLCIO E MAGNÉSIO TROCÁVEIS        
        private float va;               //SATURAÇÃO POR BASES ATUAL DO SOLO
        private float ctcph7;           //T
        private float arg;              //TEOR DE ARGILA NO SOLO
        private float prem;             //VALOR DE FÓSFORO REMANESCENTE
        private float sc;               //PERCENTAGEM DA SUPERFÍCIE A SER COBERTA NA CALAGEM
        private float pf;               //PROFUNDIDADE QUE O CALCÁRIO SERÁ INCORPORADO
        private float prnt;             //PODER RELATIVO DE NEUTRALIZAÇÃO TOTAL DO CALCÁRIO A SER UTILIZADO
        private int produtividade;      //PRODUTIVIDADE ESPERADA
        private float nfoliar;          //TEOR DE N FOLIAR
        private float ksolo;            //TEOR DE K NO SOLO
        private float psolo;            //TEOR DE P NO SOLO
        private float nutagua;          //QUANTIDADE DE NUTRIENTE NA ÁGUA DE FERTIRRIGAÇÃO
        private float nutfert;          //CONCENTRAÇÃO DE NUTRIENTE NO FERTILIZANTE
        private float eficfert;         //EFICIÊNCIA DA FERTIRRIGAÇÃO
        private float areafert;         //ÁREA TOTAL DE FERTIRRIGAÇÃO
        private int numsetores;         //NÚMERO DE SETORES NA ÁREA
        private float areasetor;        //ÁREA DO SETOR
        private int numdias;            //NÚMERO DE DIAS NO PERÍODO
        private int freqfert;           //FREQUÊNCIA DE FERTIRRIGAÇÃO
        private float fertperiodo;      //PERCENTAGEM DO FERTILIZANTE NO PERÍODO
        private float concentraagua;    //CONCENTRAÇÃO DA ÁGUA DE IRRIGAÇÃO
        private float taxainj;          //TAXA DE INJEÇÃO
        private float tempofert;        //TEMPO DE FERTIRRIGAÇÃO
        private float concentrafertsol; //CONCENTRAÇÃO DO FERTILIZANTE NA SOLUÇÃO INJETADA
        private float volumeagua;       //VOLUME DE ÁGUA NECESSÁRIO
        private float volumefert;       //VOLUME DE FERTILIZANTE NECESSÁRIO
        private float massafert;        //MASSA DO FERTILIZANTE
        private int estimanc;           //MÉTODO PARA ESTIMATIVA DE CALAGEM: (0)NEUTRALIZAÇÃO, (1)SATURAÇÃO POR BASES
        private int estimay;            //MÉTODO PARA ESTIMATIVA DE Y: (0)ARGILA, (1)PREM
        private int estimapsolo;        //ESTIMATIVA DE TEOR DE P NO SOLO: (0)ARGILA, (1)PREM
        private int analisefoliar;      //(0)SE NÃO HÁ ANÁLISE FOLIAR, (1)SE HÁ

        public float getCtcEfetiva()
        {
            return this.ctcefetiva;
        }

        public void setCtcEfetiva(float ctcefetiva)
        {
            this.ctcefetiva = ctcefetiva;
        }

        public float getAL3()
        {
            return this.al3;
        }

        public void setAl3(float al3)
        {
            this.al3 = al3;
        }

        public float getCa2Mg2()
        {
            return this.ca2mg2;
        }

        public void setCa2Mg2(float ca2mg2)
        {
            this.ca2mg2 = ca2mg2;
        }       

        public float getVa()
        {
            return this.va;
        }

        public void setVa(float va)
        {
            this.va = va;
        }

        public float getCtcPh7()
        {
            return this.ctcph7;
        }

        public void setCtcPh7(float ctcph7)
        {
            this.ctcph7 = ctcph7;
        }

        public float getArg()
        {
            return this.arg;
        }

        public void setArg(float arg)
        {
            this.arg = arg;
        }

        public float getPrem()
        {
            return this.prem;
        }

        public void setPrem(float prem)
        {
            this.prem = prem;
        }

        public float getSc()
        {
            return this.sc;
        }

        public void setSc(float sc)
        {
            this.sc = sc;
        }

        public float getPf()
        {
            return this.pf;
        }

        public void setPf(float pf)
        {
            this.pf = pf;
        }

        public float getPrnt()
        {
            return this.prnt;
        }

        public void setPrnt(float prnt)
        {
            this.prnt = prnt;
        }

        public int getProdutividade()
        {
            return this.produtividade;
        }

        public void setProdutividade(int produtividade)
        {
            this.produtividade = produtividade;
        }

        public float getNFoliar()
        {
            return this.nfoliar;
        }

        public void setNFoliar(float nfoliar)
        {
            this.nfoliar = nfoliar;
        }

        public float getKSolo()
        {
            return this.ksolo;
        }

        public void setKSolo(float ksolo)
        {
            this.ksolo = ksolo;
        }

        public float getPSolo()
        {
            return this.psolo;
        }

        public void setPSolo(float psolo)
        {
            this.psolo = psolo;
        }

        public float getNutAgua()
        {
            return this.nutagua;
        }

        public void setNutAgua(float nutagua)
        {
            this.nutagua = nutagua;
        }

        public float getNutFert()
        {
            return this.nutfert;
        }

        public void setNutFert(float nutfert)
        {
            this.nutfert = nutfert;
        }

        public float getEficFert()
        {
            return this.eficfert;
        }

        public void setEficFert(float eficfert)
        {
            this.eficfert = eficfert;
        }

        public float getAreaFert()
        {
            return this.areafert;
        }

        public void setAreaFert(float areafert)
        {
            this.areafert = areafert;
        }

        public int getNumSetores()
        {
            return this.numsetores;
        }

        public void setNumSetores(int numsetores)
        {
            this.numsetores = numsetores;
        }

        public float getAreaSetor()
        {
            return this.areasetor;
        }

        public void setAreaSetor(float areasetor)
        {
            this.areasetor = areasetor;
        }

        public int getNumDias()
        {
            return this.numdias;
        }

        public void setNumDias(int numdias)
        {
            this.numdias = numdias;
        }

        public int getFreqFert()
        {
            return this.freqfert;
        }

        public void setFreqFert(int freqfert)
        {
            this.freqfert = freqfert;
        }

        public float getFertPeriodo()
        {
            return this.fertperiodo;
        }

        public void setFertPeriodo(float fertperiodo)
        {
            this.fertperiodo = fertperiodo;
        }

        public float getConcentraAgua()
        {
            return this.concentraagua;
        }

        public void setConcentraAgua(float concentraagua)
        {
            this.concentraagua = concentraagua;
        }

        public float getTaxaInj()
        {
            return this.taxainj;
        }        

        public void setTaxaInj(float taxainj)
        {
            this.taxainj = taxainj;
        }
        
        public float getTempoFert()
        {
            return this.tempofert;
        }

        public void setTempoFert(float tempofert)
        {
            this.tempofert = tempofert;
        }

        public float getConcentraFertSol()
        {
            return this.concentrafertsol;
        }

        public void setConcentraFertSol(float concentrafertsol)
        {
            this.concentrafertsol = concentrafertsol;
        }

        public float getVolumeAgua()
        {
            return this.volumeagua;
        }

        public void setVolumeAgua(float volumeagua)
        {
            this.volumeagua = volumeagua;
        }

        public float getVolumeFert()
        {
            return this.volumefert;
        }

        public void setVolumeFert(float volumefert)
        {
            this.volumefert = volumefert;
        }

        public float getMassaFert()
        {
            return this.massafert;
        }

        public void setMassaFert(float massafert)
        {
            this.massafert = massafert;
        }

        public int getEstimaNc()
        {
            return this.estimanc;
        }

        public void setEstimaNc(int estimanc)
        {
            this.estimanc = estimanc;
        }

        public int getEstimaY()
        {
            return this.estimay;
        }

        public void setEstimaY(int estimay)
        {
            this.estimay = estimay;
        }

        public int getEstimaPSolo()
        {
            return this.estimapsolo;
        }

        public void setEstimaPSolo(int estimapsolo)
        {
            this.estimapsolo = estimapsolo;
        }

        public int getAnaliseFoliar()
        {
            return this.analisefoliar;
        }

        public void setAnaliseFoliar(int analisefoliar)
        {
            this.analisefoliar = analisefoliar;
        }
        
        public Boolean carregarDados()
        {
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "SELECT * FROM tbpropfert";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) //SE RETORNOU ALGUMA LINHA
                            {                            
                                reader.Read();
                                this.ctcefetiva = reader.GetFloat(1);
                                this.al3 = reader.GetFloat(2);
                                this.ca2mg2 = reader.GetFloat(3);                                
                                this.va = reader.GetFloat(4);
                                this.ctcph7 = reader.GetFloat(5);
                                this.arg = reader.GetFloat(6);
                                this.prem = reader.GetFloat(7);
                                this.sc = reader.GetFloat(8);
                                this.pf = reader.GetFloat(9);
                                this.prnt = reader.GetFloat(10);
                                this.produtividade = reader.GetInt32(11);
                                this.nfoliar = reader.GetFloat(12);
                                this.ksolo = reader.GetFloat(13);
                                this.psolo = reader.GetFloat(14);
                                this.nutagua = reader.GetFloat(15);
                                this.nutfert = reader.GetFloat(16);
                                this.eficfert = reader.GetFloat(17);
                                this.areafert = reader.GetFloat(18);
                                this.numsetores = reader.GetInt32(19);
                                this.areasetor = reader.GetFloat(20);
                                this.numdias = reader.GetInt32(21);
                                this.freqfert = reader.GetInt32(22);
                                this.fertperiodo = reader.GetFloat(23);
                                this.concentraagua = reader.GetFloat(24);
                                this.taxainj = reader.GetFloat(25);
                                this.tempofert = reader.GetFloat(26);
                                this.concentrafertsol = reader.GetFloat(27);
                                this.volumeagua = reader.GetFloat(28);
                                this.volumefert = reader.GetFloat(29);
                                this.massafert = reader.GetFloat(30);
                                this.estimanc = reader.GetInt32(31);
                                this.estimay = reader.GetInt32(32);
                                this.estimapsolo = reader.GetInt32(33);
                                this.analisefoliar = reader.GetInt32(34);

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
                return false;
            }
            finally
            {
            }
        }

        public Boolean inserir()
        {
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "INSERT INTO tbpropfert " +
                             "(idpropfert, ctcefetiva, al3, ca2mg2, va, ctcph7, arg, prem, sc, pf, prnt, " +
                             "produtividade, nfoliar, ksolo, psolo, nutagua, nutfert, eficfert, areafert, " +
                             "numsetores, areasetor, numdias, freqfert, fertperiodo, concentraagua, taxainj, " +
                             "tempofert, concentrafertsol, volumeagua, volumefert, massafert, " +
                             "estimanc, estimay, estimapsolo, analisefoliar) " +

                             "VALUES (@idpropfert, @ctcefetiva, @al3, @ca2mg2, @va, @ctcph7, " +
                             "@arg, @prem, @sc, @pf, @prnt, @produtividade, @nfoliar, @ksolo, @psolo, " +
                             "@nutagua, @nutfert, @eficfert, @areafert, @numsetores, @areasetor, @numdias, " +
                             "@freqfert, @fertperiodo, @concentraagua, @taxainj, @tempofert, " +
                             "@concentrafertsol, @volumeagua, @volumefert, @massafert, " +
                             "@estimanc, @estimay, @estimapsolo, @analisefoliar)";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        //COMO INICIALMENTE SERÁ MANTIDA APENAS UMA PROPRIEDADE, "idpropfert" SERÁ SEMPRE "1".                    
                        SQLiteParameter parIdPropFert = new SQLiteParameter("@idpropfert", 1);
                        SQLiteParameter parCtcEfetiva = new SQLiteParameter("@ctcefetiva", Convert.ToDouble(this.ctcefetiva));
                        SQLiteParameter parAl3 = new SQLiteParameter("@al3", Convert.ToDouble(this.al3));
                        SQLiteParameter parCa2Mg2 = new SQLiteParameter("@ca2mg2", Convert.ToDouble(this.ca2mg2));                        
                        SQLiteParameter parVa = new SQLiteParameter("@va", Convert.ToDouble(this.va));
                        SQLiteParameter parCtcPh7 = new SQLiteParameter("@ctcph7", Convert.ToDouble(this.ctcph7));
                        SQLiteParameter parArg = new SQLiteParameter("@arg", Convert.ToDouble(this.arg));
                        SQLiteParameter parPrem = new SQLiteParameter("@prem", Convert.ToDouble(this.prem));
                        SQLiteParameter parSc = new SQLiteParameter("@sc", Convert.ToDouble(this.sc));
                        SQLiteParameter parPf = new SQLiteParameter("@pf", Convert.ToDouble(this.pf));
                        SQLiteParameter parPrnt = new SQLiteParameter("@prnt", Convert.ToDouble(this.prnt));
                        SQLiteParameter parProdutividade = new SQLiteParameter("@produtividade", this.produtividade);
                        SQLiteParameter parNFoliar = new SQLiteParameter("@nfoliar", Convert.ToDouble(this.nfoliar));
                        SQLiteParameter parKSolo = new SQLiteParameter("@ksolo", Convert.ToDouble(this.ksolo));
                        SQLiteParameter parPSolo = new SQLiteParameter("@psolo", Convert.ToDouble(this.psolo));
                        SQLiteParameter parNutAgua = new SQLiteParameter("@nutagua", Convert.ToDouble(this.nutagua));
                        SQLiteParameter parNutFert = new SQLiteParameter("@nutfert", Convert.ToDouble(this.nutfert));
                        SQLiteParameter parEficFert = new SQLiteParameter("@eficfert", Convert.ToDouble(this.eficfert));
                        SQLiteParameter parAreaFert = new SQLiteParameter("@areafert", Convert.ToDouble(this.areafert));
                        SQLiteParameter parNumSetores = new SQLiteParameter("@numsetores", this.numsetores);
                        SQLiteParameter parAreaSetor = new SQLiteParameter("@areasetor", Convert.ToDouble(this.areasetor));
                        SQLiteParameter parNumDias = new SQLiteParameter("@numdias", this.numdias);
                        SQLiteParameter parFreqFert = new SQLiteParameter("@freqfert", this.freqfert);
                        SQLiteParameter parFertPeriodo = new SQLiteParameter("@fertperiodo", Convert.ToDouble(this.fertperiodo));
                        SQLiteParameter parConcentraAgua = new SQLiteParameter("@concentraagua", Convert.ToDouble(this.concentraagua));
                        SQLiteParameter parTaxaInj = new SQLiteParameter("@taxainj", Convert.ToDouble(this.taxainj));
                        SQLiteParameter parTempoFert = new SQLiteParameter("@tempofert", Convert.ToDouble(this.tempofert));
                        SQLiteParameter parConcentraFertSol = new SQLiteParameter("@concentrafertsol", Convert.ToDouble(this.concentrafertsol));
                        SQLiteParameter parVolumeAgua = new SQLiteParameter("@volumeagua", Convert.ToDouble(this.volumeagua));
                        SQLiteParameter parVolumeFert = new SQLiteParameter("@volumefert", Convert.ToDouble(this.volumefert));
                        SQLiteParameter parMassaFert = new SQLiteParameter("@massafert", Convert.ToDouble(this.massafert));
                        SQLiteParameter parEstimaNc = new SQLiteParameter("@estimanc", this.estimanc);
                        SQLiteParameter parEstimaY = new SQLiteParameter("@estimay", this.estimay);
                        SQLiteParameter parEstimaPSolo = new SQLiteParameter("@estimapsolo", this.estimapsolo);
                        SQLiteParameter parAnaliseFoliar = new SQLiteParameter("@analisefoliar", this.analisefoliar);                        

                        cmd.Parameters.Add(parIdPropFert);
                        cmd.Parameters.Add(parCtcEfetiva);
                        cmd.Parameters.Add(parAl3);
                        cmd.Parameters.Add(parCa2Mg2);                        
                        cmd.Parameters.Add(parVa);
                        cmd.Parameters.Add(parCtcPh7);
                        cmd.Parameters.Add(parArg);
                        cmd.Parameters.Add(parPrem);
                        cmd.Parameters.Add(parSc);
                        cmd.Parameters.Add(parPf);
                        cmd.Parameters.Add(parPrnt);
                        cmd.Parameters.Add(parProdutividade);
                        cmd.Parameters.Add(parNFoliar);
                        cmd.Parameters.Add(parKSolo);
                        cmd.Parameters.Add(parPSolo);
                        cmd.Parameters.Add(parNutAgua);
                        cmd.Parameters.Add(parNutFert);
                        cmd.Parameters.Add(parEficFert);
                        cmd.Parameters.Add(parAreaFert);
                        cmd.Parameters.Add(parNumSetores);
                        cmd.Parameters.Add(parAreaSetor);
                        cmd.Parameters.Add(parNumDias);
                        cmd.Parameters.Add(parFreqFert);
                        cmd.Parameters.Add(parFertPeriodo);
                        cmd.Parameters.Add(parConcentraAgua);
                        cmd.Parameters.Add(parTaxaInj);
                        cmd.Parameters.Add(parTempoFert);
                        cmd.Parameters.Add(parConcentraFertSol);
                        cmd.Parameters.Add(parVolumeAgua);
                        cmd.Parameters.Add(parVolumeFert);
                        cmd.Parameters.Add(parMassaFert);
                        cmd.Parameters.Add(parEstimaNc);
                        cmd.Parameters.Add(parEstimaY);
                        cmd.Parameters.Add(parEstimaPSolo);
                        cmd.Parameters.Add(parAnaliseFoliar);

                        cmd.ExecuteNonQuery();
                        c.Close();
                        MessageBox.Show("Operação realizada com sucesso.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
                return false;
            }
            finally
            {
            }
        }

        public void alterar()
        {
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "UPDATE tbpropfert " +
                             "SET ctcefetiva = @ctcefetiva, al3 = @al3, ca2mg2 = @ca2mg2, va = @va, " +
                             "ctcph7 = @ctcph7, arg = @arg, prem = @prem, sc = @sc, pf = @pf, prnt = @prnt, " + 
                             "produtividade = @produtividade, nfoliar = @nfoliar, ksolo = @ksolo, psolo = @psolo, " +
                             "nutagua = @nutagua, nutfert = @nutfert, eficfert = @eficfert, areafert = @areafert, " +
                             "numsetores = @numsetores, areasetor = @areasetor, numdias = @numdias, freqfert = @freqfert, " +
                             "fertperiodo = @fertperiodo, concentraagua = concentraagua, taxainj = @taxainj, " +
                             "tempofert = @tempofert, concentrafertsol = @concentrafertsol, " +
                             "volumeagua = @volumeagua, volumefert = @volumefert, massafert = @massafert, " +
                             "estimanc = @estimanc, estimay = @estimay, estimapsolo = @estimapsolo, " +
                             "analisefoliar = @analisefoliar " +
                             "WHERE idpropfert = @idpropfert";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        //COMO INICIALMENTE SERÁ MANTIDA APENAS UMA PROPRIEDADE, "idpropfert" SERÁ SEMPRE "1".                    
                        SQLiteParameter parIdPropFert = new SQLiteParameter("@idpropfert", 1);
                        SQLiteParameter parCtcEfetiva = new SQLiteParameter("@ctcefetiva", Convert.ToDouble(this.ctcefetiva));
                        SQLiteParameter parAl3 = new SQLiteParameter("@al3", Convert.ToDouble(this.al3));
                        SQLiteParameter parCa2Mg2 = new SQLiteParameter("@ca2mg2", Convert.ToDouble(this.ca2mg2));                        
                        SQLiteParameter parVa = new SQLiteParameter("@va", Convert.ToDouble(this.va));
                        SQLiteParameter parCtcPh7 = new SQLiteParameter("@ctcph7", Convert.ToDouble(this.ctcph7));
                        SQLiteParameter parArg = new SQLiteParameter("@arg", Convert.ToDouble(this.arg));
                        SQLiteParameter parPrem = new SQLiteParameter("@prem", Convert.ToDouble(this.prem));
                        SQLiteParameter parSc = new SQLiteParameter("@sc", Convert.ToDouble(this.sc));
                        SQLiteParameter parPf = new SQLiteParameter("@pf", Convert.ToDouble(this.pf));
                        SQLiteParameter parPrnt = new SQLiteParameter("@prnt", Convert.ToDouble(this.prnt));
                        SQLiteParameter parProdutividade = new SQLiteParameter("@produtividade", this.produtividade);
                        SQLiteParameter parNFoliar = new SQLiteParameter("@nfoliar", Convert.ToDouble(this.nfoliar));
                        SQLiteParameter parKSolo = new SQLiteParameter("@ksolo", Convert.ToDouble(this.ksolo));
                        SQLiteParameter parPSolo = new SQLiteParameter("@psolo", Convert.ToDouble(this.psolo));
                        SQLiteParameter parNutAgua = new SQLiteParameter("@nutagua", Convert.ToDouble(this.nutagua));
                        SQLiteParameter parNutFert = new SQLiteParameter("@nutfert", Convert.ToDouble(this.nutfert));
                        SQLiteParameter parEficFert = new SQLiteParameter("@eficfert", Convert.ToDouble(this.eficfert));
                        SQLiteParameter parAreaFert = new SQLiteParameter("@areafert", Convert.ToDouble(this.areafert));
                        SQLiteParameter parNumSetores = new SQLiteParameter("@numsetores", this.numsetores);
                        SQLiteParameter parAreaSetor = new SQLiteParameter("@areasetor", Convert.ToDouble(this.areasetor));
                        SQLiteParameter parNumDias = new SQLiteParameter("@numdias", this.numdias);
                        SQLiteParameter parFreqFert = new SQLiteParameter("@freqfert", this.freqfert);
                        SQLiteParameter parFertPeriodo = new SQLiteParameter("@fertperiodo", Convert.ToDouble(this.fertperiodo));
                        SQLiteParameter parConcentraAgua = new SQLiteParameter("@concentraagua", Convert.ToDouble(this.concentraagua));
                        SQLiteParameter parTaxaInj = new SQLiteParameter("@taxainj", Convert.ToDouble(this.taxainj));
                        SQLiteParameter parTempoFert = new SQLiteParameter("@tempofert", Convert.ToDouble(this.tempofert));
                        SQLiteParameter parConcentraFertSol = new SQLiteParameter("@concentrafertsol", Convert.ToDouble(this.concentrafertsol));
                        SQLiteParameter parVolumeAgua = new SQLiteParameter("@volumeagua", Convert.ToDouble(this.volumeagua));
                        SQLiteParameter parVolumeFert = new SQLiteParameter("@volumefert", Convert.ToDouble(this.volumefert));
                        SQLiteParameter parMassaFert = new SQLiteParameter("@massafert", Convert.ToDouble(this.massafert));
                        SQLiteParameter parEstimaNc = new SQLiteParameter("@estimanc", this.estimanc);
                        SQLiteParameter parEstimaY = new SQLiteParameter("@estimay", this.estimay);
                        SQLiteParameter parEstimaPSolo = new SQLiteParameter("@estimapsolo", this.estimapsolo);
                        SQLiteParameter parAnaliseFoliar = new SQLiteParameter("@analisefoliar", this.analisefoliar);                        

                        cmd.Parameters.Add(parIdPropFert);
                        cmd.Parameters.Add(parCtcEfetiva);
                        cmd.Parameters.Add(parAl3);
                        cmd.Parameters.Add(parCa2Mg2);                        
                        cmd.Parameters.Add(parVa);
                        cmd.Parameters.Add(parCtcPh7);
                        cmd.Parameters.Add(parArg);
                        cmd.Parameters.Add(parPrem);
                        cmd.Parameters.Add(parSc);
                        cmd.Parameters.Add(parPf);
                        cmd.Parameters.Add(parPrnt);
                        cmd.Parameters.Add(parProdutividade);
                        cmd.Parameters.Add(parNFoliar);
                        cmd.Parameters.Add(parKSolo);
                        cmd.Parameters.Add(parPSolo);
                        cmd.Parameters.Add(parNutAgua);
                        cmd.Parameters.Add(parNutFert);
                        cmd.Parameters.Add(parEficFert);
                        cmd.Parameters.Add(parAreaFert);
                        cmd.Parameters.Add(parNumSetores);
                        cmd.Parameters.Add(parAreaSetor);
                        cmd.Parameters.Add(parNumDias);
                        cmd.Parameters.Add(parFreqFert);
                        cmd.Parameters.Add(parFertPeriodo);
                        cmd.Parameters.Add(parConcentraAgua);
                        cmd.Parameters.Add(parTaxaInj);
                        cmd.Parameters.Add(parTempoFert);
                        cmd.Parameters.Add(parConcentraFertSol);
                        cmd.Parameters.Add(parVolumeAgua);
                        cmd.Parameters.Add(parVolumeFert);
                        cmd.Parameters.Add(parMassaFert);
                        cmd.Parameters.Add(parEstimaNc);
                        cmd.Parameters.Add(parEstimaY);
                        cmd.Parameters.Add(parEstimaPSolo);
                        cmd.Parameters.Add(parAnaliseFoliar);

                        cmd.ExecuteNonQuery();
                        c.Close();
                        MessageBox.Show("Operação realizada com sucesso.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
            }
            finally
            {
            }
        } 
    }
}
