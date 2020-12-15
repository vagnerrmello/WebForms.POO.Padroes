<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="UsuarioEditar.aspx.cs" Inherits="Steto.Administrador.Usuario.UsuarioEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <div class="submitButtonUsuarioCenter">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
                <fieldset class="fieldseUsuario">
                    <legend>Edição de usuário</legend>

                    <div class="submitButtonUsuario"> 
                        <asp:Label ID="lblPerfil" runat="server" Text="Perfil"></asp:Label> :
                        <asp:DropDownList ID="ddlPerfil" runat="server" Width="195px">
                        </asp:DropDownList>
                    </div>
                    <div class="submitButtonUsuario"> 
                        <asp:Label ID="lblNome" runat="server" Text="Nome" ></asp:Label> :
                        <asp:TextBox ID="txtNome" runat="server" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label> :
                        <asp:TextBox ID="txtEmail" runat="server" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario">
                        <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label> :
                        <asp:TextBox ID="txtLogin" runat="server" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario">
                        <asp:Label ID="lblSenhaAtual" runat="server" Text="Senha atual"></asp:Label> :
                        <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario">
                        <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label> :
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario">
                        <asp:Label ID="lblConfirmaSenha" runat="server" Text="Confirmar senha"></asp:Label> :
                        <asp:TextBox ID="txtCSenha" runat="server" TextMode="Password" Width="188px"></asp:TextBox>
                    </div>
                    <div class="submitButtonUsuario"> 
                        <asp:Label ID="lblTextoUsuario" runat="server" Text="Usuário Ativo? "></asp:Label> :
                        <asp:Label ID="lblAtivo" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div class="submitButtonUsuarioCenter">
                        <asp:Button ID="btnAlterar" runat="server" Width="88px" Text="Alterar" 
                            onclick="btnAlterar_Click"/>
                        <asp:Button ID="btnCancelar" runat="server" Width="88px" Text="Cancelar" 
                            onclick="btnCancelar_Click"/>
                    </div>
                </fieldset>

</asp:Content>