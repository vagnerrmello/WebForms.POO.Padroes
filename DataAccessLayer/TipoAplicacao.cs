using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    public enum TipoAplicacao
    {
        /// <summary>
        /// Stet Web com conexao PostGreSql
        /// </summary>
        WebPostGreSQL,

        /// <summary>
        /// Stet Web com conexao SqlServer
        /// </summary>
        WebSqlServer,
    }
}
