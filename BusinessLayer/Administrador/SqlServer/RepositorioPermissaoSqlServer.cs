//-----------------------------------------------------------------------
// <copyright file="RepositorioPermissaoSqlServer.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;
    using System.Data.SqlClient;

    /// <summary>
    /// Classe de repositório que persiste/consulta as informações provenientes da base de dados de Permissao
    /// </summary>
    public class RepositorioPermissaoSqlServer : IRepositorioPermissaoSqlServer
    {
        /// <summary>
        /// Método responsável por recuperar as permissões da funcionalidade
        /// </summary>
        /// <param name="idFuncionalidade">Identificação da funcionalidade</param>
        /// <returns>Retorna uma lista de objeto do tipo ValueObjectLayer.Permissao_Funcionalidade</returns>
        public IList<ValueObjectLayer.Permissao_Funcionalidade> RecuperaPermissaoPorFuncionalidade(int idFuncionalidade)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Permissao_Funcionalidade> listaPermissoesFuncionalidades = 
                new List<ValueObjectLayer.Permissao_Funcionalidade>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Permissao_Funcionalidade " +
                                    "Where IdFuncionalidade = @varId " +
                                    "Order By IdPermissao asc";

                cmd.Parameters.AddWithValue("@varId", idFuncionalidade);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPermissoesFuncionalidades.Add(
                            new ValueObjectLayer.Permissao_Funcionalidade(
                                Convert.ToInt32(reader["Id"]),
                                new ValueObjectLayer.Permissao(Convert.ToInt32(reader["IdPermissao"])),
                                new ValueObjectLayer.Funcionalidade(Convert.ToInt32(reader["IdFuncionalidade"]))));
                    }
                }

                return (listaPermissoesFuncionalidades.Count > 0) ? listaPermissoesFuncionalidades : null;
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
        /// Método responsável por recuperar as permissões da funcionalidade pelo perfil
        /// </summary>
        /// <param name="idPerfil">Identidade do perfil</param>
        /// <returns>Retorna um objeto com uma lista de ValueObjectLayer.Perfil_Permissao_Funcionalidade</returns>
        public IList<ValueObjectLayer.Perfil_Permissao_Funcionalidade> RecuperaPermissaoDaFuncionalidadePorPerfil(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<ValueObjectLayer.Perfil_Permissao_Funcionalidade> listaPerfilPermissoesFuncionalidades = 
                new List<ValueObjectLayer.Perfil_Permissao_Funcionalidade>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Select * From TB_Perfil_Permissao_Funcionalidade " +
                                    "Where IdPerfil = @varIdPerfil ";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaPerfilPermissoesFuncionalidades.Add(
                            new ValueObjectLayer.Perfil_Permissao_Funcionalidade(
                                Convert.ToInt32(reader["Id"]),
                                new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"])),
                                new ValueObjectLayer.Permissao_Funcionalidade(Convert.ToInt32(reader["IdPermissaoFuncionalidade"]))));
                    }
                }

                return (listaPerfilPermissoesFuncionalidades.Count > 0) ? listaPerfilPermissoesFuncionalidades : null;
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
        /// Método responsável por recuperar todas as permissões do perfil que existe para o usuário do sistema
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfil(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<CarregarPerfil> listaCarregarPerfil = new List<CarregarPerfil>();

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select Distinct p.Id As IdPerfil, p.Descricao As DescricaoPerfil, "+
                                    "m.Id As IdModulo, m.Nome As NomeModulo, " +
                                    "f.Id IdFuncionalidade, f.Descricao As DescricaoFuncionalidade, " +
                                    "f.CaminhoPagina  As CaminhoPaginaFuncionalidade, pf.Id As IdPF, pe.Nome As NomePermissao " +
                                    "From TB_Perfil p, TB_Modulos m, TB_Permissoes pe, TB_Funcionalidades f, " +
                                    "TB_Permissao_Funcionalidade pf, TB_Perfil_Permissao_Funcionalidade ppf " +
                                    "Where pf.IdFuncionalidade = f.Id " +
                                    "And pf.IdPermissao = pe.Id " +
                                    "And ppf.IdPermissaoFuncionalidade = pf.Id " +
                                    "And ppf.IdPerfil = p.Id " +
                                    "And f.IdModulo = m.Id " +
                                    "And f.Funcao = @varFuncao " +
                                    "And p.Id = @varIdPerfil " +
                                    "Order By m.Nome ";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);
                cmd.Parameters.AddWithValue("@varFuncao", true);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCarregarPerfil.Add(new CarregarPerfil(
                            new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"]), Convert.ToString(reader["DescricaoPerfil"])),
                            new ValueObjectLayer.Modulo(Convert.ToInt32(reader["IdModulo"]), Convert.ToString(reader["NomeModulo"])),
                            new ValueObjectLayer.Funcionalidade(Convert.ToInt32(reader["IdFuncionalidade"]), Convert.ToString(reader["DescricaoFuncionalidade"]),
                                Convert.ToString(reader["CaminhoPaginaFuncionalidade"])),
                            new Permissao_Funcionalidade(Convert.ToInt32(reader["IdPF"])),
                            new ValueObjectLayer.Permissao(Convert.ToString(reader["NomePermissao"])))
                            );
                    }
                }

                return (listaCarregarPerfil.Count > 0) ? listaCarregarPerfil : null;
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
        /// Método responsável para recuperar todas as permissões do perfil para popular a TreeView
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public IList<ValueObjectLayer.CarregarPerfil> RecuperaTodasPermissoesPerfilTreeView(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<CarregarPerfil> listaCarregarPerfil = new List<CarregarPerfil>();

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText =   "Select Distinct p.Id As IdPerfil, p.Descricao As DescricaoPerfil, m.Id IdModulo, " +
                                    "m.Nome As NomeModulo, f.Id As IdFuncionalidade, f.Descricao As DescricaoFuncionalidade, " +
                                    "f.CaminhoPagina As CaminhoPaginaFuncionalidade, pf.Id As IdPermisaoFuncionalide, " +
                                    "pe.Nome As NomePermissao, pe.Id As IdPermissao " +
                                    "From TB_Perfil p, TB_Modulos m, TB_Permissoes pe, TB_Funcionalidades f, " +
                                    "TB_Permissao_Funcionalidade pf, TB_Perfil_Permissao_Funcionalidade ppf " +
                                    "Where pf.IdFuncionalidade = f.Id " +
                                    "And pf.IdPermissao = pe.Id " +
                                    "And ppf.IdPermissaoFuncionalidade = pf.Id " +
                                    "And ppf.IdPerfil = p.Id " +
                                    "And f.IdModulo = m.Id " +
                                    "And p.Id = @varIdPerfil " +
                                    "Order By m.Nome ";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCarregarPerfil.Add(new CarregarPerfil(
                            new ValueObjectLayer.Perfil(Convert.ToInt32(reader["IdPerfil"]), Convert.ToString(reader["DescricaoPerfil"])),
                            new ValueObjectLayer.Modulo(Convert.ToInt32(reader["IdModulo"]), Convert.ToString(reader["NomeModulo"])),
                            new ValueObjectLayer.Funcionalidade(Convert.ToInt32(reader["IdFuncionalidade"]), Convert.ToString(reader["DescricaoFuncionalidade"]),
                                new ValueObjectLayer.Modulo(0, null, Convert.ToString(reader["CaminhoPaginaFuncionalidade"]))),
                            new Permissao_Funcionalidade(Convert.ToInt32(reader["IdPermisaoFuncionalide"])),
                            new ValueObjectLayer.Permissao(Convert.ToInt32(reader["IdPermissao"]), Convert.ToString(reader["NomePermissao"])))
                            );
                    }
                }

                return (listaCarregarPerfil.Count > 0) ? listaCarregarPerfil : null;
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
        /// Método responsável por recuperar o perfil para montar o sub-menu
        /// </summary>
        /// <param name="idPerfil">identificador do perfil do usuário no sistema</param>
        /// <returns>Retorna uma lista de objeto com os acessos deste perfil</returns>
        public IList<ValueObjectLayer.CarregarPerfil> RecuperaFuncionalidadesPerfil(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<CarregarPerfil> listaCarregarPerfil = new List<CarregarPerfil>();

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText =   "Select distinct f.Descricao " +
                                    "From TB_Perfil p, TB_Modulos m, TB_Permissoes pe, TB_Funcionalidades f,  " +
                                    "TB_Permissao_Funcionalidade pf, TB_Perfil_Permissao_Funcionalidade ppf " +
                                    "Where pf.IdFuncionalidade = f.Id " +
                                    "And pf.IdPermissao = pe.Id " +
                                    "And ppf.IdPermissaoFuncionalidade = pf.Id " +
                                    "And ppf.IdPerfil = p.Id " +
                                    "And f.IdModulo = m.Id " +
                                    "And p.Id = @varIdPerfil " +
                                    "order by f.Descricao asc ";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCarregarPerfil.Add(new CarregarPerfil(
                            new ValueObjectLayer.Permissao(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Nome"]))));
                    }
                }

                return (listaCarregarPerfil.Count > 0) ? listaCarregarPerfil : null;
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
        /// Método responsável para recuperar os nomes das permissões relacionadas ao perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna uma lista de objeto com as permissões deste perfil</returns>
        public IList<ValueObjectLayer.CarregarPerfil> RecuperaPermissoes(int idPerfil)
        {
            SqlCommand cmd = null;
            IList<CarregarPerfil> listaCarregarPerfil = new List<CarregarPerfil>();

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText =   "Select distinct pe.Nome " +
                                    "From TB_Perfil p, TB_Modulos m, TB_Permissoes pe, TB_Funcionalidades f,  " +
                                    "TB_Permissao_Funcionalidade pf, TB_Perfil_Permissao_Funcionalidade ppf " +
                                    "Where pf.IdFuncionalidade = f.Id " +
                                    "And pf.IdPermissao = pe.Id " +
                                    "And ppf.IdPermissaoFuncionalidade = pf.Id " +
                                    "And ppf.IdPerfil = p.Id " +
                                    "And f.IdModulo = m.Id " +
                                    "And p.Id = @varIdPerfil ";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaCarregarPerfil.Add(new CarregarPerfil(
                            new ValueObjectLayer.Permissao(Convert.ToString(reader["Nome"]))));
                    }
                }

                return (listaCarregarPerfil.Count > 0) ? listaCarregarPerfil : null;
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
        /// Método responsável por permitir o salvamento das permissões para o perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        /// <returns>Retorna um booleano se ok</returns>
        public bool SalvarPermissaoPerfil(IList<ValueObjectLayer.CarregarPerfil> listaCarregarPerfil)
        {
            SqlCommand cmd = null;
            bool deletado = false;

            try
            {
                cmd = Factory.AcessoDados();

                foreach (CarregarPerfil carregarPerfil in listaCarregarPerfil)
                {
                    IList<ValueObjectLayer.Perfil_Permissao_Funcionalidade> listaPpf = RecuperaPermissaoDaFuncionalidadePorPerfil(carregarPerfil._Perfil.Id);
                    
                    if (cmd != null) cmd = Factory.AcessoDados();

                    if (listaPpf != null && !deletado)
                    {
                        foreach (ValueObjectLayer.Perfil_Permissao_Funcionalidade ppf in listaPpf)
                        {
                            DeletaPermissaoPerfil(ppf);
                        }
                        deletado = true;
                    }

                    if (cmd != null) cmd = Factory.AcessoDados();

                    cmd.CommandText = "Insert Into TB_Perfil_Permissao_Funcionalidade (IdPerfil, IdPermissaoFuncionalidade) " +
                    "Values(@varIdPerfil, @varIdPermissaoFuncionalidade)";

                    cmd.Parameters.AddWithValue("@varIdPerfil", carregarPerfil._Perfil.Id);
                    cmd.Parameters.AddWithValue("@varIdPermissaoFuncionalidade", carregarPerfil._Permissao.Id);

                    cmd.ExecuteNonQuery();
                }

                return true;
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
        /// Método responsável por deletar as permissões e suas funcionalidades do perfil
        /// </summary>
        /// <param name="ppf">Recebe um objeto do tipo ValueObjectLayer.Perfil_Permissao_Funcionalidade</param>
        public void DeletaPermissaoPerfil(ValueObjectLayer.Perfil_Permissao_Funcionalidade ppf)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();
                cmd.CommandText = "Delete From TB_Perfil_Permissao_Funcionalidade Where IdPerfil = @varIdPerfil";

                cmd.Parameters.AddWithValue("@varIdPerfil", ppf._Perfil.Id);

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
        /// Método responsável por deletar as permissões que o perfil que tem em relação aos módulos do sistema
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        public void DeletaPerfilModulo(ValueObjectLayer.Perfil_Modulo PerfilModulo)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Delete From TB_Perfil_Modulo Where IdModulo = @varIdModulo And IdPerfil = @varIdPerfil";

                cmd.Parameters.AddWithValue("@varIdModulo", PerfilModulo._Modulo.Id);
                cmd.Parameters.AddWithValue("@varIdPerfil", PerfilModulo._Perfil.Id);

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
        /// Método responsável por deletar todas as permissões do perfil
        /// </summary>
        /// <param name="idPerfil">Identificador do perfil</param>
        public void DeletaPerfilModulo(int idPerfil)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Delete From TB_Perfil_Modulo Where IdPerfil = @varIdPerfil";

                cmd.Parameters.AddWithValue("@varIdPerfil", idPerfil);

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
        /// Método responsável por verificar se existe um determinado módulo cadastrado para um perfil
        /// </summary>
        /// <param name="perfilModulo">Objeto ValueObjectLayer.Perfil_Modulo que contém os dados identificadore para o Módulo e Perfil a ser pesquisados</param>
        /// <returns>Retorna true se a pesquisa encontrar um módulo cadastrado para o perfil</returns>
        public bool RetornaPerfilModulo(ValueObjectLayer.Perfil_Modulo perfilModulo)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText =   "Select * From TB_Perfil_Modulo " +
                                    "Where IdModulo = @varIdModulo " +
                                    "And IdPerfil = @varIdPerfil";

                cmd.Parameters.AddWithValue("@varIdModulo", perfilModulo._Modulo.Id);
                cmd.Parameters.AddWithValue("@varIdPerfil", perfilModulo._Perfil.Id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return (reader.Read()) ? true : false;
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
        /// Método responsável por salvar a permissão de um determinado módulo ao perfil
        /// </summary>
        /// <param name="pm">Objeto ValueObjectLayer.Perfil_Modulo com os parâmetros preenchidos a ser cadastrados</param>
        /// <returns>Retorna true se a inserção tenha ocorrido ok</returns>
        public bool SalvarPerfilModulo(ValueObjectLayer.Perfil_Modulo pm)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Factory.AcessoDados();

                cmd.CommandText = "Insert Into TB_Perfil_Modulo (IdModulo, IdPerfil) " +
                "Values(@varIdModulo, @varIdPerfil)";

                cmd.Parameters.AddWithValue("@varIdModulo", pm._Modulo.Id);
                cmd.Parameters.AddWithValue("@varIdPerfil", pm._Perfil.Id);

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

    }
}
