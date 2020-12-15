//-----------------------------------------------------------------------
// <copyright file="Auditoria.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    using System;

    /// <summary>
    /// Representa o objeto Auditoria 
    /// </summary>
    public class Auditoria
    {
        public Auditoria()
        { }

        public Auditoria(int id)
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

        public virtual string Descricao
        {
            get;
            set;
        }

        public virtual DateTime Data
        {
            get;
            set;
        }
        #endregion
    }
}
