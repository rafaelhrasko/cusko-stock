using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace WebAppTeste
{
    public abstract class Agente
    {
        static int nAgentesCriados = 0;
        protected EnviaRequestCallback envia;
        protected const string connstring = "Server=cusko.db.8505846.hostedresource.com;Database=cusko;Uid=cusko;Pwd=Teste1234;";
        protected Thread workerThread;
        protected int threadSleepTime = 10000;

        protected string NomeAgente { get; private set; }

        public Agente(string nome)
        {
            NomeAgente = String.Format("{0}(id {1})",nome,nAgentesCriados++);
            envia = new EnviaRequestCallback();
            workerThread = new Thread(this.DoWork);
        }

        public void Start()
        {
            workerThread.Start();
            Log("iniciado");
        }

        private void DoWork()
        {
            while (true)
            {
                Log("começando a trabalhar");
                Work();
                Log(String.Format("dormir... Volto em {0}",threadSleepTime));
                Thread.Sleep(threadSleepTime);
            }
        }

        protected void Log(string message)
        {
            System.Diagnostics.Debug.WriteLine(NomeAgente + ": " +  message);
        }

        public virtual void StopThread()
        {
            this.workerThread.Abort();
        }

        protected abstract void Work();

    }
}