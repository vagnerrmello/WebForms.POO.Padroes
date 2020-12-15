<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="PerfilNovo.aspx.cs" Inherits="Steto.Administrador.Perfil.PerfilNovo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <fieldset class="fieldseUsuario" >
        <legend>Novo perfil</legend>
            <div class="submitButtonUsuario2">
                <asp:Label ID="Label1" runat="server" Text="Insira o nome do novo perfil: "></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtPerfil" runat="server" Width="184px"></asp:TextBox>
            </div>

            <div class="submitButtonUsuario2">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" 
                    onclick="btnSalvar_Click" />
                &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="88px" 
                    onclick="btnCancelar_Click" />
            </div>
        </fieldset>
</asp:Content>
