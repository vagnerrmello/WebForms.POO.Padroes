//-----------------------------------------------------------------------
// <copyright file="ClienteFacade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.FacadeLayer
{
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer;
    using System.Collections.Generic;

    public class ClienteFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos de Cliente
        /// </summary>
        static IRepositorioCliente repositorioCliente = new RepositorioCliente();

        /// <summary>
        /// Fachada que cria um novo Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        /// <returns>Id do Cliente</returns>
        public static int InsereCliente(Cliente cliente)
        {
            return repositorioCliente.InsereCliente(cliente);
        }

        /// <summary>
        /// Fachada que recupera vários objetos Clientes por Empresa
        /// </summary>
        /// <param name="cliente"> Um objeto Cliente com o Parametro Id da Empresa preenchida</param>
        /// <returns>Retorna uma lista de objetos Empresa Tipo Clientes </returns>
        public static IList<Cliente> RecuperaVariosClientesPorEmpresa(Cliente cliente)
        {
            return repositorioCliente.RecuperaVariosClientesPorEmpresa(cliente);
        }

        /// <summary>
        /// Fachada que cria um novo Responsável
        /// </summary>
        /// <param name="cliente">Objeto Cliente para inserir um novo responsável</param>
        /// <returns>Id do Cliente</returns>
        public static int InsereResponsavel(Cliente cliente)
        {
            return repositorioCliente.InsereResponsavel(cliente);
        }

    }
}
