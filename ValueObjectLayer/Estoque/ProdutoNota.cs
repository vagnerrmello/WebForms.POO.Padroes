//-----------------------------------------------------------------------
// <copyright file="Nota.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto ProdutoNota para inserir o Produto na Nota
    /// </summary>
    public class ProdutoNota
    {

        public ProdutoNota()
		{
        }

        public ProdutoNota(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Nota Nota
        {
            get;
            set;
        }

        public virtual Produto Produto
        {
            get;
            set;
        }

        public virtual IList<Produto> Produtos
        {
            get;
            set;
        }

        public virtual string Ativo
        {
            get;
            set;
        }

        #endregion
    }
}
