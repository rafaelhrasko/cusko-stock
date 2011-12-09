using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using MySql.Data.MySqlClient;

namespace Core.DAO
{
    class CarteiraDAO
    {

        internal static int inserirCarteira(Carteira cart)
        {
            string sql = "insert into cusko.Carteira ( Investidor_idInvestidor, nome)  values ( " + cart.Usuario.ICodigo + ", '" + cart.StrNome + "')";
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                msCommand.ExecuteNonQuery();
                sql = "select idCarteira from cusko.Carteira where Investidor_idInvestidor = " + cart.Usuario.ICodigo + " and nome = '" + cart.StrNome + "'";
                msCommand = new MySqlCommand(sql, msc);
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

        internal static List<Carteira> listarCarteirasUsuario(Investidor investidor)
        {
            string sql = "select * from Carteira where Investidor_idInvestidor = " + investidor.ICodigo;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<Carteira> LstCarteira = new List<Carteira>();

            try
            {
                msc.Open();

                MySqlDataReader mdr = msCommand.ExecuteReader();

                if (mdr.HasRows)
                {
                    Carteira cart = new Carteira();
                    while (mdr.Read())
                    {
                        cart = new Carteira();

                        cart.ICodigo = int.Parse(mdr["idCarteira"].ToString());
                        cart.StrNome = mdr["nome"].ToString();
                        cart.Usuario = investidor;
                        cart.LstAcoes = AcaoDAO.listarAcoesCarteira(cart);

                        LstCarteira.Add(cart);
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

            return LstCarteira;
        }

        internal static void excluirAcoesRelacionadas(Carteira cart)
        {
            string sql = "delete from Carteira_has_Acao where Carteira_idCarteira =" + cart.ICodigo;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<Carteira> LstCarteira = new List<Carteira>();

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

        internal static void excluirCarteira(Carteira cart)
        {
            string sql = "delete from Carteira where idCarteira =" + cart.ICodigo;
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            MySqlCommand msCommand = new MySqlCommand(sql, msc);
            List<Carteira> LstCarteira = new List<Carteira>();

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
