//-----------------------------------------------------------------------
// <copyright file="CarregarPerfil.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    using Steto.ValueObjectLayer.Endereco;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Representa o objeto Logrodouro 
    /// </summary>
    public class Logradouro
    {
        public Logradouro()
        { }

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

        public virtual Paciente Paciente_
        {
            get;
            set;
        }

        public virtual TipoLogradouro TipoLogradouro_
        {
            get;
            set;
        }

        public virtual TipoEndereco TipoEndereco_
        {
            get;
            set;
        }

        public virtual string Descricao
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

        public virtual int IdUf
        {
            get;
            set;
        }

        public virtual string Uf
        {
            get;
            set;
        }

        public virtual int IdCidade
        {
            get;
            set;
        }

        public virtual string Cidade
        {
            get;
            set;
        }

        public virtual int IdBairro
        {
            get;
            set;
        }

        public virtual string Descricao_Bairro
        {
            get;
            set;
        }

        public virtual string Cep
        {
            get;
            set;
        }

        public virtual Pais Pais
        {
            get;
            set;
        }
        #endregion
    }
}
