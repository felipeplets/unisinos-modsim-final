using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Comum.Framework
{
    public class Email
    {
        #region Atributos e Construtores

        private string stHost;
        private int iPorta;
        private string stUsuario;
        private string stSenha;
        private string stRemetente;
        private string stAssunto;
        private string stMensagem;
        private List<string> loDestinatario;

        public Email(string pstHost, int piPorta, string pstUsuario, string pstSenha, string pstRementente, string pstAssunto, string pstMensagem,
            List<string> ploDestinatario)
        {
            this.stHost = pstHost;
            this.iPorta = piPorta;
            this.stUsuario = pstUsuario;
            this.stSenha = pstSenha;
            this.stRemetente = pstRementente;
            this.stAssunto = pstAssunto;
            this.stMensagem = pstMensagem;
            this.loDestinatario = ploDestinatario;
        }

        #endregion

        #region Métodos

        public void Enviar()
        {
            SmtpClient oSmtpClient = new SmtpClient(this.stHost, this.iPorta);
            oSmtpClient.Credentials = new NetworkCredential(this.stUsuario, this.stSenha);

            MailMessage oMailMessage = new MailMessage();

            oMailMessage.Body = this.stMensagem;
            oMailMessage.Subject = this.stAssunto;
            oMailMessage.From = new MailAddress(this.stRemetente);

            foreach (string stDestinatario in this.loDestinatario)
                oMailMessage.To.Add(stDestinatario);

            oSmtpClient.Send(oMailMessage);
        }

        #endregion

        #region Propriedades

        public string Host
        {
            get { return this.stHost; }
            set { this.stHost = value; }
        }

        public int Porta
        {
            get { return this.iPorta; }
            set { this.iPorta = value; }
        }

        public string Usuario
        {
            get { return this.stUsuario; }
            set { this.stUsuario = value; }
        }

        public string Remetente
        {
            get { return this.stRemetente; }
            set { this.stRemetente = value; }
        }

        public string Assunto
        {
            get { return this.stAssunto; }
            set { this.stAssunto = value; }
        }

        public string Mensagem
        {
            get { return this.stMensagem; }
            set { this.stMensagem = value; }
        }

        public List<string> Destinatario
        {
            get { return this.loDestinatario; }
            set { this.loDestinatario = value; }
        }

        #endregion
    }
}
