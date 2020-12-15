using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Steto.ValueObjectLayer
{
    public abstract class GerenciadorConexao : IGerenciadorTransacoes
    {
        // Instancia do Gerenciador de Conexão
        private static GerenciadorConexao instancia = null;

        /// <summary>
        /// Estado do gerenciador de conexão
        /// </summary>
        protected abstract EstadoGerenciadorConexao Estado { get; }

        /// <summary>
        /// Construtor é protegido, o que garante que somente as classes derivadas podem instanciar
        /// </summary>
        protected GerenciadorConexao() { }

        /// <summary>
        /// Instância do gerenciador de conexão
        /// </summary>
        public static GerenciadorConexao Instancia
        {
            get
            {
                if (instancia == null)
                {
                    switch (Aplicacao.Instancia.Tipo)
                    {
                        case TipoAplicacao.WebPostGreSQL:
                            instancia = new GerenciadorConexaoPostGreSql();
                            break;
                        case TipoAplicacao.WebSqlServer:
                            instancia = new GerenciadorConexaoSqlServer();
                            break;
                        default:
                            break;
                    }
                }
                return instancia;
            }
        }

        /// <summary>
        /// Inicia uma transação
        /// </summary>
        public abstract void IniciarTransacao();

        /// <summary>
        /// Cancela a transação (rollback)
        /// </summary>
        public abstract void CancelarTransacao();

        /// <summary>
        /// Finaliza a transação (commit)
        /// </summary>
        public abstract void FinalizarTransacao();

        /// <summary>
        /// Retorna o nome do servidor de banco de dados
        /// </summary>
        /// <returns>Nome do servidor de banco de dados</returns>
        public string GetBanco()
        {
            return Estado.Banco;
        }

        /// <summary>
        /// Define o nome do servidor de banco de dados
        /// </summary>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        protected void SetBanco(string banco)
        {
            Estado.Banco = banco;
        }

        /// <summary>
        /// Retorna o login do usuário(Na conexão ao banco de dados)
        /// </summary>
        /// <returns>Login do usuário(Na conexão ao banco de dados)</returns>
        public string GetLogin()
        {
            return Estado.Login;
        }

        /// <summary>
        /// Define o login do usuário(Na conexão ao banco de dados)
        /// </summary>
        /// <param name="login">Login do usuário(Na conexão ao banco de dados)</param>
        protected void SetLogin(string login)
        {
            Estado.Login = login;
        }

        /// <summary>
        /// Retorna a senha do usuário(Na conexão ao banco de dados)
        /// </summary>
        /// <returns>Senha do usuário(Na conexão ao banco de dados)</returns>
        public string GetSenha()
        {
            return Estado.Senha;
        }

        /// <summary>
        /// Define a senha do usuário(Na conexão ao banco de dados)
        /// </summary>
        /// <param name="senha">Senha do usuário(Na conexão ao banco de dados)</param>
        protected void SetSenha(string senha)
        {
            Estado.Senha = senha;
        }

        /// <summary>
        /// Retorna a conexão ao banco de dados
        /// </summary>
        /// <returns>Conexão ao banco de dados</returns>
        protected SqlConnection GetConexao()
        {
            return Estado.Conexao;
        }

        /// <summary>
        /// Define a conexão ao banco de dados
        /// </summary>
        /// <param name="conexao">A conexão ao banco de dados</param>
        protected void SetConexao(SqlConnection conexao)
        {
            Estado.Conexao = conexao;
        }

        /// <summary>
        /// Retorna a transação ativa
        /// </summary>
        /// <returns>Transação ativa</returns>
        protected SqlTransaction GetTransacao()
        {
            return Estado.Transacao;
        }

        /// <summary>
        /// Define a transação ativa
        /// </summary>
        /// <param name="transacao">Transação ativa</param>
        protected void SetTransacao(SqlTransaction transacao)
        {
            Estado.Transacao = transacao;
        }

        /// <summary>
        /// Retorna o número de transações ativas
        /// </summary>
        /// <returns>Número de transações ativas</returns>
        public int GetContadorTransacoes()
        {
            return Estado.ContadorTransacoes;
        }

        /// <summary>
        /// Define o número de transações ativas
        /// </summary>
        /// <param name="contador">Transações ativas</param>
        protected void SetContadorTransacoes(int contador)
        {
            Estado.ContadorTransacoes = contador;
        }

        /// <summary>
        /// Faz a conexão ao banco de dados
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        /// <returns>Conexão ao banco de dados</returns>
        public abstract SqlConnection Conectar(String login, String senha, String banco);

        /// <summary>
        /// Faz a conexão ao banco de dados
        /// </summary>
        /// <returns>Conexão ao banco de dados</returns>
        public abstract SqlConnection Conectar();

        /// <summary>
        /// Desconecta do banco de dados
        /// </summary>
        public abstract void Desconectar();

        /// <summary>
        /// Cria um comando
        /// </summary>
        /// <returns>Comando criado</returns>
        public abstract SqlCommand CriarComando();

        /// <summary>
        /// Verifica se a conexão ao banco de dados está ativa
        /// </summary>
        /// <returns>true se estiver ativa,false caso contrário</returns>
        public abstract bool IsConnected();

        /// <summary>
        /// Faz uma nova conexão ao banco de dados
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="banco">Nome do servidor de banco de dados</param>
        /// <returns>Conexão ao banco de dados</returns>
        public abstract SqlConnection AbrirNovaConexao(string login, string senha, string banco);

        /// <summary>
        /// Faz uma nova conexão ao banco de dados
        /// </summary>
        /// <returns>Conexão ao banco de dados</returns>
        public abstract SqlConnection AbrirNovaConexao();
    }
}
