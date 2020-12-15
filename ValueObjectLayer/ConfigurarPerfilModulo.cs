//-----------------------------------------------------------------------
// <copyright file="ConfigurarPerfilModulo.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto ConfigurarPerfilModulo
    /// </summary>
    public class ConfigurarPerfilModulo
    {
        private int id;
        private int idPerfil;
        private int idModulo;
        private bool checkModulo;

        public bool CheckModulo
        {
            get { return checkModulo; }
            set { checkModulo = value; }
        }

        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public ConfigurarPerfilModulo(int id, int idPerfil, int idModulo, bool checkModulo)
        {
            this.id = id;
            this.idPerfil = idPerfil;
            this.idModulo = idModulo;
            this.checkModulo = checkModulo;
        }

        public ConfigurarPerfilModulo(int idPerfil, int idModulo, bool checkModulo)
        {
            this.idPerfil = idPerfil;
            this.idModulo = idModulo;
            this.checkModulo = checkModulo;
        }

    }
}
