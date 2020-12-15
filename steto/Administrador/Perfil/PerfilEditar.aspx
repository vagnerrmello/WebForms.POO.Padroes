<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="PerfilEditar.aspx.cs" Inherits="Steto.Administrador.Perfil.PerfilEditar1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <fieldset class="fieldseUsuario" >
        <legend>Edição de perfil</legend>
            <div class="submitButtonUsuario">
                <asp:Label ID="Label1" runat="server" Text="Altere o nome do perfil: "></asp:Label>
            </div>
            <div class="submitButtonUsuario">
                <asp:TextBox ID="txtPerfil" runat="server" Width="184px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario"> 
                <asp:Label ID="lblTextoUsuario" runat="server" Text="Usuário Ativo? "></asp:Label> :
                <asp:Label ID="lblAtivo" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div class="submitButtonUsuario">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" 
                    onclick="btnSalvar_Click" />
                &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="88px" 
                    onclick="btnCancelar_Click" />
            </div>
        </fieldset>
</asp:Content>
