//-----------------------------------------------------------------------
// <copyright file="RepositorioAuditoria.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;
    using System.Data.SqlClient;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de RepositorioAuditoria para retorno das ações de usuários do sistema
    /// </summary>
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        /// <summary>
        /// Método que cria uma Auditoria de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Objeto Auditoria com informações do Usuário, Descrição da ação, e Data da ocorrência</param>
        /// <returns>Retorna o Id do Inserção</returns>
        public int CriarAuditoria(Auditoria Auditoria)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (Auditoria != null)
                {
                    cmd.CommandText = "Insert Into TB_Log(IdUsuario, Descricao, Data) " +
                                        "Values(@varIdUsuario, @varDescricao, @varData)";

                    cmd.Parameters.AddWithValue("@varIdUsuario", Auditoria.Usuario.Id);
                    cmd.Parameters.AddWithValue("@varDescricao", Auditoria.Descricao);
                    cmd.Parameters.AddWithValue("@varData", Auditoria.Data);

                    cmd.ExecuteNonQuery();
                    string query2 = "Select @@Identity";
                    cmd.CommandText = query2;
                    newID = Convert.ToInt32(cmd.ExecuteScalar());

                    return (Convert.ToInt32(newID) > 0) ? Convert.ToInt32(newID) : 0;
                }
                else
                {
                    return 0;
                }
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
        /// Método que recupera todas ações de um Usuário dentro do sistema
        /// </summary>
        /// <param name="Auditoria">Parametro para recuperar todas as ações de um usuário para auditoria</param>
        /// <returns>Retorna um objeto Auditoria</returns>
        public IList<Auditoria> RecuperarUsuario(Auditoria Auditoria)
        {
            SqlCommand cmd = null;
            Auditoria AuditoriaRetorno = null;
            IList<Auditoria> lstAuditoria = new List<Auditoria>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select L.Id, U.Id As IdUsuario, U.Nome, L.Descricao, L.Data From TB_Log L, TB_Usuarios U " +
                                    "Where U.Id = @varIdUsuario ";

                cmd.Parameters.AddWithValue("@varIdUsuario", Auditoria.Usuario.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AuditoriaRetorno = new Auditoria(Convert.ToInt32(reader["Id"]));
                        Usuario usuario = new Usuario(Convert.ToInt32(reader["IdUsuario"]));
                        usuario.Nome = Convert.ToString(reader["Nome"]);
                        AuditoriaRetorno.Usuario = usuario;
                        AuditoriaRetorno.Descricao = Convert.ToString(reader["Descricao"]);
                        AuditoriaRetorno.Data = Convert.ToDateTime(reader["Data"]);
                        lstAuditoria.Add(AuditoriaRetorno);
                    }
                }
                return (lstAuditoria != null) ? lstAuditoria : null;
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
