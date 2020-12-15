//-----------------------------------------------------------------------
// <copyright file="RepositorioEmailSqlServer.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Steto.ValueObjectLayer;
    using System.Security.Cryptography;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using System.Net;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de Email
    /// </summary>
    public class RepositorioEmailSqlServer : IRepositorioEmailSqlServer
    {
        /// <summary>
        /// Método que recupera todos os tipos de email
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tio ValueObjectLayer.Email</returns>
        public IList<ValueObjectLayer.Email_Tipo> RecuperaTipoEmail(ValueObjectLayer.TipoEmail tipoEmail)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Email> Emails = new List<ValueObjectLayer.Email>();

            IList<ValueObjectLayer.Email_Tipo> EmailsTipo = new List<ValueObjectLayer.Email_Tipo>();
            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select e.Id As idEmail , et.TipoEmail " +
                                    "From TB_Email e, TB_Email_Tipo et " +
                                    "Where e.IdTipoEmail = et.Id " +
                                    "And et.Id = @varidEmail";

                cmd.Parameters.AddWithValue("@varidEmail", Convert.ToInt32(tipoEmail));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmailsTipo.Add(
                            new ValueObjectLayer.Email_Tipo(Convert.ToInt32(reader["idEmail"]), Convert.ToString(reader["TipoEmail"]))
                            );
                    //    Emails.Add(new ValueObjectLayer.Email(
                    //        Convert.ToInt32(reader["idEmail"]),
                    //        new ValueObjectLayer.Email_Tipo(Convert.ToInt32(reader["idEmail"]), Convert.ToString(reader["TipoEmail"]))
                    //        ));
                    }
                }

                return (EmailsTipo.Count > 0) ? EmailsTipo : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Método responsável por recuperar as configurações de um email
        /// </summary>
        /// <param name="idEmail">Identificador da configuração do email</param>
        /// <returns>Retorna um objeto Email</returns>
        public ValueObjectLayer.Email RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail tipoEmail)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Email email = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Email e " +
                                    "Where e.Id = @varidEmail";

                cmd.Parameters.AddWithValue("@varidEmail", Convert.ToInt32(tipoEmail));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        email = new ValueObjectLayer.Email();

                        email.Id = Convert.ToInt32(reader["Id"]);
                        email._Email_Tipo = new ValueObjectLayer.Email_Tipo(Convert.ToInt32(reader["IdTipoEmail"]));
                        email._Funcionalidade = new ValueObjectLayer.Funcionalidade(Convert.ToInt32(reader["IdFuncionalidade"]));
                        email.Smtp = Convert.ToString(reader["Smtp"]);
                        email.Email_Empresa = Convert.ToString(reader["Email_Empresa"]);
                        email.Assunto = Convert.ToString(reader["Assunto"]);
                        email.CorpoEmail = Convert.ToString(reader["CorpoEmail"]);
                        email.UsarPorta = Convert.ToBoolean(reader["UsarPorta"]);
                        email.Porta = Convert.ToInt32(reader["Porta"]);
                        email.EnviarEmailAdm = Convert.ToBoolean(reader["EnviarEmailAdm"]);
                        email.EmailAdm = Convert.ToString(reader["EmailAdm"]);
                        email.EnviarEmailGestor = Convert.ToBoolean(reader["EnviarEmailGestor"]);
                        email.EmailGestor = Convert.ToString(reader["EmailGestor"]);
                        email.UsuarioEmailEmpresa = Convert.ToString(reader["UsuarioEmailEmpresa"]);
                        email.UsuarioEmailEmpresa = Convert.ToString(reader["UsuarioEmailEmpresa"]);
                        email.SenhaEmailEmpresa = Convert.ToString(reader["SenhaEmailEmpresa"]);
                        email.EnviarEmail = Convert.ToBoolean(reader["EnviarEmail"]);
                        email.Ssl = Convert.ToBoolean(reader["Ssl"]);
                    }
                }

                return (email != null) ? email : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Método responsável por salvar as configurações de email
        /// </summary>
        /// <param name="email">Objeto do tipo ValueObjectLayer.Email</param>
        /// <returns>Retorna um bool se ok</returns>
        public bool SalvaConfiguracaoEmail(ValueObjectLayer.Email email)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                string sQuery = "UPDATE TB_Email Set " +
                                    "IdTipoEmail = @varEmailTipoId " +
                                    ", IdFuncionalidade = @varIdFuncionalidade " +
                                    ", Smtp = @varSmtp " +
                                    ", Email_Empresa = @varEmail_Empresa " +
                                    ", Assunto = @varAssunto " +
                                    ", CorpoEmail = @varCorpoEmail " +
                                    ", UsarPorta = @varUsarPorta " +
                                    ", Porta = @varPorta " +
                                    ", EnviarEmailAdm = @varEnviarEmailAdm " +
                                    ", EnviarEmailGestor = @varEnviarEmailGestor " +
                                    ", UsuarioEmailEmpresa = @varUsuarioEmailEmpresa " +
                                    ", EnviarEmail = @varEnviarEmail " +
                                    ", Ssl = @varSsl ";
                if (!string.IsNullOrEmpty(email.SenhaEmailEmpresa))
                {
                    sQuery += ", SenhaEmailEmpresa = @varSenhaEmailEmpresa ";
                }

                sQuery += "Where Id = @emailId ";


                cmd.CommandText = sQuery;

                cmd.Parameters.AddWithValue("@varEmailTipoId", email._Email_Tipo.Id);
                cmd.Parameters.AddWithValue("@varIdFuncionalidade", email._Funcionalidade.Id);
                cmd.Parameters.AddWithValue("@varSmtp", email.Smtp);
                cmd.Parameters.AddWithValue("@varEmail_Empresa", email.Email_Empresa);
                cmd.Parameters.AddWithValue("@varAssunto", email.Assunto);
                cmd.Parameters.AddWithValue("@varCorpoEmail", email.CorpoEmail);
                cmd.Parameters.AddWithValue("@varUsarPorta", email.UsarPorta);
                cmd.Parameters.AddWithValue("@varPorta", email.Porta);
                cmd.Parameters.AddWithValue("@varEnviarEmailAdm", email.EnviarEmailAdm);
                cmd.Parameters.AddWithValue("@varEnviarEmailGestor", email.EnviarEmailGestor);
                cmd.Parameters.AddWithValue("@varUsuarioEmailEmpresa", email.UsuarioEmailEmpresa);
                if (!string.IsNullOrEmpty(email.SenhaEmailEmpresa))
                    cmd.Parameters.AddWithValue("@varSenhaEmailEmpresa", email.SenhaEmailEmpresa);
                cmd.Parameters.AddWithValue("@varEnviarEmail", email.EnviarEmail);
                cmd.Parameters.AddWithValue("@varSsl", email.Ssl);
                cmd.Parameters.AddWithValue("@emailId", email.Id);

                return (cmd.ExecuteNonQuery() > 0) ? true : false; 

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Método que envia email do sistema
        /// </summary>
        /// <param name="email">Email requerido para envio</param>
        /// <param name="corpoEmail">Mensagem que o email irá enviar</param>
        /// <returns>Retorna true se ok</returns>
        public bool EnviarEmail(ValueObjectLayer.Usuario usuario, string msgUsuario)
        {
            try
            {
                ValueObjectLayer.Email isEmail = RecuperarConfiguracaoEmail(TipoEmail.Empresa);
                IList<string> comCopia = new List<string>();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(isEmail.Smtp);

                mail.From = new MailAddress(isEmail.Email_Empresa);

                mail.To.Add(usuario.Email);
                mail.IsBodyHtml = true;
                mail.Subject = isEmail.Assunto;

                StringBuilder sbcorpoEmail = new StringBuilder();
                //string[] msg = isEmail.CorpoEmail.ToString().Split(new char[] { '|' });
                //sbcorpoEmail.Append(msg[0] + "\n\r");
                //sbcorpoEmail.Append(msg[1] + "\n\r");
                
                sbcorpoEmail.Append(isEmail.CorpoEmail + "\n\r");
                string[] msg = msgUsuario.ToString().Split(new char[] { '|' });
                foreach (var item in msg)
                {
                    sbcorpoEmail.Append(item + "\n\r");
                }
                
                string msgCompleta = sbcorpoEmail.ToString();

                mail.Body = sbcorpoEmail.ToString();
                mail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                if ((bool)isEmail.UsarPorta)
                    SmtpServer.Port = (int)isEmail.Porta;

                SmtpServer.Credentials = new System.Net.NetworkCredential(isEmail.Email_Empresa, isEmail.SenhaEmailEmpresa);
                if ((bool)isEmail.Ssl)
                    SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                if (isEmail.EnviarEmailAdm || isEmail.EnviarEmailGestor)
                {
                    IList<ValueObjectLayer.Usuario> usuarios = RepositorioUsuarioSqlServer.RecuperarUsuariosPorPerfil(ValueObjectLayer.TipoPerfil.Administrador);
                    if (usuarios != null)
                    {
                        if (usuarios.Count > 0)
                        {
                            EnviarEmailAdmnistracao(usuarios, isEmail, usuario);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que envia email do sistema
        /// </summary>
        /// <param name="email">Email requerido para envio</param>
        /// <param name="corpoEmail">Mensagem que o email irá enviar</param>
        /// <returns>Retorna true se ok</returns>
        public bool EnviarEmailAdmnistracao(IList<ValueObjectLayer.Usuario> usuariosAdm, ValueObjectLayer.Email isEmail, ValueObjectLayer.Usuario usuarioFuncionario)
        {
            try
            {
                IList<string> comCopia = new List<string>();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(isEmail.Smtp);
                string emailAdm = string.Empty;
                string emailGestor = string.Empty;

                mail.From = new MailAddress(isEmail.Email_Empresa);

                if (isEmail.EnviarEmailAdm)
                {
                    foreach (ValueObjectLayer.Usuario usuarioAdm in usuariosAdm)
                    {
                        mail.To.Add(usuarioAdm.Email);
                    }

                    if (isEmail.EnviarEmailGestor)
                    {
                        IList<ValueObjectLayer.Usuario> usuariosGestor = RepositorioUsuarioSqlServer.RecuperarUsuariosPorPerfil(ValueObjectLayer.TipoPerfil.Gestor);
                        if (usuariosGestor != null)
                        {
                            if (usuariosGestor.Count > 0)
                            {
                                foreach (ValueObjectLayer.Usuario usuarioGestor in usuariosAdm)
                                {
                                    mail.CC.Add(usuarioGestor.Email);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (isEmail.EnviarEmailGestor)
                    {
                        IList<ValueObjectLayer.Usuario> usuariosGestor = RepositorioUsuarioSqlServer.RecuperarUsuariosPorPerfil(ValueObjectLayer.TipoPerfil.Gestor);
                        if (usuariosGestor != null)
                        {
                            if (usuariosGestor.Count > 0)
                            {
                                foreach (ValueObjectLayer.Usuario usuarioGestor in usuariosAdm)
                                {
                                    mail.To.Add(usuarioGestor.Email);
                                }
                            }
                        }
                    }
                }

                string corpoEmail = "O usuário " + usuarioFuncionario.Nome + " foi inserido no sistema";

                mail.Subject = isEmail.Assunto;

                StringBuilder sbcorpoEmail = new StringBuilder();
                string[] msg = isEmail.CorpoEmail.ToString().Split(new char[] { '|' });
                sbcorpoEmail.Append(msg[0] + "\n\r");
                sbcorpoEmail.Append(msg[1] + "\n\r");
                string msgCompleta = sbcorpoEmail.ToString();

                mail.Body = msgCompleta + corpoEmail;
                if (isEmail.UsarPorta)
                    SmtpServer.Port = (int)isEmail.Porta;

                SmtpServer.Credentials = new System.Net.NetworkCredential(isEmail.UsuarioEmailEmpresa, isEmail.SenhaEmailEmpresa);
                if (isEmail.Ssl)
                    SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por validar email
        /// </summary>
        /// <param name="inputEmail">email a ser validado</param>
        /// <returns>Retorna true se email for um email válido</returns>
        public bool ValidarEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public string retornaCrypto(string str)
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

        public string retornaDecrypto(string str)
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
    }
}
