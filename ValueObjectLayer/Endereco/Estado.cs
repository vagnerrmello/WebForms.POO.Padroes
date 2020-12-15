//-----------------------------------------------------------------------
// <copyright file="Estado.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer.Endereco
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Representa um objeto Estado
    /// </summary>
    public class Estado

    {
        public Estado()
		{
		}

        public Estado(int id)
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

        public virtual string Sigla
        {
            get;
            set;
        }



        #endregion
    }
}
