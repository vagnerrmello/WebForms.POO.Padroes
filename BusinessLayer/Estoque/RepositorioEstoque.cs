//-----------------------------------------------------------------------
// <copyright file="RepositorioEstoque.cs" company="Vikn">
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
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de Estoque
    /// </summary>
    public class RepositorioEstoque : IRepositorioEstoque
    {
        /// <summary>
        /// Método que Insere um Produto no Estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque</param>
        /// <returns>Retorna o Id do Estoque</returns>
        public int InserirEstoque(Estoque estoque)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (estoque != null)
                {
                    cmd.CommandText = "Insert Into TB_Estoque (IdEmpresa, IdFornecedor, IdProduto, Quantidade) " +
                                        "Values(@varIdEmpresa, @varIdFornecedor, @varIdProduto, @varQuantidade)";

                    //cmd.Parameters.AddWithValue("@varIdEmpresa", estoque.Empresa.Id);
                    cmd.Parameters.AddWithValue("@varIdFornecedor", estoque.Fornecedor.Id);
                    cmd.Parameters.AddWithValue("@varIdProduto", estoque.Produto.Id);
                    cmd.Parameters.AddWithValue("@varQuantidade", estoque.Quantidade);

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
        /// Método que recupera um objeto Estoque 
        /// </summary>
        /// <param name="estoque">Parametro para recuperar Estoque</param>
        /// <returns>Retorna um objeto Estoque</returns>
        public Estoque RecuperarProdutoNoEstoque(Estoque estoque)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select e.Id As IdEstoque, p.id As IdProduto, p.Descricao, e.Quantidade, p.QuantidadeMinimaEstoque, ep.Id AS IdEmpresa, ep.Nome AS NomeEmpresa, f.Id AS IdFornecedor, f.Nome AS NomeFornecedor " +
                                    "From TB_Estoque e, TB_Empresa ep, TB_Fornecedores f, TB_Produtos p " +
                                    "Where e.IdEmpresa = ep.Id " +
                                    "And e.IdFornecedor = f.Id " +
                                    "And e.IdProduto = p.Id " +
                                    "And e.IdEmpresa = @varIdEmpresa ";
                                    

                //cmd.Parameters.AddWithValue("@varIdEmpresa", estoque.Empresa.Id);

                if(estoque.Produto != null)
                    if (estoque.Produto.Id > 0)
                    {
                        cmd.Parameters.AddWithValue("@varIdProduto", estoque.Produto.Id);
                        strQuery += "And e.IdProduto = @varIdProduto ";
                    }

                if (estoque.Id > 0)
                {
                    strQuery += "And e.Id = @varIdEstoque ";
                    cmd.Parameters.AddWithValue("@varIdEstoque", estoque.Id);
                }

                if (estoque.Fornecedor != null)
                    if (estoque.Fornecedor.Id > 0)
                    {
                        cmd.Parameters.AddWithValue("@varIdFornecedor", estoque.Fornecedor.Id);
                        strQuery += "And e.IdFornecedor = @varIdFornecedor ";
                    }

                cmd.CommandText = strQuery;

                Estoque isEstoque = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isEstoque = new Estoque(Convert.ToInt32(reader["IdEstoque"]));
                        isEstoque.Produto = new Produto(Convert.ToInt32(reader["IdProduto"]));
                        isEstoque.Produto.Descricao = Convert.ToString(reader["Descricao"]);
                        isEstoque.Quantidade = Convert.ToDecimal(reader["Quantidade"]);
                        isEstoque.Produto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isEstoque.Produto.QuantidadeRealEstoque = Convert.ToDecimal(reader["Quantidade"]);
                        //isEstoque.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        //isEstoque.Empresa.Nome = Convert.ToString(reader["NomeEmpresa"]);
                        isEstoque.Fornecedor = new Fornecedor(Convert.ToInt32(reader["IdFornecedor"]));
                        isEstoque.Fornecedor.Nome = Convert.ToString(reader["NomeFornecedor"]);
                    }
                }

                return (isEstoque != null) ? isEstoque : null;
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
        /// Método que recupera uma Lista de Produtos no Estoque Relacionadas a Nota
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota Existentes no Estoque</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Nota</returns>
        public IList<Produto> RecuperaUmaListaDeProdutosNoEstoqueRelacionadasANota(ProdutoNota ProdutoNota)
        {
            IList<Produto> lstProdutos = new List<Produto>();
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select p.Id,  p.Descricao, np.QuantidadeEntrada, np.ValorEntrada, np.Ativo, e.Quantidade, np.IdNota, p.UnidadeDeMedida, p.ValorUnitario, p.QuantidadeRealEstoque, p.QuantidadeMinimaEstoque, p.ConsumoInterno, p.IdEmpresa " +
                            "From TB_Produtos p, TB_Nota_Produto np, TB_Estoque e " +
                            "Where np.IdProduto = p.Id " +
                            "And np.IdProduto = e.IdProduto " +
                            "And np.IdEmpresa = @varIdEmpresa " +
                            "And np.IdNota = @varIdNota";

                //cmd.Parameters.AddWithValue("@varIdEmpresa", ProdutoNota.Empresa.Id);
                cmd.Parameters.AddWithValue("@varIdNota", ProdutoNota.Nota.Id);

                cmd.CommandText = strQuery;

                Produto isProduto = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isProduto = new Produto(Convert.ToInt32(reader["Id"]));
                        isProduto.Descricao = Convert.ToString(reader["Descricao"]);
                        isProduto.UnidadeDeMedida = Convert.ToString(reader["UnidadeDeMedida"]);
                        if (reader["ValorEntrada"] != System.DBNull.Value)
                            isProduto.ValorUnitario = Convert.ToDecimal(reader["ValorEntrada"]);
                        isProduto.QuantidadeRealEstoque = Convert.ToDecimal(reader["Quantidade"]);
                        isProduto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isProduto.Entrada = Convert.ToDecimal(reader["QuantidadeEntrada"]);
                        isProduto.ConsumoInterno = Convert.ToInt32(reader["ConsumoInterno"]);
                        //isProduto.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        isProduto.Ativo = Convert.ToString(reader["Ativo"]);

                        lstProdutos.Add(isProduto);
                    }
                }
                return (lstProdutos != null) ? lstProdutos : null;
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
        /// Método que recupera uma Lista de Produtos no Estoque Relacionadas a Empresa
        /// </summary>
        /// <param name="Produto">Parametro para recuperar Produto(s) vinculado(s) a Empresa</param>
        /// <returns>Retorna uma lista de Produtos Existentes no Estoque vinculadas a Empresa</returns>
        public IList<Produto> RecuperaUmaListaDeProdutosNoEstoquePorEmpresa(Produto Produto)
        {
            IList<Produto> lstProdutos = new List<Produto>();
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select p.Id,  p.Descricao, e.Quantidade, p.UnidadeDeMedida, p.ValorUnitario, p.QuantidadeRealEstoque, p.QuantidadeMinimaEstoque, p.ConsumoInterno, p.IdEmpresa " +
                            "From TB_Produtos p, TB_Estoque e " +
                            "Where p.Id = e.IdProduto " +
                            "And p.IdEmpresa = @varIdEmpresa ";

                //cmd.Parameters.AddWithValue("@varIdEmpresa", Produto.Empresa.Id);

                cmd.CommandText = strQuery;

                Produto isProduto = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isProduto = new Produto(Convert.ToInt32(reader["Id"]));
                        isProduto.Descricao = Convert.ToString(reader["Descricao"]);
                        isProduto.UnidadeDeMedida = Convert.ToString(reader["UnidadeDeMedida"]);
                        isProduto.ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]);
                        isProduto.QuantidadeRealEstoque = Convert.ToDecimal(reader["Quantidade"]);
                        isProduto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isProduto.ConsumoInterno = Convert.ToInt32(reader["ConsumoInterno"]);
                        //isProduto.Empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));

                        lstProdutos.Add(isProduto);
                    }
                }
                return (lstProdutos != null) ? lstProdutos : null;
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
        /// Método que altera a quantidade do produto no estoque 
        /// </summary>
        /// <param name="estoque">Objeto Estoque com a quantidade a ser alterada</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool AlteraQuantidadeDoProdutoNoEstoque(Estoque estoque)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = Factory.AcessoDados();

                if (estoque != null)
                {
                    cmd.CommandText = "Update TB_Estoque Set Quantidade = @varQuantidade " +
                                        "Where IdEmpresa = @varIdEmpresa " +
                                        "And IdProduto = @varIdProduto";

                    cmd.Parameters.AddWithValue("@varQuantidade", estoque.Quantidade);
                    //cmd.Parameters.AddWithValue("@varIdEmpresa", estoque.Empresa.Id);
                    cmd.Parameters.AddWithValue("@varIdProduto", estoque.Produto.Id);

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
        /// Método que deleta um produto em estoque
        /// </summary>
        /// <param name="estoque">Objeto Estoque com Id da Empresa e do Produto preenchidos para deleção</param>
        /// <returns>Retorna True se sucesso na deleção</returns>
        public bool ExcluiProdutoNoEstoque(Estoque estoque)
        {
            SqlCommand cmd = null;

            try
            {
                bool isRetorno = false;

                if (estoque != null)
                {
                    cmd = Factory.AcessoDados();

                    cmd.CommandText = "Delete From TB_Estoque " +
                                        "Where IdEmpresa = @varIdEmpresa " +
                                        "And IdProduto = @varIdProduto";

                    //cmd.Parameters.AddWithValue("@varIdEmpresa", estoque.Empresa.Id);
                    cmd.Parameters.AddWithValue("@varIdProduto", estoque.Produto.Id);

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
