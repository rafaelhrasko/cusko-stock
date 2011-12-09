using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Class;
using Ext.Net;
using Core.App;

namespace TCC_EXT
{
    public partial class SettingsNegociacaoPnl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        private int NewId
        {
            get
            {
                Investidor usu = Session["usuario"] as Investidor;
                return HistMovimentacaoAPL.obterUltimaNegociacaoInvestidor(usu.ICodigo) + 1;
            }
        }

        private List<HistMovimentacao> CurrentData
        {
            get
            {
                List<HistMovimentacao> persons = this.Session["TestPersons"] as List<HistMovimentacao>;

                if (persons == null)
                {
                    persons = new List<HistMovimentacao>();
                    this.Session["TestPersons"] = persons;
                }

                return (List<HistMovimentacao>)persons;
            }
        }

        private int AddPerson(HistMovimentacao person)
        {
            var persons = this.CurrentData;
            person.ICodigo = this.NewId;
            persons.Add(person);
            this.Session["TestPersons"] = persons;

            return person.ICodigo;
        }

        private void DeletePerson(int id)
        {
            var persons = this.CurrentData;
            HistMovimentacao person = null;

            foreach (HistMovimentacao p in persons)
            {
                if (p.ICodigo == id)
                {
                    person = p;
                    break;
                }
            }

            if (person == null)
            {
                throw new Exception("Movimentação não encontrada!");
            }

            persons.Remove(person);

            this.Session["TestPersons"] = persons;
        }

        private void UpdatePerson(HistMovimentacao person)
        {
            var persons = this.CurrentData;
            HistMovimentacao updatingPerson = null;

            foreach (HistMovimentacao p in persons)
            {
                if (p.ICodigo == person.ICodigo)
                {
                    updatingPerson = p;
                    break;
                }
            }

            if (updatingPerson == null)
            {
                throw new Exception("Negociação não encontrada");
            }

            updatingPerson = person;

            this.Session["TestPersons"] = persons;
        }

        private void BindData()
        {
            if (X.IsAjaxRequest)
            {
                return;
            }

            this.Store2.DataSource = this.CurrentData;
            this.Store2.DataBind();
        }

        protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
        {
            ChangeRecords<HistMovimentacao> persons = e.DataHandler.ObjectData<HistMovimentacao>();

            foreach (HistMovimentacao created in persons.Created)
            {
                int tempId = created.ICodigo;
                int newId = this.AddPerson(created);

                if (Store2.UseIdConfirmation)
                {
                    e.ConfirmationList.ConfirmRecord(tempId.ToString(), newId.ToString());
                }
                else
                {
                    Store2.UpdateRecordId(tempId, newId);
                }

            }

            foreach (HistMovimentacao deleted in persons.Deleted)
            {
                this.DeletePerson(deleted.ICodigo);

                if (Store2.UseIdConfirmation)
                {
                    e.ConfirmationList.ConfirmRecord(deleted.ICodigo.ToString());
                }
            }

            foreach (HistMovimentacao updated in persons.Updated)
            {
                this.UpdatePerson(updated);

                if (Store2.UseIdConfirmation)
                {
                    e.ConfirmationList.ConfirmRecord(updated.ICodigo.ToString());
                }
            }
            e.Cancel = true;
        }
    }
}