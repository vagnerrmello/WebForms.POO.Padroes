using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.Util.Mensagens
{
    public enum MensagemLog
    {
        LOGIN
    }

    public static class MensagensValorLog
    {

        public static string GetStringValue(string valor)
        {
            switch (valor)
            {
                case "LOGIN":
                    return "O usuário #usuario# entrou no sistema! IP: #ip#";
                default:
                    return string.Empty;
            }

        }
    }

}
