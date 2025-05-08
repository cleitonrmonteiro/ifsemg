using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PROJ_EXT_17_V10
{
    class Propriedade
    {        
        private String nmpropriedade;
        private String nmproprietario;
        private String resptecnico;
        //private int cultura;
        private int idade;
        private float entrelinhas;
        private float entreplantas;
        private float pas; //areasombreada
        private float capacidadecampo;
        private float pontomurcha;
        private float densidadeaparente;
        private float tempmax;
        private float tempmin;
        //private float sistemairrigacao;
        private float areamolhada;
        private float vazaoemissor;
        private float entreemissores;
        private int emissoresplanta;
        private float eficiencia;

        public String getNmPropriedade()
        {
            return this.nmpropriedade;
        }

        public void setNmPropriedade(String nmpropriedade)
        {
            this.nmpropriedade = nmpropriedade;
        }

        public String getNmProprietario()
        {
            return this.nmproprietario;
        }

        public void setNmProprietario(String nmproprietario)
        {
            this.nmproprietario = nmproprietario;
        }

        public String getRespTecnico()
        {
            return this.resptecnico;
        }

        public void setRespTecnico(String resptecnico)
        {
            this.resptecnico = resptecnico;
        }

        public int getIdade()
        {
            return this.idade;
        }

        public void setIdade(int idade)
        {
            this.idade = idade;
        }

        public float getEntreLinhas()
        {
            return this.entrelinhas;
        }

        public void setEntreLinhas(float entrelinhas)
        {
            this.entrelinhas = entrelinhas;
        }

        public float getEntrePlanstas()
        {
            return this.entreplantas;
        }

        public void setEntrePlanstas(float entreplantas)
        {
            this.entreplantas = entreplantas;
        }

        public float getPas()
        {
            return this.pas;
        }

        public void setPas(float pas)
        {
            this.pas = pas;
        }

        public float getCapacidadeCampo()
        {
            return this.capacidadecampo;
        }

        public void setCapacidadeCampo(float capacidadecampo)
        {
            this.capacidadecampo = capacidadecampo;
        }

        public float getPontoMurcha()
        {
            return this.pontomurcha;
        }

        public void setPontoMurcha(float pontomurcha)
        {
            this.pontomurcha = pontomurcha;
        }        

        public float getDensidadeAparente()
        {
            return this.densidadeaparente;
        }

        public void setDensidadeAparente(float densidadeaparente)
        {
            this.densidadeaparente = densidadeaparente;
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

        public float getAreaMolhada()
        {
            return this.areamolhada;
        }

        public void setAreaMolhada(float areamolhada)
        {
            this.areamolhada = areamolhada;
        }

        public float getVazaoEmissor()
        {
            return this.vazaoemissor;
        }

        public void setVazaoEmissor(float vazaoemissor)
        {
            this.vazaoemissor = vazaoemissor;
        }

        public float getEntreEmissores()
        {
            return this.entreemissores;
        }

        public void setEntreEmissores(float entreemissores)
        {
            this.entreemissores = entreemissores;
        }

        public int getEmissoresPlanta()
        {
            return this.emissoresplanta;
        }

        public void setEmissoresPlanta(int emissoresplanta)
        {
            this.emissoresplanta = emissoresplanta;
        }

        public float getEficiencia()
        {
            return this.eficiencia;
        }

        public void setEficiencia(float eficiencia)
        {
            this.eficiencia = eficiencia;
        }

        public Boolean carregarDados()
        {
            try
            {
                String appBin = Application.StartupPath;
                String strConn = @"Data Source=" + appBin + "\\bdextec1.s3db";

                String sql = "SELECT * FROM tbpropriedade";

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
                                this.nmpropriedade = reader.GetString(1);
                                this.nmproprietario = reader.GetString(2);
                                this.resptecnico = reader.GetString(3);
                                this.idade = reader.GetInt32(5);
                                this.entrelinhas = reader.GetFloat(6);
                                this.entreplantas = reader.GetFloat(7);
                                this.pas = reader.GetFloat(8);
                                this.capacidadecampo = reader.GetFloat(9);
                                this.pontomurcha = reader.GetFloat(10);
                                this.densidadeaparente = reader.GetFloat(11);
                                this.tempmax = reader.GetFloat(12);
                                this.tempmin = reader.GetFloat(13);
                                this.areamolhada = reader.GetFloat(15);
                                this.vazaoemissor = reader.GetFloat(16);
                                this.entreemissores = reader.GetFloat(17);
                                this.emissoresplanta = reader.GetInt32(18);
                                this.eficiencia = reader.GetFloat(19);

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

                String sql = "INSERT INTO tbpropriedade " +
                             "(idpropriedade, nmpropriedade, nmproprietario, resptecnico, cultura, idade, " +
                             "entrelinhas, entreplantas, areasombreada, capacidadecampo, pontomurcha, densidadeaparente, " +
                             "tempmax, tempmin, sistemairrigacao, areamolhada, vazaoemissor, entreemissores, " +
                             "emissoresplanta, eficiencia) " +

                             "VALUES (@idpropriedade, @nmpropriedade, @nmproprietario, @resptecnico, " +
                             "@cultura, @idade, @entrelinhas, @entreplantas, @areasombreada, " +
                             "@capacidadecampo, @pontomurcha, @densidadeaparente, " +
                             "@tempmax, @tempmin, " +
                             "@sistemairrigacao, @areamolhada, @vazaoemissor, @entreemissores, @emissoresplanta, @eficiencia)";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        //COMO INICIALMENTE SERÁ MANTIDA APENAS UMA PROPRIEDADE, "idpropriedade" SERÁ SEMPRE "1".                    
                        SQLiteParameter parIdPropriedade = new SQLiteParameter("@idpropriedade", 1);
                        SQLiteParameter parNmPropriedade = new SQLiteParameter("@nmpropriedade", this.nmpropriedade);
                        SQLiteParameter parNmProprietario = new SQLiteParameter("@nmproprietario", this.nmproprietario);
                        SQLiteParameter parRespTecnico = new SQLiteParameter("@resptecnico", this.resptecnico);
                        SQLiteParameter parCultura = new SQLiteParameter("@cultura", 1);                        
                        SQLiteParameter parIdade = new SQLiteParameter("@idade", Convert.ToInt32(this.idade));
                        SQLiteParameter parEntreLinhas = new SQLiteParameter("@entrelinhas", Convert.ToDouble(this.entrelinhas));
                        SQLiteParameter parEntrePlantas = new SQLiteParameter("@entreplantas", Convert.ToDouble(this.entreplantas));
                        SQLiteParameter parAreaSombreada = new SQLiteParameter("@areasombreada", Convert.ToDouble(this.pas));
                        SQLiteParameter parCapacidadeCampo = new SQLiteParameter("@capacidadecampo", Convert.ToDouble(this.capacidadecampo));
                        SQLiteParameter parPontoMurcha = new SQLiteParameter("@pontomurcha", Convert.ToDouble(this.pontomurcha));
                        SQLiteParameter parDensidadeAparente = new SQLiteParameter("@densidadeaparente", Convert.ToDouble(this.densidadeaparente));
                        SQLiteParameter parTempMax = new SQLiteParameter("@tempmax", Convert.ToDouble(this.tempmax));
                        SQLiteParameter parTempMin = new SQLiteParameter("@tempmin", Convert.ToDouble(this.tempmin));
                        SQLiteParameter parSistemaIrrigacao = new SQLiteParameter("@sistemairrigacao", 1);
                        SQLiteParameter parAreaMolhada = new SQLiteParameter("@areamolhada", Convert.ToDouble(this.areamolhada));
                        SQLiteParameter parVazaoEmissor = new SQLiteParameter("@vazaoemissor", Convert.ToDouble(this.vazaoemissor));
                        SQLiteParameter parEntreEmissores = new SQLiteParameter("@entreemissores", Convert.ToDouble(this.entreemissores));
                        SQLiteParameter parEmissoresPlanta = new SQLiteParameter("@emissoresplanta", Convert.ToInt32(this.emissoresplanta));
                        SQLiteParameter parEficiencia = new SQLiteParameter("@eficiencia", Convert.ToDouble(this.eficiencia));

                        cmd.Parameters.Add(parIdPropriedade);
                        cmd.Parameters.Add(parNmPropriedade);
                        cmd.Parameters.Add(parNmProprietario);
                        cmd.Parameters.Add(parRespTecnico);
                        cmd.Parameters.Add(parCultura);
                        cmd.Parameters.Add(parIdade);
                        cmd.Parameters.Add(parEntreLinhas);
                        cmd.Parameters.Add(parEntrePlantas);
                        cmd.Parameters.Add(parAreaSombreada);
                        cmd.Parameters.Add(parCapacidadeCampo);
                        cmd.Parameters.Add(parPontoMurcha);
                        cmd.Parameters.Add(parDensidadeAparente);
                        cmd.Parameters.Add(parTempMax);
                        cmd.Parameters.Add(parTempMin);
                        cmd.Parameters.Add(parSistemaIrrigacao);
                        cmd.Parameters.Add(parAreaMolhada);
                        cmd.Parameters.Add(parVazaoEmissor);
                        cmd.Parameters.Add(parEntreEmissores);
                        cmd.Parameters.Add(parEmissoresPlanta);
                        cmd.Parameters.Add(parEficiencia);

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

                String sql = "UPDATE tbpropriedade " +
                             "SET nmpropriedade = @nmpropriedade, nmproprietario = @nmproprietario, resptecnico = @resptecnico, " +
                             "idade = @idade, entrelinhas = @entrelinhas, entreplantas = @entreplantas, areasombreada = @areasombreada, " +
                             "capacidadecampo = @capacidadecampo, pontomurcha = @pontomurcha, densidadeaparente = @densidadeaparente, " +
                             "tempmax = @tempmax, tempmin = @tempmin, " +
                             "areamolhada = @areamolhada, vazaoemissor = @vazaoemissor, entreemissores = @entreemissores, emissoresplanta = @emissoresplanta, eficiencia = @eficiencia " +
                             "WHERE idpropriedade = @idpropriedade";

                using (SQLiteConnection c = new SQLiteConnection(strConn))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        //COMO INICIALMENTE SERÁ MANTIDA APENAS UMA PROPRIEDADE, "idpropriedade" SERÁ SEMPRE "1".                    
                        SQLiteParameter parIdPropriedade = new SQLiteParameter("@idpropriedade", 1);
                        SQLiteParameter parNmPropriedade = new SQLiteParameter("@nmpropriedade", this.nmpropriedade);
                        SQLiteParameter parNmProprietario = new SQLiteParameter("@nmproprietario", this.nmproprietario);
                        SQLiteParameter parRespTecnico = new SQLiteParameter("@resptecnico", this.resptecnico);
                        //SQLiteParameter parCultura = new SQLiteParameter("@cultura", 1);                        
                        SQLiteParameter parIdade = new SQLiteParameter("@idade", Convert.ToInt32(this.idade));
                        SQLiteParameter parEntreLinhas = new SQLiteParameter("@entrelinhas", Convert.ToDouble(this.entrelinhas));
                        SQLiteParameter parEntrePlantas = new SQLiteParameter("@entreplantas", Convert.ToDouble(this.entreplantas));
                        SQLiteParameter parAreaSombreada = new SQLiteParameter("@areasombreada", Convert.ToDouble(this.pas));
                        SQLiteParameter parCapacidadeCampo = new SQLiteParameter("@capacidadecampo", Convert.ToDouble(this.capacidadecampo));
                        SQLiteParameter parPontoMurcha = new SQLiteParameter("@pontomurcha", Convert.ToDouble(this.pontomurcha));
                        SQLiteParameter parDensidadeAparente = new SQLiteParameter("@densidadeaparente", Convert.ToDouble(this.densidadeaparente));
                        SQLiteParameter parTempMax = new SQLiteParameter("@tempmax", Convert.ToDouble(this.tempmax));
                        SQLiteParameter parTempMin = new SQLiteParameter("@tempmin", Convert.ToDouble(this.tempmin));
                        //SQLiteParameter parSistemaIrrigacao = new SQLiteParameter("@sistemairrigacao", 1);
                        SQLiteParameter parAreaMolhada = new SQLiteParameter("@areamolhada", Convert.ToDouble(this.areamolhada));
                        SQLiteParameter parVazaoEmissor = new SQLiteParameter("@vazaoemissor", Convert.ToDouble(this.vazaoemissor));
                        SQLiteParameter parEntreEmissores = new SQLiteParameter("@entreemissores", Convert.ToDouble(this.entreemissores));
                        SQLiteParameter parEmissoresPlanta = new SQLiteParameter("@emissoresplanta", Convert.ToInt32(this.emissoresplanta));
                        SQLiteParameter parEficiencia = new SQLiteParameter("@eficiencia", Convert.ToDouble(this.eficiencia));

                        cmd.Parameters.Add(parIdPropriedade);
                        cmd.Parameters.Add(parNmPropriedade);
                        cmd.Parameters.Add(parNmProprietario);
                        cmd.Parameters.Add(parRespTecnico);
                        //cmd.Parameters.Add(parCultura);
                        cmd.Parameters.Add(parIdade);
                        cmd.Parameters.Add(parEntreLinhas);
                        cmd.Parameters.Add(parEntrePlantas);
                        cmd.Parameters.Add(parAreaSombreada);
                        cmd.Parameters.Add(parCapacidadeCampo);
                        cmd.Parameters.Add(parPontoMurcha);
                        cmd.Parameters.Add(parDensidadeAparente);
                        cmd.Parameters.Add(parTempMax);
                        cmd.Parameters.Add(parTempMin);
                        //cmd.Parameters.Add(parSistemaIrrigacao);
                        cmd.Parameters.Add(parAreaMolhada);
                        cmd.Parameters.Add(parVazaoEmissor);
                        cmd.Parameters.Add(parEntreEmissores);
                        cmd.Parameters.Add(parEmissoresPlanta);
                        cmd.Parameters.Add(parEficiencia);

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
