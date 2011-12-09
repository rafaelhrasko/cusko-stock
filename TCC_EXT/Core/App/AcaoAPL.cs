using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using Core.DAO;

namespace Core.App
{
    public class AcaoAPL
    {
        public static List<Acao> listarAcoes()
        {
            return AcaoDAO.listarAcoes();
        }

        public static Acao obterAcaoPorSimbolo(string text)
        {
            return AcaoDAO.obterAcaoPorSimbolo(text);
        }

        public static void inserirAcaoCarteira(Carteira cart, Acao stock)
        {
            AcaoDAO.inserirAcaoCarteira(cart, stock);
        }
    }
}
