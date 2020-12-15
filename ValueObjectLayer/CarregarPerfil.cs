//-----------------------------------------------------------------------
// <copyright file="CarregarPerfil.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto CarregarPerfil
    /// </summary>
    public class CarregarPerfil
    {
        public CarregarPerfil()
        { }

        public CarregarPerfil(Funcionalidade funcionalidade)
        {
            this._Funcionalidade = funcionalidade;
        }

        public CarregarPerfil(Perfil perfil, Modulo modulo, Funcionalidade funcionalidade,
                               Permissao_Funcionalidade permissaoFuncionalidade, Permissao permissao)
        {
            this._Perfil = perfil;
            this._Modulo = modulo;
            this._Funcionalidade = funcionalidade;
            this._Permissao_Funcionalidade = permissaoFuncionalidade;
            this._Permissao = permissao;
        }

        public CarregarPerfil(Permissao permissao)
        {
            this._Permissao = permissao;
        }

        public Perfil _Perfil
        {
            get;
            set;
        }

        public Modulo _Modulo
        {
            get;
            set;
        }

        public Permissao_Funcionalidade _Permissao_Funcionalidade
        {
            get;
            set;
        }

        public Funcionalidade _Funcionalidade
        {
            get;
            set;
        }

        public Permissao _Permissao
        {
            get;
            set;
        }

        public string CaminhoPagina
        {
            get;
            set;
        }
    }
}
