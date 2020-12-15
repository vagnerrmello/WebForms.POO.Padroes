using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Steto.ValueObjectLayer
{
    public class PerfilModuloFuncionalidadePermissao
    {
        private int idPerfil;
        private string nomePerfil;
        private int idModulo;
        private string nomeModulo;
        private int idFuncionalidade;
        private string nomeFuncionalidade;
        private int idPermissao;
        private string nomePermissao;
        private string caminhoPagina;


        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public string NomePerfil
        {
            get { return nomePerfil; }
            set { nomePerfil = value; }
        }

        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        public string NomeModulo
        {
            get { return nomeModulo; }
            set { nomeModulo = value; }
        }
        
        public int IdFuncionalidade
        {
            get { return idFuncionalidade; }
            set { idFuncionalidade = value; }
        }
        
        public string NomeFuncionalidade
        {
            get { return nomeFuncionalidade; }
            set { nomeFuncionalidade = value; }
        }
        
        public int IdPermissao
        {
            get { return idPermissao; }
            set { idPermissao = value; }
        }
        
        public string NomePermissao
        {
            get { return nomePermissao; }
            set { nomePermissao = value; }
        }


        public string CaminhoPagina
        {
            get { return caminhoPagina; }
            set { caminhoPagina = value; }
        }

        public PerfilModuloFuncionalidadePermissao()
        {}

        public PerfilModuloFuncionalidadePermissao(string isNomeFuncionalidade
            )
        {
            this.nomeFuncionalidade = isNomeFuncionalidade;
        }

        public PerfilModuloFuncionalidadePermissao(int isIdPerfil, int isIdModulo,
                                                   int isIdFuncionalidade,
                                                   int isIdPermissao
            )
        {
            this.IdPerfil = isIdPerfil;
            this.idModulo = isIdModulo;
            this.idFuncionalidade = isIdFuncionalidade;
            this.idPermissao = isIdPermissao;
        }

        public PerfilModuloFuncionalidadePermissao(int isIdPerfil, string isNomePerfil, int isIdModulo,
                                                    string isNomeModulo, int isIdFuncionalidade, 
                                                    string isNomeFuncionalidade, int isIdPermissao,
                                                    string isNomePermissao, string isCaminhoPagina
            )
        {
            this.IdPerfil = isIdPerfil;
            this.NomePerfil = isNomePerfil;
            this.idModulo = isIdModulo;
            this.nomeModulo = isNomeModulo;
            this.idFuncionalidade = isIdFuncionalidade;
            this.nomeFuncionalidade = isNomeFuncionalidade;
            this.idPermissao = isIdPermissao;
            this.nomePermissao = isNomePermissao;
            this.caminhoPagina = isCaminhoPagina;
        }


    }
}
