<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelDeControleMenu.aspx.cs" Inherits="Steto.Administrador.PainelDeControleMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
       <div class="header">
            <div class="title">
                <h1>
                    Bem vindo ao Painel de controle do Steto
                </h1>
            </div>
            <div>
                <br /><br />
                <br />
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Administrador/PainelDeControle.aspx" 
                            Text="Usuário" Value="Usuario">
                            <asp:MenuItem NavigateUrl="~/Administrador/Usuario/UsuarioPesquisa.aspx" 
                                Text="Pesquisar" Value="Pesquisarr"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Administrador/Usuario/UsuarioNovo.aspx" 
                                Text="Novo" Value="Novo"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Perfil" Value="Perfil"/>
                    </Items>
                </asp:Menu>
            </div>
        </div>
    </form>
</body>
</html>
