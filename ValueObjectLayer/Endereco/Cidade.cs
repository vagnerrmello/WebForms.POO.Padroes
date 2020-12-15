//-----------------------------------------------------------------------
// <copyright file="Cidade.cs" company="Steto">
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
    /// Representa um objeto Cidade
    /// </summary>
    public class Cidade

    {
        public Cidade()
		{
		}

        public Cidade(int id)
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

        public virtual Estado Estado
        {
            get;
            set;
        }

        #region Campo Utilizado apenas para recuperação do IBGE
        public virtual int Codgigo_IBGE
        {
            get;
            set;
        }
        #endregion Fim do recuperação do IBGE

        #endregion
    }
}
