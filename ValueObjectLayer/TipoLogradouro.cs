using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    public class TipoLogradouro
    {
        public TipoLogradouro()
        { }

        public TipoLogradouro(int id) { this.Id = id; }

        public int Id
        {
            get;
            set;
        }

        public string Tipo
        {
            get;
            set;
        }
    }


}
