//-----------------------------------------------------------------------
// <copyright file="RepositorioNota.cs" company="Vikn">
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
    using Util;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de Notas
    /// </summary>
    public class RepositorioNota : IRepositorioNota
    {
        /// <summary>
        /// Método que Cria uma nova Nota
        /// </summary>
        /// <param name="nota">Objeto Nota</param>
        /// <returns>Retorna o Id da Nota</returns>
        public int CriarNota(Nota nota)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            string strQuery = string.Empty;
            string strValues = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                if (nota != null)
                {
                    strQuery = "Insert Into TB_Notas (IdFornecedor, NumeroNota, ValorParcela, Vencimento, IdEmpresa, ContasPagar, N_Parcela, Emissao, Cadastro";
                    if (nota.imagem != null)
                        strQuery += ", Comprovante";

                    strValues = "Values(@varIdFornecedor, @varNumeroNota, @varValorParcela, @varVencimento, @varIdEmpresa, @varContasPagar, @varN_Parcela, @varEmissao, @varCadastro";
                    if (nota.imagem != null)
                        strValues += ", @varComprovante";

                    strQuery += ") ";
                    strValues += ") ";

                    cmd.Parameters.AddWithValue("@varIdFornecedor", nota.Fornecedor.Id);
                    cmd.Parameters.AddWithValue("@varNumeroNota", nota.NumeroDocumento);
                    cmd.Parameters.AddWithValue("@varValorParcela", nota.Valor);
                    cmd.Parameters.AddWithValue("@varVencimento", nota.Vencimento);
                    cmd.Parameters.AddWithValue("@varContasPagar", nota.ContasPagar);
                    if (nota.imagem != null)
                        cmd.Parameters.AddWithValue("@varComprovante", nota.imagem);
                    cmd.Parameters.AddWithValue("@varN_Parcela", nota.NumeroParcela);
                    cmd.Parameters.AddWithValue("@varEmissao", nota.Emissao);
                    cmd.Parameters.AddWithValue("@varCadastro", nota.Cadastro);

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
        /// Método responsável para inserir o produto na Nota
        /// </summary>
        /// <param name="InserirProdutoNaNota">Objeto preenchido com o id da nota, id</param>
        /// <returns>Retorna o Id da Nota</returns>
        public int InserirProdutoNaNota(ProdutoNota InserirProdutoNaNota)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            try
            {
                cmd = Factory.AcessoDados();

                if (InserirProdutoNaNota != null)
                {

                    cmd.CommandText = "Insert Into TB_Nota_Produto (IdNota, IdProduto, IdEmpresa, QuantidadeEntrada, Ativo, ValorEntrada) " +
                                                "Values(@varIdNota, @varIdProduto, @varIdEmpresa, @varQuantidadeEntrada, @varAtivo, @varValorEntrada)";

                    cmd.Parameters.AddWithValue("@varIdNota", InserirProdutoNaNota.Nota.Id);
                    cmd.Parameters.AddWithValue("@varIdProduto", InserirProdutoNaNota.Produto.Id);
                    cmd.Parameters.AddWithValue("@varQuantidadeEntrada", InserirProdutoNaNota.Produto.Entrada);
                    cmd.Parameters.AddWithValue("@varValorEntrada", InserirProdutoNaNota.Produto.ValorUnitario);
                    cmd.Parameters.AddWithValue("@varAtivo", InserirProdutoNaNota.Ativo);

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
        /// Método responsável para Alterar um produto na Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna True se alteração realizada com sucesso</returns>
        public bool AlteraProdutoNaNota(Nota Nota)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (Nota != null)
                {
                    cmd.CommandText = "Update  TB_Nota_Produto Set " +
                                        "QuantidadeEntrada = @varQuantidadeEntrada, " +
                                        "Ativo = @varAtivo, " +
                                        "ValorEntrada = @varValorEntrada " +
                                        "Where IdEmpresa = @varIdEmpresa " +
                                        "And IdProduto = @IdProduto";

                    cmd.Parameters.AddWithValue("@varQuantidadeEntrada", Nota.Produto.Entrada);
                    cmd.Parameters.AddWithValue("@varAtivo", Nota.Produto.Ativo);
                    cmd.Parameters.AddWithValue("@varValorEntrada", Nota.Produto.ValorUnitario);

                    cmd.Parameters.AddWithValue("@IdProduto", Nota.Produto.Id);

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
        /// Método responsável para Atualizar uma Nota
        /// </summary>
        /// <param name="Nota">Objeto com todas propriedades preenchidas</param>
        /// <returns>Retorna um booleano</returns>
        public bool AtualizaNota(Nota Nota)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (Nota != null)
                {
                    cmd.CommandText = "Update  TB_Notas Set " +
                                        "IdFornecedor = @varIdFornecedor " +
                                        ",Cadastro = @varCadastro " +
                                        ",ValorParcela = @varValorParcela " +
                                        ",Emissao = @varEmissao " +
                                        ",Vencimento = @varVencimento " +
                                        ",IdEmpresa = @varIdEmpresa " +
                                        ",ContasPagar = @varContasPagar " +
                                        ",N_Parcela = @varN_Parcela " +
                                        "Where Id = @varId";

                    cmd.Parameters.AddWithValue("@varIdFornecedor", Nota.Fornecedor.Id);
                    cmd.Parameters.AddWithValue("@varCadastro", Nota.Cadastro);
                    cmd.Parameters.AddWithValue("@varValorParcela", Nota.Valor);
                    cmd.Parameters.AddWithValue("@varVencimento", Nota.Emissao);
                    cmd.Parameters.AddWithValue("@varVencimento", Nota.Vencimento);
                    cmd.Parameters.AddWithValue("@varContasPagar", Nota.ContasPagar);
                    cmd.Parameters.AddWithValue("@varN_Parcela", Nota.NumeroParcela);
                    cmd.Parameters.AddWithValue("@varId", Nota.Id);

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
        /// Método responsável para Excluir um Produto da Nota
        /// </summary>
        /// <param name="ExcluirProdutoDaNota">Objeto preenchido com o id da Nota e Produto</param>
        public void ExcluirProdutoDaNota(ProdutoNota ExcluirProdutoDaNota)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText = "Delete From TB_Nota_Produto Where idNota = @varidNota And IdProduto = @varIdProduto";

                cmd.Parameters.AddWithValue("@varidNota", ExcluirProdutoDaNota.Nota.Id);
                cmd.Parameters.AddWithValue("@varIdProduto", ExcluirProdutoDaNota.Produto.Id);

                cmd.ExecuteNonQuery();
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
        /// Método que recupera um objeto ProdutoNota 
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar um Produto vinculado a Nota para verificação</param>
        /// <returns>Retorna um Produto vinculado a nota</returns>
        public ProdutoNota RecuperarProdutoNaNota(ProdutoNota ProdutoNota)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select Id, IdProduto, IdEmpresa, IdNota From TB_Nota_Produto " +
                            "Where IdProduto = @varIdProduto " +
                            "And IdEmpresa = @varIdEmpresa " +
                            "And IdNota = @varIdNota";

                cmd.Parameters.AddWithValue("@varIdNota", ProdutoNota.Nota.Id);
                cmd.Parameters.AddWithValue("@varIdProduto", ProdutoNota.Produto.Id);

                cmd.CommandText = strQuery;

                ProdutoNota isProdutoNota = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isProdutoNota = new ProdutoNota(Convert.ToInt32(reader["Id"]));
                        isProdutoNota.Produto = new Produto(Convert.ToInt32(reader["IdProduto"]));
                        isProdutoNota.Nota = new Nota(Convert.ToInt32(reader["IdNota"]));
                        isProdutoNota.Produto.Entrada = Convert.ToDecimal(reader["QuantidadeEntrada"]);
                        isProdutoNota.Produto.ValorUnitario = Convert.ToDecimal(reader["ValorEntrada"]);
                        isProdutoNota.Ativo = Convert.ToString(reader["Ativo"]);
                    }
                }
                return (isProdutoNota != null) ? isProdutoNota : null;
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
        /// Método que recupera um objeto ProdutoNota para inserção
        /// </summary>
        /// <param name="ProdutoNota">Parametro para recuperar Produto(s) vinculado(s) a Nota</param>
        /// <returns>Retorna uma lista de Produtos vinculadas a nota</returns>
        public IList<Produto> RecuperaUmaListaDeProdutosNaNota(ProdutoNota ProdutoNota)
        {
            IList<Produto> lstProdutos = new List<Produto>();
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select p.Id, p.Descricao, p.UnidadeDeMedida, p.ValorUnitario, p.QuantidadeRealEstoque, p.QuantidadeMinimaEstoque, p.ConsumoInterno, p.IdEmpresa " +
                            "From TB_Produtos p, TB_Nota_Produto np " +
                            "Where np.IdProduto = p.Id " +
                            "And np.IdEmpresa = @varIdEmpresa " +
                            "And np.IdNota = @varIdNota";

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
                        isProduto.ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]);
                        isProduto.QuantidadeRealEstoque = Convert.ToDecimal(reader["QuantidadeRealEstoque"]);
                        isProduto.QuantidadeMinimaEstoque = Convert.ToDecimal(reader["QuantidadeMinimaEstoque"]);
                        isProduto.ConsumoInterno = Convert.ToInt32(reader["ConsumoInterno"]);

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
        /// Método que recupera uma lista de Notas
        /// </summary>
        /// <param name="Nota">Parametro para recuperar Notas de uma empresa com o número Vencimento e empresa que pertence a nota</param>
        /// <returns>Retorna uma lista de Notas</returns>
        public IList<Nota> RecuperaNotas(Nota Nota)
        {
            IList<Nota> lstNotas = new List<Nota>();
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select n.IdEmpresa, e.Nome As Empresa, n.NumeroNota, f.Nome As Fornecedor, f.Id As IdFornecedor, n.N_Parcela, n.Id As IdNota, n.ValorParcela, n.Vencimento, n.ContasPagar " +
                            "From TB_Notas n, TB_Empresa e, TB_Fornecedores f " +
                            "Where n.IdEmpresa = e.Id " +
                            "And n.IdFornecedor = f.Id " +
                            "And n.IdEmpresa = @varIdEmpresa ";
                            


                if (Nota.NumeroDocumento != null)
                    if (!Nota.NumeroDocumento.Equals(""))
                    {
                        strQuery += "And n.NumeroNota like @varNumeroNota ";
                        cmd.Parameters.AddWithValue("@varNumeroNota", SqlDbType.VarChar).Value = "%" + Nota.NumeroDocumento + "%";
                    }

                if (Validacao.IsData(Nota.Vencimento.ToString("dd/MM/yyyy")))
                {
                    strQuery += "And Vencimento = @varVencimento "; 
                    cmd.Parameters.AddWithValue("@varVencimento", Nota.Vencimento);
                }

                cmd.CommandText = strQuery;

                Nota isNota = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isNota = new Nota(Convert.ToInt32(reader["IdNota"]));
                        isNota.NumeroDocumento = Convert.ToString(reader["NumeroNota"]);
                        isNota.NumeroParcela = Convert.ToString(reader["N_Parcela"]);
                        isNota.Valor = Convert.ToDecimal(reader["ValorParcela"]);
                        isNota.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        isNota.ContasPagar = Convert.ToInt32(reader["ContasPagar"]);

                        Empresa empresa = new Empresa(Convert.ToInt32(reader["IdEmpresa"]));
                        empresa.Nome = Convert.ToString(reader["Empresa"]);

                        Fornecedor fornecedor = new Fornecedor(Convert.ToInt32(reader["IdFornecedor"]));
                        isNota.Fornecedor = fornecedor;

                        lstNotas.Add(isNota);
                    }
                }
                return (lstNotas != null) ? lstNotas : null;
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
        /// Método que uma lista de contas (Pagar/Receber)
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna uma lista de Contas Cadastrada para uma nota</returns>
        public Nota RecuperaUmaConta(Nota nota)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select cp.Id, n.NumeroNota, n.N_Parcela, cp.Vencimento, cp.Valor, cp.Status, cp.idNota, cp.PagarReceber " +
                                    "From TB_ContasPagar cp, TB_Notas n " +
                                    "Where cp.idNota = n.Id " +
                                    "And n.IdEmpresa = @varIdEmpresa " +
                                    "And n.Id = @varIdNota";

                cmd.Parameters.AddWithValue("@varIdNota", nota.Id);


                cmd.CommandText = strQuery;

                Nota isNota = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isNota = new Nota();
                        isNota.Id = Convert.ToInt32(reader["Id"]);
                        isNota = new Nota(Convert.ToInt32(reader["idNota"]));
                        isNota.NumeroDocumento = Convert.ToString(reader["NumeroNota"]);
                        isNota.NumeroParcela = Convert.ToString(reader["N_Parcela"]);
                        isNota.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        isNota.Valor = Convert.ToDecimal(reader["Valor"]);
                        //isConta.Status = Convert.ToString(reader["Status"]);
                        ////isConta.Comprovante = (Byte[])(reader["Comprovante"]);
                        //isConta.PagarReceber = Convert.ToString(reader["PagarReceber"]);
                    }
                }
                return (isNota != null) ? isNota : null;
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
        /// Método que Verifica se uma Nota já existe
        /// </summary>
        /// <param name="conta">Objeto do tipo Nota</param>
        /// <returns>Retorna uma Nota Existente</returns>
        public Nota VerificaNotaExistente(Nota nota)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select n.Cadastro, n.Id, n.IdFornecedor, n.NumeroNota, n.ValorParcela, n.Emissao, n.Vencimento, n.IdEmpresa, n.ContasPagar, n.Comprovante, n.N_Parcela " +
                            "From TB_Notas n  " +
                            "Where  n.IdEmpresa = @varIdEmpresa " +
                            "And n.Id = @varId " +
                            "And n.NumeroNota = @varNumeroNota ";

                cmd.Parameters.AddWithValue("@varId", nota.Id);
                cmd.Parameters.AddWithValue("@varNumeroNota", nota.NumeroDocumento);

                cmd.CommandText = strQuery;

                Nota isNota = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isNota = new Nota();
                        isNota.Id = Convert.ToInt32(reader["Id"]);
                        isNota.Cadastro = Convert.ToDateTime(reader["Cadastro"]);
                        isNota.Fornecedor = new Fornecedor(Convert.ToInt32(reader["IdFornecedor"]));
                        isNota.NumeroDocumento = Convert.ToString(reader["NumeroNota"]);
                        isNota.Valor = Convert.ToDecimal(reader["ValorParcela"]);
                        isNota.Emissao = Convert.ToDateTime(reader["Emissao"]);
                        isNota.Vencimento = Convert.ToDateTime(reader["Vencimento"]);
                        isNota.ContasPagar = Convert.ToInt32(reader["ContasPagar"]);
                        //isNota.imagem  = (Byte[])(reader["Comprovante"]);
                        isNota.NumeroParcela = Convert.ToString(reader["N_Parcela"]);
                    }
                }
                return (isNota != null) ? isNota : null;
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
