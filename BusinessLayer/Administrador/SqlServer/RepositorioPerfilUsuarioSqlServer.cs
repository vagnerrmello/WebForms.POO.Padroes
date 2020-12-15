//-----------------------------------------------------------------------
// <copyright file="RepositorioPerfilUsuarioSqlServer.cs" company="Steto">
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
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de PerfilUsuario
    /// </summary>
    public class RepositorioPerfilUsuarioSqlServer : IRepositorioPerfilUsuarioSqlServer
    {
        /// <summary>
        /// Método responsável por alterar o perfil do usuário
        /// </summary>
        /// <param name="perfilUsuario">Objeto Perfil_Usuario para </param>
        /// <returns>true a alteração ocorreu com sucesso</returns>
        public  bool AlteraPerfilUsuario(ValueObjectLayer.Perfil_Usuario perfilUsuario)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Perfil_Usuario isPerfilUsuario = null;
            try
            {
                isPerfilUsuario = RecuperarPerfilUsuario(perfilUsuario._Usuario.Id);

                cmd = Factory.AcessoDados();

                if (perfilUsuario != null)
                {
                    if (perfilUsuario != null)
                    {
                        if (perfilUsuario._Perfil.Id != 0)
                        {
                            if (isPerfilUsuario != null)
                                DeletaPerfilUsuario(perfilUsuario);

                            cmd = Factory.AcessoDados();
                            cmd.CommandText = "Insert Into TB_Perfil_Usuario (IdUsuario, IdPerfil) " +
                                        "Values(@varIdUsuario, @varIdPerfil)";

                            cmd.Parameters.AddWithValue("@varIdUsuario", perfilUsuario._Usuario.Id);
                            cmd.Parameters.AddWithValue("@varIdPerfil", perfilUsuario._Perfil.Id);

                            return (cmd.ExecuteNonQuery() > 0) ? true : false;
                        }
                        else
                        {
                            if (isPerfilUsuario != null)
                                DeletaPerfilUsuario(isPerfilUsuario);

                            return true;
                        }
                    }
                    else { return false; }

                }
                else { return false; }

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
        /// Método responsável por recuperar o perfil do usuário
        /// </summary>
        /// <param name="idUsuario">Id que indentifica o perfil do usuário</param>
        /// <returns>Retorna um objeto perfil do usuário</returns>
        public ValueObjectLayer.Perfil_Usuario RecuperarPerfilUsuario(int idUsuario)
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            ValueObjectLayer.Perfil_Usuario perfilUsuario = null;
            ValueObjectLayer.Perfil perfil = null;
            ValueObjectLayer.Usuario usuario = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil_Usuario pu " +
                                    "Where pu.IdUsuario = @varIdUsuario ";

                cmd.Parameters.AddWithValue("@varIdUsuario", idUsuario);

                using (reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    { 
                        perfilUsuario = new ValueObjectLayer.Perfil_Usuario();

                        perfilUsuario.Id = Convert.ToInt32(reader["Id"]);
                        usuario = new ValueObjectLayer.Usuario(Convert.ToInt32(reader["IdUsuario"]));
                        perfil = new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"]));
                        perfilUsuario._Usuario = usuario;
                        perfilUsuario._Perfil = perfil;
                    }
                }

                return perfilUsuario;
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
        /// Método responsável por deletar perfil do usário
        /// </summary>
        /// <param name="pu">Objeto Perfil_Usuario para deleção</param>
        public void DeletaPerfilUsuario(ValueObjectLayer.Perfil_Usuario pu)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (pu != null)
                {
                    cmd.CommandText = "Delete From TB_Perfil_Usuario Where IdUsuario = @varId";

                    cmd.Parameters.AddWithValue("@varId", pu._Usuario.Id);

                    //cmd.Prepare();
                    cmd.ExecuteNonQuery();
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
    }
}
