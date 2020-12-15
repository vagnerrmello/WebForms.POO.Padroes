//-----------------------------------------------------------------------
// <copyright file="RepositorioProduto.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Estoque
{
    using System;
    using System.Collections.Generic;
    using Steto.ValueObjectLayer;
    using System.Data.SqlClient;
    using System.Data;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de usuário
    /// </summary>
    public class RepositorioFornecedor : IRepositorioForncedor
    {
        /// <summary>
        /// Método que Cria uma novo Fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor criado</returns>
        public int CriarFornecedor(Fornecedor fornecedor)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            string strQuery = string.Empty;
            string strValues = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                if (fornecedor != null)
                {
                    strQuery = "Insert Into TB_Fornecedores (Nome ,Cpf_Cnpj ,Logradouro ,Bairro ,Cep ,Cidade ,Estado ,Email ,Telefone ,InscricaoEstaual ,PessoaFisicaJuridica ,IdEmpresa) ";
                    strValues = "Values(@varNome ,@varCpf_Cnpj ,@varLogradouro ,@varBairro ,@varCep ,@varCidade ,@varEstado ,@varEmail ,@varTelefone ,@varInscricaoEstaual ,@varPessoaFisicaJuridica ,@varIdEmpresa)";

                    //cmd.Parameters.AddWithValue("@varNome", fornecedor.Empresa.Nome);
                    //cmd.Parameters.AddWithValue("@varCpf_Cnpj", fornecedor.Empresa.Cpf_Cnpj);
                    cmd.Parameters.AddWithValue("@varLogradouro", fornecedor.Logradouro.Descricao);
                    cmd.Parameters.AddWithValue("@varBairro", fornecedor.Logradouro.Descricao_Bairro);
                    cmd.Parameters.AddWithValue("@varCep", fornecedor.Logradouro.Cep);
                    cmd.Parameters.AddWithValue("@varCidade", fornecedor.Logradouro.Cidade);
                    cmd.Parameters.AddWithValue("@varEstado", fornecedor.Logradouro.Uf);
                    //cmd.Parameters.AddWithValue("@varEmail", fornecedor.Empresa.Email);
                    //cmd.Parameters.AddWithValue("@varTelefone", fornecedor.Empresa.Fone);
                    //cmd.Parameters.AddWithValue("@varInscricaoEstaual", fornecedor.Empresa.InscricaoEstadual);
                    //cmd.Parameters.AddWithValue("@varPessoaFisicaJuridica", fornecedor.Empresa.PessoaFisicaJuridica);
                    //cmd.Parameters.AddWithValue("@varIdEmpresa", fornecedor.Empresa.Id);

                    cmd.CommandText = strQuery + strValues;
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
        /// Método responsável para alterar Fornecedor 
        /// </summary>
        /// <param name="fornecedor">Fornecedor </param>
        /// <returns>true se ok</returns>
        public bool AlterarFornecedor(Fornecedor fornecedor)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Update TB_Fornecedores Set Nome = @varNome ,Cpf_Cnpj = @varCpf_Cnpj ,Logradouro = @varLogradouro ,Bairro = @varBairro ,Cep = @varCep ,Cidade = @varCidade ,Estado = @varEstado ,Email = @varEmail ,Telefone = @varTelefone ,InscricaoEstaual = @varInscricaoEstaual ,PessoaFisicaJuridica = @varPessoaFisicaJuridica ,IdEmpresa = @varIdEmpresa " +
                                    "Where Id = @varId";

                //cmd.Parameters.AddWithValue("@varNome", fornecedor.Empresa.Nome);
                //cmd.Parameters.AddWithValue("@varCpf_Cnpj", fornecedor.Empresa.Cpf_Cnpj);
                cmd.Parameters.AddWithValue("@varLogradouro", fornecedor.Logradouro.Descricao);
                cmd.Parameters.AddWithValue("@varBairro", fornecedor.Logradouro.Descricao_Bairro);
                cmd.Parameters.AddWithValue("@varCep", fornecedor.Logradouro.Cep);
                cmd.Parameters.AddWithValue("@varCidade", fornecedor.Logradouro.Cidade);
                cmd.Parameters.AddWithValue("@varEstado", fornecedor.Logradouro.Uf);
                //cmd.Parameters.AddWithValue("@varEmail", fornecedor.Empresa.Email);
                //cmd.Parameters.AddWithValue("@varTelefone", fornecedor.Empresa.Fone);
                //cmd.Parameters.AddWithValue("@varInscricaoEstaual", fornecedor.Empresa.InscricaoEstadual);
                //cmd.Parameters.AddWithValue("@varPessoaFisicaJuridica", fornecedor.Empresa.PessoaFisicaJuridica);
                //cmd.Parameters.AddWithValue("@varIdEmpresa", fornecedor.Empresa.Id);

                cmd.Parameters.AddWithValue("@varId", fornecedor.Id);

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
        /// Método que recupera um objeto Fornecedor por Id
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma Fornecedor por seu id</param>
        /// <returns>Retorna um objeto Fornecedor</returns>
        public Fornecedor RecuperarFornecedor(Fornecedor fornecedor)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "SELECT Id, Nome, Logradouro, Bairro, Cidade, Estado, Cep, Cpf_Cnpj, InscricaoEstaual, PessoaFisicaJuridica, Telefone, Email " +
                            "From TB_Fornecedores " +
                            "Where IdEmpresa = @varIdEmpresa ";
                
                //cmd.Parameters.AddWithValue("@varIdEmpresa", fornecedor.Empresa.Id);

                if (fornecedor.Id > 0)
                {
                    strQuery += "And Id = @varId ";
                    cmd.Parameters.AddWithValue("@varId", fornecedor.Id);
                }

                //if (fornecedor.Empresa.Cpf_Cnpj != null)
                //    if (!fornecedor.Empresa.Cpf_Cnpj.Equals(""))
                //    {
                //        strQuery += "And Cpf_Cnpj = @varCpf_Cnpj ";
                //        cmd.Parameters.AddWithValue("@varCpf_Cnpj", fornecedor.Empresa.Cpf_Cnpj);
                //    }

                cmd.CommandText = strQuery;

                Fornecedor isFornecedor = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isFornecedor = new Fornecedor();
                        isFornecedor.Id = Convert.ToInt32(reader["Id"]);
                        //isFornecedor.Empresa = new Empresa();
                        //isFornecedor.Empresa.Nome = Convert.ToString(reader["Nome"]);
                        //isFornecedor.Empresa.Cpf_Cnpj = Convert.ToString(reader["Cpf_Cnpj"]);
                        //isFornecedor.Empresa.InscricaoEstadual = Convert.ToString(reader["InscricaoEstaual"]);
                        //isFornecedor.Empresa.PessoaFisicaJuridica = Convert.ToString(reader["PessoaFisicaJuridica"]);
                        //isFornecedor.Empresa.Fone = Convert.ToString(reader["Telefone"]);
                        //isFornecedor.Empresa.Email = Convert.ToString(reader["Email"]);

                        Logradouro logradouro = new Logradouro();
                        logradouro.Descricao = Convert.ToString(reader["Logradouro"]);
                        logradouro.Descricao_Bairro = Convert.ToString(reader["Bairro"]);
                        logradouro.Cidade = Convert.ToString(reader["Cidade"]);
                        logradouro.Uf = Convert.ToString(reader["Estado"]);
                        logradouro.Cep = Convert.ToString(reader["Cep"]);
                        isFornecedor.Logradouro = logradouro;
                    }
                }
                return (isFornecedor != null) ? isFornecedor : null;
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
        /// Método que recupera uma lista de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Parametro para recuperar uma lista de Fornecedores por empresa</param>
        /// <returns>Retorna uma lista de objetos Fornecedor</returns>
        public IList<Fornecedor> RecuperarFornecedores(Fornecedor fornecedor)
        {
            SqlCommand cmd = null;
            IList<Fornecedor> lstFornecedores = new List<Fornecedor>();
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "SELECT Id, Nome, Logradouro, Bairro, Cidade, Estado, Cep, Cpf_Cnpj, InscricaoEstaual, PessoaFisicaJuridica " +
                            "From TB_Fornecedores " +
                            "Where IdEmpresa = @varIdEmpresa ";


                //cmd.Parameters.AddWithValue("@varIdEmpresa", fornecedor.Empresa.Id);

                //if (fornecedor.Empresa.Nome != null)
                //    if (!fornecedor.Empresa.Nome.Equals(""))
                //    {
                //        strQuery += "And Nome like @varNome ";
                //        cmd.Parameters.AddWithValue("@varNome", SqlDbType.NVarChar).Value = "%" + fornecedor.Empresa.Nome + "%";
                //    }

                cmd.CommandText = strQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Fornecedor isFornecedor = null;
                    while (reader.Read())
                    {
                        isFornecedor = new Fornecedor();
                        isFornecedor.Id = Convert.ToInt32(reader["Id"]);
                        isFornecedor.Nome = Convert.ToString(reader["Nome"]);
                        //isFornecedor.Empresa = new Empresa();
                        //isFornecedor.Empresa.Nome = Convert.ToString(reader["Nome"]);
                        //isFornecedor.Empresa.Cpf_Cnpj = Convert.ToString(reader["Cpf_Cnpj"]);
                        //isFornecedor.Empresa.InscricaoEstadual = Convert.ToString(reader["InscricaoEstaual"]);
                        //isFornecedor.Empresa.PessoaFisicaJuridica = Convert.ToString(reader["PessoaFisicaJuridica"]);

                        Logradouro logradouro = new Logradouro();
                        logradouro.Descricao = Convert.ToString(reader["Logradouro"]);
                        logradouro.Descricao_Bairro = Convert.ToString(reader["Bairro"]);
                        logradouro.Cidade = Convert.ToString(reader["Cidade"]);
                        logradouro.Uf = Convert.ToString(reader["Estado"]);
                        logradouro.Cep = Convert.ToString(reader["Cep"]);
                        isFornecedor.Logradouro = logradouro;

                        lstFornecedores.Add(isFornecedor);
                    }
                }
                return (lstFornecedores != null) ? lstFornecedores : null;
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
        /// Método que deleta dados de objetos Fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto Fornecedor com Id preenchido para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        public bool ExcluiFornecedor(Fornecedor fornecedor)
        {
            SqlCommand cmd = null;

            try
            {
                bool isRetorno = false;

                if (fornecedor != null)
                {

                    cmd = Factory.AcessoDados();

                    cmd.CommandText = "Delete From TB_Fornecedores Where Id = @varId";

                    cmd.Parameters.AddWithValue("@varId", fornecedor.Id);

                    isRetorno = (cmd.ExecuteNonQuery() > 0) ? true : false;
                    if (cmd != null) cmd.Dispose();
                    cmd = null;
                }

                return isRetorno;
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
