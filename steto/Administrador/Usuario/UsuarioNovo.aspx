<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="UsuarioNovo.aspx.cs" Inherits="Steto.Administrador.Usuario.UsuarioNovo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldseUsuario">
        <legend>Novo usuário</legend>
        <div class="submitButtonUsuario"> 
            <asp:Label ID="lblPerfil" runat="server" Text="Perfil"></asp:Label> :
            <asp:DropDownList ID="ddlPerfil" runat="server" Width="193px">
            </asp:DropDownList>
        </div>
        <div class="submitButtonUsuario"> 
            <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label> :
            <asp:TextBox ID="txtNome" runat="server" Width="187px"></asp:TextBox>
        </div>
        <div class="submitButtonUsuario">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label> :
            <asp:TextBox ID="txtEmail" runat="server" Width="187px"></asp:TextBox>
        </div>
        <div class="submitButtonUsuario">
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label> :
            <asp:TextBox ID="txtLogin" runat="server" Width="187px"></asp:TextBox>
        </div>
        <div class="submitButtonUsuario">
            <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label> :
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="187px"></asp:TextBox>
        </div>
        <div class="submitButtonUsuario">
            <asp:Label ID="lblConfirmarSenha" runat="server" Text="Confirmar senha :"></asp:Label>
            <asp:TextBox ID="txtConfirmarSenha" runat="server" TextMode="Password" Width="187px"></asp:TextBox>
        </div>
        <br />
        <div class="submitButtonUsuario">
            <asp:Button ID="btnSalvar" runat="server" Width="88px" Text="Salvar" 
                onclick="btnSalvar_Click"/>
            <asp:Button ID="btnCancelar" runat="server" Width="88px" Text="Cancelar" 
                onclick="btnCancelar_Click"/>
        </div>
    </fieldset>
</asp:Content>
