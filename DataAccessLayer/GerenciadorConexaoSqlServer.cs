using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Steto.ValueObjectLayer
{
    public class GerenciadorConexaoSqlServer : GerenciadorConexao
    {
        // Estado do gerenciador de conexão
        private EstadoGerenciadorConexao estado = null;

        /// <summary>
        /// Estado do Gerenciador de Conexão
        /// </summary>
        protected override EstadoGerenciadorConexao Estado
        {
            get
            {
                if (estado == null) estado = new EstadoGerenciadorConexao();
                return estado;
            }
        }

        /// <summary>
        /// Cria um comando para executar comandos SQL no PostGreSQL
        /// </summary>
        /// <returns>Comando criado</returns>
        /// <remarks>Caso exista uma transação ativa, o comando automaticamente herda essa transação</remarks>
        public override SqlCommand CriarComando()
        {
            SqlConnection connection = GetConexao();
            if (connection == null)
            {
                throw new Exception();
            }
            else
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Transaction = GetTransacao();
                return cmd;
            }
        }	

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        public override void IniciarTransacao()
        {
            SqlConnection connection = GetConexao();
            if (connection == null)
            {
                throw new Exception();
            }
            else
            {
                try
                {
                    if (GetTransacao() == null) SetTransacao(connection.BeginTransaction());
                    SetContadorTransacoes(GetContadorTransacoes() + 1);
                }
                catch (OdbcException ex)
                {
                    throw ex;
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Cancela a transação
        /// </summary>
        public override void CancelarTransacao()
        {
            try
            {
                if (GetContadorTransacoes() > 0 && GetTransacao() != null)
                {
                    GetTransacao().Rollback();
                    SetContadorTransacoes(GetContadorTransacoes() - 1);
                    if (GetContadorTransacoes() == 0) SetTransacao(null);
                }
            }
            catch (OdbcException ex)
            {
                throw ex;
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Finaliza(commit) a transação
        /// </summary>
        public override void FinalizarTransacao()
        {
            try
            {
                if (GetContadorTransacoes() > 0 && GetTransacao() != null)
                {
                    SetContadorTransacoes(GetContadorTransacoes() - 1);
                    if (GetContadorTransacoes() == 0)
                    {
                        GetTransacao().Commit();
                        SetTransacao(null);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Verifica se a conexão com o PostreSQL está aberta
        /// </summary>
        /// <returns></returns>
        public override bool IsConnected()
        {
            return (GetConexao() != null && GetConexao().State == ConnectionState.Open);
        }

        /// <summary>
        /// Abre uma nova conexão ao PostGreSql
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        /// <returns>Conexão ao banco de dados</returns>
        public override SqlConnection AbrirNovaConexao(string login, string senha, string banco)
        {
            string connectionString = null;
            if (banco != null) connectionString = "Data Source=localhost;Initial Catalog=**;Integrated Security=True;MultipleActiveResultSets=True";
            //"Data Source=**;Initial Catalog=**;Integrated Security=True;MultipleActiveResultSets=True"
            //"Data Source=localhost;Initial Catalog=**;Persist Security Info=True;User ID=**;Password=**"
            //if (banco != null) connectionString = "Data Source=" + banco + ";";
            //connectionString += "User Id=" + login + ";Password=" + senha + ";";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
                //throw new GerenciadorConexaoException(e.Code, e.Message);
            }
            return connection;
        }

        /// <summary>
        /// Abre uma nova conexão ao PostGreSql
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        /// <returns>Conexão ao banco de dados</returns>
        public override SqlConnection AbrirNovaConexao()
        {
            string connectionString = null;
            connectionString = "Data Source=localhost;Initial Catalog=**;Integrated Security=True;MultipleActiveResultSets=True";
            //connectionString = "Data Source=localhost;Initial Catalog=**;Persist Security Info=True;User ID=**;Password=**";
            //if (banco != null) connectionString = "Data Source=" + banco + ";";
            //connectionString += "User Id=" + login + ";Password=" + senha + ";";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
                //throw new GerenciadorConexaoException(e.Code, e.Message);
            }
            return connection;
        }

        /// <summary>
        /// Faz a conexão ao PostGreSql
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        /// <returns>Conexão ao banco de dados(SqlServer)</returns>
        public override SqlConnection Conectar(String login, String senha, String banco)
        {
            Desconectar();

            SqlConnection conexao = AbrirNovaConexao(login, senha, banco);
            SetConexao(conexao);
            SetLogin(login);
            SetSenha(senha);
            SetBanco(banco);
            return GetConexao();
        }

        /// <summary>
        /// Faz a conexão ao PostGreSql
        /// </summary>
        /// <returns>Conexão ao banco de dados(SqlServer)</returns>
        public override SqlConnection Conectar()
        {
            Desconectar();

            SqlConnection conexao = AbrirNovaConexao();
            SetConexao(conexao);

            return GetConexao();
        }

        /// <summary>
        /// Desconecta do PostGreSql
        /// </summary>
        public override void Desconectar()
        {
            SqlConnection connection = GetConexao();
            Desconectar(connection);
            SetConexao(null);
        }

        protected void Desconectar(SqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
