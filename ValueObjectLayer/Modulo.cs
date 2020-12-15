//-----------------------------------------------------------------------
// <copyright file="Modulo.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Modulo
    /// </summary>
    public class Modulo
	{
        public Modulo()
		{
		}

        public Modulo(int id)
        {
            this.Id = id;
        }

        public Modulo(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public Modulo(int id, string nome, string caminhoPagina)
        {
            this.Id = id;
            this.Nome = nome;
            this.CaminhoPagina = caminhoPagina;
        }

        public Modulo(int id, string nome, string descricao, string caminhoPagina)
        {
            this.Id = id;
            this.Nome = nome;
            this.CaminhoPagina = caminhoPagina;
            this.Descricao = descricao;
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

        public virtual string Descricao
        {
            get;
            set;
        }

        public virtual string CaminhoPagina
        {
            get;
            set;
        }
		#endregion
	}
}
