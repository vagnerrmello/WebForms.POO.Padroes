//-----------------------------------------------------------------------
// <copyright file="RepositorioCepSqlServer.cs" company="Steto">
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
    using System.IO;

    /// <summary>
    /// Interface padrão para o repositório Cep
    /// </summary>
    public class RepositorioCepSqlServer
    {
        /// <summary>
        /// Método que importa dados via arquivo cvs para a base de dados do sistema
        /// </summary>
        public void ImportarCvs()
        {
            //SqlCommand cmd = null;

            StreamReader stream = new StreamReader(@"C:\Documents and Settings\vrm\Meus documentos\CEP\tb_cep.csv");

            string linha = null;
            while ((linha = stream.ReadLine()) != null)
            {
                string[] linhaSeparada = linha.Split(';');
                //Response.Write(linhaSeparada[0] + " - " + linhaSeparada[1] + "");
            }

            stream.Close();

            //Int32 newID = 0;
            //try
            //{
            //    cmd = Factory.AcessoDados();

            //    if (usuario != null)
            //    {
            //        string password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.Login + usuario.Senha, "MD5");

            //        usuario.Senha = password;
            //        usuario.Ativo = true;
            //        usuario.Bloqueado = false;

            //        cmd.CommandText = "Insert Into TB_Usuarios (Nome, Email, Login, Senha, Ativo, Bloqueado) " +
            //                            "Values(@varNome, @varEmail, @varLogin, @varSenha, @varAtivo, @varBloqueado)";

            //        cmd.Parameters.AddWithValue("@varNome", usuario.Nome);
            //        cmd.Parameters.AddWithValue("@varEmail", usuario.Email);
            //        cmd.Parameters.AddWithValue("@varLogin", usuario.Login);
            //        cmd.Parameters.AddWithValue("@varSenha", usuario.Senha);
            //        cmd.Parameters.AddWithValue("@varAtivo", usuario.Ativo);
            //        cmd.Parameters.AddWithValue("@varBloqueado", usuario.Bloqueado);

            //        cmd.ExecuteNonQuery();
            //        string query2 = "Select @@Identity";
            //        cmd.CommandText = query2;
            //        newID = Convert.ToInt32(cmd.ExecuteScalar());

            //        return (Convert.ToInt32(newID) > 0) ? Convert.ToInt32(newID) : 0;

            //    }
            //    else
            //    {
            //        return 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    if (cmd != null) cmd.Dispose();
            //}
        }
    }
}
