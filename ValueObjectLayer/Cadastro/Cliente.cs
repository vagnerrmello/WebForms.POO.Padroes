//-----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Cliente
    /// </summary>
	public class Cliente
    {
		public Cliente()
		{
		}

        public Cliente(int id)
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

        public virtual string CPF
        {
            get;
            set;
        }

        public virtual string Identidade
        {
            get;
            set;
        }

        public virtual string Email
        {
            get;
            set;
        }

        public virtual string Fone
        {
            get;
            set;
        }

        public virtual string Sexo
        {
            get;
            set;
        }

        public virtual string Parentesco
        {
            get;
            set;
        }

        public virtual DateTime Nascimento
        {
            get;
            set;
        }

        public virtual string Deficiencia
        {
            get;
            set;
        }

        public virtual string Tipo_Sanguineo
        {
            get;
            set;
        }

        /// <summary>
        /// Número do Registro de Nascimento
        /// </summary>
        public virtual string Registro_Nascimento
        {
            get;
            set;
        }

        /// <summary>
        /// Carteira Nacional de Saúde
        /// </summary>
        public virtual string CNS
        {
            get;
            set;
        }

        public virtual string Alergia
        {
            get;
            set;
        }

        public virtual string Plano_Saude
        {
            get;
            set;
        }

        public virtual string Plano_Matricula
        {
            get;
            set;
        }

        public virtual DateTime Plano_Validade
        {
            get;
            set;
        }

        public virtual string Plano_Titular
        {
            get;
            set;
        }

        public virtual string Outras_Obs
        {
            get;
            set;
        }

        public virtual bool Ativo
        {
            get;
            set;
        }

        public virtual bool Bloqueado
        {
            get;
            set;
        }
        #endregion
    }

    public enum GrauParentesco
    {
        Pai = '1',
        Mae = '2',
        Padrasto = '3',
        Madrasta = '4',
        Avo = '5',
        Tio = '6',
        Motorista = '7',
        Amigo = '8'

    }
}
