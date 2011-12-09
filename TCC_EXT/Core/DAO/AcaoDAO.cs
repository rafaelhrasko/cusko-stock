using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using MySql.Data.MySqlClient;

namespace Core.DAO
{
    class AcaoDAO
    {
        internal static List<Acao> listarAcoes()
        {
            List<Acao> LstAcao = new List<Acao>();
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from Acao ac inner join Bolsa bl on (ac.Bolsa_idBolsa = bl.idBolsa)   ";

            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                Acao stock = new Acao();
                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        stock = new Acao();
                        stock.ICodigo = int.Parse(lol["idAcao"].ToString());
                        stock.StrSimbolo = lol["symbol"].ToString();
                        stock.StrBolsa = lol["nome"].ToString();
                        LstAcao.Add(stock);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                msc.Close();
            }

            return LstAcao;
        }

        internal static List<Acao> listarAcoesCarteira(Carteira cart)
        {
            string sql = "select * from Carteira_has_Acao where Carteira_idCarteira  = " + cart.ICodigo;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<Acao> LstAcao = new List<Acao>();

            try
            {
                msc.Open();
                MySqlDataReader mdr = msCommand.ExecuteReader();

                if (mdr.HasRows)
                {
                    Acao stock = new Acao();
                    while (mdr.Read())
                    {
                        stock = new Acao();
                        stock.ICodigo = int.Parse(mdr["Acao_idAcao"].ToString());

                        stock = AcaoDAO.obterAcao(stock);

                        LstAcao.Add(stock);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msc.Close();
            }

            return LstAcao;
        }

        private static Acao obterAcao(Acao stock)
        {
            string sql = "select * from Acao ac inner join Bolsa bl on (bl.idBolsa = ac.Bolsa_idBolsa) where ac.idAcao  = " + stock.ICodigo;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            Acao acao = new Acao();

            try
            {
                msc.Open();
                MySqlDataReader mdr = msCommand.ExecuteReader();

                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        acao = stock;
                        acao.StrSimbolo = mdr["symbol"].ToString();
                        acao.StrBolsa = mdr["nome"].ToString();
                        //acao.DDividendos = double.Parse(mdr["dividendos"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msc.Close();
            }

            return acao;
        }

        internal static Acao obterAcaoPorSimbolo(string text)
        {
            string sql = "select * from Acao ac inner join Bolsa bl on (bl.idBolsa = ac.Bolsa_idBolsa) where ac.symbol  = '" + text + "'";
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            Acao acao = null;

            try
            {
                msc.Open();
                MySqlDataReader mdr = msCommand.ExecuteReader();

                if (mdr.HasRows)
                {
                    while (mdr.Read())
                    {
                        acao = new Acao();
                        acao.ICodigo = int.Parse(mdr["idAcao"].ToString()); ;
                        acao.StrSimbolo = mdr["symbol"].ToString();
                        acao.StrBolsa = mdr["nome"].ToString();
                        //acao.DDividendos = double.Parse(mdr["dividendos"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msc.Close();
            }
            return acao;
        }

        internal static void inserirAcaoCarteira(Carteira cart, Acao stock)
        {
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "insert into cusko.Carteira_has_Acao (Carteira_idCarteira, Acao_idAcao) values (" + cart.ICodigo + "," + stock.ICodigo + ")";
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                msCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msc.Close();
                MySqlConnection.ClearAllPools();
            }
        }
    }
}
