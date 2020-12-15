//-----------------------------------------------------------------------
// <copyright file="Produto.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Estoque
    /// </summary>
    public class Produto
    {

        public Produto()
		{
        }

        public Produto(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string NumeroNota
        {
            get;
            set;
        }

        public virtual Fornecedor Fornecedor
        {
            get;
            set;
        }

        //1 = Sim (Lan�ar); 0 = N�o (N�o Lan�ar)
        public virtual int LanncarContasAPagar
        {
            get;
            set;
        }

        public virtual string Descricao
        {
            get;
            set;
        }

        public virtual string UnidadeDeMedida
        {
            get;
            set;
        }

        public virtual decimal ValorUnitario
        {
            get;
            set;
        }

        public virtual decimal ValorTotal
        {
            get;
            set;
        }

        public virtual decimal QuantidadeRealEstoque
        {
            get;
            set;
        }

        public virtual decimal QuantidadeMinimaEstoque
        {
            get;
            set;
        }

        public virtual decimal Entrada
        {
            get;
            set;
        }

        //1 = Sim (Consumo Interno); 0 = N�o (N�o � para Consumo Interno)
        public virtual int ConsumoInterno
        {
            get;
            set;
        }

        //S = "Sim"; N = "N�o"
        public virtual string Ativo
        {
            get;
            set;
        }

        #endregion

    }
}
