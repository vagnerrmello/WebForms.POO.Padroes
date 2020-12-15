//-----------------------------------------------------------------------
// <copyright file="Email_Tipo.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Email_Tipo
    /// </summary>
    public class Email_Tipo
	{
        public Email_Tipo()
		{
		}

        public Email_Tipo(int id)
        {
            this.Id = id;
        }

        public Email_Tipo(int id, string tipoEmail)
        {
            this.Id = id;
            this.TipoEmail = tipoEmail;
        }	

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string TipoEmail
        {
            get;
            set;
        }

		#endregion

    }

    public enum TipoEmail
    {
        Empresa = 1
    }
}
