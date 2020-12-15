//-----------------------------------------------------------------------
// <copyright file="RepositorioEmpresa.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Steto.ValueObjectLayer;
    using Util;

    /// <summary>
    /// Armazena as informações provenientes do repositório Empresa
    /// </summary>
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        /// <summary>
        /// Método que cria uma nova Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public int CriarEmpresa(Empresa empresa)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                Int32 newID = 0;
                string isQuery = string.Empty;

                string isValue = string.Empty;

                if (empresa != null)
                {
                    isQuery = "Insert Into TB_Empresa (";
                    isValue += "Values( ";

                    if (empresa.Nome != null)
                    {
                        isQuery += "Nome";
                        isValue += "@varNome";
                        cmd.Parameters.AddWithValue("@varNome", empresa.Nome);
                    }

                    if (empresa.Cpf_Cnpj != null)
                    {
                        isQuery += " ,Cpf_Cnpj";
                        isValue += " ,@varCpf_Cnpj";
                        cmd.Parameters.AddWithValue("@varCpf_Cnpj", empresa.Cpf_Cnpj);
                    }

                    if (empresa.Logradouro != null)
                    {
                        isQuery += " ,Logradouro";
                        isValue += " ,@varLogradouro";
                        cmd.Parameters.AddWithValue("@varLogradouro", empresa.Logradouro);
                    }

                    if (empresa.Bairro != null)
                    {
                        isQuery += " ,Bairro";
                        isValue += " ,@varBairro";
                        cmd.Parameters.AddWithValue("@varBairro", empresa.Bairro);
                    }

                    if (empresa.Cep != null)
                    {
                        isQuery += " ,Cep";
                        isValue += " ,@varCep";
                        cmd.Parameters.AddWithValue("@varCep", empresa.Cep);
                    }

                    if (empresa.Cidade != null)
                    {
                        isQuery += " ,Cidade";
                        isValue += " ,@varCidade";
                        cmd.Parameters.AddWithValue("@varCidade", empresa.Cidade);
                    }

                    if (empresa.Estado != null)
                    {
                        isQuery += " ,Estado";
                        isValue += " ,@varEstado";
                        cmd.Parameters.AddWithValue("@varEstado", empresa.Estado);
                    }

                    if (empresa.Email != null)
                    {
                        isQuery += " ,Email";
                        isValue += " ,@varEmail";
                        cmd.Parameters.AddWithValue("@varEmail", empresa.Email);
                    }

                    isQuery += ") ";
                    isValue += ") ";

                    cmd.CommandText = isQuery + isValue;

                    cmd.ExecuteNonQuery();
                    string query2 = "Select @@Identity";
                    cmd.CommandText = query2;
                    newID = Convert.ToInt32(cmd.ExecuteScalar());

                    return (Convert.ToInt32(newID) > 0) ? Convert.ToInt32(newID) : 0;
                }

                return 0;
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
        /// Método que Atualiza uma Empresa
        /// </summary>
        /// <param name="empresa">Objeto Empresa</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AtualizarEmpresa(Empresa empresa)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                string isQuery = string.Empty;

                if (empresa != null)
                {
                    isQuery = "Update TB_Empresa Set ";

                    if (!string.IsNullOrEmpty(empresa.Nome))
                    {
                        isQuery += "Nome = @varNome";
                        cmd.Parameters.AddWithValue("@varNome", empresa.Nome);
                    }

                    if (empresa.Cpf_Cnpj != null)
                    {
                        isQuery += ", Cpf_Cnpj = @varCpf_Cnpj";
                        cmd.Parameters.AddWithValue("@varCpf_Cnpj", empresa.Cpf_Cnpj);
                    }

                    if (empresa.Logradouro != null)
                    {
                        isQuery += ", Logradouro = @varLogradouro";
                        cmd.Parameters.AddWithValue("@varLogradouro", empresa.Logradouro);
                    }

                    if (empresa.Bairro != null)
                    {
                        isQuery += ", Bairro = @varBairro";
                        cmd.Parameters.AddWithValue("@varBairro", empresa.Bairro);
                    }

                    if (empresa.Cep != null)
                    {
                        isQuery += ", Cep = @varCep";
                        cmd.Parameters.AddWithValue("@varCep", empresa.Cep);
                    }

                    if (empresa.Cidade != null)
                    {
                        isQuery += ", Cidade = @varCidade";
                        cmd.Parameters.AddWithValue("@varCidade", empresa.Cidade);
                    }

                    if (empresa.Estado != null)
                    {
                        isQuery += ", Estado = @varEstado";
                        cmd.Parameters.AddWithValue("@varEstado", empresa.Estado);
                    }

                    if (empresa.Email != null)
                    {
                        isQuery += ", Email = @varEmail";
                        cmd.Parameters.AddWithValue("@varEmail", empresa.Email);
                    }

                    isQuery += " Where Id = @varId";
                    cmd.Parameters.AddWithValue("@varId", empresa.Id);

                    cmd.CommandText = isQuery;

                    return (cmd.ExecuteNonQuery() > 0) ? true : false;
                }

                return false;
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
        /// Método que recupera um objeto Empresa
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa através do seu Id</param>
        /// <returns>Retorna o objeto Empresa</returns>
        public Empresa RecuperaEmpresa(Empresa empresa)
        {
            SqlCommand cmd = null;
            Empresa isEmpresa = null;
            try
            {
                cmd = Factory.AcessoDados();
                string isQuery = string.Empty;

                isQuery = "Select Id, Nome, Cpf_Cnpj, " +// Oficial, OficialSubstituto, Escrevente1, Escrevente2, Escrevente3, " +
                            "Logradouro, Bairro, Cep, Cidade, Estado, Email, Telefone " +
                            "From TB_Empresa ";

                if (empresa.Id > 0)
                {
                    isQuery += "Where Id = @varId";
                    cmd.Parameters.AddWithValue("@varId", empresa.Id);
                }

                cmd.CommandText = isQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isEmpresa = new Empresa(Convert.ToInt32(reader["Id"]));
                        isEmpresa.Nome = Convert.ToString(reader["Nome"]);
                        isEmpresa.Cpf_Cnpj = Convert.ToString(reader["Cpf_Cnpj"]);
                        //isEmpresa.Oficial = Convert.ToString(reader["Oficial"]);
                        //isEmpresa.OficialSubstituto = Convert.ToString(reader["OficialSubstituto"]);
                        //isEmpresa.Escrevente1 = Convert.ToString(reader["Escrevente1"]);
                        //isEmpresa.Escrevente2 = Convert.ToString(reader["Escrevente2"]);
                        //isEmpresa.Escrevente3 = Convert.ToString(reader["Escrevente3"]);
                        isEmpresa.Logradouro = Convert.ToString(reader["Logradouro"]);
                        isEmpresa.Bairro = Convert.ToString(reader["Bairro"]);
                        isEmpresa.Cep = Convert.ToString(reader["Cep"]);
                        isEmpresa.Cidade = Convert.ToString(reader["Cidade"]);
                        isEmpresa.Estado = Convert.ToString(reader["Estado"]);
                        isEmpresa.Email = Convert.ToString(reader["Email"]);
                        isEmpresa.Fone = Convert.ToString(reader["Telefone"]);
                    }
                }

                return (isEmpresa != null) ? isEmpresa : null;
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
        /// Método que recupera um objeto Empresa do Tipo Fornecedor
        /// </summary>
        /// <param name="empresa">Parametro para recuperar um objeto Empresa com o Tipo Fornecedor</param>
        /// <returns>Retorna uma lista de objetos Empresa Tipo Fornecedor </returns>
        public IList<Empresa> RecuperaEmpresaTipoFornecedor(Empresa empresa)
        {
            SqlCommand cmd = null;
            Empresa isEmpresa = null;
            IList<Empresa> lstEmpresaTpFornecedor = new List<Empresa>(); 
            try
            {
                cmd = Factory.AcessoDados();
                string isQuery = string.Empty;

                isQuery = "Select Id, Nome, Cpf_Cnpj, Logradouro, Bairro, Cep, Cidade, Estado, Email, Telefone " +
                            "From TB_Empresa " +
                            "Where IdEmpresa = @varId And Tipo = 'F'";

                cmd.Parameters.AddWithValue("@varId", empresa.Id);

                cmd.CommandText = isQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isEmpresa = new Empresa(Convert.ToInt32(reader["Id"]));
                        isEmpresa.Nome = Convert.ToString(reader["Nome"]);
                        isEmpresa.Cpf_Cnpj = Convert.ToString(reader["Cpf_Cnpj"]);
                        isEmpresa.Logradouro = Convert.ToString(reader["Logradouro"]);
                        isEmpresa.Bairro = Convert.ToString(reader["Bairro"]);
                        isEmpresa.Cep = Convert.ToString(reader["Cep"]);
                        isEmpresa.Cidade = Convert.ToString(reader["Cidade"]);
                        isEmpresa.Estado = Convert.ToString(reader["Estado"]);
                        isEmpresa.Email = Convert.ToString(reader["Email"]);
                        isEmpresa.Fone = Convert.ToString(reader["Telefone"]);
                        lstEmpresaTpFornecedor.Add(isEmpresa);
                    }
                }

                return (lstEmpresaTpFornecedor != null) ? lstEmpresaTpFornecedor : null;
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
