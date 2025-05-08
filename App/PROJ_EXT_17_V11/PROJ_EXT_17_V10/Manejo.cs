using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    class Manejo
    {        
        private int idmanejo;
        private DateTime dtmanejo;
        private float tempmax;
        private float tempmin;
        private float chuva;
        private float quandoaplic;      //QUANDO APLICAR?
        private float quantoaplic;      //QUANTO APLICAR?
        private float tempoaplic;       //POR QUANTO TEMPO?        
        private float etcdia;
        private float etctotal;
        private int irrigou;            //0-false, 1-true
        private DateTime ultimairriga;  //Data da última irrigação, caso exista.
        
        private Propriedade propriedade;       
        
        private const double W = 1.5;        
        private const double Z = 50; //PROFUNDIDADE DO SISTEMA RADICULAR
        private const double F = 0.5;       

        public Manejo()
        {            
        }

        public int idManejo()
        {
            return this.idmanejo;
        }

        public void setIdManeho(int idmanejo)
        {
            this.idmanejo = idmanejo;
        }
        
        public DateTime getDtManejo()
        {
            return this.dtmanejo;
        }
        
        public void setDtManejo(DateTime dtmanejo)
        {
            this.dtmanejo = dtmanejo;
        }

        public float getTempMax()
        {
            return this.tempmax;
        }

        public void setTempMax(float tempmax)
        {
            this.tempmax = tempmax;
        }

        public float getTempMin()
        {
            return this.tempmin;
        }

        public void setTempMin(float tempmin)
        {
            this.tempmin = tempmin;
        }
        
        public float getChuva()
        {
            return this.chuva;
        }        

        public void setChuva(float chuva)
        {
            this.chuva = chuva;
        }

        public float getQuandoAplic()
        {
            return this.quandoaplic;
        }

        public void setQuandoAplic(float quandoaplic)
        {
            this.quandoaplic = quandoaplic;
        }

        public float getQuantoAplic()
        {
            return this.quantoaplic;
        }

        public void setQuantoAplic(float quantoaplic)
        {
            this.quantoaplic = quantoaplic;
        }

        public float getTempoAplic()
        {
            return this.tempoaplic;
        }

        public void setTempoAplic(float tempoaplic)
        {
            this.tempoaplic = tempoaplic;
        }        

        public float getEtcDia()
        {
            return this.etcdia;
        }

        public void setEtcDia(float etcdia)
        {
            this.etcdia = etcdia;
        }

        public float getEtcTotal()
        {
            return this.etctotal;
        }

        public void setEtcTotal(float etctotal)
        {
            this.etctotal = etctotal;
        }

        public int getIrrigou()
        {
            return this.irrigou;
        }

        public void setIrrigou(int irrigou)
        {
            this.irrigou = irrigou;
        }

        public DateTime getUltimaIrriga()
        {
            return this.ultimairriga;
        }

        public void setUltimaIrriga(DateTime ultimairriga)
        {
            this.ultimairriga = ultimairriga;
        }

        public Propriedade getPropriedade()
        {
            return this.propriedade;
        }

        public void setPropriedade(Propriedade propriedade)
        {
            this.propriedade = propriedade;
        }               
        
        public Boolean carregarDados()
        {
            try
            {                
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "SELECT * FROM tbmanejo WHERE strftime('%d/%m/%Y', dtmanejo) = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'";

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
                                this.idmanejo = reader.GetInt32(0);
                                this.dtmanejo = reader.GetDateTime(1);
                                this.tempmax = reader.GetFloat(2);
                                this.tempmin = reader.GetFloat(3);
                                this.chuva = reader.GetFloat(4);
                                this.quandoaplic = reader.GetFloat(5);
                                this.quantoaplic = reader.GetFloat(6);
                                this.tempoaplic = reader.GetFloat(7);
                                this.etcdia = reader.GetFloat(8);
                                this.etctotal = reader.GetFloat(9);                                
                                this.irrigou = reader.GetInt32(10);

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

        //OBTÉM, CASO EXISTA, O "etctotal" DO MANEJO ANTERIOR (ÚLTIMO NÃO IRRIGADO).
        public Double obterEtcTotal()
        {            
            try
            {                
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";                
                
                String sql = "SELECT etctotal, irrigou FROM tbmanejo WHERE strftime('%d/%m/%Y', dtmanejo) = " +
                             "(" +
                                "SELECT MAX(strftime('%d/%m/%Y', dtmanejo)) AS dtmanejo FROM tbmanejo " +
                                "WHERE strftime('%d/%m/%Y', dtmanejo) <> '" + DateTime.Now.ToString("dd/MM/yyyy") + "')";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows) //SE EXISTE "etctotal" ACUMULADO
                            {
                                if (reader.GetInt32(1) == 0)
                                    return this.etcDia() + reader.GetFloat(0);                                
                            }                            
                            return this.etcDia();
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
                return -1;
            }
        }       

        public Boolean inserirClima()
        {            
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";                
                
                String sql = "INSERT INTO tbmanejo " +
                             "(dtmanejo, tempmax, tempmin, chuva, quando, quanto, tempo, etcdia, etctotal, irrigou) " +
                             "VALUES (@dtmanejo, @tempmax, @tempmin, @chuva, @quando, @quanto, @tempo, @etcdia, @etctotal, @irrigou)";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        String data = DateTime.Now.ToString("dd/MM/yyyy");
                        SQLiteParameter parDtManejo = new SQLiteParameter("@dtmanejo", Convert.ToDateTime(data));

                        SQLiteParameter parTempMax = new SQLiteParameter("@tempmax", Convert.ToDouble(this.tempmax));
                        SQLiteParameter parTempMin = new SQLiteParameter("@tempmin", Convert.ToDouble(this.tempmin));
                        SQLiteParameter parChuva = new SQLiteParameter("@chuva", Convert.ToDouble(this.chuva));
                        SQLiteParameter parQuando = new SQLiteParameter("@quando", Convert.ToDouble(0));
                        SQLiteParameter parQuanto = new SQLiteParameter("@quanto", Convert.ToDouble(0));
                        SQLiteParameter parTempo = new SQLiteParameter("@tempo", Convert.ToDouble(0));
                        SQLiteParameter parEtcDia = new SQLiteParameter("@etcdia", Convert.ToDouble(this.etcDia()));
                        SQLiteParameter parEtcTotal = new SQLiteParameter("@etctotal", Convert.ToDouble(this.obterEtcTotal()));
                        SQLiteParameter parIrrigou = new SQLiteParameter("@irrigou", Convert.ToDouble(0));

                        cmd.Parameters.Add(parDtManejo);
                        cmd.Parameters.Add(parTempMax);
                        cmd.Parameters.Add(parTempMin);
                        cmd.Parameters.Add(parChuva);
                        cmd.Parameters.Add(parQuando);
                        cmd.Parameters.Add(parQuanto);
                        cmd.Parameters.Add(parTempo);
                        cmd.Parameters.Add(parEtcDia);
                        cmd.Parameters.Add(parEtcTotal);
                        cmd.Parameters.Add(parIrrigou);

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

        public void alterarClima()
        {            
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "UPDATE tbmanejo " +
                             "SET tempmax = @tempmax, tempmin = @tempmin, chuva = @chuva, " +
                             "etcdia = @etcdia, etctotal = @etctotal " +
                             "WHERE strftime('%d/%m/%Y', dtmanejo) = '" + DateTime.Now.ToString("dd/MM/yyyy") + "'";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        SQLiteParameter parTempMax = new SQLiteParameter("@tempmax", Convert.ToDouble(this.tempmax));
                        SQLiteParameter parTempMin = new SQLiteParameter("@tempmin", Convert.ToDouble(this.tempmin));
                        SQLiteParameter parChuva = new SQLiteParameter("@chuva", Convert.ToDouble(this.chuva));
                        SQLiteParameter parEtcDia = new SQLiteParameter("@etcdia", Convert.ToDouble(this.etcDia()));                        
                        SQLiteParameter parEtcTotal = new SQLiteParameter("@etctotal", Convert.ToDouble(this.obterEtcTotal()));

                        cmd.Parameters.Add(parTempMax);
                        cmd.Parameters.Add(parTempMin);
                        cmd.Parameters.Add(parChuva);
                        cmd.Parameters.Add(parEtcDia);
                        cmd.Parameters.Add(parEtcTotal);

                        cmd.ExecuteNonQuery();
                        c.Close();                        
                    }
                } MessageBox.Show("Operação realizada com sucesso.", "IFSudesteMG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.ToString());
            }
            finally
            {                
            }
        }
        
        //PORCENTAGEM DE ÁREA MOLHADA (PAM)
        public double pan()
        {
            return ((propriedade.getEntreEmissores() * W) / (propriedade.getEntrePlanstas() * propriedade.getEntreLinhas())) * 100;                        
        }

        //mm
        public double irn()
        {            
            return ((propriedade.getCapacidadeCampo() - propriedade.getPontoMurcha()) / 10) * propriedade.getDensidadeAparente() * Z * F * (pan() / 100);            
        }

        //RADIAÇÃO EXTRATERRESTRE (mm/dia) OBS: "Lat S = 20"
        public double ra()
        {
            int mes = DateTime.Now.Month;
            switch (mes)
            {
                case 1:
                    return 16.7;
                    //break;
                case 2:
                    return 16;
                    //break;
                case 3:
                    return 14.5;
                    //break;
                case 4:
                    return 12.4;
                    //break;
                case 5:
                    return 10.6;
                    //break;
                case 6:
                    return 9.6;
                    //break;
                case 7:
                    return 10;
                //break;
                case 8:
                    return 11.5;
                //break;
                case 9:
                    return 13.5;
                //break;
                case 10:
                    return 15.3;
                //break;
                case 11:
                    return 16.2;
                //break;
                case 12: return 16.8;
                default: return 0;
            }
        }

        //EVAPOTRANSPIRAÇÃO DE REFERÊNCIA (mm/dia)
        public double et0(float tempmax, float tempmin)
        {                        
            double tempmed = (tempmax + tempmin) / 2;            
            return 0.0023 * ra() * (Math.Pow(tempmax - tempmin, 0.5)) * (tempmed + 17.8);            
        }

        //COEFICIENTE DE CULTURA
        public double kc()
        {            
            if (propriedade.getIdade() == 0)
            {
                if ((propriedade.getEntreLinhas() > 3) && (propriedade.getEntrePlanstas() > 1))
                    return 1;
                else if ((propriedade.getEntreLinhas() >= 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 1.1;
                else if ((propriedade.getEntreLinhas() >= 2) && (propriedade.getEntreLinhas() < 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 1.2;
                else if ((propriedade.getEntreLinhas() >= 1) && (propriedade.getEntreLinhas() < 2) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 1.3;
            }
            else if (propriedade.getIdade() == 1)
            {
                if ((propriedade.getEntreLinhas() > 3) && (propriedade.getEntrePlanstas() > 1))
                    return 0.8;
                else if ((propriedade.getEntreLinhas() >= 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 0.9;
                else if ((propriedade.getEntreLinhas() >= 2) && (propriedade.getEntreLinhas() < 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 1;
                else if ((propriedade.getEntreLinhas() >= 1) && (propriedade.getEntreLinhas() < 2) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 1.1;
            }
            else if (propriedade.getIdade() == 2)
            {
                if ((propriedade.getEntreLinhas() > 3) && (propriedade.getEntrePlanstas() > 1))
                    return 0.6;
                else if ((propriedade.getEntreLinhas() >= 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 0.7;
                else if ((propriedade.getEntreLinhas() >= 2) && (propriedade.getEntreLinhas() < 3) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 0.8;
                else if ((propriedade.getEntreLinhas() >= 1) && (propriedade.getEntreLinhas() < 2) && (propriedade.getEntrePlanstas() >= 0.5) && (propriedade.getEntrePlanstas() <= 1))
                    return 0.9;
            }
            return 0;
        }

        //COEFICIENTE DE LOCALIZADA
        public double kl()
        {
            double p;
            
            if (propriedade.getPas() > pan())
                p = propriedade.getPas();
            else
                p = pan();

            return 0.1 * Math.Sqrt(p);            
        }

        //EVAPOTRANSPIRAÇÃO DA CULTURA (mm/dia)
        public double etc(float tempmax, float tempmin)
        {            
            return et0(tempmax, tempmin) * kc() * kl();            
        }

        public double etcDia()
        {
            //PASSA PARA "etc" A TEMPERATURA DO DIA.
            return etc(this.tempmax, this.tempmin);
        }
        
        //TURVO DE REGA (DIAS) --QUANDO APLICAR?--
        public double tr()
        {            
            //PASSA PARA "etc" A TEMPERATURA MÉDIA ANUAL DA PROPRIEDADE.
            
            //A ESTRATÉGIA ABAIXO FOI UTILIZADA PARA O CASO DE "DIVISÃO POR 0".
            double result_etc = etc(propriedade.getTempMax(), propriedade.getTempMin());
            
            if (result_etc == 0)
                return 0;
            else
                return irn() / result_etc; 
        }

        // --QUANTO APLICAR?--
        public double qtdAplic()
        {
            return (this.etctotal - this.chuva) / propriedade.getEficiencia();            
        }

        //INTENSIDADE DE APLICAÇÃO
        public double ia()
        {
            return (propriedade.getEmissoresPlanta() * propriedade.getVazaoEmissor()) / (propriedade.getEntrePlanstas() * propriedade.getEntreLinhas());
        }
        
        // --POR QUANTO TEMPO?--
        public double qtdTempo()
        {           
            return qtdAplic() / ia();
        }

        //FORMATA O RESULTADO DE "qtdTempo()" PARA "XhYm"
        public string formataQtdTempo()
        {
            Double t = qtdTempo();
            Double h = Math.Floor(t);
            Double m = (t - h) * 60;
            return String.Format("{0:0.00}", h.ToString() + "h" + String.Format("{0:0}", m) + "m");
        }

        public void registrarIrrigacao()
        {
            
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "UPDATE tbmanejo " +
                             "SET irrigou = 1, quando = @quando, quanto = @quanto, tempo = @tempo " +
                             "WHERE idmanejo = @idmanejo";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        SQLiteParameter parIdmanejo = new SQLiteParameter("@idmanejo", this.idmanejo);
                        SQLiteParameter parQuando = new SQLiteParameter("@quando", Convert.ToDouble(this.tr()));
                        SQLiteParameter parQuanto = new SQLiteParameter("@quanto", Convert.ToDouble(this.qtdAplic()));
                        SQLiteParameter parTempo = new SQLiteParameter("@tempo", Convert.ToDouble(this.qtdTempo()));

                        cmd.Parameters.Add(parIdmanejo);
                        cmd.Parameters.Add(parQuando);
                        cmd.Parameters.Add(parQuanto);
                        cmd.Parameters.Add(parTempo);

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
        
        //VERIFICA SE HÁ ALGUMA IRRIGAÇÃO E ARMAZENA EM "ultimairriga" A "ÚLTIMA", RETORNANDO "true".
        public Boolean ultimaIrrigacao()
        {
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "SELECT dtmanejo FROM tbmanejo WHERE strftime('%d/%m/%Y', dtmanejo) = " +
                             "(" +
                                "SELECT MAX(strftime('%d/%m/%Y', dtmanejo)) AS dtmanejo FROM tbmanejo " +
                                "WHERE irrigou = 1)";             

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
                                this.ultimairriga = reader.GetDateTime(0);
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

        public Boolean ultimaIrrigaIsDay()
        {
            this.ultimaIrrigacao();
            if (this.ultimairriga == Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                return true;
            return false;
        }
    }
}
