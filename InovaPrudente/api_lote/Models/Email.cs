using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace apiInovaPP.Models
{
    public class Email
    {

        public string ServidorSmtp { get; set; }
        public int Porta { get; set; }
        public string EmailRemetente { get; set; }
        public string SenhaEmail { get; set; }
        public bool Autenticar { get; set; }
        public bool Erro { get; set; }
        public string Mensagem { get; set; }
        public string CorpoEmail { get; set; }
        public string Assunto { get; set; }


        public Email()
        {
            
            this.ServidorSmtp = string.Empty;
            this.Porta = 0;
            this.EmailRemetente = string.Empty;
            this.SenhaEmail = string.Empty;
            this.Autenticar = false;            
            this.CorpoEmail = string.Empty;
            this.Assunto = string.Empty;
        }


     
        public bool EnviarEmail()
        {
            using (MailMessage mail = new MailMessage())
            {
                 
                    mail.From = new MailAddress(EmailRemetente);

                    

                    mail.Subject = Assunto;
                    mail.Body = CorpoEmail;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (SmtpClient smtp = new SmtpClient(ServidorSmtp, Porta))
                        {
                            smtp.Credentials = new NetworkCredential(EmailRemetente, SenhaEmail);
                            smtp.EnableSsl = Autenticar;
                            smtp.Send(mail);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Erro = true;
                        Mensagem = ex.Message;
                        return false;
                    }
                 

            }

            return false;

        }


    }
}