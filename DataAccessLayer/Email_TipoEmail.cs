using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    public class Email_TipoEmail
    {
        private int idEmail;
        private string tipoEmail;

        public string TipoEmail
        {
            get { return tipoEmail; }
            set { tipoEmail = value; }
        }

        public int IdEmail
        {
            get { return idEmail; }
            set { idEmail = value; }
        }

        public Email_TipoEmail(int idEmail, string tipoEmail)
        {
            this.IdEmail = idEmail;
            this.tipoEmail = tipoEmail;
        }
    }
}
