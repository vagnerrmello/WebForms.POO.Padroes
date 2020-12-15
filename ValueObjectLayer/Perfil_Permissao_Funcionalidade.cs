//-----------------------------------------------------------------------
// <copyright file="Perfil_Permissao_Funcionalidade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Perfil_Permissao_Funcionalidade
    /// </summary>
	public class Perfil_Permissao_Funcionalidade
	{
        public Perfil_Permissao_Funcionalidade()
		{
		}

        public Perfil_Permissao_Funcionalidade(int id)
        {
            this.Id = id;
        }

        public Perfil_Permissao_Funcionalidade(int id, Perfil perfil, Permissao_Funcionalidade permissao_Funcionalidade)
        {
            this.Id = id;
            this._Perfil = perfil;
            this._Permissao_Funcionalidade = permissao_Funcionalidade;
        }	

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Perfil _Perfil
        {
            get;
            set;
        }

        public virtual Permissao_Funcionalidade _Permissao_Funcionalidade
        {
            get;
            set;
        }
		#endregion
	}
}
