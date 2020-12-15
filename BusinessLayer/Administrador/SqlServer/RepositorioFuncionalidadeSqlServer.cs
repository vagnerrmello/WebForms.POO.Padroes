//-----------------------------------------------------------------------
// <copyright file="RepositorioModuloSqlServer.cs" company="Steto">
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
    using Steto.BusinessLayer;

    /// <summary>
    /// Armazena as informações provenientes do repositório Funcionalidade
    /// </summary>
    public class RepositorioFuncionalidadeSqlServer : IRepositorioFuncionalidadeSqlServer
    {
        /// <summary>
        /// Recupera todos as funcionalidades por módulo
        /// </summary>
        /// <param name="idModulo">Id do módulo para recuperar a funcionalidade</param>
        /// <returns>Retorna uma lista de funcionalidade por módulo</returns>
        public IList<ValueObjectLayer.Funcionalidade> RecuperaFuncionalidadesPorModulo(int idModulo)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Funcionalidade> listaFuncionalidades = new List<ValueObjectLayer.Funcionalidade>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * " +
                                    "From TB_Funcionalidades f " +
                                    "Where f.IdModulo = @idModulo";

                cmd.Parameters.AddWithValue("@idModulo", idModulo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaFuncionalidades.Add(new ValueObjectLayer.Funcionalidade(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["Descricao"]),
                            new ValueObjectLayer.Modulo(Convert.ToInt32(reader["IdModulo"]))
                            ));
                    }
                }

                return (listaFuncionalidades.Count > 0) ? listaFuncionalidades : null;
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
    }
}
