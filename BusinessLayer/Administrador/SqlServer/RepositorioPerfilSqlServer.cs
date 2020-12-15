//-----------------------------------------------------------------------
// <copyright file="RepositorioPerfilSqlServer.cs" company="Steto">
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

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de usuário
    /// </summary>
    public class RepositorioPerfilSqlServer : IRepositorioPerfilSqlServer
    {
        /// <summary>
        /// Método responsável para criar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        public bool CriarPerfil(ValueObjectLayer.Perfil perfil)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Insert Into TB_Perfil (Descricao, Ativo) Values(@varDescricao, @varAtivo)";

                cmd.Parameters.AddWithValue("@varDescricao", perfil.Descricao);
                cmd.Parameters.AddWithValue("@varAtivo", true);

                return (cmd.ExecuteNonQuery() > 0) ? true : false;
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
        /// Método responsável para alterar Perfil do usuário do sistema
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        public bool AlterarPerfil(ValueObjectLayer.Perfil perfil)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Update TB_Perfil Set Descricao = @varDescricao " +
                                    "Where Id = @varId";

                cmd.Parameters.AddWithValue("@varDescricao", perfil.Descricao);
                cmd.Parameters.AddWithValue("@varId", perfil.Id);

                return (cmd.ExecuteNonQuery() > 0) ? true : false;
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
        /// Método que Inativa um perfil do sistema
        /// </summary>
        /// <param name="id">Parametro com o id do perfil</param>
        /// <returns>Retorna True se ok</returns>
        public bool InativarPerfil(int id)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (id != 0)
                {
                    cmd.CommandText =   "Update TB_Perfil Set Ativo = @varAtivo " +
                                        "Where Id = @varId";

                    cmd.Parameters.AddWithValue("@varAtivo", false);
                    cmd.Parameters.AddWithValue("@varId", id);

                    return (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                else
                {
                    return false;
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
        /// Método responsável para recuperar Perfil pelo id do peril
        /// </summary>
        /// <param name="perfil">perfil </param>
        /// <returns>true se ok</returns>
        public ValueObjectLayer.Perfil RecuperarPerfil(int idPerfil)
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            ValueObjectLayer.Perfil perfil = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil " +
                                    "Where Id = @varId";

                cmd.Parameters.AddWithValue("@varId", idPerfil);

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfil = new ValueObjectLayer.Perfil(
                                                            Convert.ToInt32(reader["Id"]),
                                                            Convert.ToString(reader["Descricao"]),
                                                            Convert.ToBoolean(reader["Ativo"]));
                    }
                }

                return perfil;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (cmd != null) cmd.Dispose();
            }
        }

        /// <summary>
        /// Método responsável por verificar se o nome do perfil já existe
        /// </summary>
        /// <param name="perfilNome">Nome do perfil a ser recuperado</param>
        /// <returns>return true se já existir um perfil com o mesmo nome que está querendo ser criado</returns>
        public bool RecuperarPerfil(string perfilNome)
        {
            SqlCommand cmd = null;
            
            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil " +
                                    "Where Descricao = @varDescricao";

                cmd.Parameters.AddWithValue("@varDescricao", perfilNome);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return (reader.Read()) ? true : false;
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
        /// Método que recupera todos os perfis do sistema
        /// </summary>
        /// <returns>Retorna uma lista de perfis já cadastrados</returns>
        public IList<ValueObjectLayer.Perfil> RecuperarPerfis()
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Perfil> perfilLista = new List<ValueObjectLayer.Perfil>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil " +
                                    "Order By Descricao asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        perfilLista.Add(
                            new ValueObjectLayer.Perfil(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToString(reader["Descricao"]),
                                Convert.ToBoolean(reader["Ativo"])));
                    }
                }
                return (perfilLista.Count > 0) ? perfilLista : null;
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
        /// Recupera os perfis pelo nome 
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Perfil> perfilLista = new List<ValueObjectLayer.Perfil>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Perfil " +
                                    "Where Descricao Like '%" + nomePerfil +"%' " +
                                    "Order By Descricao asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfilLista.Add(
                            new ValueObjectLayer.Perfil(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToString(reader["Descricao"]),
                                Convert.ToBoolean(reader["Ativo"])));
                    }
                }
                return (perfilLista.Count > 0) ? perfilLista : null;
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
        /// Recupera os perfis pelo nome e o status ativo
        /// </summary>
        /// <param name="nomePerfil">Referente ao nome do perfil</param>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public IList<ValueObjectLayer.Perfil> RecuperarPerfis(string nomePerfil, bool ativo)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Perfil> perfilLista = new List<ValueObjectLayer.Perfil>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil Where Descricao Like '%" + nomePerfil + "%' " +
                                    "And Ativo = @varAtivo Order By Descricao asc";

                cmd.Parameters.AddWithValue("@varAtivo", ativo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfilLista.Add(
                            new ValueObjectLayer.Perfil(
                                Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Descricao"]), 
                                Convert.ToBoolean(reader["Ativo"])));
                    }
                }

                return (perfilLista.Count > 0) ? perfilLista : null;
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
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="ativo">Status do perfil</param>
        /// <returns>IList<> com o resultado</returns>
        public IList<ValueObjectLayer.Perfil> RecuperarPerfis(bool ativo)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Perfil> perfilLista = new List<ValueObjectLayer.Perfil>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Perfil Where Ativo = @varAtivo Order By Descricao asc";

                cmd.Parameters.AddWithValue("@varAtivo", ativo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfilLista.Add(
                            new ValueObjectLayer.Perfil(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToString(reader["Descricao"]),
                                Convert.ToBoolean(reader["Ativo"])));
                    }
                }
                return (perfilLista.Count > 0) ? perfilLista : null;
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
        /// Recupera os perfis pelo status do perfil
        /// </summary>
        /// <param name="idUsuario">id do usuario</param>
        /// <param name="status">status do usuario</param>
        /// <returns>Retorna um objeto Perfil_Usuario com o resultado</returns>
        public IList<ValueObjectLayer.CarregarPerfil> RecuperarPerfilUsuario(int idUsuario, ValueObjectLayer.TipoBuscaPerfil tipoBuscaPerfil)
        {
            SqlCommand cmd = null;
            IRepositorioPermissaoSqlServer repositorioPermissaoSqlServer = new RepositorioPermissaoSqlServer();
            ValueObjectLayer.Perfil_Usuario perfilUsuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil_Usuario " +
                                    "Where IdUsuario = @varIdUsuario ";

                cmd.Parameters.AddWithValue("@varIdUsuario", idUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfilUsuario = new ValueObjectLayer.Perfil_Usuario(
                            Convert.ToInt32(reader["Id"]),
                            new ValueObjectLayer.Usuario(Convert.ToInt32(reader["IdUsuario"])),
                            new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"]))
                            );
                    }
                }

                IList<ValueObjectLayer.CarregarPerfil> listaPerfilUsuario = null;
                if (perfilUsuario != null)
                {
                    switch (tipoBuscaPerfil)
                    {
                        case TipoBuscaPerfil.RecuperaTodasPermissoesPerfil:
                            listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfil(perfilUsuario._Perfil.Id);
                            break;
                        case TipoBuscaPerfil.RecuperaFuncionalidadesPerfil:
                            listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaFuncionalidadesPerfil(perfilUsuario._Perfil.Id);
                            break;
                        case TipoBuscaPerfil.RecuperaPermissoes:
                            listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaPermissoes(perfilUsuario._Perfil.Id);
                            break;
                        default:
                            break;
                    }
                    //if (tipoBuscaPerfil == ValueObjectLayer.TipoBuscaPerfil.RecuperaTodasPermissoesPerfil)
                    //{
                    //    listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaTodasPermissoesPerfil(perfilUsuario._Perfil.Id);
                    //}
                    //else if (tipoBuscaPerfil == ValueObjectLayer.TipoBuscaPerfil.RecuperaFuncionalidadesPerfil)
                    //{
                    //    listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaFuncionalidadesPerfil(perfilUsuario._Perfil.Id);
                    //}
                    //else if (tipoBuscaPerfil == ValueObjectLayer.TipoBuscaPerfil.RecuperaFuncionalidadesPerfil)
                    //{
                    //    listaPerfilUsuario = repositorioPermissaoSqlServer.RecuperaPermissoes(perfilUsuario._Perfil.Id);
                    //}
                }

                if (listaPerfilUsuario != null)
                {
                    return (listaPerfilUsuario.Count > 0) ? listaPerfilUsuario : null;
                }
                else
                { return null; }
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
        /// Método que recupera o perfil do usuário do sistema
        /// </summary>
        /// <param name="idUsuario">Identificação do usuário no sistema</param>
        /// <returns>Retorna um objeto ValueObjectLayer.Perfil_Usuario devidamente preechido</returns>
        public ValueObjectLayer.Perfil_Usuario RecuperarPerfilPorId(int idUsuario)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Perfil_Usuario perfilUsuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Perfil_Usuario " +
                                    "Where IdUsuario = @varIdUsuario ";

                cmd.Parameters.AddWithValue("@varIdUsuario", idUsuario);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perfilUsuario = new ValueObjectLayer.Perfil_Usuario(
                            Convert.ToInt32(reader["Id"]),
                            new ValueObjectLayer.Usuario(Convert.ToInt32(reader["IdUsuario"])),
                            new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"])));
                    }
                }

                return (perfilUsuario != null) ? perfilUsuario : null;
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
