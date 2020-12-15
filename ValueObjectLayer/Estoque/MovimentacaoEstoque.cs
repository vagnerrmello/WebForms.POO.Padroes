//-----------------------------------------------------------------------
// <copyright file="MovimentacaoEstoque.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto MovimentacaoEstoque
    /// </summary>
    public class MovimentacaoEstoque
    {

        public MovimentacaoEstoque()
		{
        }

        public MovimentacaoEstoque(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
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

        public virtual decimal Valor
        {
            get;
            set;
        }

        public virtual DateTime Data
        {
            get;
            set;
        }

        /// <summary>
        /// E = "Entrada"; S = "Saída"
        /// </summary>
        public virtual string Status
        {
            get;
            set;
        }

        public virtual Usuario Usuario
        {
            get;
            set;
        }

        #endregion
    }
}
