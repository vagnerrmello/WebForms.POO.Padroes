//-----------------------------------------------------------------------
// <copyright file="RepositorioSolicitacao.cs" company="Vikn">
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
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados das Solicitacões
    /// </summary>
    public class RepositorioSolicitacao : IRepositorioSolicitacao
    {
        /// <summary>
        /// Método que Insere uma nova Solicitacao
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao</returns>
        public int CriarSolicitacao(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (solicitacao != null)
                {
                    cmd.CommandText = "Insert Into TB_Solicitacao(IdFuncionario, Data_Solicitacao, Status) Values(@varIdFuncionario, @varData_Solicitacao, @varStatus)";

                    cmd.Parameters.AddWithValue("@varIdFuncionario", solicitacao.Funcionario.Id);
                    cmd.Parameters.AddWithValue("@varData_Solicitacao", solicitacao.Data_Solicitacao);
                    cmd.Parameters.AddWithValue("@varStatus", solicitacao.Status);

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
        /// Método que altera uma Solicitação 
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitação</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AlteraSolicitacao(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                if (solicitacao != null)
                {
                    strQuery = "Update TB_Solicitacao Set ";
                                
                    if (solicitacao.Funcionario != null)
                    {
                        if (solicitacao.Id > 0)
                        {
                            strQuery += "IdFuncionario = @varIdFuncionario, ";
                            cmd.Parameters.AddWithValue("@varIdFuncionario", solicitacao.Funcionario.Id);
                        }
                    }

                    if (Util.Validacao.IsData(solicitacao.Data_Solicitacao.ToString()))
                    {
                        strQuery += "Data_Solicitacao = @varData_Solicitacao, ";
                        cmd.Parameters.AddWithValue("@varData_Solicitacao", solicitacao.Data_Solicitacao);
                    }

                    if (solicitacao.Status != null)
                    {
                        strQuery += "Status = @varStatus ";
                        cmd.Parameters.AddWithValue("@varStatus", solicitacao.Data_Solicitacao);
                    }

                    strQuery += "Where Id = @varId ";
                    cmd.Parameters.AddWithValue("@varId", solicitacao.Id);

                    cmd.CommandText = strQuery;

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
        /// Método que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        public int CriarSolicitacaoEstoque(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (solicitacao != null)
                {
                    cmd.CommandText = "Insert Into TB_Solicitacao_Estoque(IdSolicitacao, IdEstoque, Quantidade) Values(@varIdSolicitacao, @varIdEstoque, @varQuantidade)";

                    cmd.Parameters.AddWithValue("@varIdSolicitacao", solicitacao.Id);
                    cmd.Parameters.AddWithValue("@varIdEstoque", solicitacao.Estoque.Id);
                    cmd.Parameters.AddWithValue("@varQuantidade", solicitacao.Quantidade);

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
        /// Método que Insere uma nova Solicitacao em Estoque
        /// </summary>
        /// <param name="solicitacao">Objeto Solicitacao</param>
        /// <returns>Retorna o Id da Solicitacao em Estoque</returns>
        public int CriarSolicitacaoAnalise(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (solicitacao != null)
                {
                    cmd.CommandText = "Insert Into TB_Solicitacao_Analise(IdUsuario, IdSolicitacao, Observacao) " +
                                        "Values(@varIdIdUsuario, @varIdSolicitacao, @varObservacao)";

                    cmd.Parameters.AddWithValue("@varIdSolicitacao", solicitacao.Usuario.Id);
                    cmd.Parameters.AddWithValue("@varIdSolicitacao", solicitacao.Id);
                    cmd.Parameters.AddWithValue("@varObservacao", solicitacao.Observacao);

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
        /// Método que altera o produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AlteraProduto(Produto produto)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (produto != null)
                {
                    cmd.CommandText = "Update TB_Produtos Set Descricao = @varDescricao, UnidadeDeMedida = @varUnidadeDeMedida, " +
                                        "ValorUnitario = @varValorUnitario, QuantidadeRealEstoque = @varQuantidadeRealEstoque, " +
                                        "QuantidadeMinimaEstoque = @varQuantidadeMinimaEstoque, ConsumoInterno = @varConsumoInterno " +
                                        "Where Id = @varId ";

                    cmd.Parameters.AddWithValue("@varDescricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@varUnidadeDeMedida", produto.UnidadeDeMedida);
                    cmd.Parameters.AddWithValue("@varValorUnitario", produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@varQuantidadeRealEstoque", produto.QuantidadeRealEstoque);
                    cmd.Parameters.AddWithValue("@varQuantidadeMinimaEstoque", produto.QuantidadeMinimaEstoque);
                    cmd.Parameters.AddWithValue("@varConsumoInterno", produto.ConsumoInterno);
                    cmd.Parameters.AddWithValue("@varId", produto.Id);

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
        /// Método que altera apenas a Quantidade do produto 
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AlteraQuantidadeProduto(Produto produto)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (produto != null)
                {
                    cmd.CommandText = "Update TB_Produtos Set QuantidadeRealEstoque = @varQuantidadeRealEstoque " +
                                        "Where Id = @varId ";

                    cmd.Parameters.AddWithValue("@varQuantidadeRealEstoque", produto.QuantidadeRealEstoque);
                    cmd.Parameters.AddWithValue("@varId", produto.Id);

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
        /// Método que recupera uma lista de Solicitações 
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar uma lista de solicitações. Obrigatório passa a empresa</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        public IList<Solicitacao> RecuperarListaDeSolicitacoes(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            IList<Solicitacao> solicitacoes = new List<Solicitacao>();
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select e.Id As IdEmpresa, e.Nome As NomeEmpresa, s.Id As NumeroSolictacao, s.Data_Solicitacao, s.Status As StatusSolicitacao,  f.Nome As NomeFuncionario " +
                            "From TB_Solicitacao s, TB_Funcionarios f, TB_Empresa e " +
                            "Where s.IdFuncionario = f.Id " +
                            "And f.IdEmpresa = e.Id " +
                            "And e.Id = @varIdEmpresa ";

                //cmd.Parameters.Add("@varIdEmpresa", SqlDbType.Int).Value = solicitacao.Empresa.Id;

                if (solicitacao.Status != null)
                {
                    strQuery += "And s.Status = @varStatus ";
                    cmd.Parameters.Add("@varStatus", SqlDbType.VarChar).Value = solicitacao.Status;
                }

                if (solicitacao.Id > 0)
                {
                    strQuery += "And s.Id like @varIdSolicitacao ";
                    cmd.Parameters.AddWithValue("@varIdSolicitacao", SqlDbType.VarChar).Value = "%" + solicitacao.Id + "%";
                }

                if (Util.Validacao.IsData(solicitacao.Data_Solicitacao.ToString()))
                {
                    strQuery += "And s.Id = @Data ";
                    cmd.Parameters.Add("@Data", SqlDbType.DateTime).Value = solicitacao.Data_Solicitacao;
                }

                cmd.CommandText = strQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Solicitacao isSolicitacao = null;
                    while (reader.Read())
                    {
                        isSolicitacao = new Solicitacao(Convert.ToInt32(reader["NumeroSolictacao"]));
                        isSolicitacao.Data_Solicitacao = Convert.ToDateTime(reader["Data_Solicitacao"]);
                        isSolicitacao.Status = Convert.ToString(reader["StatusSolicitacao"]);

                        isSolicitacao.Funcionario = new Funcionario();
                        isSolicitacao.Funcionario.Nome = Convert.ToString(reader["NomeFuncionario"]);

                        //isSolicitacao.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        //isSolicitacao.Empresa.Nome = Convert.ToString(reader["NomeEmpresa"]);

                        solicitacoes.Add(isSolicitacao);
                    }
                }
                return (solicitacoes != null) ? solicitacoes : null;
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
        /// Método que recupera uma lista de Solicitações Para Análise
        /// </summary>
        /// <param name="solicitacao">Parametro para recuperar várias solicitações</param>
        /// <returns>Retorna uma lista de solicitações</returns>
        public IList<Solicitacao> RecuperarSolicitacaoAnalise(Solicitacao solicitacao)
        {
            SqlCommand cmd = null;
            IList<Solicitacao> solicitacoes = new List<Solicitacao>();
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select e.Id As IdEmpresa, e.Nome As NomeEmpresa, s.Id As NumeroSolictacao, s.Data_Solicitacao, s.Status As StatusSolicitacao,  f.Nome As NomeFuncionario, est.Id As IdProdutoEstoque, p.Descricao, se.Quantidade " +
                            "From TB_Empresa e, TB_Solicitacao s, TB_Solicitacao_Estoque se, TB_Estoque est, TB_Produtos p, TB_Funcionarios f " +
                            "Where se.IdSolicitacao = s.Id " +
                            "And s.IdFuncionario = f.Id " +
                            "And f.IdEmpresa = e.Id " +
                            "And se.IdEstoque = est.Id " +
                            "And est.IdProduto = p.Id " +
                            "And est.IdEmpresa = e.Id " +
                            "And e.Id = @varIdEmpresa ";

                //cmd.Parameters.Add("@varIdEmpresa", SqlDbType.Int).Value = solicitacao.Empresa.Id;

                if (solicitacao.Status != null)
                {
                    strQuery += "And s.Status = @varStatus ";
                    cmd.Parameters.Add("@varStatus", SqlDbType.VarChar).Value = solicitacao.Status;
                }

                if (solicitacao.Id > 0)
                {
                    strQuery += "And s.Id like @varIdSolicitacao ";
                    cmd.Parameters.AddWithValue("@varIdSolicitacao", SqlDbType.VarChar).Value = "%" + solicitacao.Id + "%";
                }

                if(Util.Validacao.IsData(solicitacao.Data_Solicitacao.ToString()))
                {
                    strQuery += "And s.Id = @Data ";
                    cmd.Parameters.Add("@Data", SqlDbType.DateTime).Value = solicitacao.Data_Solicitacao;
                }

                cmd.CommandText = strQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Solicitacao isSolicitacao = null;
                    while (reader.Read())
                    {
                        isSolicitacao = new Solicitacao(Convert.ToInt32(reader["NumeroSolictacao"]));
                        isSolicitacao.Data_Solicitacao = Convert.ToDateTime(reader["Data_Solicitacao"]);
                        isSolicitacao.Status = Convert.ToString(reader["StatusSolicitacao"]);
                        isSolicitacao.Quantidade = Convert.ToDecimal(reader["Quantidade"]);

                        isSolicitacao.Funcionario = new Funcionario();
                        isSolicitacao.Funcionario.Nome = Convert.ToString(reader["NomeFuncionario"]);

                        isSolicitacao.Estoque = new Estoque(Convert.ToInt32(reader["IdProdutoEstoque"]));

                        isSolicitacao.Produto = new Produto();
                        isSolicitacao.Produto.Descricao = Convert.ToString(reader["Descricao"]);
                        
                        //isSolicitacao.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        //isSolicitacao.Empresa.Nome = Convert.ToString(reader["NomeEmpresa"]);

                        solicitacoes.Add(isSolicitacao);
                    }
                }
                return (solicitacoes != null) ? solicitacoes : null;
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
        /// Método que recupera um objeto Produto por seu Id
        /// </summary>
        /// <param name="produto">Parametro para recuperar produto com Id preenchido</param>
        /// <returns>Retorna objeto Produto</returns>
        public Produto RecuperarUmProduto(Produto produto)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select * From TB_Produtos " +
                                    "Where IdEmpresa = @varIdEmpresa " +
                                    "And Id = @varId ";

                //cmd.Parameters.AddWithValue("@varIdEmpresa", produto.Empresa.Id);
                cmd.Parameters.AddWithValue("@varId", produto.Id);

                cmd.CommandText = strQuery;

                Produto isProduto = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isProduto = new Produto();
                        isProduto.Id = Convert.ToInt32(reader["Id"]);
                        isProduto.Descricao = Convert.ToString(reader["Descricao"]);
                        isProduto.UnidadeDeMedida = Convert.ToString(reader["UnidadeDeMedida"]);
                        isProduto.ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]);
                        isProduto.QuantidadeRealEstoque = Convert.ToDecimal(reader["QuantidadeRealEstoque"]);
                        isProduto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isProduto.ConsumoInterno = Convert.ToInt32(reader["ConsumoInterno"]);

                        //isProduto.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                    }
                }
                return (isProduto != null) ? isProduto : null;
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
        /// Método que Desativa um produto no sistema
        /// </summary>
        /// <param name="id">Parametro com o id do produto</param>
        /// <returns>Retorna True se ok</returns>
        public bool DesativarProduto(Produto produto)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (produto.Id != 0)
                {

                    cmd.CommandText = "Update TB_Produtos Set Ativo = @varAtivo " +
                                        "Where Id = @varId ";

                    cmd.Parameters.AddWithValue("@varAtivo", "N");
                    cmd.Parameters.AddWithValue("@varId", produto.Id);

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
