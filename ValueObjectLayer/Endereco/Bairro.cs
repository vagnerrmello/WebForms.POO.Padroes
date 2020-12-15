//-----------------------------------------------------------------------
// <copyright file="Bairro.cs" company="Steto">
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
    /// Representa um objeto Bairro
    /// </summary>
    public class Bairro

    {
        public Bairro()
		{
		}

        public Bairro(int id)
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

        public virtual Cidade Cidade
        {
            get;
            set;
        }

        public virtual Estado Estado
        {
            get;
            set;
        }
        #endregion
    }
}
