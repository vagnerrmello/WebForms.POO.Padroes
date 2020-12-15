//-----------------------------------------------------------------------
// <copyright file="EmailFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer;

    /// <summary>
    /// Fachada padrão para o objeto Email
    /// </summary>
    public class EmailFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioEmailSqlServer repositorioEmaiilSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioEmailSqlServer();

        /// <summary>
        /// Fachada que recupera todos os tipos de email
        /// </summary>
        /// <returns>Retorna uma lista de objetos do tio ValueObjectLayer.Email</returns>
        public static IList<ValueObjectLayer.Email_Tipo> RecuperaTipoEmail(ValueObjectLayer.TipoEmail tipoEmail)
        {
            //return BusinessLayer.Administrador.Email.RecuperaTipoEmail();
            if (dados.Equals("SqlServer"))
                return repositorioEmaiilSqlServer.RecuperaTipoEmail(tipoEmail);
            else
                return repositorioEmaiilSqlServer.RecuperaTipoEmail(tipoEmail);
        }

        /// <summary>
        /// Fachada responsável por recuperar as configurações de um email
        /// </summary>
        /// <param name="idEmail">Identificador da configuração do email</param>
        /// <returns>Retorna um objeto Email</returns>
        public static ValueObjectLayer.Email RecuperarConfiguracaoEmail(ValueObjectLayer.TipoEmail tipoEmail)
        {
            //return BusinessLayer.Administrador.Email.RecuperarConfiguracaoEmail(idEmail);
            if (dados.Equals("SqlServer"))
                return repositorioEmaiilSqlServer.RecuperarConfiguracaoEmail(tipoEmail);
            else
                return repositorioEmaiilSqlServer.RecuperarConfiguracaoEmail(tipoEmail);
        }

        /// <summary>
        /// Fachada responsável por salvar as configurações de email
        /// </summary>
        /// <param name="email">Objeto do tipo ValueObjectLayer.Email</param>
        /// <returns>Retorna um bool se ok</returns>
        public static bool SalvaConfiguracaoEmail(ValueObjectLayer.Email email)
        {
            //return BusinessLayer.Administrador.Email.SalvaConfiguracaoEmail(email);
            if (dados.Equals("SqlServer"))
                return repositorioEmaiilSqlServer.SalvaConfiguracaoEmail(email);
            else
                return repositorioEmaiilSqlServer.SalvaConfiguracaoEmail(email);
        }

        /// <summary>
        /// Fachada que envia email do sistema
        /// </summary>
        /// <param name="email">email requerido para envio</param>
        /// <param name="corpoEmail">mensagem que o email irá enviar</param>
        /// <returns>retorna true se ok</returns>
        public static bool EnviarEmail(ValueObjectLayer.Usuario usuario, string msgUsuario)
        {
            //return BusinessLayer.Administrador.Email.EnviarEmail(email, corpoEmail);
            if (dados.Equals("SqlServer"))
                return repositorioEmaiilSqlServer.EnviarEmail(usuario, msgUsuario);
            else
                return repositorioEmaiilSqlServer.EnviarEmail(usuario, msgUsuario);
        }

        /// <summary>
        /// Método responsável por validar email
        /// </summary>
        /// <param name="inputEmail">email a ser validado</param>
        /// <returns>Retorna true se email for um email válido</returns>
        public static bool ValidarEmail(string inputEmail)
        {
            //return BusinessLayer.Administrador.Email.EnviarEmail(email, corpoEmail);
            if (dados.Equals("SqlServer"))
                return repositorioEmaiilSqlServer.ValidarEmail(inputEmail);
            else
                return repositorioEmaiilSqlServer.ValidarEmail(inputEmail);
        }
    }
}
