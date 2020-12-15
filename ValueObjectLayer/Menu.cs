//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Menu
    /// </summary>
    public class Menu
    {
        public Menu()
		{
		}

        public Menu(int id)
        {
            this.Id = id;
        }

		#region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual Modulo Modulo
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

        public virtual SubMenu SubMenu
        {
            get;
            set;
        }
        #endregion
    }
}
