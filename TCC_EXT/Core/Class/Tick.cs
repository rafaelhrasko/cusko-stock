using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Class
{
    [Serializable()]
    public class HistMovimentacao
    {
        #region Atributos
        private int iCodigo;
        private DateTime dtNegociada;
        private Empresa empresa;
        private Acao acao;
        private float fPercentual;
        private float fValorNegociado;
        private int iQuantidadeNegociada;
        #endregion

        #region Propriedades
        public int ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public DateTime DtNegociada
        {
            get { return dtNegociada; }
            set { dtNegociada = value; }
        }
        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public Acao Acao
        {
            get { return acao; }
            set { acao = value; }
        }
        public float FPercentual
        {
            get { return fPercentual; }
            set { fPercentual = value; }
        }
        public float FValorNegociado
        {
            get { return fValorNegociado; }
            set { fValorNegociado = value; }
        }
        public int IQuantidadeNegociada
        {
            get { return iQuantidadeNegociada; }
            set { iQuantidadeNegociada = value; }
        }
        #endregion

        public HistMovimentacao()
        {
            this.Empresa = new Empresa();
            this.Acao = new Acao();
        }
    }
}