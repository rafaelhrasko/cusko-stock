using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Class
{
    [Serializable()]
    public class Acao
    {

        private int iCodigo;
        private Empresa empresa;
        private List<HistMovimentacao> lstTicks;
        private string strSimbolo;
        private string strBolsa;
        private double dDividendos;
        private float fPercentual;
        private int iNegociacoes;

        public int ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public string StrSimbolo
        {
            get { return strSimbolo; }
            set { strSimbolo = value; }
        }
        public string StrBolsa
        {
            get { return strBolsa; }
            set { strBolsa = value; }
        }
        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public List<HistMovimentacao> LstTicks
        {
            get { return lstTicks; }
            set { lstTicks = value; }
        }
        public double DDividendos
        {
            get { return dDividendos; }
            set { dDividendos = value; }
        }
        public float FPercentual
        {
            get { return fPercentual; }
            set { fPercentual = value; }
        }
        public int INegociacoes
        {
            get { return iNegociacoes; }
            set { iNegociacoes = value; }
        }

        public Acao()
        {
            lstTicks = new List<HistMovimentacao>();
            empresa = new Empresa();
        }

    }
}