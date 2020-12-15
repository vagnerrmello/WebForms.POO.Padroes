//-----------------------------------------------------------------------
// <copyright file="Estoque.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Fornecedor
    /// </summary>
    public class Estoque
    {

        public Estoque()
		{
        }

        public Estoque(int id)
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

        public virtual Fornecedor Fornecedor
        {
            get;
            set;
        }

        public virtual Produto Produto
        {
            get;
            set;
        }

        public virtual decimal Quantidade
        {
            get;
            set;
        }

        #endregion

    }
}
