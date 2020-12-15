using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Steto.ValueObjectLayer
{
    public class CEP
    {
        #region "Váriavies"  

        #endregion  
 
        #region "Propiedades"  
        public string UF
        {
            get;
            set;
        }

        public int IdCidade
        {
            get;
            set;
        }  

        public  string Cidade  
        {
            get;
            set;
        }

        public int IdBairro
        {
            get;
            set;
        }

        public string Bairro  
        {
            get;
            set; 
        }  
        public string TipoLagradouro  
         {
             get;
             set;
        }  
        
        public  string Lagradouro  
        {
            get;
            set;
        }

        public string isCep
        {
            get;
            set;
        }  

        public string Resultado  
        {
            get;
            set;
        }  
        public string  ResultadoTXT  
        {
            get;
            set;
        }  
        #endregion  

#region "Construtor"  
        public CEP() { }
         /// <summary>  
        /// WebService para Busca de CEP  
        ///  </summary>  
        /// <param  name="CEP"></param>  
        //public CEP(string isCEP)  
        // {  
        //    _uf = "";  
        //    _cidade = "";  
        //    _bairro =  "";  
        //    _tipo_lagradouro="";  
        //     _lagradouro="";  
        //    _resultado="0";  
        //     _resultato_txt="CEP não encontrado";  
  
        //    //Cria um DataSet  baseado no retorno do XML  
        //    DataSet ds = new  DataSet();  
        //    ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep="  + isCEP.Replace("-","").Trim() + "&formato=xml");  
  
        //    if (ds !=  null)  
        //    {  
        //         if (ds.Tables[0].Rows.Count >  0)  
        //         {  
        //            _resultado =  ds.Tables[0].Rows[0]["resultado"].ToString();  
        //            switch  (_resultado)  
        //            {  
        //                case  "1":  
        //                    _uf =  ds.Tables[0].Rows[0]["uf"].ToString().Trim();  
        //                    _cidade =  ds.Tables[0].Rows[0]["cidade"].ToString().Trim();  
        //                    _bairro =  ds.Tables[0].Rows[0]["bairro"].ToString().Trim();  
        //                    _tipo_lagradouro =  ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();  
        //                    _lagradouro =  ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();  
        //                    _resultato_txt = "CEP completo";  
        //                    break;  
        //                case "2":  
        //                    _uf =  ds.Tables[0].Rows[0]["uf"].ToString().Trim();  
        //                    _cidade =  ds.Tables[0].Rows[0]["cidade"].ToString().Trim();  
        //                    _bairro = "";  
        //                    _tipo_lagradouro =  "";  
        //                    _lagradouro =  "";  
        //                    _resultato_txt = "CEP  único";  
        //                    break;  
        //                 default:  
        //                    _uf = "";  
        //                    _cidade = "";  
        //                    _bairro =  "";  
        //                    _tipo_lagradouro =  "";  
        //                    _lagradouro =  "";  
        //                    _resultato_txt = "CEP não  encontrado";  
        //                    break;  
        //             }  
        //         }  
        //    }  
        //    //Exemplo do retorno da  WEB  
        //    //<?xml version="1.0"  encoding="iso-8859-1"?>  
        //    //<webservicecep>  
        //     //<uf>RS</uf>  
        //    //<cidade>Porto  Alegre</cidade>  
        //    //<bairro>Passo  D'Areia</bairro>  
        //     //<tipo_logradouro>Avenida</tipo_logradouro>  
        //     //<logradouro>Assis Brasil</logradouro>  
        //     //<resultado>1</resultado>  
        //     //<resultado_txt>sucesso - cep  completo</resultado_txt>  
        //     //</webservicecep>  
        //}  
        #endregion  
    }
}
