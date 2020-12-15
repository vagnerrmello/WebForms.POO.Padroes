//-----------------------------------------------------------------------
// <copyright file="CBO.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Representa um objeto CBO
    /// </summary>
    public class CBO
    {
        public CBO()
		{
		}

        public CBO(int id)
        {
            this.Id = id;
        }

        #region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Codigo
        {
            get;
            set;
        }

        public virtual string Descricao
        {
            get;
            set;
        }
        #endregion
    }
}
