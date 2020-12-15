//-----------------------------------------------------------------------
// <copyright file="Permissao_Funcionalidade.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Permissao_Funcionalidade
    /// </summary>
	public class Permissao_Funcionalidade
	{
        public Permissao_Funcionalidade()
		{
		}

        public Permissao_Funcionalidade(int id)
        {
            this.Id = id;
        }	

        public Permissao_Funcionalidade(int id, Permissao permissao, Funcionalidade funcionalidade)
        {
            this.Id = id;
            this._Permissao = permissao;
            this._Funcionalidade = funcionalidade;
        }	

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Permissao _Permissao
        {
            get;
            set;
        }

        public virtual Funcionalidade _Funcionalidade
        {
            get;
            set;
        }


		#endregion

	}
}
