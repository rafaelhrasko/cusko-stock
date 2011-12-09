using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Class;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;

namespace Core.App
{
    public class Mathematica
    {

        public double MediaMovelSimples(List<HistMovimentacao> LstHistMov)
        {
            double MediaMovelSimples = 0;

            foreach (HistMovimentacao item in LstHistMov)
            {
                MediaMovelSimples += item.FValorNegociado;
            }

            MediaMovelSimples /= LstHistMov.Count;

            return MediaMovelSimples;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iDias">Número N de dias para o qual se quer o calculo</param>
        /// <param name="LstHistMov">Lista de Movimentacoes para uma acao</param>
        /// <param name="day">O dia atual</param>
        /// <returns></returns>
        public double MediaMovelExponencial(int iDias, List<HistMovimentacao> LstHistMov, DateTime day)
        {
            double MediaExponencial = 0d;

            if (LstHistMov.FindAll(a => a.DtNegociada == day.AddDays(-1)).Count <= 0)
            {
                return MediaMovelSimples(LstHistMov);
            }
            else
            {
                MediaExponencial = MediaMovelExponencial(iDias - 1, LstHistMov.FindAll(a => a.DtNegociada < day).ToList(), day.AddDays(-1)) + (2 / (float.Parse(iDias.ToString()) + 1)) * (LstHistMov.FindLast(a => a.DtNegociada == day).FValorNegociado - MediaMovelExponencial(iDias - 1, LstHistMov.FindAll(a => a.DtNegociada < day).ToList(), day.AddDays(-1)));
            }
            return MediaExponencial;
        }

        public double MediaMovelSimples(List<Double> LstDoubles)
        {
            return LstDoubles.Average();
        }

        public double MediaMovelExponencial(int iPeriodo, List<double> lstDoubles)
        {
            double MediaExponencial = 0d;

            if (iPeriodo == 1)
            {
                return MediaMovelSimples(lstDoubles);
            }
            else
            {
                MediaExponencial = MediaMovelExponencial(iPeriodo - 1, lstDoubles.Take(iPeriodo - 1).ToList()) + (2 / (float.Parse(iPeriodo.ToString()) + 1)) * (lstDoubles.ElementAt(lstDoubles.Count - 2) - MediaMovelExponencial(iPeriodo - 1, lstDoubles.Take(iPeriodo - 1).ToList()));
            }
            return MediaExponencial;
        }

        public double DesvioPadrao(List<HistMovimentacao> LstHistMov)
        {
            double DesvioPadrao = 0d;
            double Media = MediaMovelSimples(LstHistMov);

            foreach (HistMovimentacao item in LstHistMov)
            {
                DesvioPadrao += Math.Pow(item.FValorNegociado - Media, 2);
            }

            DesvioPadrao /= (LstHistMov.Count - 1);
            DesvioPadrao = Math.Sqrt(DesvioPadrao);

            return DesvioPadrao;

        }

        public Series CurvaBollingerIntermediaria(List<HistMovimentacao> LstHistMov, int nPeriodo)
        {

            Series sreCurvaIntermediaria = new Series();
            sreCurvaIntermediaria.ChartType = SeriesChartType.Line;
            sreCurvaIntermediaria.Color = System.Drawing.Color.Black;
            sreCurvaIntermediaria.Name = "Curva Intermediária";

            List<DateTime> lstPeriodo = new List<DateTime>();
            Dictionary<DateTime, List<HistMovimentacao>> dicDatHist = new Dictionary<DateTime, List<HistMovimentacao>>();
            Double dMedia = 0d;
            DateTime dtInicial = LstHistMov.OrderBy(a => a.DtNegociada).First().DtNegociada;
            DateTime dtFinal = LstHistMov.OrderBy(a => a.DtNegociada).Last().DtNegociada;


            do
            {
                lstPeriodo.Add(dtInicial.AddDays(nPeriodo));
                if (dtInicial > dtFinal)
                    break;
                dtInicial = dtInicial.AddDays(nPeriodo);
            } while (true);


            foreach (DateTime item in lstPeriodo)
            {
                dicDatHist.Add(item, LstHistMov.FindAll(a => a.DtNegociada >= dtInicial && a.DtNegociada < item).ToList());

                dtInicial = item;
            }

            foreach (KeyValuePair<DateTime, List<HistMovimentacao>> item in dicDatHist)
            {
                dMedia = MediaMovelSimples(item.Value);
                DataPoint dtp = new DataPoint();
                //double[] vetD = { dMedia };
                //dtp.YValues = vetD;
                //sreCurvaIntermediaria.Points.Add(dtp);
                sreCurvaIntermediaria.Points.AddXY(item.Key, dMedia);

            }

            return sreCurvaIntermediaria;
        }

        public Series CurvaBollingerInferior(List<HistMovimentacao> LstHistMov, int nPeriodo, int kValor)
        {
            Series sreCurvaInferior = new Series();
            sreCurvaInferior.ChartType = SeriesChartType.Line;
            sreCurvaInferior.Color = System.Drawing.Color.Blue;
            sreCurvaInferior.Name = "Curva Inferior";

            List<DateTime> lstPeriodo = new List<DateTime>();
            Dictionary<DateTime, List<HistMovimentacao>> dicDatHist = new Dictionary<DateTime, List<HistMovimentacao>>();
            Double dMedia = 0d;
            DateTime dtInicial = LstHistMov.OrderBy(a => a.DtNegociada).First().DtNegociada;
            DateTime dtFinal = LstHistMov.OrderBy(a => a.DtNegociada).Last().DtNegociada;

            do
            {
                lstPeriodo.Add(dtInicial.AddDays(nPeriodo));
                if (dtInicial > dtFinal)
                    break;
                dtInicial = dtInicial.AddDays(nPeriodo);
            } while (true);


            foreach (DateTime item in lstPeriodo)
            {
                dicDatHist.Add(item, LstHistMov.FindAll(a => a.DtNegociada >= dtInicial && a.DtNegociada < item).ToList());

                dtInicial = item;
            }

            foreach (KeyValuePair<DateTime, List<HistMovimentacao>> item in dicDatHist)
            {
                dMedia = MediaMovelSimples(item.Value) - kValor * DesvioPadrao(item.Value);
                //DataPoint dtp = new DataPoint();
                //double[] vetD = { dMedia };
                //dtp.YValues = vetD;
                //sreCurvaInferior.Points.Add(dtp);
                sreCurvaInferior.Points.AddXY(item.Key, dMedia);

            }
            return sreCurvaInferior;

        }

        public Series CurvaBollingerSuperior(List<HistMovimentacao> LstHistMov, int nPeriodo, int kValor)
        {
            Series sreCurvaSuperior = new Series();
            sreCurvaSuperior.ChartType = SeriesChartType.Line;
            sreCurvaSuperior.Color = System.Drawing.Color.Red;
            sreCurvaSuperior.Name = "Curva Superior";

            List<DateTime> lstPeriodo = new List<DateTime>();
            Dictionary<DateTime, List<HistMovimentacao>> dicDatHist = new Dictionary<DateTime, List<HistMovimentacao>>();
            Double dMedia = 0d;
            DateTime dtInicial = LstHistMov.OrderBy(a => a.DtNegociada).First().DtNegociada;
            DateTime dtFinal = LstHistMov.OrderBy(a => a.DtNegociada).Last().DtNegociada;

            do
            {
                lstPeriodo.Add(dtInicial.AddDays(nPeriodo));
                if (dtInicial > dtFinal)
                    break;
                dtInicial = dtInicial.AddDays(nPeriodo);
            } while (true);


            foreach (DateTime item in lstPeriodo)
            {
                dicDatHist.Add(item, LstHistMov.FindAll(a => a.DtNegociada >= dtInicial && a.DtNegociada < item).ToList());

                dtInicial = item;
            }

            foreach (KeyValuePair<DateTime, List<HistMovimentacao>> item in dicDatHist)
            {
                dMedia = MediaMovelSimples(item.Value) + kValor * DesvioPadrao(item.Value);
                //DataPoint dtp = new DataPoint();
                //double[] vetD = { dMedia };
                //dtp.YValues = vetD;
                //sreCurvaSuperior.Points.Add(dtp);
                sreCurvaSuperior.Points.AddXY(item.Key, dMedia);

            }
            return sreCurvaSuperior;

        }

        public Series LinhaMACD(List<HistMovimentacao> lstHistMov)
        {

            Series sreLinhaMACD = new Series();
            List<DateTime> lstDias = new List<DateTime>();
            Double dMedia = 0d;
            double dMME12 = 0d;
            double dMME26 = 0d;

            sreLinhaMACD.ChartType = SeriesChartType.FastPoint;
            sreLinhaMACD.Color = System.Drawing.Color.Green;
            sreLinhaMACD.Name = "Linha MACD";

            foreach (HistMovimentacao item in lstHistMov)
            {
                lstDias.Add(item.DtNegociada);
            }

            foreach (DateTime item in lstDias)
            {
                dMME12 = MediaMovelExponencial(12, lstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-12)), item);
                dMME26 = MediaMovelExponencial(26, lstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-26)), item);

                dMedia = dMME12 - dMME26;
                DataPoint dtp = new DataPoint();
                double[] vetD = { dMedia };
                dtp.YValues = vetD;
                sreLinhaMACD.Points.Add(dtp);
            }

            return sreLinhaMACD;
        }

        public Series LinhaSinal(List<HistMovimentacao> LstHistMov)
        {

            Series sreLinhaMACD = new Series();
            List<DateTime> lstDias = new List<DateTime>();
            List<Double> dMedia = new List<double>();
            Double dMediaFinal = 0d;
            double dMME12 = 0d;
            double dMME26 = 0d;

            sreLinhaMACD.ChartType = SeriesChartType.FastLine;
            sreLinhaMACD.Color = System.Drawing.Color.Red;
            sreLinhaMACD.Name = "Linha de Sinal";

            foreach (HistMovimentacao item in LstHistMov)
            {
                lstDias.Add(item.DtNegociada);
            }

            foreach (DateTime item in lstDias)
            {
                dMME12 = MediaMovelExponencial(12, LstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-12)), item);
                dMME26 = MediaMovelExponencial(26, LstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-26)), item);
                dMedia.Add(dMME12 - dMME26);
            }

            //for (int i = 0; i < dMedia.Count; i = i + 9)
            //{

            //    dMediaFinal = MediaMovelExponencial(9, dMedia.GetRange(i, 9));
            //    DataPoint dtp = new DataPoint();
            //    double[] vetD = { dMediaFinal };
            //    dtp.YValues = vetD;
            //    sreLinhaMACD.Points.Add(dtp);
            //}

            if (dMedia.Count % 9 == 0)
                for (int i = 0; i < dMedia.Count; i = i + 9)
                {

                    dMediaFinal = MediaMovelExponencial(9, dMedia.GetRange(i, 9));
                    DataPoint dtp = new DataPoint();
                    double[] vetD = { dMediaFinal };
                    dtp.YValues = vetD;
                    sreLinhaMACD.Points.Add(dtp);
                }
            else
            {
                int iIteracoesDoFor = dMedia.Count / 9;
                int iResto = dMedia.Count % 9;

                for (int i = 0; i < iIteracoesDoFor; i = i + 9)
                {
                    dMediaFinal = MediaMovelExponencial(9, dMedia.GetRange(i, 9));
                    DataPoint dtp = new DataPoint();
                    double[] vetD = { dMediaFinal };
                    dtp.YValues = vetD;
                    sreLinhaMACD.Points.Add(dtp);
                }

                dMediaFinal = MediaMovelExponencial(iResto, dMedia.GetRange(iIteracoesDoFor, iResto));
                DataPoint dtp2 = new DataPoint();
                double[] vetD2 = { dMediaFinal };
                dtp2.YValues = vetD2;
                sreLinhaMACD.Points.Add(dtp2);

            }

            return sreLinhaMACD;

        }

        public Series Histograma(List<HistMovimentacao> LstHistMov)
        {
            Series sreHistograma = new Series();
            List<DateTime> lstDias = new List<DateTime>();
            List<Double> dMedia = new List<double>();
            Double dMediaFinal = 0d;
            double dMME12 = 0d;
            double dMME26 = 0d;

            sreHistograma.ChartType = SeriesChartType.Candlestick;
            sreHistograma.Color = System.Drawing.Color.Black;
            sreHistograma.Name = "Histograma";

            foreach (HistMovimentacao item in LstHistMov)
            {
                lstDias.Add(item.DtNegociada);
            }

            foreach (DateTime item in lstDias)
            {
                dMME12 = MediaMovelExponencial(12, LstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-12)), item);
                dMME26 = MediaMovelExponencial(26, LstHistMov.FindAll(a => a.DtNegociada >= item.AddDays(-26)), item);
                dMedia.Add(dMME12 - dMME26);
            }

            if (dMedia.Count % 9 == 0)
                for (int i = 0; i < dMedia.Count; i = i + 9)
                {

                    dMediaFinal = MediaMovelExponencial(9, dMedia.GetRange(i, 9));
                    DataPoint dtp = new DataPoint();
                    double[] vetD = { (dMedia.GetRange(i, 9).Average() - dMediaFinal) };
                    dtp.YValues = vetD;
                    sreHistograma.Points.Add(dtp);
                }
            else
            {
                int iIteracoesDoFor = dMedia.Count / 9;
                int iResto = dMedia.Count % 9;

                for (int i = 0; i < iIteracoesDoFor; i = i + 9)
                {
                    dMediaFinal = MediaMovelExponencial(9, dMedia.GetRange(i, 9));
                    DataPoint dtp = new DataPoint();
                    double[] vetD = { (dMedia.GetRange(i, 9).Average() - dMediaFinal) };
                    dtp.YValues = vetD;
                    sreHistograma.Points.Add(dtp);
                }

                dMediaFinal = MediaMovelExponencial(iResto, dMedia.GetRange(iIteracoesDoFor, iResto));
                DataPoint dtp2 = new DataPoint();
                double[] vetD2 = { (dMedia.GetRange(iIteracoesDoFor, iResto).Average() - dMediaFinal) };
                dtp2.YValues = vetD2;
                sreHistograma.Points.Add(dtp2);

            }

            return sreHistograma;
        }

        public Series VolumeWeightedAvaragePrice(List<HistMovimentacao> LstHistMov, string asd)
        {
            Series sreHistograma = new Series();
            List<DateTime> lstDias = new List<DateTime>();
            List<Double> dMedia = new List<double>();
            double dNumerador = 0d;
            double dDenominador = 0d;

            sreHistograma.ChartType = SeriesChartType.Line;
            sreHistograma.Color = System.Drawing.Color.Black;
            sreHistograma.Name = "VWAP de " + asd;
            sreHistograma.IsXValueIndexed = true;
            sreHistograma.XValueType = ChartValueType.Date;

            foreach (HistMovimentacao item in LstHistMov)
            {
                dNumerador += item.FValorNegociado * item.IQuantidadeNegociada;
                dDenominador += item.IQuantidadeNegociada;

                DataPoint dtp = new DataPoint();
                //double[] vetD = { (dNumerador / dDenominador) };
                double vetD = dNumerador / dDenominador;
                //dtp.YValues = vetD;
                //sreHistograma.Points.Add(dtp);
                sreHistograma.Points.AddXY(item.DtNegociada, vetD);
            }

            return sreHistograma;

        }

        public Series VolumeWeightedAvaragePriceForComparacao(List<HistMovimentacao> LstHistMov)
        {
            Series sreHistograma = new Series();
            List<DateTime> lstDias = new List<DateTime>();
            List<Double> dMedia = new List<double>();
            double dNumerador = 0d;
            double dDenominador = 0d;

            sreHistograma.ChartType = SeriesChartType.Line;
            sreHistograma.Color = System.Drawing.Color.Black;
            sreHistograma.Name = "VWAP";
            sreHistograma.IsXValueIndexed = true;

            foreach (HistMovimentacao item in LstHistMov)
            {
                dNumerador += item.FValorNegociado * item.IQuantidadeNegociada;
                dDenominador += item.IQuantidadeNegociada;

                DataPoint dtp = new DataPoint();
                double[] vetD = { (dNumerador / dDenominador) };
                dtp.YValues = vetD;
                sreHistograma.Points.Add(dtp);
            }

            return sreHistograma;

        }

        //Testar
        public double SugestaoVenda(List<HistMovimentacao> LstHistMov, int iQuantidade)
        {

            List<DateTime> lstDias = new List<DateTime>();
            Double dMedia = 0d;
            double dNumerador = 0d;
            double dDenominador = 0d;

            foreach (HistMovimentacao item in LstHistMov)
            {
                dNumerador += item.FValorNegociado * item.IQuantidadeNegociada;
                dDenominador += item.IQuantidadeNegociada;
            }

            dMedia = (dNumerador + iQuantidade) / (dDenominador + iQuantidade);

            return dMedia;
        }

        public Dictionary<Acao, double> compararAcoes(List<Acao> LstAcao)
        {
            List<DateTime> lstDias = new List<DateTime>();
            Dictionary<Acao, double> dicComparacao = new Dictionary<Acao, double>();
            Double dMedia = 0d;
            double dMME12 = 0d;
            double dMME26 = 0d;

            foreach (Acao item in LstAcao)
            {
                List<HistMovimentacao> lstHistMov = HistMovimentacaoAPL.obterHistoricoCompletoPorSimbolo(item.StrSimbolo);

                foreach (HistMovimentacao mov in lstHistMov)
                {
                    lstDias.Add(mov.DtNegociada);
                }

                foreach (DateTime dia in lstDias)
                {
                    dMME12 = MediaMovelExponencial(12, lstHistMov.FindAll(a => a.DtNegociada >= dia.AddDays(-12)), dia);
                    dMME26 = MediaMovelExponencial(26, lstHistMov.FindAll(a => a.DtNegociada >= dia.AddDays(-26)), dia);

                    dMedia = dMME12 - dMME26;
                }

                dicComparacao.Add(item, dMedia);
            }

            return dicComparacao;
        }
    }
}
