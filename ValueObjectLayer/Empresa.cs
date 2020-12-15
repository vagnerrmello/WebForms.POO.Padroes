//-----------------------------------------------------------------------
// <copyright file="Empresa.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;
namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Empresa
    /// </summary>
	public class Empresa
    {
		public Empresa() { }

        public Empresa(int id){ this.Id = id; }

		#region Properties
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Cpf_Cnpj { get; set; }

        public virtual string Logradouro { get; set; }
        public virtual string nroLogradouro { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Cep { get; set; }

        public virtual string Pais { get; set; }
        public virtual string codPais { get; set; }

        public virtual string Cidade { get; set; }
        public virtual string codCidade { get; set; }


        public virtual string Estado { get; set; }

        public virtual string Fone { get; set; }

        public virtual string Email { get; set; }

        public virtual string Inscricao_Estadual { get; set; }

        public virtual string Isento { get; set; }

        public virtual string IE_Substituto_Tributario { get; set; }

        public virtual string Inscricao_Municipal { get; set; }

        public virtual string CNAE { get; set; }

        public virtual string Codigo_Regime_tributario { get; set; }

        public virtual string Nome_Fantasia { get; set; }




        /// <summary>
        /// F = Física; J = Jurídica
        /// </summary>
        public virtual string PessoaFisicaJuridica { get; set; }

        /// <summary>
        /// E = Empresa; F = Fornecedor
        /// </summary>
        public virtual string Tipo { get; set; }

        #endregion
    }

}
