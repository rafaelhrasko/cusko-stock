using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Class
{
    [Serializable()]
    public class Carteira
    {
        private int iCodigo;
        private string strNome;
        private Investidor usuario;
        private List<Acao> lstAcoes;

        public int ICodigo
        {
            get { return iCodigo; }
            set { iCodigo = value; }
        }
        public string StrNome
        {
            get { return strNome; }
            set { strNome = value; }
        }
        public Investidor Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public List<Acao> LstAcoes
        {
            get { return lstAcoes; }
            set { lstAcoes = value; }
        }

        public int IQuantidadeAcoesNaCarteira
        {
            get { return lstAcoes.Count; }
        }

        public Carteira()
        {
            usuario = new Investidor();
            lstAcoes = new List<Acao>();
        }
    }
}