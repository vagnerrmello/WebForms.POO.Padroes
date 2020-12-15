using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Steto.ValueObjectLayer
{
    public class EstadoGerenciadorConexao
    {
        // Login do usuário
        private string login = null;
        // Senha do usuário
        private string senha = null;
        // Nome do servidor de banco de dados
        private string banco = null;
        // Contador de transações
        private int contadorTransacoes = 0;
        // Conexão ao Banco de Dados
        private SqlConnection conexao = null;
        // Transação ativa
        private SqlTransaction transacao = null;

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        /// <summary>
        /// Senha do usuário(Na conexão ao banco de dados)
        /// </summary>
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        /// <summary>
        /// Nome do servidor de banco de dados
        /// </summary>
        public string Banco
        {
            get { return banco; }
            set { banco = value; }
        }

        /// <summary>
        /// Contador do número de transações ativas
        /// </summary>
        public int ContadorTransacoes
        {
            get { return contadorTransacoes; }
            set { contadorTransacoes = value; }
        }

        /// <summary>
        /// Conexão ao banco de dados
        /// </summary>
        public SqlConnection Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }

        /// <summary>
        /// Transação ativa
        /// </summary>
        public SqlTransaction Transacao
        {
            get { return transacao; }
            set { transacao = value; }
        }
    }
}
