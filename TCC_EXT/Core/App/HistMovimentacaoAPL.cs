using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DAO;
using Core.Class;

namespace Core.App
{
    public class HistMovimentacaoAPL
    {
        public static List<Class.HistMovimentacao> ultimasNegociacoes()
        {
            return HistMovimentacaoDAO.ultimasNegociacoes();
        }


        public static HistMovimentacao listarUltimaNegociacaoAcao(Class.Acao item)
        {
            return HistMovimentacaoDAO.listarUltimaNegociacaoAcao(item);
        }

        public static HistMovimentacao obterHistoricoPorSimbolo(string SYMBOL)
        {
            return HistMovimentacaoDAO.obterHistoricoPorSimbolo(SYMBOL);
        }

        public static List<HistMovimentacao> obterHistoricoCompletoPorSimbolo(string SYMBOL)
        {
            return HistMovimentacaoDAO.obterHistoricoCompletoPorSimbolo(SYMBOL);
        }

        public static List<HistMovimentacao> obterHistoricoCompletoPorSimboloDiaAnterior(string p)
        {
            return HistMovimentacaoDAO.obterHistoricoCompletoPorSimboloDiaAnterior(p);
        }

        public static List<HistMovimentacao> listarUltimaNegociacaoAcao(List<Acao> lstAcoes)
        {
            return HistMovimentacaoDAO.listarUltimaNegociacaoAcao(lstAcoes); ;
        }

        public static int obterUltimaNegociacaoInvestidor(int p)
        {
            return HistMovimentacaoDAO.obterUltimaNegociacaoInvestidor(p);
        }
    }
}
