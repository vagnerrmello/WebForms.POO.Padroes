//-----------------------------------------------------------------------
// <copyright file="Permissao.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Permissao
    /// </summary>
	public class Permissao
	{
        public Permissao()
		{
		}

        public Permissao(int id)
        {
            this.Id = id;
        }

        public Permissao(string nome)
        {
            this.Nome = nome;
        }

        public Permissao(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
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

        public virtual string Tipo
        {
            get;
            set;
        }


		#endregion

	}
}
