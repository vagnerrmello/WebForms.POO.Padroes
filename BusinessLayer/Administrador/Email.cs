using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steto.ValueObjectLayer;
using System.Security.Cryptography;
using System.Net.Mail;

namespace Steto.BusinessLayer.Administrador
{
    public class Email
    {
        public static IList<Email_TipoEmail> RecuperaTipoEmail()
        {
            AcessoDadosDataContext acessoDados = new AcessoDadosDataContext();

            try
            {
                var tipoEmail = from e in acessoDados.TB_Emails
                                join et in acessoDados.TB_Email_Tipos
                                on e.IdTipoEmail equals et.Id
                                select new
                                {
                                    idEmail = e.Id,
                                    tipo = et.TipoEmail
                                };

                IList<Email_TipoEmail> Emails = new List<Email_TipoEmail>();
                foreach (var email in tipoEmail)
                {
                    Emails.Add(new Email_TipoEmail(email.idEmail, email.tipo));
                }

                return Emails;
                                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TB_Email RecuperarConfiguracaoEmail(int idEmail)
        {
            AcessoDadosDataContext acessoDados = new AcessoDadosDataContext();

            try
            {
                var email = (from e in acessoDados.TB_Emails
                             where e.Id == idEmail
                             select e).Single();

                //email.SenhaEmailEmpresa = retornaDecrypto(email.SenhaEmailEmpresa);

                return email;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SalvaConfiguracaoEmail(TB_Email email)
        {
            AcessoDadosDataContext acessoDados = new AcessoDadosDataContext();
            try
            {
                var isEmail = acessoDados.TB_Emails.Single(u => u.Id == email.Id);

                isEmail.EnviarEmail = email.EnviarEmail;
                isEmail.EnviarEmailAdm = email.EnviarEmailAdm;
                isEmail.EmailAdm = email.EmailAdm;
                isEmail.EnviarEmailGestor = email.EnviarEmailGestor;
                isEmail.EmailGestor = email.EmailGestor;
                isEmail.UsarPorta = email.UsarPorta;
                isEmail.Porta = email.Porta;
                isEmail.Smtp = email.Smtp;
                isEmail.Assunto = email.Assunto;
                isEmail.CorpoEmail = email.CorpoEmail;
                isEmail.Email_Empresa = email.Email_Empresa;
                isEmail.UsuarioEmailEmpresa = email.UsuarioEmailEmpresa;
                isEmail.SenhaEmailEmpresa = email.SenhaEmailEmpresa;

                acessoDados.SubmitChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string retornaCrypto(string str)
        {
            RSACryptoServiceProvider myrsa = new RSACryptoServiceProvider();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();//Encode String to Convert to Bytes
            Byte[] dado = encoding.GetBytes(str);//convert to Bytes
            Byte[] crypto = myrsa.Encrypt(dado, false);
            string strCrypto = "";
            for (int i = 0; i < crypto.Length; i++)
            {
                strCrypto += crypto[i];
            }
            return strCrypto;
        }

        public static string retornaDecrypto(string str)
        {
            RSACryptoServiceProvider myrsa = new RSACryptoServiceProvider();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();//Encode String to Convert to Bytes
            Byte[] dado = encoding.GetBytes(str);//convert to Bytes
            Byte[] decrypto = myrsa.Decrypt(dado, false);//decrypt 
            string dData = encoding.GetString(decrypto); //encode bytes back to string 
            string strDecrypto = "";
            for (int i = 0; i < decrypto.Length; i++)
            {
                strDecrypto = dData[i].ToString();
            }
            return strDecrypto;
        }

        /// <summary>
        /// Método que envia email do sistema
        /// </summary>
        /// <param name="email">Email requerido para envio</param>
        /// <param name="corpoEmail">Mensagem que o email irá enviar</param>
        /// <returns>Retorna true se ok</returns>
        public static bool EnviarEmail(string email, string corpoEmail)
        {
            try
            {
                TB_Email isEmail = RecuperarConfiguracaoEmail(1);
                IList<string> comCopia = new List<string>();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(isEmail.Smtp);

                mail.From = new MailAddress(isEmail.Email_Empresa);
                
                mail.To.Add(email);
                if ((bool)isEmail.EnviarEmailAdm)
                    mail.CC.Add(isEmail.EmailAdm);

                if ((bool)isEmail.EnviarEmailGestor)
                    mail.CC.Add(isEmail.EmailGestor);

                mail.Subject = isEmail.Assunto;
                mail.Body = @isEmail.CorpoEmail + corpoEmail;
                if ((bool)isEmail.UsarPorta)
                    SmtpServer.Port = (int)isEmail.Porta;

                SmtpServer.Credentials = new System.Net.NetworkCredential(isEmail.UsuarioEmailEmpresa, isEmail.SenhaEmailEmpresa);
                if ((bool)isEmail.Ssl)
                    SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
