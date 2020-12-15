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
    using Steto.ValueObjectLayer;
    using Steto.BusinessLayer;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de Módulos
    /// </summary>
    public class RepositorioModuloSqlServer : IRepositorioModuloSqlServer
    {
        /// <summary>
        /// Método que recupera todos os módulos
        /// </summary>
        /// <returns>Retorna uma lista com todos os módulos pertencentes ao sistema</returns>
        public IList<ValueObjectLayer.Modulo> RecuperaTodosOsModulos()
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Modulo> listaModulos = new List<ValueObjectLayer.Modulo>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Modulos m " +
                                    "Order By m.Nome";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaModulos.Add(new ValueObjectLayer.Modulo(
                            Convert.ToInt32(reader["Id"]),
                            Convert.ToString(reader["Nome"]),
                            Convert.ToString(reader["Descricao"]),
                            Convert.ToString(reader["CaminhoPagina"])));
                    }
                }

                return (listaModulos.Count > 0) ? listaModulos : null;
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
        /// Método responsável por recuperar os módulos do perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objetos do tipo Modulo</returns>
        public IList<ValueObjectLayer.Modulo> RecuperaModulosdoPerfil(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Modulo> listaModulos = new List<ValueObjectLayer.Modulo>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select m.Id As IdModulo, m.Nome As NomeModulo, m.CaminhoPagina As CaminhoPaginaModulo " +
                                    "From TB_Perfil p, TB_Modulos m, TB_Perfil_Modulo pm " +
                                    "Where pm.IdModulo = m.Id " +
                                    "And pm.IdPerfil = p.Id " +
                                    "And p.Id = @idPerfil";

                cmd.Parameters.AddWithValue("@idPerfil", idPerfil);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaModulos.Add(new ValueObjectLayer.Modulo(
                            Convert.ToInt32(reader["IdModulo"]),
                            Convert.ToString(reader["NomeModulo"]),
                            Convert.ToString(reader["CaminhoPaginaModulo"])));
                    }
                }

                return (listaModulos.Count > 0) ? listaModulos : null;
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
