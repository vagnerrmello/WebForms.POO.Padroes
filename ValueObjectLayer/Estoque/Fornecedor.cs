//-----------------------------------------------------------------------
// <copyright file="Fornecedor.cs" company="Vikn">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Fornecedor
    /// </summary>
    public class Fornecedor
    {

        public Fornecedor()
		{
        }

        public Fornecedor(int id)
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

        public virtual Logradouro Logradouro
        {
            get;
            set;
        }

        #endregion

    }
}
