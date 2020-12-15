<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="EmailEditar.aspx.cs" Inherits="Steto.Administrador.Configuracoes.EmailEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                <div class="submitButtonUsuarioCenter">
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
    <fieldset class="fieldsetPesquisa">
        <legend>Configuração de email</legend>
            <div class="submitButtonUsuario2">
                <asp:CheckBox ID="CheckEnviarEmail" runat="server" 
                    Text="Enviar email" AutoPostBack="True" 
                    oncheckedchanged="CheckEnviarEmail_CheckedChanged" />
            </div>
            <div class="submitButtonUsuario2">
                <asp:CheckBox ID="CheckAdm" runat="server" 
                    Text="Enviar email para o administrador ao cadastrar usuário" 
                    AutoPostBack="True" oncheckedchanged="CheckAdm_CheckedChanged" />
            </div>
            <div class="submitButtonUsuario2">
                <asp:Label ID="lblEmailAdm" runat="server" Text="Email (Admnistrador) :"></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtEmailAdm" runat="server" Enabled="false" Width="200px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario2">
                <asp:CheckBox ID="CheckGestor" runat="server" 
                    Text="Enviar email para o gestor ao cadastrar usuário" AutoPostBack="True" 
                    oncheckedchanged="CheckGestor_CheckedChanged" />
            </div>
            <div class="submitButtonUsuario2">
                <asp:Label ID="lblEmailGestor" runat="server" Text="Email (Gestor):"></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtEmailGestor" runat="server" Enabled="false" Width="200px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario2">
                <asp:CheckBox ID="CheckPorta" runat="server" Text="Usar porta?: " 
                    AutoPostBack="True" oncheckedchanged="CheckPorta_CheckedChanged" />
            </div>
            <div class="submitButtonUsuario2">
                <asp:Label ID="lblPorta" runat="server" Text="Porta :"></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtPorta" runat="server" Enabled="false" Width="200px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario2">
                <asp:CheckBox ID="CheckSsl" runat="server" Text="Usar SSL?: " 
                    AutoPostBack="True" />
            </div>
            <div class="submitButtonUsuario2"> 
                <asp:Label ID="lblSmtp" runat="server" Text="SMTP: "></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtSmtp" runat="server" Width="200px"></asp:TextBox>
            </div>

            <div class="submitButtonUsuario2"> 
                <asp:Label ID="lblAssunto" runat="server" Text="Assunto : "></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtAssunto" runat="server" Width="420px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario2"> 
                <asp:Label ID="lblCorpoEmail" runat="server" Text="Corpo do email : " ></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtCorpoEmail" runat="server" TextMode="MultiLine" 
                    Width="420px" Height="50px"></asp:TextBox>
            </div>
            <div class="submitButtonUsuario2"> 
                <asp:Label ID="lblEmailEmpresa" runat="server" Text="Email (Empresa) : "></asp:Label>
            </div>
            <div class="submitButtonUsuario2">
                <asp:TextBox ID="txtEmailEmpresa" runat="server" Width="200px"></asp:TextBox>
            </div>
            <br />
            <div class="linha">
                <div class="coluna"> 
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario (Empresa) : "></asp:Label>
                </div>
                <div class="coluna">
                <asp:Label ID="Label1" runat="server" Text="Senha (Empresa) :   "></asp:Label>
                    
                </div>
            </div>
            <div class="linha">
                <div class="coluna"> 
                    <asp:TextBox ID="txtUsuario" runat="server" Width="200px"></asp:TextBox>
                </div>
                <div class="coluna">
                    <asp:TextBox ID="txtSenha" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="submitButtonUsuarioCenter">
                <asp:Button ID="btnAlterar" runat="server" Width="88px" Text="Alterar" 
                    onclick="btnAlterar_Click"/>
                &nbsp;<asp:Button ID="btnCancelar" runat="server" Width="88px" Text="Cancelar" 
                    onclick="btnCancelar_Click"/>
            </div>
    </fieldset>
</asp:Content>
