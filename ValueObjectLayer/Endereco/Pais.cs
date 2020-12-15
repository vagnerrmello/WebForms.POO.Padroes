//-----------------------------------------------------------------------
// <copyright file="Logradouro.cs" company="Steto">
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
    /// Representa um objeto Pais
    /// </summary>
    public class Pais
    {
        public Pais()
        { }

        public Pais(int id)
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

        public virtual string Sigla1
        {
            get;
            set;
        }

        public virtual string Sigla2
        {
            get;
            set;
        }
        #endregion
    }
}
