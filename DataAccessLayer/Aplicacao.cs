using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Steto.ValueObjectLayer
{
    public class Aplicacao
    {
        private static Aplicacao instancia = null;
        private TipoAplicacao tipo;
        private IGerenciadorSessao sessao = null;
        private string servidor = null;

        /// <summary>
        /// Cria uma nova instância da aplicação.
        /// </summary>
        /// <param name="tipo" type="TipoAplicacao">Tipo da aplicação que será criada.</param>
        /// <param name="sessao" type="IGerenciadorSessao">Gerenciador de sessões da aplicação.</param>
        private Aplicacao(TipoAplicacao tipo, IGerenciadorSessao sessao)
        {
            if (sessao == null)
            {
                throw new ArgumentNullException("Gerenciador de sessão inválido.");
            }
            else
            {
                this.sessao = sessao;
            }
            this.tipo = tipo;
        }

        /// <summary>
        /// Cria a única instância da aplicação.
        /// </summary>
        /// <param name="tipo" type="TipoAplicacao">Tipo da aplicação que será criada.</param>
        /// <param name="sessao" type="IGerenciadorSessao">Gerenciador de sessões da aplicação.</param>
        /// <exception cref="Exception"></exception>
        public static void CriarInstancia(TipoAplicacao tipo, IGerenciadorSessao sessao)
        {
            if (instancia == null)
            {
                instancia = new Aplicacao(tipo, sessao);
            }
            else
            {
                instancia = null;
                instancia = new Aplicacao(tipo, sessao);
                //throw new Exception();
            }
        }

        /// <summary>
        /// Instância da aplicação.
        /// </summary>
        public static Aplicacao Instancia
        {
            get { return instancia; }
        }

        /// <summary>
        /// Tipo de aplicação.
        /// </summary>
        public TipoAplicacao Tipo
        {
            get { return tipo; }
        }

        /// <summary>
        /// Servidor no qual a aplicação está executando.
        /// </summary>
        public string Servidor
        {
            get { return servidor; }

            set { this.servidor = value; }
        }

        /// <summary>
        /// Instância do gerenciador de sessões.
        /// </summary>
        public IGerenciadorSessao Sessao
        {
            get { return sessao; }
        }

        /// <summary>
        /// Número da versão do sistema (formato V.VV.RR)
        /// </summary>
        public static string Versao
        {
            get
            {
                Assembly assembly = Assembly.Load("BLL");
                if (assembly != null)
                {
                    Version versao = assembly.GetName().Version;
                    return
                      versao.Major.ToString() + "." +
                      versao.Minor.ToString().PadLeft(2, '0') + "." +
                      versao.Build.ToString().PadLeft(2, '0');
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Build number do sistema
        /// </summary>
        public static string RevisionNumber
        {
            get
            {
                Assembly assembly = Assembly.Load("BLL");
                if (assembly != null)
                {
                    Version versao = assembly.GetName().Version;
                    return versao.Revision.ToString().PadLeft(1, '0');
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
