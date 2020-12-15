//-----------------------------------------------------------------------
// <copyright file="Perfil_Usuario.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Perfil_Usuario
    /// </summary>
	public class Perfil_Usuario
	{
		public Perfil_Usuario()
		{
		}

        public Perfil_Usuario(int id, Usuario usuario, Perfil perfil)
        {
            this.Id = id;
            this._Usuario = usuario;
            this._Perfil = perfil;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Usuario _Usuario
        {
            get;
            set;
        }

        public virtual Perfil _Perfil
        {
            get;
            set;
        }


		#endregion
	}
}
