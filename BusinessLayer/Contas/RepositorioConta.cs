//-----------------------------------------------------------------------
// <copyright file="RepositorioConta.cs" company="Vikn">
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
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de TB_ContasPagar
    /// </summary>
    public class RepositorioConta : IRepositorioConta
    {
        /// <summary>
        /// Método que Insere uma conta (Pagar/Receber)
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna o Id da Conta Cadastrada</returns>
        public int InserirConta(object conta)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            string strQuery = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                if (conta != null)
                {
                    strQuery = "Insert Into TB_ContasPagar (Valor, Vencimento, Status, ";

                    cmd.CommandText = strQuery;
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
        /// Método que Cadastra uma conta (Pagar/Receber)
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna o Id da Conta Cadastrada</returns>
        public int CadastraConta(object conta)
        {
            SqlCommand cmd = null;
            Int32 newID = 0;
            string strQuery = string.Empty;
            string strQueryValues = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                if (conta != null)
                {
                    strQuery = "Insert Into TB_ContasPagar (";
                    strQueryValues += " Values(";

               

                    strQuery += ")";
                    strQueryValues += ")";

                    cmd.CommandText = strQuery + strQueryValues;
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
        /// Método que Atualiza uma conta(Pagar/Receber) já cadastrada
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna true(verdadeiro) caso a atualização tenha sido realizada com sucesso</returns>
        public bool AtualizarConta(object conta)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                if (conta != null)
                {
                    strQuery = "UPDATE TB_ContasPagar Set ";

 

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
        /// Método que recupera uma lista de contas (Pagar/Receber)
        /// </summary>
        /// <param name="conta">Objeto do tipo Conta</param>
        /// <returns>Retorna uma lista de Contas Cadastrada para uma nota</returns>
        public void RecuperaUmaListaDeContas(object conta)
        {
            SqlCommand cmd = null;
            string strQuery = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                strQuery = "Select cp.Id, n.NumeroNota, n.N_Parcela, cp.Vencimento, cp.Valor, cp.Status, cp.idNota, cp.PagarReceber " +
                                    "From TB_ContasPagar cp, TB_Notas n " +
                                    "Where cp.idNota = n.Id " +
                                    "And n.IdEmpresa = @varIdEmpresa ";


     
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
