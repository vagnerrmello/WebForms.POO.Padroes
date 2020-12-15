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
    /// Representa um objeto Bairro
    /// </summary>
    public class Logradouro

    {
        public Logradouro()
		{
		}

        public Logradouro(int id)
        {
            this.Id = id;
        }

        #region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual TipoLogradouro TipoLogradouro
        {
            get;
            set;
        }

        public virtual TiposLogradouro TiposLogradouro
        {
            get;
            set;
        }

        public virtual TipoEndereco TipoEndereco
        {
            get;
            set;
        }

        public virtual string Endereco
        {
            get;
            set;
        }

        public virtual string Complemento
        {
            get;
            set;
        }

        public virtual string Numero
        {
            get;
            set;
        }

        public virtual Bairro Bairro
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

        public virtual string Cep
        {
            get;
            set;
        }

        public virtual Cliente Cliente
        {
            get;
            set;
        }

        public virtual Pais  Pais
        {
            get;
            set;
        }

        public virtual string Observacao
        {
            get;
            set;
        }
        #endregion
    }

    public enum TiposLogradouro
    {
        Residencial = 'R',
        Comercial = 'C',
        ResponsávelFinanceiro = 'F'
    }
}
