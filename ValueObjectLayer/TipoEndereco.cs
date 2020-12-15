//-----------------------------------------------------------------------
// <copyright file="TipoEndereco.cs" company="Steto">
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
    /// Representa o objeto referente ao TipoEndereco
    /// </summary>
    public class TipoEndereco
    {
        public TipoEndereco()
        { }

        public TipoEndereco(int id)
        {
            this.Id = id;
        }
        
        #region Properties
        public virtual int Id
        {
            get;
            set;
        }

        public virtual string Tipo
        {
            get;
            set;
        }
        #endregion
    }
}
