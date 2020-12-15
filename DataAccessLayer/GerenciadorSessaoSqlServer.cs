using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Steto.ValueObjectLayer
{
    public class GerenciadorSessaoSqlServer : IGerenciadorSessao
    {
        // Usuário usando a sessão
        private ValueObjectLayer.Usuario usuario = null;

        /// <summary>
        /// Retorna o usuário que está usando a sessão
        /// </summary>
        public virtual ValueObjectLayer.Usuario Usuario
        {
            get
            {
                return usuario;
            }
        }

        /// <summary>
        /// Indica qual o usuário que está usando a sessão
        /// </summary>
        /// <param name="usuario">Usuário que está usando a sessão</param>
        protected virtual void SetUsuario(ValueObjectLayer.Usuario usuario)
        {
            this.usuario = usuario;
        }

        /// <summary>
        /// Abre uma sessão
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <param name="modulo">Módulo do Stet</param>
        /// <returns>true se a sessão foi aberta, false caso contrário</returns>
        public virtual bool Abrir(string login, string senha, string modulo)
        {
            return true;
        }
        
        /// <summary>
        /// Fecha a sessão
        /// </summary>
        public virtual void Fechar()
        {
            GerenciadorConexao.Instancia.Desconectar();
        }

        /// <summary>
        /// Verifica se a sessão está aberta
        /// </summary>
        /// <returns>true se a sessão estiver aberta,false caso contrário</returns>
        public virtual bool IsOpened()
        {
            return GerenciadorConexao.Instancia.IsConnected();
        }
    }
}
