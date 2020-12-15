//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Email
    /// </summary>
    public class Email
	{

        public Email()
		{
        }

        public Email(int id)
        {
            this.Id = id;
        }

        public Email(int id, Email_Tipo email_tipo)
        {
            this.Id = id;
            this._Email_Tipo = email_tipo;
        }	

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Email_Tipo _Email_Tipo
        {
            get;
            set;
        }

        public virtual Funcionalidade _Funcionalidade
        {
            get;
            set;
        }

        public virtual string Smtp
        {
            get;
            set;
        }

        public virtual string Email_Empresa
        {
            get;
            set;
        }

        public virtual string Assunto
        {
            get;
            set;
        }

        public virtual string CorpoEmail
        {
            get;
            set;
        }

        public virtual bool UsarPorta
        {
            get;
            set;
        }

        public virtual int Porta
        {
            get;
            set;
        }

        public virtual bool EnviarEmailAdm
        {
            get;
            set;
        }

        public virtual string EmailAdm
        {
            get;
            set;
        }

        public virtual bool EnviarEmailGestor
        {
            get;
            set;
        }

        public virtual string EmailGestor
        {
            get;
            set;
        }

        public virtual string UsuarioEmailEmpresa
        {
            get;
            set;
        }

        public virtual string SenhaEmailEmpresa
        {
            get;
            set;
        }

        public virtual bool EnviarEmail
        {
            get;
            set;
        }

        public virtual bool Ssl
        {
            get;
            set;
        }


		#endregion

	}
}
