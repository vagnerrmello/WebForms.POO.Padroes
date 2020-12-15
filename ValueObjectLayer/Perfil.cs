//-----------------------------------------------------------------------
// <copyright file="Perfil.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Perfil
    /// </summary>
	public class Perfil
	{
		public Perfil()
		{
		}

        public Perfil(int id)
        {
            this.Id = id;
        }

        public Perfil(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }	

        public Perfil(int id, string descricao, bool ativo)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Ativo = ativo;
        }	

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Descricao
        {
            get;
            set;
        }

        public virtual bool Ativo
        {
            get;
            set;
        }
		#endregion
	}

    public enum TipoBuscaPerfil
    {
        RecuperaTodasPermissoesPerfil = 1,
        RecuperaFuncionalidadesPerfil = 2,
        RecuperaPermissoes = 3
    }

    public enum TipoPerfil
    {
        Administrador = 1,
        Gestor = 13
    }
}
