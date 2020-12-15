//-----------------------------------------------------------------------
// <copyright file="EmpresaFacade.cs" company="Steto">
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


    public class EmpresaFacade
    {
        /// <summary>
        /// Variável responsável por selecionar a base de dados que está sendo instanciada pelo sistema
        /// </summary>
        static string dados = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");

        /// <summary>
        /// Repositório responsável pelos métodos de Escritura
        /// </summary>
        static IRepositorioEmpresa repositorioEmpresa = new RepositorioEmpresa();

        /// <summary>
        /// Fachada que cria uma nova Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static int CriarEmpresa(Empresa empresa)
        {
            return repositorioEmpresa.CriarEmpresa(empresa);
        }

        /// <summary>
        /// Fachada que Atualiza uma Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public static bool AtualizarEmpresa(Empresa empresa)
        {
            return repositorioEmpresa.AtualizarEmpresa(empresa);
        }

        /// <summary>
        /// Fachada que recupera um objeto Empresa
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa através do seu Id</param>
        /// <returns>Retorna o objeto Empresa</returns>
        public static Empresa RecuperaEmpresa(Empresa empresa)
        {
            return repositorioEmpresa.RecuperaEmpresa(empresa);
        }

        /// <summary>
        /// Fachada que recupera um objeto Empresa do Tipo Fornecedor
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa com o Tipo Fornecedor</param>
        /// <returns>Retorna o objeto Tipo FornecedorEmpresa </returns>
        public static IList<Empresa> RecuperaEmpresaTipoFornecedor(Empresa empresa)
        {
            return repositorioEmpresa.RecuperaEmpresaTipoFornecedor(empresa);
        }
    }
}
