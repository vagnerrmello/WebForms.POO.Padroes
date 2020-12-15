//-----------------------------------------------------------------------
// <copyright file="Paciente.cs" company="Steto">
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
    /// Representa o objeto referente ao paciente da clínica
    /// </summary>
    public class Paciente
    {

        public Paciente()
        { }

        public Paciente(int id)
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

        public virtual string Identidade
        {
            get;
            set;
        }

        public virtual string CPF
        {
            get;
            set;
        }

        /// <summary>
        /// CNS = Carteira Nacional de Saúde
        /// </summary>
        public virtual string CNS
        {
            get;
            set;
        }

        public virtual byte[] Imagem
        {
            get;
            set;
        }

        public virtual int Sexo
        {
            get;
            set;
        }

        public virtual int EstadoCivil
        {
            get;
            set;
        }

        public virtual int Cor
        {
            get;
            set;
        }

        public virtual CBO Cbo
        {
            get;
            set;
        }

        public virtual DateTime Nascimento
        {
            get;
            set;
        }

        public virtual int IdConvenio
        {
            get;
            set;
        }
        #endregion

    }
}
