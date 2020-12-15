//-----------------------------------------------------------------------
// <copyright file="RepositorioEndereco.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Endereco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using Steto.ValueObjectLayer;
    using Steto.ValueObjectLayer.Endereco;

    public class RepositorioEndereco : IRepositorioEndereco
    {
        /// <summary>
        /// Método que recupera Pais
        /// </summary>
        /// <param name="pais">Parametro para recuperar uma lista de paises</param>
        /// <returns>Retorna uma lista de objetos Pais</returns>
        public IList<Pais> RecuperarPais()
        {
            SqlCommand cmd = null;
            IList<Pais> paises = new List<Pais>();
            Pais pais = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Nome, Sigla1, Sigla2 From TB_Paises " +
                                    "Order By Nome asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pais = new Pais(Convert.ToInt32(reader["Id"]));
                        pais.Nome = Convert.ToString(reader["Nome"]);
                        pais.Sigla1 = Convert.ToString(reader["Sigla1"]);
                        pais.Sigla2 = Convert.ToString(reader["Sigla2"]);

                        paises.Add(pais);
                    }
                }
                return (paises.Count > 0) ? paises : null;
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
        /// Método que recupera Estado
        /// </summary>
        /// <returns>Retorna uma lista de objetos Estado</returns>
        public IList<Estado> RecuperarEstado()
        {
            SqlCommand cmd = null;
            IList<Estado> estados = new List<Estado>();
            Estado estado = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Estado, Sigla From TB_Estados " +
                                    "Order By Estado asc";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estado = new Estado(Convert.ToInt32(reader["Id"]));
                        estado.Nome = Convert.ToString(reader["Estado"]);
                        estado.Sigla = Convert.ToString(reader["Sigla"]);

                        estados.Add(estado);
                    }
                }
                return (estados.Count > 0) ? estados : null;
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
        /// Método que recupera Cidade
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        public IList<Cidade> RecuperarCidade(Estado estado)
        {
            SqlCommand cmd = null;
            IList<Cidade> cidades = new List<Cidade>();
            Cidade cidade = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Cidade From TB_Cidades " +
                                    "Where IdEstado = @varId " +
                                    "Order By Cidade asc";

                cmd.Parameters.AddWithValue("@varId", estado.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cidade = new Cidade(Convert.ToInt32(reader["Id"]));
                        cidade.Nome = Convert.ToString(reader["Cidade"]);

                        cidades.Add(cidade);
                    }
                }
                return (cidades.Count > 0) ? cidades : null;
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
        /// Método que recupera todos os Bairros de uma Cidade
        /// </summary>
        /// <param name="cidade">Parametro para recuperar uma lista de Bairros</param>
        /// <returns>Retorna uma lista de objetos Bairro</returns>
        public IList<Bairro> RecuperarBairros(Cidade cidade)
        {
            SqlCommand cmd = null;
            IList<Bairro> bairros = new List<Bairro>();
            Bairro bairro = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Bairro From TB_Bairros " +
                                    "Where IdCidade = @varId " +
                                    "Order By Bairro asc";

                cmd.Parameters.AddWithValue("@varId", cidade.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bairro = new Bairro(Convert.ToInt32(reader["Id"]));
                        bairro.Nome = Convert.ToString(reader["Bairro"]);

                        bairros.Add(bairro);
                    }
                }
                return (bairros.Count > 0) ? bairros : null;
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
        /// Método que recupera Cidade com código do ibge
        /// </summary>
        /// <param name="estado">Parametro para recuperar uma lista de cidades</param>
        /// <returns>Retorna uma lista de objetos Cidade</returns>
        public IList<Cidade> RecuperarCidadeIBGE(Estado estado)
        {
            SqlCommand cmd = null;
            IList<Cidade> cidades = new List<Cidade>();
            Cidade cidade = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select Id, Sigra_UF, Codigo_IBGE, Municipio From TB_Cidades_IBGE " +
                                  "Where Sigra_UF = (Select e.Sigla From TB_Estados e Where e.Id = @varEstado) " +
                                  "Order By Municipio asc";

                cmd.Parameters.AddWithValue("@varEstado", estado.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cidade = new Cidade(Convert.ToInt32(reader["Codigo_IBGE"]));
                        cidade.Codgigo_IBGE = Convert.ToInt32(reader["Codigo_IBGE"]);
                        cidade.Nome = Convert.ToString(reader["Municipio"]) + "-" + Convert.ToString(reader["Codigo_IBGE"]);

                        cidades.Add(cidade);
                    }
                }
                return (cidades.Count > 0) ? cidades : null;
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
        /// Método que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        public bool InsereLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (logradouro != null)
                {
                    cmd.CommandText = "Insert Into TB_Logradouro (Endereco, Complemento, Numero, IdBairro, IdCidade, IdUf, Cep, IdCliente) " +
                                      "Values(@varEndereco, @varComplemento, @varNumero, @varIdBairro, @varIdCidade, @varIdUf, @varCep, @varIdCliente)";

                    cmd.Parameters.AddWithValue("@varEndereco", logradouro.Endereco);
                    cmd.Parameters.AddWithValue("@varComplemento", logradouro.Complemento);
                    cmd.Parameters.AddWithValue("@varNumero", logradouro.Numero);
                    cmd.Parameters.AddWithValue("@varIdBairro", logradouro.Bairro.Id);
                    cmd.Parameters.AddWithValue("@varIdCidade", logradouro.Cidade.Id);
                    cmd.Parameters.AddWithValue("@varIdUf", logradouro.Estado.Id);
                    cmd.Parameters.AddWithValue("@varCep", logradouro.Cep);
                    cmd.Parameters.AddWithValue("@varIdCliente", logradouro.Cliente.Id);

                    return (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que atualiza um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para atualização de Logradouro</param>
        /// <returns>Retorna True caso a atualização tenha sido com sucesso</returns>
        public bool AtualizaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (logradouro != null)
                {
                    cmd.CommandText = "Update TB_Logradouro Set " +
                                      "Endereco = @varEndereco " +
                                      ", Complemento = @varComplemento " +
                                      ", Numero = @varNumero " +
                                      ", IdBairro = @varIdBairro " +
                                      ", IdCidade = @varIdCidade " +
                                      ", IdUf = @varIdUf " +
                                      ", Cep = @varCep " +
                                      ", IdParte = @varIdParte " +
                                      "Where Id = @varId";

                    cmd.Parameters.AddWithValue("@varEndereco", logradouro.Endereco);
                    cmd.Parameters.AddWithValue("@varComplemento", logradouro.Complemento);
                    cmd.Parameters.AddWithValue("@varNumero", logradouro.Numero);
                    cmd.Parameters.AddWithValue("@varIdBairro", logradouro.Bairro.Id);
                    cmd.Parameters.AddWithValue("@varIdCidade", logradouro.Cidade.Id);
                    cmd.Parameters.AddWithValue("@varIdUf", logradouro.Estado.Id);
                    cmd.Parameters.AddWithValue("@varCep", logradouro.Cep);
                    cmd.Parameters.AddWithValue("@varId", logradouro.Id);

                    return (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por deletar um logradouro de uma parte
        /// </summary>
        /// <param name="logradouro">Recebe um objeto Logradouro</param>
        public bool DeletaLogradouro(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText = "Delete From TB_Logradouro Where Id = @varId";

                cmd.Parameters.AddWithValue("@varId", logradouro.Id);

                return (cmd.ExecuteNonQuery() > 0)? true : false;
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
        /// Método que recupera o(s) Logradouro(s) pertencente a uma Parte
        /// </summary>
        /// <param name="parte">Parametro para recuperar uma lista de Objetos tipo Logradouro através do Id de Parte</param>
        /// <returns>Retorna todos os objetos Logradouro que pertencente a uma Parte</returns>
        public List<ValueObjectLayer.Endereco.Logradouro> RecuperaLogradouros(object parte)
        {
            SqlCommand cmd = null;
            List<ValueObjectLayer.Endereco.Logradouro> Logradouros = new List<ValueObjectLayer.Endereco.Logradouro>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select l.Id, l.Endereco, l.Complemento, l.Numero, l.IdBairro, l.IdCidade, l.IdUf, l.Cep, l.idPais, e.Sigla, c.Cidade, b.Bairro " +
                                  "From TB_Logradouro l, TB_Estados e, TB_Cidades c, TB_Bairros b " +
                                  "Where l.IdUf = e.Id " +
                                  "And l.IdCidade = c.Id " +
                                  "And l.IdBairro = b.Id " +
                                  "And IdParte  = @varIdParte";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ValueObjectLayer.Endereco.Logradouro logradouro = new ValueObjectLayer.Endereco.Logradouro(Convert.ToInt32(reader["Id"]));
                        logradouro.Endereco = Convert.ToString(reader["Endereco"]);
                        logradouro.Complemento = Convert.ToString(reader["Complemento"]);
                        logradouro.Numero = Convert.ToString(reader["Numero"]);
                        logradouro.Bairro = new Bairro(Convert.ToInt32(reader["IdBairro"]));
                        logradouro.Bairro.Nome = Convert.ToString(reader["Bairro"]);
                        logradouro.Cidade = new Cidade(Convert.ToInt32(reader["IdCidade"]));
                        logradouro.Cidade.Nome = Convert.ToString(reader["Cidade"]);
                        logradouro.Estado = new Estado(Convert.ToInt32(reader["IdUf"]));
                        logradouro.Estado.Sigla = Convert.ToString(reader["Sigla"]);
                        logradouro.Cep = Convert.ToString(reader["Cep"]);

                        Logradouros.Add(logradouro);
                        logradouro = null;
                    }
                }
                return (Logradouros != null) ? Logradouros : null;
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
        /// Método que recupera um Logradouro
        /// </summary>
        /// <param name="IsLogradouro">Parametro para recuperar um Objeto tipo Logradouro através do seu Id Parte</param>
        /// <returns>Retorna um objeto Logradouro</returns>
        public ValueObjectLayer.Endereco.Logradouro RecuperaLogradouro(ValueObjectLayer.Endereco.Logradouro IsLogradouro)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select l.Id, l.Endereco, l.Complemento, l.Numero, l.IdBairro, l.IdCidade, l.IdUf, l.Cep, l.idPais, e.Sigla, c.Cidade, b.Bairro " +
                                  "From TB_Logradouro l, TB_Estados e, TB_Cidades c, TB_Bairros b " +
                                  "Where l.IdUf = e.Id " +
                                  "And l.IdCidade = c.Id " +
                                  "And l.IdBairro = b.Id " +
                                  "And l.Id  = @varId";

                cmd.Parameters.AddWithValue("@varId", IsLogradouro.Id);

                ValueObjectLayer.Endereco.Logradouro logradouro = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        logradouro = new ValueObjectLayer.Endereco.Logradouro(Convert.ToInt32(reader["Id"]));
                        logradouro.Endereco = Convert.ToString(reader["Endereco"]);
                        logradouro.Complemento = Convert.ToString(reader["Complemento"]);
                        logradouro.Numero = Convert.ToString(reader["Numero"]);
                        logradouro.Bairro = new Bairro(Convert.ToInt32(reader["IdBairro"]));
                        logradouro.Bairro.Nome = Convert.ToString(reader["Bairro"]);
                        logradouro.Cidade = new Cidade(Convert.ToInt32(reader["IdCidade"]));
                        logradouro.Cidade.Nome = Convert.ToString(reader["Cidade"]);
                        logradouro.Estado = new Estado(Convert.ToInt32(reader["IdUf"]));
                        logradouro.Estado.Sigla = Convert.ToString(reader["Sigla"]);
                        logradouro.Cep = Convert.ToString(reader["Cep"]);
                    }
                }
                return (logradouro != null) ? logradouro : null;
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
        /// Método que insere um Logradouro
        /// </summary>
        /// <param name="logradouro">Parametro para inserção de Logradouro</param>
        /// <returns>Retorna True caso a inserção tenha sido com sucesso</returns>
        public bool InsereEndereco(ValueObjectLayer.Endereco.Logradouro logradouro)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                if (logradouro != null)
                {
                    cmd.CommandText = "Insert Into TB_Enderecos (IdCliente, TipoEndereco, Logradouro, Complemento, Numero, IdBairro, IdCidade, IdUf, Cep, Observacao) " +
                                      "Values(@varIdCliente, @varTipoEndereco, @varLogradouro, @varComplemento, @varNumero, @varIdBairro, @varIdCidade, @varIdUf, @varCep, @varObservacao)";

                    cmd.Parameters.AddWithValue("@varIdCliente", logradouro.Cliente.Id);
                    cmd.Parameters.AddWithValue("@varTipoEndereco", logradouro.TiposLogradouro.ToString());
                    cmd.Parameters.AddWithValue("@varLogradouro", logradouro.Endereco);
                    cmd.Parameters.AddWithValue("@varComplemento", logradouro.Complemento);
                    cmd.Parameters.AddWithValue("@varNumero", logradouro.Numero);
                    cmd.Parameters.AddWithValue("@varIdBairro", logradouro.Bairro.Id);
                    cmd.Parameters.AddWithValue("@varIdCidade", logradouro.Cidade.Id);
                    cmd.Parameters.AddWithValue("@varIdUf", logradouro.Estado.Id);
                    cmd.Parameters.AddWithValue("@varCep", logradouro.Cep);
                    if(logradouro.Observacao != null)
                        cmd.Parameters.AddWithValue("@varObservacao", logradouro.Observacao);

                    return (cmd.ExecuteNonQuery() > 0) ? true : false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
