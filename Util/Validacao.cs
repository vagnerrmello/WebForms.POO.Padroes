
using Steto.ValueObjectLayer;
using System;

namespace Steto.Util
{
    /// <summary>
    /// Classe Util para Validação
    /// </summary>
    /// <remarks>
    /// Métodos do CPF, CNPJ e PIS retirados da página do Macoratti.
    /// http://www.macoratti.net/11/09/c_val1.htm
    /// </remarks>
    public class Validacao
    {
        #region Métodos Públicos
        /// <summary>
        /// Método para validação do CNPJ
        /// </summary>
        /// <param name="cnpj">CNPJ a validar</param>
        /// <returns></returns>
        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            ///Remove os espaços em branco, '.', '-' e '/'
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        /// <summary>
        /// Método para validação do CPF
        /// </summary>
        /// <param name="cpf">CPF a validar</param>
        /// <returns></returns>
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            ///Remove os espaços em branco, '.' e '-'
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Método para validação do PIS
        /// </summary>
        /// <param name="pis">PIS a validar</param>
        /// <returns></returns>
        public static bool IsPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            if (pis.Trim().Length != 11)
                return false;

            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return pis.EndsWith(resto.ToString());
        }

        /// <summary>
        /// Método para validação de uma Data
        /// </summary>
        /// <param name="data">Data a validar</param>
        /// <returns>true se Verdadeiro</returns>
        public static bool IsData(string data)
        {
            bool retorno = false;
            if (!data.Equals(""))
            {
                //DateTime isData = Convert.ToDateTime(data);
                System.Text.RegularExpressions.Regex er = new System.Text.RegularExpressions.Regex(@"^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$");
                retorno = er.IsMatch(Convert.ToDateTime(data).ToString("dd/MM/yyyy"));

                if (data.Equals("01/01/0001 00:00:00")) retorno = false;
            }

            return retorno;
        }

        private static bool VerificaLicenca()
        {
            string mensagem = string.Empty;
            string vChaveAtual = string.Empty;
            DateTime dtUltimaLicenca = Convert.ToDateTime("12/06/2017");
            DateTime dtAtual = DateTime.Now;
            int dias = (DateTime.Parse("12/07/2017") - DateTime.Parse("12/07/2017")).Days;
            
   

            return false;
        }

        /// <summary>
        /// Método que verifica se o valor passado é númerico
        /// </summary>
        /// <param name="strValor">Valor para verificação</param>
        /// <returns>true se Valor for númerico</returns>
        public static bool IsNumeric(string strValor)
        {
            char[] AIM_stDatachars = strValor.ToCharArray();

            foreach (var AIM_stDatachar in AIM_stDatachars)
            {
                if (!char.IsDigit(AIM_stDatachar))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Verifica se a quantidade em estoque está baixa
        /// </summary>
        /// <param name="strValor">Valor para verificação</param>
        /// <returns>true se Valor for númerico</returns>
        private static string VerificaQuantidadeEmEstoque(Estoque estoque)
        {
            string retorno = string.Empty;
            if (estoque.Quantidade > estoque.Produto.QuantidadeMinimaEstoque)
                retorno = "OK";

            if (estoque.Quantidade == estoque.Produto.QuantidadeMinimaEstoque)
                retorno = "Produto com estoque mínimo!";

            if (estoque.Quantidade < estoque.Produto.QuantidadeMinimaEstoque)
                retorno = "Produto com estoque abaixo do mínimo!";

            return retorno;
        }

        #endregion Métodos Públicos
    }
}
