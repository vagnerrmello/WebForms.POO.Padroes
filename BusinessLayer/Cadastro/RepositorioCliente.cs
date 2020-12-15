//-----------------------------------------------------------------------
// <copyright file="RepositorioCliente.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Steto.ValueObjectLayer;
    using Util;

    /// <summary>
    /// Armazena as informações provenientes do repositório Cliente
    /// </summary>
    public class RepositorioCliente : IRepositorioCliente
    {
        /// <summary>
        /// Método que cria um novo Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente</param>
        /// <returns>Id do Cliente</returns>
        public int InsereCliente(Cliente cliente)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                Int32 newID = 0;
                string isQuery = string.Empty;

                string isValue = string.Empty;

                if (cliente != null)
                {
                    isQuery = "Insert Into TB_Clientes (";
                    isValue += "Values( ";

                    if (cliente.Nome != null)
                    {
                        isQuery += ", Nome";
                        isValue += ", @varNome";
                        cmd.Parameters.AddWithValue("@varNome", cliente.Nome);
                    }

                    if (cliente.CPF != null)
                    {
                        isQuery += ", CPF";
                        isValue += ", @varCPF";
                        cmd.Parameters.AddWithValue("@varCPF", cliente.CPF.Replace(".", "").Replace("-", ""));
                    }

                    if (cliente.Sexo != null)
                    {
                        isQuery += ", Sexo";
                        isValue += ", @varSexo";
                        cmd.Parameters.AddWithValue("@varSexo", cliente.Sexo);
                    }

                    if (cliente.Nascimento != null)
                    {
                        isQuery += ", Nascimento";
                        isValue += ", @varNascimento";
                        cmd.Parameters.AddWithValue("@varNascimento", cliente.Nascimento);
                    }

                    if (cliente.Deficiencia != null)
                    {
                        isQuery += ", Deficiencia";
                        isValue += ", @varDeficiencia";
                        cmd.Parameters.AddWithValue("@varDeficiencia", cliente.Deficiencia);
                    }

                    if (cliente.Tipo_Sanguineo != null)
                    {
                        isQuery += ", Tipo_Sanguineo";
                        isValue += ", @varTipo_Sanguineo";
                        cmd.Parameters.AddWithValue("@varTipo_Sanguineo", cliente.Tipo_Sanguineo);
                    }

                    if (cliente.Registro_Nascimento != null)
                    {
                        isQuery += ", Registro_Nascimento";
                        isValue += ", @varRegistro_Nascimento";
                        cmd.Parameters.AddWithValue("@varRegistro_Nascimento", cliente.Registro_Nascimento);
                    }

                    if (cliente.CNS != null)
                    {
                        isQuery += ", CNS";
                        isValue += ", @varCNS";
                        cmd.Parameters.AddWithValue("@varCNS", cliente.CNS);
                    }

                    if (cliente.Alergia != null)
                    {
                        isQuery += ", Alergia";
                        isValue += ", @varAlergia";
                        cmd.Parameters.AddWithValue("@varAlergia", cliente.Alergia);
                    }

                    if (cliente.Plano_Saude != null)
                    {
                        isQuery += ", Plano_Saude";
                        isValue += ", @varPlano_Saude";
                        cmd.Parameters.AddWithValue("@varPlano_Saude", cliente.Plano_Saude);
                    }

                    if (cliente.Plano_Matricula != null)
                    {
                        isQuery += ", Plano_Matricula";
                        isValue += ", @varPlano_Matricula";
                        cmd.Parameters.AddWithValue("@varPlano_Matricula", cliente.Plano_Matricula);
                    }

                    if (cliente.Plano_Validade != null)
                    {
                        isQuery += ", Plano_Validade";
                        isValue += ", @varPlano_Validade";
                        cmd.Parameters.AddWithValue("@varPlano_Validade", cliente.Plano_Validade);
                    }

                    if (cliente.Plano_Titular != null)
                    {
                        isQuery += ", Plano_Titular";
                        isValue += ", @varPlano_Titular";
                        cmd.Parameters.AddWithValue("@varPlano_Titular", cliente.Plano_Titular);
                    }

                    if (cliente.Outras_Obs != null)
                    {
                        isQuery += ", Outras_Obs";
                        isValue += ", @varOutras_Obs";
                        cmd.Parameters.AddWithValue("@varOutras_Obs", cliente.Outras_Obs);
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
        /// Método que recupera vários objetos Clientes por Empresa
        /// </summary>
        /// <param name="cliente"> Um objeto Cliente com o Parametro Id da Empresa preenchida</param>
        /// <returns>Retorna uma lista de objetos Cliente por Empresa</returns>
        public IList<Cliente> RecuperaVariosClientesPorEmpresa(Cliente cliente)
        {
            SqlCommand cmd = null;
            Cliente isCliente = null;
            IList<Cliente> lstClientes = new List<Cliente>(); 
            try
            {
                cmd = Factory.AcessoDados();
                string isQuery = string.Empty;

                isQuery = "Select Id, Nome, CPF, IdEmpresa, Email " +
                            "From TB_Clientes " +
                            "Where IdEmpresa = @varId ";

                cmd.CommandText = isQuery;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isCliente = new Cliente(Convert.ToInt32(reader["Id"]));
                        isCliente.Nome = Convert.ToString(reader["Nome"]);
                        isCliente.CPF = Convert.ToString(reader["CPF"]);
                        isCliente.Email = Convert.ToString(reader["Email"]);
                        lstClientes.Add(isCliente);
                    }
                }

                return (lstClientes != null) ? lstClientes : null;
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
        /// Método que cria um novo Responsável
        /// </summary>
        /// <param name="cliente">Objeto Cliente para inserir um novo responsável</param>
        /// <returns>Id do Cliente</returns>
        public int InsereResponsavel(Cliente cliente)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                Int32 newID = 0;
                string isQuery = string.Empty;

                string isValue = string.Empty;

                if (cliente != null)
                {
                    isQuery = "Insert Into TB_Responsaveis (";
                    isValue += "Values( ";

                    if (cliente.Nome != null)
                    {
                        isQuery += ", Nome";
                        isValue += ", @varNome";
                        cmd.Parameters.AddWithValue("@varNome", cliente.Nome);
                    }

                    if (cliente.CPF != null)
                    {
                        isQuery += ", CPF";
                        isValue += ", @varCPF";
                        cmd.Parameters.AddWithValue("@varCPF", cliente.CPF.Replace(".", "").Replace("-", ""));
                    }

                    if (cliente.Identidade != null)
                    {
                        isQuery += ", Identidade";
                        isValue += ", @varIdentidade";
                        cmd.Parameters.AddWithValue("@varIdentidade", cliente.Identidade);
                    }

                    if (cliente.Fone!= null)
                    {
                        isQuery += ", Fone";
                        isValue += ", @varFone";
                        cmd.Parameters.AddWithValue("@varFone", cliente.Fone);
                    }

                    if (cliente.Parentesco != null)
                    {
                        isQuery += ", Parentesco";
                        isValue += ", @varParentesco";
                        cmd.Parameters.AddWithValue("@varParentesco", cliente.Parentesco);
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
        /// Método que Atualiza um Responsável de um Cliente
        /// </summary>
        /// <param name="cliente">Objeto Cliente para atualizar um responsável</param>
        /// <returns>Id do true, caso sucesso</returns>
        public bool AtualizaResponsavel(Cliente cliente)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                //Int32 newID = 0;
                string isQuery = string.Empty;

                string isValue = string.Empty;

                if (cliente != null)
                {
                    isQuery = "Update TB_Responsaveis Set";

                    if (cliente.Nome != null)
                    {
                        isQuery += " Nome = @varNome";
                        cmd.Parameters.AddWithValue("@varNome", cliente.Nome);
                    }

                    if (cliente.CPF != null)
                    {
                        if (cliente.Nome != null) isQuery += ", ";

                        isQuery += "CPF = @varCPF";
                        cmd.Parameters.AddWithValue("@varCPF", cliente.CPF.Replace(".", "").Replace("-", ""));
                    }

                    if (cliente.Identidade != null)
                    {
                        if (cliente.CPF != null) isQuery += ", ";

                        isQuery += "Identidade = @varIdentidade";
                        cmd.Parameters.AddWithValue("@varIdentidade", cliente.Identidade);
                    }

                    if (cliente.Fone != null)
                    {
                        if (cliente.Identidade != null) isQuery += ", ";

                        isQuery += "Fone = @varFone";
                        cmd.Parameters.AddWithValue("@varFone", cliente.Fone);
                    }

                    if (cliente.Parentesco != null)
                    {
                        if (cliente.Fone != null) isQuery += ", ";

                        isQuery += "Parentesco = @varParentesco";
                        cmd.Parameters.AddWithValue("@varParentesco", cliente.Parentesco);
                    }

                    isQuery += " Where Id = @varId";
                    cmd.Parameters.AddWithValue("@varId", cliente.Id);

                    cmd.CommandText = isQuery;

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

    }
}
