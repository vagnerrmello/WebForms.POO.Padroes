//-----------------------------------------------------------------------
// <copyright file="Solicitacao.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Solicitação
    /// </summary>
    public class Solicitacao
    {

        public Solicitacao()
		{
        }

        public Solicitacao(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Usuario Usuario
        {
            get;
            set;
        }

        public virtual Funcionario Funcionario
        {
            get;
            set;
        }

        public virtual Produto Produto
        {
            get;
            set;
        }

        public virtual Estoque Estoque
        {
            get;
            set;
        }

        public virtual string Status
        {
            get;
            set;
        }

        public virtual DateTime Data_Solicitacao
        {
            get;
            set;
        }

        public virtual decimal Quantidade
        {
            get;
            set;
        }

        public virtual string Observacao
        {
            get;
            set;
        }
        #endregion
    }
}
