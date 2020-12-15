//-----------------------------------------------------------------------
// <copyright file="RepositorioUsuarioSqlServer.cs" company="Steto">
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
    using System.Data.Odbc;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de usuário
    /// </summary>
    public class RepositorioUsuarioSqlServer : IRepositorioUsuarioSqlServer
    {
        /// <summary>
        /// Método que cria um novo usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public int CriarUsuario(Usuario usuario)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (usuario != null)
                {
                    string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.Login + usuario.Senha, "MD5");

                    usuario.Senha = password;
                    usuario.Ativo = true;
                    usuario.Bloqueado = false;

                    cmd.CommandText = "Insert Into TB_Usuarios (Nome, Email, Login, Senha, Ativo, Bloqueado) " +
                                        "Values(@varNome, @varEmail, @varLogin, @varSenha, @varAtivo, @varBloqueado)";

                    cmd.Parameters.AddWithValue("@varNome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@varEmail", usuario.Email);
                    cmd.Parameters.AddWithValue("@varLogin", usuario.Login);
                    cmd.Parameters.AddWithValue("@varSenha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@varAtivo", usuario.Ativo);
                    cmd.Parameters.AddWithValue("@varBloqueado", usuario.Bloqueado);

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
        /// Método que altera o usuário para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto usuário</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AlteraUsuario(ValueObjectLayer.Usuario usuario)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (usuario != null)
                {

                    cmd.CommandText =   "Update TB_Usuarios Set Nome = @varNome,  Email = @varEmail, Login = @varLogin, " +
                                        "Ativo = @varAtivo, Bloqueado = @varBloqueado " +
                                        "Where Id = @varId ";

                    cmd.Parameters.AddWithValue("@varNome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@varEmail", usuario.Email);
                    cmd.Parameters.AddWithValue("@varLogin", usuario.Login);
                    cmd.Parameters.AddWithValue("@varAtivo", usuario.Ativo);
                    cmd.Parameters.AddWithValue("@varBloqueado", false);
                    cmd.Parameters.AddWithValue("@varId", usuario.Id);

                    return (cmd.ExecuteNonQuery() > 0) ? true : false ;
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
        /// Método que recupera um usuário do sistema
        /// </summary>
        /// <param name="idUsuario">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto usuário</returns>
        public ValueObjectLayer.Usuario RecuperarUsuario(Usuario ObjUsuario)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Usuario usuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Usuarios u " +
                                    "Where u.Id = @varId "+
                                    "And IdEmpresa = @varIdEmpresa";

                cmd.Parameters.AddWithValue("@varId", ObjUsuario.Id);
                //cmd.Parameters.AddWithValue("@varIdEmpresa", ObjUsuario.Empresa.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new ValueObjectLayer.Usuario();
                        usuario.Id = Convert.ToInt32(reader["Id"]);
                        usuario.Nome = Convert.ToString(reader["Nome"]);
                        usuario.Email = Convert.ToString(reader["Email"]);
                        usuario.Login = Convert.ToString(reader["Login"]);
                        usuario.Senha = Convert.ToString(reader["Senha"]);
                        usuario.Ativo = Convert.ToBoolean(reader["Ativo"]);
                        usuario.Bloqueado = Convert.ToBoolean(reader["Bloqueado"]);
                        //usuario.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                    }
                }
                return (usuario != null) ? usuario : null;
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
        /// Método que recupera o login do usuário do sistema
        /// </summary>
        /// <param name="login">Parametro para recuperar o usuário</param>
        /// <returns>Retorna um objeto Usuario</returns>
        public ValueObjectLayer.Usuario RecuperarPorLogin(string login)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Usuario usuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                    cmd.CommandText =   "Select * From TB_Usuarios u " +
                                        "Where u.Login = @varLogin ";

                    cmd.Parameters.AddWithValue("@varLogin", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new ValueObjectLayer.Usuario();
                            usuario.Id = Convert.ToInt32(reader["Id"]);
                            usuario.Nome = Convert.ToString(reader["Nome"]);
                            usuario.Email = Convert.ToString(reader["Email"]);
                            usuario.Login = Convert.ToString(reader["Login"]);
                            usuario.Senha = Convert.ToString(reader["Senha"]);
                            usuario.Ativo = Convert.ToBoolean(reader["Ativo"]);
                            usuario.Bloqueado = Convert.ToBoolean(reader["Bloqueado"]);
                            //usuario.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        }
                    }

                    return (usuario != null) ? usuario : null;
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
        /// Método que bloqueia um usuário no sistema
        /// </summary>
        /// <param name="usuario">Parametro com o objeto usuário para o bloqueio no sistema</param>
        /// <returns>Retorna True se ok</returns>
        public bool BloquearUsuario(ValueObjectLayer.Usuario usuario)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Update TB_Usuarios Set Bloqueado = @varBloqueado " +
                                    "Where Id = @varId ";

                cmd.Parameters.AddWithValue("@varBloqueado", true);
                cmd.Parameters.AddWithValue("@varId", usuario.Id);

                return  (cmd.ExecuteNonQuery() > 0) ? true : false;
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
        /// Método responsável por recuperar usuário do sistema bloqueado no momento do login
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        public bool RecuperarUsuarioBloqueado(string login, string senha)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(senha))
                {
                    string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "MD5");

                    cmd.CommandText =   "Select * From TB_Usuarios u " +
                                        "Where u.Login = @varLogin " +
                                        "And u.Senha = @varSenha " +
                                        "And u.Bloqueado = @varBloqueado";

                    cmd.Parameters.AddWithValue("@varLogin", login);
                    cmd.Parameters.AddWithValue("@varSenha", password);
                    cmd.Parameters.AddWithValue("@varBloqueado", 1);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return (reader.Read()) ? true : false;
                    }
                }
                else
                {
                    return true;
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
        /// Método responsável por logar o usuário no sistema
        /// </summary>
        /// <param name="login">Login do usuário do sistema</param>
        /// <param name="senha">Senha do usuário do sistema</param>
        /// <returns>Retorna um objeto usuário</returns>
        public ValueObjectLayer.Usuario Logar(string login, string senha)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Usuario usuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (ValidarLogin_CamposVazios(login, senha))
                {
                    //string hashLogin = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(login, "MD5");
                    //string hashSenha = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "MD5");

                    //string hashLoginSenha = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(hashLogin + hashSenha, "MD5");
                    //string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(hashLoginSenha + hashLoginSenhaPura, "MD5");

                    string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "MD5");

                    cmd.CommandText = "Select * From TB_Usuarios u " +
                                        "Where u.Login = @varLogin " +
                                        "And u.Senha = @varSenha " +
                                        "And u.Ativo = @varAtivo";

                    cmd.Parameters.AddWithValue("@varLogin", login);
                    cmd.Parameters.AddWithValue("@varSenha", password);
                    cmd.Parameters.AddWithValue("@varAtivo", 1);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuario = new ValueObjectLayer.Usuario();
                            usuario.Id = Convert.ToInt32(reader["Id"]);
                            usuario.Nome = Convert.ToString(reader["Nome"]);
                            usuario.Email = Convert.ToString(reader["Email"]);
                            usuario.Login = Convert.ToString(reader["Login"]);
                            usuario.Senha = Convert.ToString(reader["Senha"]);
                            usuario.Ativo = Convert.ToBoolean(reader["Ativo"]);
                            usuario.Bloqueado = Convert.ToBoolean(reader["Bloqueado"]);
                            //usuario.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        }
                    }

                    return (usuario != null) ? usuario : null;
                }
                else
                {
                    return null;
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
        /// Método que recupera todos os usuários do sistema
        /// </summary>
        /// <returns>Retorna True se ok</returns>
        public IList<ValueObjectLayer.Usuario> RecuperarUsuarios()
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Usuario> usuarios = new List<ValueObjectLayer.Usuario>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Usuarios u " +
                                  "Order By u.Nome asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(
                            new ValueObjectLayer.Usuario(
                                Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Nome"]),
                                Convert.ToString(reader["Email"]), Convert.ToString(reader["Login"]),
                                Convert.ToString(reader["Senha"]), Convert.ToBoolean(reader["Ativo"]),
                                Convert.ToBoolean(reader["Bloqueado"])));
                    }
                }

                return (usuarios.Count > 0) ? usuarios : null;
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
        /// Método que recupera todos os usuários do sistema
        /// </summary>
        /// <returns>Retorna True se ok</returns>
        public static IList<ValueObjectLayer.Usuario> RecuperarUsuariosPorPerfil(ValueObjectLayer.TipoPerfil tipoPerfil)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Usuario> usuarios = new List<ValueObjectLayer.Usuario>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select u.Id As IdUsuario, u.Nome As NomeUsuario, u.Login As LoginUsuario, u.Email As EmailUsuario " +
                                    "From TB_Usuarios u, TB_Perfil p, TB_Perfil_Usuario pu " +
                                    "Where u.Id = pu.IdUsuario " +
                                    "And p.Id = pu.IdPerfil " +
                                    "And p.Id = @varId " +
                                    "And u.Ativo = @varAtivo " +
                                    "And u.Bloqueado = @varBloqueado " +
                                    "Order By u.Nome";
                
                cmd.Parameters.AddWithValue("@varId", Convert.ToInt32(tipoPerfil));
                cmd.Parameters.AddWithValue("@varAtivo", 1);
                cmd.Parameters.AddWithValue("@varBloqueado", 0);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(
                            new ValueObjectLayer.Usuario(
                                Convert.ToInt32(reader["IdUsuario"]), Convert.ToString(reader["NomeUsuario"]),
                                Convert.ToString(reader["EmailUsuario"]), Convert.ToString(reader["LoginUsuario"]),
                                null,true, false ));
                    }
                }

                return (usuarios.Count > 0) ? usuarios : null;
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
        /// Método que recupera o usuário do sistema pelo Nome
        /// </summary>
        /// <param name="nomeUsuario">Parametro com o nome do usuário do sistema</param>
        /// <returns>Retorna True se ok</returns>
        public IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nomeUsuario)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Usuario> usuarios = new List<ValueObjectLayer.Usuario>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Usuarios u " +
                                    "Where u.Nome Like '%" + nomeUsuario + "%' " +
                                    "Order By u.Nome asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(
                            new ValueObjectLayer.Usuario(
                                Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Nome"]),
                                Convert.ToString(reader["Email"]), Convert.ToString(reader["Login"]),
                                Convert.ToString(reader["Senha"]), Convert.ToBoolean(reader["Ativo"]),
                                Convert.ToBoolean(reader["Bloqueado"])));
                    }
                }

                return (usuarios.Count > 0) ? usuarios : null;
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
        /// Método que recupera o usuário do sistema pelo Nome e se está ativo
        /// </summary>
        /// <param name="nome">Parametro com o nome do usuário do sistema</param>
        /// <param name="ativo">Parametro se o usuário está ativo ou não no sistema</param>
        /// <returns>Retorna True se ok</returns>
        public IList<ValueObjectLayer.Usuario> RecuperarUsuarios(string nome, bool ativo)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Usuario> usuarios = new List<ValueObjectLayer.Usuario>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Usuarios u " +
                                    "Where u.Nome Like '%" + nome + "%' " +
                                    "And u.Ativo = @varAtivo " +
                                    "Order By u.Nome asc";

                cmd.Parameters.AddWithValue("@varAtivo", ativo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        usuarios.Add(
                            new ValueObjectLayer.Usuario(
                                Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Nome"]),
                                Convert.ToString(reader["Email"]), Convert.ToString(reader["Login"]),
                                Convert.ToString(reader["Senha"]), Convert.ToBoolean(reader["Ativo"]),
                                Convert.ToBoolean(reader["Bloqueado"])));
                    }
                }

                return (usuarios.Count > 0) ? usuarios : null;
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
        /// Método que recupera todos os usuários do sistema
        /// </summary>
        /// <param name="ativo">Parametro com o status do usuário no sistema</param>
        /// <returns>Retorna True se ok</returns>
        public IList<ValueObjectLayer.Usuario> RecuperarUsuarios(bool ativo)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Usuario> usuarios = new List<ValueObjectLayer.Usuario>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Usuarios u " +
                                    "Where u.Ativo = @varAtivo " +
                                    "Order By u.Nome asc";

                cmd.Parameters.AddWithValue("@varAtivo", ativo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(
                            new ValueObjectLayer.Usuario(
                                Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Nome"]),
                                Convert.ToString(reader["Email"]), Convert.ToString(reader["Login"]),
                                Convert.ToString(reader["Senha"]), Convert.ToBoolean(reader["Ativo"]),
                                Convert.ToBoolean(reader["Bloqueado"])));
                    }
                }

                return (usuarios.Count > 0) ? usuarios : null;
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
        /// Método que Inativa um usuário no sistema
        /// </summary>
        /// <param name="id">Parametro com o id do usuário</param>
        /// <returns>Retorna True se ok</returns>
        public bool InativarUsuario(int id)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (id != 0)
                {

                    cmd.CommandText =   "Update TB_Usuarios Set Ativo = @varAtivo " +
                                        "Where Id = @varId ";

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

        #region Validaçoes

        /// <summary>
        /// Validar se login já existe no momento do cadastro
        /// </summary>
        /// <param name="isLogin">parametro que passa o login para validação</param>
        /// <returns>bool</returns>
        public bool ValidarLogin(string isLogin)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Usuarios u " +
                                    "Where u.Login = @varLogin";

                cmd.Parameters.AddWithValue("@varLogin", isLogin);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return  (reader.Read()) ? false : true;
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
        /// Método responsável por veridicar os campos estão vázios ou nulos para o login
        /// </summary>
        /// <param name="login">campo login</param>
        /// <param name="senha">campo senha</param>
        /// <returns>Retorna true se os campos estiverem preenchidos</returns>
        public static bool ValidarLogin_CamposVazios(string login, string senha)
        {
            if (!string.IsNullOrEmpty(login) || !string.IsNullOrEmpty(senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Método responsável por verificar se os campos relacionados ao objeto usuário estão vázios ou nulos
        /// </summary>
        /// <param name="usuario">Objeto usuário preenchido com os dados relacionados ao usuário</param>
        /// <returns>Retorna true se os campos estiverem preenchidos</returns>
        public static bool ValidacaoObjetoVazio(ValueObjectLayer.Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Nome) || !string.IsNullOrEmpty(usuario.Email) ||
               !string.IsNullOrEmpty(usuario.Login) || !string.IsNullOrEmpty(usuario.Senha) ||
               !string.IsNullOrEmpty(usuario.Senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
