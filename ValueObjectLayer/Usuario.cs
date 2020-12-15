//-----------------------------------------------------------------------
// <copyright file="Usuario.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Usuário
    /// </summary>
	public class Usuario
	{
		public Usuario()
		{
		}

        public Usuario(int id)
        {
            this.Id = id;
        }

        public Usuario(int id, string nome, string email, string login, string senha, bool ativo, bool bloqueado)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Login = login;
            this.Senha = senha;
            this.Ativo = ativo;
            this.Bloqueado = bloqueado;
        }	
		
		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Nome
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string Login
        {
            get;
            set;
        }

        public virtual string Senha
        {
            get;
            set;
        }

        public virtual bool Ativo
        {
            get;
            set;
        }

        public virtual bool Bloqueado
        {
            get;
            set;
        }



        #endregion


    }
}
