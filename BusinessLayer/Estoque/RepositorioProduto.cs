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
    public class RepositorioProduto : IRepositorioProduto
    {
        /// <summary>
        /// Método que Insere um novo Produto no Estoque
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        /// <returns>Retorna o Id do Produto</returns>
        public int CriarProduto(Produto produto)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (produto != null)
                {
                    cmd.CommandText = "Insert Into TB_Produtos (IdEmpresa, Descricao, UnidadeDeMedida, ValorUnitario, QuantidadeRealEstoque, QuantidadeMinimaEstoque, ConsumoInterno) " +
                                        "Values(@varIdEmpresa, @varDescricao, @varUnidadeDeMedida, @varValorUnitario, @varQuantidadeRealEstoque, @varQuantidadeMinimaEstoque, @varConsumoInterno)";

                    cmd.Parameters.AddWithValue("@varDescricao", produto.Descricao);
                    cmd.Parameters.AddWithValue("@varUnidadeDeMedida", produto.UnidadeDeMedida);
                    cmd.Parameters.AddWithValue("@varValorUnitario", produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@varQuantidadeRealEstoque", produto.QuantidadeRealEstoque);
                    cmd.Parameters.AddWithValue("@varQuantidadeMinimaEstoque", produto.QuantidadeMinimaEstoque);
                    cmd.Parameters.AddWithValue("@varConsumoInterno", produto.ConsumoInterno);

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
        /// Método que recupera uma lista de objetos Produtos com base em pesquisa
        /// </summary>
        /// <param name="produto">Parametro para recuperar produto</param>
        /// <returns>Retorna uma lista de objetos Produto</returns>
        public IList<Produto> RecuperarProduto(Produto produto)
        {
            SqlCommand cmd = null;
            IList<Produto> produtos = new List<Produto>();
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select * From TB_Produtos " +
                                    "Where IdEmpresa = @varIdEmpresa ";

                if (produto.Descricao != null)
                    strQuery += "And Descricao like @varDescricao";

                if (produto.Id > 0)
                    strQuery += "And Id = @varId";

                if (produto.Id > 0)
                    cmd.Parameters.AddWithValue("@varId", produto.Id);

                if(produto.Descricao != null)
                    cmd.Parameters.AddWithValue("@varDescricao", SqlDbType.VarChar).Value = "%" + produto.Descricao + "%";

                //if (produto.ConsumoInterno < 2)
                //{
                //    strQuery += " And ConsumoInterno = @varConsumoInterno";
                //    cmd.Parameters.AddWithValue("@varConsumoInterno", produto.ConsumoInterno);
                //}

                cmd.CommandText = strQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Produto isProduto = null;
                    while (reader.Read())
                    {
                        isProduto = new Produto();
                        isProduto.Id = Convert.ToInt32(reader["Id"]);
                        isProduto.Descricao = Convert.ToString(reader["Descricao"]);
                        isProduto.UnidadeDeMedida = Convert.ToString(reader["UnidadeDeMedida"]);
                        isProduto.ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]);
                        //isProduto.QuantidadeRealEstoque = Convert.ToDecimal(reader["QuantidadeRealEstoque"]);
                        isProduto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isProduto.ConsumoInterno = Convert.ToInt32(reader["ConsumoInterno"]);

                        produtos.Add(isProduto);
                    }
                }
                return (produtos != null) ? produtos : null;
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
        /// <param name="produto">Parametro para recuperação com o Id de produto e Empresa preenchidos</param>
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

        /// <summary>
        /// Método que Cria uma nova Movimentação de um Produto
        /// </summary>
        /// <param name="movimentacao">Objeto MovimentacaoEstoque com os Ids de Empresa, Fornecedor, Produto assim como Quantidade, Valor, Data e Status </param>
        /// <returns>Retorna o Id da movimentação</returns>
        public int CriarMovimentacaoProduto(MovimentacaoEstoque movimentacao)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (movimentacao != null)
                {
                    cmd.CommandText = "Insert Into TB_Movimento_Estoque (IdEmpresa, IdFornecedor, IdProduto, Quantidade, Valor, Data, Status, IdUsuario) " +
                                        "Values(@varIdEmpresa, @varIdFornecedor, @varIdProduto, @varQuantidade, @varValor, @varData, @varStatus, @varIdUsuario)";

                    cmd.Parameters.AddWithValue("@varIdFornecedor", movimentacao.Fornecedor.Id);
                    cmd.Parameters.AddWithValue("@varIdProduto", movimentacao.Produto.Id);
                    cmd.Parameters.AddWithValue("@varQuantidade", movimentacao.Produto.Entrada);
                    cmd.Parameters.AddWithValue("@varValor", movimentacao.Produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@varData", movimentacao.Data);
                    cmd.Parameters.AddWithValue("@varStatus", movimentacao.Status);
                    cmd.Parameters.AddWithValue("@varIdUsuario", movimentacao.Usuario.Id);

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
        /// Método que Insere um novo Produto relacionado a uma conta
        /// </summary>
        /// <param name="conta">Objeto Conta</param>
        /// <returns>Retorna o Id </returns>
        public int CriarProdutoConta(object conta)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (conta != null)
                {
                    cmd.CommandText = "Insert Into TB_Conta_Produtos (IdConta, IdProduto, Qtd, Vlr) " +
                                        "Values(@varIdConta, @varIdProduto, @varQtd, @varVlr)";


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
