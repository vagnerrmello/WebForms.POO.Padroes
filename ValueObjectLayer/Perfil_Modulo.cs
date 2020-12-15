//-----------------------------------------------------------------------
// <copyright file="Perfil_Modulo.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Perfil_Modulo
    /// </summary>
	public class Perfil_Modulo 
	{
        public Perfil_Modulo()
		{
		}

        public Perfil_Modulo(Modulo modulo, Perfil perfil)
        {
            this._Modulo = modulo;
            this._Perfil = perfil;
        }
		

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Modulo _Modulo
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
