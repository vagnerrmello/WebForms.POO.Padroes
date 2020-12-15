using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Steto.ValueObjectLayer
{
    public class Factory
    {
        #region Campos privados

        /// <summary>
        /// Dados com a conexão
        /// </summary>
        private static GerenciadorConexao gerenciadorConexao;
        #endregion


        #region Métodos públicos

        /// <summary>
        /// Método de acesso a base de dados podendo ser "SqlServer" ou "PostGreSQL"
        /// </summary>
        /// <returns>OdbcCommand com a conexão ativa</returns>
        public static SqlCommand AcessoDados()
        {
            SqlCommand cmd = null;
            try
            {
                string banco = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("SGBD");
                gerenciadorConexao = getInstance(banco);
                cmd = gerenciadorConexao.CriarComando();

                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Instancia uma conexão com o banco</summary>
        /// <remarks>
        /// <para>A entrada para este método é o nome do Banco criando uma fábrica </para>
        /// </remarks>
        /// <param name="type">parametro de entrada com o tipo de banco a instanciar</param>
        /// <returns>GerenciadorConexao</returns>
        /// <exception cref="Exception">Lançada quando o tipo de entrada é diferente dos bancos relacionados" </exception>
        static GerenciadorConexao getInstance(String type)
        {
            try
            {
                    if ("SqlServer".Equals(type))
                    {
                        Aplicacao.CriarInstancia(TipoAplicacao.WebSqlServer, new GerenciadorSessaoSqlServer());
                        gerenciadorConexao = GerenciadorConexao.Instancia;
                        SqlConnection con = gerenciadorConexao.Conectar();

                    }
                    else if ("PostGreSQL".Equals(type))
                    {
                        Aplicacao.CriarInstancia(TipoAplicacao.WebPostGreSQL, new GerenciadorSessaoPostGreSQL());
                        gerenciadorConexao = GerenciadorConexao.Instancia;
                        SqlConnection con = gerenciadorConexao.Conectar();
                    }
                    else
                    {
                        throw new Exception("Problema com a conexão do banco, por favor entre em contato com o administrador!");
                    }

                return gerenciadorConexao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
