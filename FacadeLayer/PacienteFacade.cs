//-----------------------------------------------------------------------
// <copyright file="PacienteFacade.cs" company="Steto">
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
    using Steto.BusinessLayer.Administrador.SqlServer;

    public class PacienteFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos da base SqlServer
        /// </summary>
        static BusinessLayer.Administrador.SqlServer.IRepositorioPacienteSqlServer repositorioPacienteSqlServer = new BusinessLayer.Administrador.SqlServer.RepositorioPacienteSqlServer();

        /// <summary>
        /// Fachada que cria um novo usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool CriarPaciente(Paciente paciente)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.CriarPaciente(paciente);
            else
                return repositorioPacienteSqlServer.CriarPaciente(paciente);
        }


        /// <summary>
        /// Fachada que recupera um objeto paciente
        /// </summary>
        /// <param name="idPaciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public static ValueObjectLayer.Paciente RecuperarPaciente(int idPaciente)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.RecuperarPaciente(idPaciente);
            else
                return repositorioPacienteSqlServer.RecuperarPaciente(idPaciente);
        }

        /// <summary>
        /// Fachada que recupera um objeto paciente
        /// </summary>
        /// <param name="idPaciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public static ValueObjectLayer.Paciente RecuperarPaciente(Paciente paciente)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.RecuperarPaciente(paciente);
            else
                return repositorioPacienteSqlServer.RecuperarPaciente(paciente);
        }

        /// <summary>
        /// Fachada responsável por vincular um contato ao paciente
        /// </summary>
        /// <param name="contato">Objeto contato</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool VincularContatoAoPaciente(Contato contato)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.VincularContatoAoPaciente(contato);
            else
                return repositorioPacienteSqlServer.VincularContatoAoPaciente(contato);
        }

        /// <summary>
        /// Método responsável por deletar os contatos de um paciente
        /// </summary>
        /// <param name="contato">Objeto contato</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool DeletarVinculoDeContatoAoPaciente(Paciente paciente)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.DeletarVinculoDeContatoAoPaciente(paciente);
            else
                return repositorioPacienteSqlServer.DeletarVinculoDeContatoAoPaciente(paciente);
        }

        /// <summary>
        /// Fachada responsável por recuperar todos os CBOs (Código Brasileiro de Ocupação)
        /// </summary>
        /// <returns>return uma lista com todos os objetos CBO</returns>
        public static IList<CBO> RecuperarCBO()
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.RecuperarCBO();
            else
                return repositorioPacienteSqlServer.RecuperarCBO();
        }

        /// <summary>
        /// Método que recupera uma lista de pacientes
        /// </summary>
        /// <param name="paciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public static List<Paciente> PesquisarPaciente(Paciente paciente)
        {
            if (dados.Equals("SqlServer"))
                return repositorioPacienteSqlServer.PesquisarPaciente(paciente);
            else
                return repositorioPacienteSqlServer.PesquisarPaciente(paciente);
        }
    }
}
