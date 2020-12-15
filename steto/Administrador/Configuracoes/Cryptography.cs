using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Criptografia de QueryStrin
/// por Edgar Esteves
/// </summary>

public class Cryptography
{
    private static byte[] chave = { };
    private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };
    public Cryptography()
    {

    }
    public static string GerarCriptografia(string info, string key)
    {
        DESCryptoServiceProvider des;
        MemoryStream ms;
        CryptoStream cs; byte[] input;

        try
        {
            des = new DESCryptoServiceProvider();
            ms = new MemoryStream();
            input = System.Text.Encoding.UTF8.GetBytes(info); chave = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));

            cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static string GerarDescriptografia(string info, string key)
    {
        DESCryptoServiceProvider des;
        MemoryStream ms;
        CryptoStream cs; byte[] input;

        try
        {
            des = new DESCryptoServiceProvider();
            ms = new MemoryStream();

            input = new byte[info.Length];
            input = Convert.FromBase64String(info.Replace(" ", "+"));

            chave = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));

            cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
