//-----------------------------------------------------------------------
// <copyright file="IRepositorioEmpresa.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Empresa
    /// </summary>
    public interface IRepositorioEmpresa
    {
        /// <summary>
        /// Interface que cria uma nova Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        int CriarEmpresa(Empresa empresa);

        /// <summary>
        /// Interface que Atualiza uma Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool AtualizarEmpresa(Empresa empresa);

        /// <summary>
        /// Interface que recupera um objeto Empresa
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa através ou não do seu Id</param>
        /// <returns>Retorna o objeto Empresa</returns>
        Empresa RecuperaEmpresa(Empresa empresa);

        /// <summary>
        /// Interface que recupera um objeto Empresa do Tipo Fornecedor
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa com o Tipo Fornecedor</param>
        /// <returns>Retorna o objeto Tipo FornecedorEmpresa </returns>
        IList<Empresa> RecuperaEmpresaTipoFornecedor(Empresa empresa);
    }
}
