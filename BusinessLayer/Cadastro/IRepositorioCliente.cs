//-----------------------------------------------------------------------
// <copyright file="IRepositorioCliente.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer
{
    using System.Collections.Generic;
    using ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Funcionario
    /// </summary>
    public interface IRepositorioCliente
    {
        /// <summary>
        /// Interface que cria um novo Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        /// <returns>Id do Cliente</returns>
        int InsereCliente(Cliente cliente);

        /// <summary>
        /// Interface que recupera vários objetos Clientes por Empresa
        /// </summary>
        /// <param name="cliente"> Um objeto Cliente com o Parametro Id da Empresa preenchida</param>
        /// <returns>Retorna uma lista de objetos Cliente por Empresa</returns>
        IList<Cliente> RecuperaVariosClientesPorEmpresa(Cliente cliente);

        /// <summary>
        /// Interface que cria um novo Responsável
        /// </summary>
        /// <param name="cliente">Objeto Cliente para inserir um novo responsável</param>
        /// <returns>Id do Cliente</returns>
        int InsereResponsavel(Cliente cliente);
    }
}
