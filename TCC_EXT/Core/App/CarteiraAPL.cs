using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using Core.DAO;

namespace Core.App
{
    public class CarteiraAPL
    {

        public static int inserirCarteira(Carteira cart)
        {
            return CarteiraDAO.inserirCarteira(cart);
        }

        public static void excluirCarteira(Carteira cart)
        {
            CarteiraDAO.excluirAcoesRelacionadas(cart);
            CarteiraDAO.excluirCarteira(cart);

        }

        public static void excluirAcaoCarteira(Acao newstock, Carteira cart)
        {
            CarteiraDAO.excluirAcoesRelacionadas(cart);
        }
    }
}
