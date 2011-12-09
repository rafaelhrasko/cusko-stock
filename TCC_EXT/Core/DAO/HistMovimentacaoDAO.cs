using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Core.Class;

namespace Core.DAO
{
    class HistMovimentacaoDAO
    {

        internal static List<Class.HistMovimentacao> ultimasNegociacoes()
        {
            List<HistMovimentacao> lstHistMov = new List<HistMovimentacao>();
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) ";

            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                HistMovimentacao asd = new HistMovimentacao();
                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        asd = new HistMovimentacao();
                        asd.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        asd.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        asd.FValorNegociado = float.Parse(lol["valor"].ToString());
                        asd.Acao.StrSimbolo = lol["symbol"].ToString();

                        lstHistMov.Add(asd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return lstHistMov;
        }

        internal static HistMovimentacao listarUltimaNegociacaoAcao(Acao item)
        {
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) where Acao_idAcao = " + item.ICodigo + " order by data desc limit 1 ";
            HistMovimentacao asd = new HistMovimentacao();
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        asd = new HistMovimentacao();
                        asd.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        asd.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        asd.FValorNegociado = float.Parse(lol["valor"].ToString());
                        asd.Acao.StrSimbolo = lol["symbol"].ToString();
                        asd.IQuantidadeNegociada = int.Parse(lol["volume"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return asd;
        }

        internal static HistMovimentacao obterHistoricoPorSimbolo(string symbol)
        {
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) where UPPER(symbol) = UPPER('" + symbol + "') order by data desc limit 1 ";
            HistMovimentacao asd = new HistMovimentacao();
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        asd = new HistMovimentacao();
                        asd.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        asd.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        asd.FValorNegociado = float.Parse(lol["valor"].ToString());
                        asd.Acao.StrSimbolo = lol["symbol"].ToString();
                        asd.IQuantidadeNegociada = int.Parse(lol["volume"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return asd;
        }

        internal static List<HistMovimentacao> obterHistoricoCompletoPorSimbolo(string symbol)
        {
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) where UPPER(symbol) = UPPER('" + symbol + "') order by data desc LIMIT 2000";
            HistMovimentacao asd = new HistMovimentacao();
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<HistMovimentacao> lstHistMov = new List<HistMovimentacao>();

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        asd = new HistMovimentacao();
                        asd.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        asd.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        asd.FValorNegociado = float.Parse(lol["valor"].ToString());
                        asd.Acao.StrSimbolo = lol["symbol"].ToString();
                        asd.IQuantidadeNegociada = int.Parse(lol["volume"].ToString());

                        lstHistMov.Add(asd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return lstHistMov.OrderBy(a => a.DtNegociada).ToList();
        }

        internal static List<HistMovimentacao> obterHistoricoCompletoPorSimboloDiaAnterior(string symbol)
        {
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) where UPPER(symbol) = UPPER('" + symbol + "') AND data > cast( '" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + "' as date) order by data desc";
            HistMovimentacao asd = new HistMovimentacao();
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<HistMovimentacao> lstHistMov = new List<HistMovimentacao>();

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                if (lol.HasRows)
                {
                    while (lol.Read())
                    {
                        asd = new HistMovimentacao();
                        asd.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        asd.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        asd.FValorNegociado = float.Parse(lol["valor"].ToString());
                        asd.Acao.StrSimbolo = lol["symbol"].ToString();
                        asd.IQuantidadeNegociada = int.Parse(lol["volume"].ToString());

                        lstHistMov.Add(asd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return lstHistMov.OrderBy(a => a.DtNegociada).ToList();
        }

        internal static List<HistMovimentacao> listarUltimaNegociacaoAcao(List<Acao> lstAcoes)
        {
            string sql = "";

            for (int i = 0; i < lstAcoes.Count; i++)
            {
                sql += "select * from HistoricoMovimentacao hm inner join Acao a on (a.idAcao = hm.Acao_idAcao) where Acao_idAcao = " + lstAcoes[i].ICodigo + " LIMIT 1";
                if (i + 1 != lstAcoes.Count)
                    sql += " UNION ";
            }

            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            List<HistMovimentacao> asd = new List<HistMovimentacao>();
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader lol = msCommand.ExecuteReader();

                if (lol.HasRows)
                {
                    HistMovimentacao hm = new HistMovimentacao();
                    while (lol.Read())
                    {
                        hm = new HistMovimentacao();
                        hm.Acao.ICodigo = int.Parse(lol["Acao_idAcao"].ToString());
                        hm.Acao.StrSimbolo = lol["symbol"].ToString();
                        hm.DtNegociada = DateTime.Parse(lol["data"].ToString());
                        hm.FValorNegociado = float.Parse(lol["valor"].ToString());
                        hm.IQuantidadeNegociada = int.Parse(lol["volume"].ToString());

                        asd.Add(hm);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MySqlConnection.ClearAllPools();
                msc.Close();
            }

            return asd;
        }

        internal static void inserirNegociacaoInvestidor(HistMovimentacao histMov, Investidor usu)
        {
            string sql = @"INSERT INTO `cusko`.`MovimentacaoInvestidor`(`Investidor_idInvestidor`,`Acao_idAcao`,`data`,`quantidade`,`valor`) VALUES (" + usu.ICodigo + "," + histMov.Acao.ICodigo + "," + histMov.DtNegociada + "," + histMov.Acao.INegociacoes + "," + histMov.FValorNegociado + ")";
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
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

        internal static int obterUltimaNegociacaoInvestidor(int p)
        {
            string sql = @"select max(idMovimentacaoInvestidor) from MovimentacaoInvestidor where Investidor_idInvestidor = " + p;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                return int.Parse(msCommand.ExecuteScalar().ToString());
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
