//-----------------------------------------------------------------------
// <copyright file="Nota.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Fornecedor
    /// </summary>
    public class Nota
    {

        public Nota()
		{
        }

        public Nota(int id)
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

        public virtual string NumeroDocumento
        {
            get;
            set;
        }

        public virtual decimal Valor
        {
            get;
            set;
        }

        public virtual DateTime Vencimento
        {
            get;
            set;
        }

        public virtual DateTime Emissao
        {
            get;
            set;
        }

        public virtual DateTime Cadastro
        {
            get;
            set;
        }

        public virtual string NumeroParcela
        {
            get;
            set;
        }

        public virtual int ContasPagar
        {
            get;
            set;
        }

        public virtual string Observacao
        {
            get;
            set;
        }

        public virtual byte[] imagem
        {
            get;
            set;
        }

        public virtual Produto Produto
        {
            get;
            set;
        }
        #endregion
    }
}
