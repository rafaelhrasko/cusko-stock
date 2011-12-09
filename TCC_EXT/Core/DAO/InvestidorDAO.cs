using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using MySql.Data.MySqlClient;

namespace Core.DAO
{
    internal class InvestidorDAO
    {
        internal static Investidor logarUsuario(Investidor investidor)
        {
            Investidor usu = new Investidor();
            MySqlConnection msc = new MySqlConnection("Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;");
            string sql = "select * from Investidor iv where iv.login = '" + investidor.StrLogin + "' and iv.senha = '" + investidor.StrKeyPass + "'";
            MySqlCommand msCommand = new MySqlCommand(sql, msc);

            try
            {
                msc.Open();
                MySqlDataReader mdr = msCommand.ExecuteReader();

                if (mdr.HasRows)
                    while (mdr.Read())
                    {
                        usu.ICodigo = int.Parse(mdr["idInvestidor"].ToString());
                        usu.StrNome = mdr["nome"].ToString();
                        usu.StrLogin = mdr["login"].ToString();
                        usu.StrKeyPass = mdr["senha"].ToString();
                        usu.LstCarteiras = CarteiraDAO.listarCarteirasUsuario(usu);
                    }
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

            return usu;
        }

        internal static void asdasdasd()
        {

        }
    }

}
