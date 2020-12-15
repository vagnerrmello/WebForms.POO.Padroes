//-----------------------------------------------------------------------
// <copyright file="Contato.cs" company="Steto">
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
    /// Representa um objeto Contato
    /// </summary>
    public class Contato
    {
        public Contato()
		{
        }

        public Contato(int id)
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

        public virtual Cliente Cliente
        {
            get;
            set;
        }

        public virtual TipoLogradouro TipoLogradouro_
        {
            get;
            set;
        }



        public virtual string isContato
        {
            get;
            set;
        }

        public virtual int Preferencia
        {
            get;
            set;
        }

        public virtual TipoContato TipoDeContato
        {
            get;
            set;
        }

        #endregion
    }

    public enum TipoContato
    {
        Telefone = 1,
        Email = 2
    }
}
