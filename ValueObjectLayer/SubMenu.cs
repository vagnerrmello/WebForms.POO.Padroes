//-----------------------------------------------------------------------
// <copyright file="Modulo.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto SubMenu
    /// </summary>
    public class SubMenu
    {
        public SubMenu()
		{
		}

        public SubMenu(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Menu Menu
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
		#endregion
	}
}
