//-----------------------------------------------------------------------
// <copyright file="Tentativa.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Steto.ValueObjectLayer
{
    /// <summary>
    /// Representa um objeto Tentativa
    /// </summary>
    public class Tentativa
    {
        private int nTentativa;
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public int NTentativa
        {
            get { return nTentativa; }
            set { nTentativa = value; }
        }
    }
}
