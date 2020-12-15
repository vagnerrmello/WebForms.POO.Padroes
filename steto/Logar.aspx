<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logar.aspx.cs" Inherits="Steto.Logar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="lblInicio" runat="server" Text="Por favor entre com seu login e senha!"></asp:Label>
    </p>
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>



        <fieldset >
            <legend> Informe sua conta:</legend>
                <table>
        <tr>
            <td>
                <p >
                    Login:
                    <asp:TextBox ID="txtLogin" runat="server" Width="200px"></asp:TextBox> <br />
                    </p>
                    <p >
                    Senha:<br />
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                </p>
                <p  >
                    <asp:Button ID="btnLogar" runat="server" Text="Logar" onclick="btnLogar_Click" />
            </p>
            </td>
            <td>  </td>
            <td align="right">
                <asp:Image ID="img" runat="server" ImageUrl="~/imagens/AmagoLogo.png" Height="109px" Width="188px"  />
            </td>
        </tr>
    </table>
        </fieldset>


</asp:Content>
