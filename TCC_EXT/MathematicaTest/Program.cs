using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using Core.App;

namespace MathematicaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Double> lstDoubles = new List<double>() { 0, 1, 2 };

            //Core.App.Mathematica math = new Core.App.Mathematica();

            //Console.WriteLine(math.MediaMovelExponencial(3, lstDoubles).ToString());
            //string asd = Console.ReadLine();
            //Acao stock = testeObterAcaoViaSymbol(asd);
            //testeInserirAcaoNaCarteira(stock);
            Console.WriteLine("lol");
            Console.WriteLine(testeSugestaoAcao());
            Console.ReadKey();
        }

        public static void testeInserirAcaoNaCarteira(Acao stock)
        {
            //Carteira cart = new Carteira();
            //cart.ICodigo = 0;
            //cart.StrNome = "Carteira_lol";
            //cart.Usuario.ICodigo = 0;



            //AcaoAPL.inserirAcaoCarteira(cart, stock);

        }

        public static Acao testeObterAcaoViaSymbol(string StockSymbol)
        {
            //return AcaoAPL.obterAcaoPorSimbolo(StockSymbol);

        }

        public static double testeSugestaoAcao()
        {
            Mathematica mathe = new Mathematica();
            List<HistMovimentacao> lstHistMov = HistMovimentacaoAPL.obterHistoricoCompletoPorSimboloDiaAnterior("GOOG");
            double dSugestao = mathe.SugestaoVenda(lstHistMov, 100);
            return dSugestao;
        }
    }
}
