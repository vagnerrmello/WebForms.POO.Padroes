//-----------------------------------------------------------------------
// <copyright file="Funcionalidade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Funcionalidade
    /// </summary>
    public class Funcionalidade
	{
        public Funcionalidade()
		{
		}

        public Funcionalidade(int id)
        {
            this.Id = id;
        }

        public Funcionalidade(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public Funcionalidade(int id, string descricao, string caminhoPagina)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.CaminhoPagina = caminhoPagina;
        }

        public Funcionalidade(int id, int idModulo, string descricao)
        {
            this.Id = id;
            this._Modulo.Id = idModulo;
            this.Descricao = descricao;
        }

        public Funcionalidade(int id, string descricao, Modulo modulo)
        {
            this.Id = id;
            this.Descricao = descricao;
            this._Modulo = modulo;
        }



		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Modulo _Modulo
        {
            get;
            set;
        }

        public virtual string Descricao
        {
            get;
            set;
        }

        public virtual string CaminhoPagina
        {
            get;
            set;
        }

        public virtual string Funcao
        {
            get;
            set;
        }

		#endregion
	}
}
