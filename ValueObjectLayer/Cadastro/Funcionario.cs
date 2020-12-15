//-----------------------------------------------------------------------
// <copyright file="Funcionario.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Funcionario
    /// </summary>
	public class Funcionario
    {
		public Funcionario()
		{
		}

        public Funcionario(int id)
        {
            this.Id = id;
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

        public virtual string CPF
        {
            get;
            set;
        }

        public virtual string Email
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
