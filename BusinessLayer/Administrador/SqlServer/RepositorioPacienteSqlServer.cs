//-----------------------------------------------------------------------
// <copyright file="RepositorioPacienteSqlServer.cs" company="Steto">
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
    using Steto.BusinessLayer;

    public class RepositorioPacienteSqlServer : IRepositorioPacienteSqlServer
    {
        /// <summary>
        /// Método que cria um novo paciente para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto paciente</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool CriarPaciente(Paciente paciente)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (paciente != null)
                {
                    cmd.CommandText = "Insert Into TB_Pacientes (Nome, Identidade, CPF, CNS, Sexo, EstadoCivil, Cor, Profissao, Nascimento, Imagem) " +
                                      "Values(@varNome, @varIdentidade, @varCPF, @varCNS, @varSexo, @varEstadoCivil, @varCor, @varProfissao, @varNascimento, @varImagem)";

                    paciente.CPF = paciente.CPF.Replace(".", "").Replace("-", "");
                    cmd.Parameters.AddWithValue("@varNome", paciente.Nome);
                    cmd.Parameters.AddWithValue("@varIdentidade", paciente.Identidade);
                    cmd.Parameters.AddWithValue("@varCPF", paciente.CPF);
                    cmd.Parameters.AddWithValue("@varCNS", paciente.CNS);
                    cmd.Parameters.AddWithValue("@varSexo", paciente.Sexo);
                    cmd.Parameters.AddWithValue("@varEstadoCivil", paciente.EstadoCivil);
                    cmd.Parameters.AddWithValue("@varCor", paciente.Cor);
                    cmd.Parameters.AddWithValue("@varProfissao", paciente.Cbo.Codigo);
                    cmd.Parameters.AddWithValue("@varNascimento", paciente.Nascimento);
                    cmd.Parameters.AddWithValue("@varImagem", paciente.Imagem);

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
        /// Método que recupera um paciente
        /// </summary>
        /// <param name="idPaciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public ValueObjectLayer.Paciente RecuperarPaciente(int idPaciente)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Paciente paciente = null;

            try
            {
                idPaciente = 3;//TODO: APAGAR DEPOIS, APENAS PARA TESTE
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Pacientes " +
                                  "Where Id = @varId ";

                cmd.Parameters.AddWithValue("@varId", idPaciente);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paciente = new ValueObjectLayer.Paciente();
                        paciente.Id = Convert.ToInt32(reader["Id"]);
                        paciente.Nome = Convert.ToString(reader["Nome"]);
                        paciente.Identidade = Convert.ToString(reader["Identidade"]);
                        paciente.CPF = Convert.ToString(reader["CPF"]);
                        paciente.CNS = Convert.ToString(reader["CNS"]);
                        if(reader["Imagem"] != System.DBNull.Value)
                            paciente.Imagem = (byte[])reader["Imagem"]; 
                            
                    }
                }
                return (paciente != null) ? paciente : null;
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
        /// Método que recupera um paciente
        /// </summary>
        /// <param name="idPaciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public ValueObjectLayer.Paciente RecuperarPaciente(Paciente paciente)
        {
            SqlCommand cmd = null;
            ValueObjectLayer.Paciente isPaciente = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Pacientes " +
                                  "Where Nome = @varNome " +
                                  "And Identidade = @varIdentidade " +
                                  "And CPF = @varCPF " +
                                  "And CNS = @varCNS ";

                cmd.Parameters.AddWithValue("@varNome", paciente.Nome);
                cmd.Parameters.AddWithValue("@varIdentidade", paciente.Identidade);
                cmd.Parameters.AddWithValue("@varCPF", paciente.CPF);
                cmd.Parameters.AddWithValue("@varCNS", paciente.CNS);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isPaciente = new ValueObjectLayer.Paciente(Convert.ToInt32(reader["Id"]));
                    }
                }
                return (isPaciente != null) ? isPaciente : null;
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
        /// Método que recupera uma lista de  paciente
        /// </summary>
        /// <param name="paciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public List<Paciente> PesquisarPaciente(Paciente paciente)
        {
            SqlCommand cmd = null;
            List<Paciente> pacientes = new List<Paciente>();
            string query = string.Empty;
            string isWhere = string.Empty;
            try
            {
                cmd = Factory.AcessoDados();

                query = "Select p.Id, p.Nome, p.CPF " +
                        "From TB_Pacientes p ";

                if (paciente.Nome != null)
                {
                    isWhere += "Where p.Nome like '%" + paciente.Nome + "%' ";
                }

                if (paciente.CPF != null)
                {
                    if (isWhere.Equals(""))
                    {
                        isWhere += " Where";
                    }
                    else
                    {
                        isWhere += " And";
                    }

                    isWhere += " p.CPF = @varCPF";
                    string isCpf = paciente.CPF.Replace(".", "").Replace("-", "");
                    cmd.Parameters.AddWithValue("@varCPF", isCpf);
                }
                
                cmd.CommandText = query + isWhere;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Paciente isPaciente = new Paciente();
                        isPaciente.Id = Convert.ToInt32(reader["Id"]);
                        isPaciente.Nome = Convert.ToString(reader["Nome"]);
                        isPaciente.CPF = Convert.ToString(reader["CPF"]);

                        pacientes.Add(isPaciente);
                        isPaciente = null;
                    }
                }
                return (pacientes != null) ? pacientes : null;
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
        /// Método que recupera um paciente para edição
        /// </summary>
        /// <param name="paciente">Parametro para recuperação de paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        public Paciente EditarPaciente(Paciente paciente)
        {
            SqlCommand cmd = null;
            Paciente isPaciente = new Paciente();
            string query = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();

                query = "Select Id, Nome, CPF " +
                        "From TB_Pacientes " +
                        "And Id = %varId";

                cmd.Parameters.AddWithValue("@varId", paciente.Nome);

                cmd.CommandText = query;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        isPaciente.Id = Convert.ToInt32(reader["Id"]);
                        isPaciente.Nome = Convert.ToString(reader["Nome"]);
                        isPaciente.CPF = Convert.ToString(reader["CPF"]);
                    }
                }
                return (isPaciente != null) ? isPaciente : null;
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
        /// Método responsável por vincular um contato ao paciente
        /// </summary>
        /// <param name="contato">Objeto contato</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool VincularContatoAoPaciente(Contato contato)
        {
            SqlCommand cmd = null;
            string queryInsert = string.Empty;
            string queryValues = string.Empty;

            try
            {
                cmd = Factory.AcessoDados();
                
                if (contato != null)
                {

                    cmd.CommandText = "Insert Into TB_Contato (IdPaciente, IdTipoEndereco, IdTipoContato, Contato) " +
                                      "Values(@varIdPaciente, @varIdTipoEndereco, @varIdTipoContato, @varContato)";
                     
                    cmd.Parameters.AddWithValue("@varIdPaciente", contato.Paciente_.Id);
                    cmd.Parameters.AddWithValue("@varIdTipoEndereco", contato.TipoLogradouro_.Id);
                    cmd.Parameters.AddWithValue("@varIdTipoContato", contato.TipoDeContato);
                    //cmd.Parameters.AddWithValue("@varContato", contato.Contato_);

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
        /// Método responsável por deletar os contatos de um paciente
        /// </summary>
        /// <param name="paciente">Objeto contato</param>
        /// <returns>True se ocorrer tudo ok</returns>
        public bool DeletarVinculoDeContatoAoPaciente(Paciente paciente)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (paciente != null)
                {
                    cmd.CommandText = "Delete From TB_Contato Where IdPaciente = @varIdPaciente";

                    cmd.Parameters.AddWithValue("@varIdPaciente", paciente.Id);

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
        /// Método responsável por recuperar todos os CBOs (Código Brasileiro de Ocupação)
        /// </summary>
        /// <returns>return uma lista com todos os objetos CBO</returns>
        public IList<CBO> RecuperarCBO()
        {
            SqlCommand cmd = null;
            IList<CBO> cbos = new List<CBO>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_CBO Order By Codigo";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CBO cbo = new CBO();
                        cbo.Id = Convert.ToInt32(reader["Id"]);
                        cbo.Codigo = Convert.ToString(reader["Codigo"]);
                        cbo.Descricao = Convert.ToString(reader["Descricao"]);
                        cbos.Add(cbo);
                    }
                }

                return cbos != null ? cbos : null;
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
