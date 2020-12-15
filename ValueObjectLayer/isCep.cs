using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    public class isCep
    {
        public isCep()
		{
		}

        public isCep(int id)
        {
            this.Id = id;
        }

        #region Properties

        public virtual int Id
        {
            get;
            set;
        }

        public virtual int Codigo
        {
            get;
            set;
        }

        public virtual string Cep
        {
            get;
            set;
        }
        #endregion
    }
}
