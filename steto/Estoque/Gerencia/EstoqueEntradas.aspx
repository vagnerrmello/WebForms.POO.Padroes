<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstoqueEntradas.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoqueEntradas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server"  >

        <div class="clear">
            </div>

        <center>
        <table class="page3">
            <tr>
                <td align="left" colspan="5"><b><asp:Label ID="lblEstoqueProduto" runat="server" Text="Adicionar Produto ao Estoque: "></asp:Label></b> 
                    <asp:Label ID="lblMsg" runat="server" Text="" BackColor="Yellow" ForeColor="Red" Font-Bold="true" ></asp:Label>

                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <table>
                        <tr>
                            <td align="right"><asp:Label ID="lblProdutoCodigo" runat="server" Text="Código:"></asp:Label></td>
                            <td  align="left"><asp:Label ID="lblCodigo" runat="server" ></asp:Label></td>
                        </tr>
                       <tr>
                            <td align="right"><asp:Label ID="lblEstoqueProdutoDescricao" runat="server" Text="Descrição:"></asp:Label></td>
                            <td  colspan="5"><asp:TextBox ID="txtEstoqueProdutoDescricao" runat="server" Width="540px"></asp:TextBox></td>
                        </tr>

                                    <tr>

                                        <td align="right"><asp:Label ID="lblEstoqueProdutoUnidadeMedida" runat="server" Text="Unid. Medida:"></asp:Label></td>
                                        <td >
                                            <asp:DropDownList ID="ddlEstoqueProdutoUnidadeMedida" runat="server" Width="100px" > 
                                                <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                                <asp:ListItem Value="un"> un - unidade </asp:ListItem>
                                                <asp:ListItem Value="m"> m - metro </asp:ListItem>
                                                <asp:ListItem Value="l"> l -litro </asp:ListItem>
                                                <asp:ListItem Value="kg"> kg -quilograma </asp:ListItem>
                                                <asp:ListItem Value="m2"> m² -metro quadrado </asp:ListItem>
                                                <asp:ListItem Value="m3"> m³ -metro cúbico </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right"><asp:Label ID="lblEstoqueProdutoValorUnitario" runat="server" Text="Valor Unitário:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtEstoqueProdutoValorUnitario" runat="server" Width="100px"></asp:TextBox></td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td><asp:Label ID="lblEstoqueProdutoQuantidadeMinima" runat="server" Text="Estoque Mínimo:"></asp:Label><asp:TextBox ID="txtEstoqueProdutoQuantidadeMinima" runat="server" Width="100px"></asp:TextBox></td>
                                    </tr>

                    </table>
                    </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <b> <asp:CheckBox ID="ChkConsumoInterno" runat="server" Text="Produto Para Consumo Interno?" TextAlign="Left" /></b>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnSalvar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White"  Width="88px" Text="Adicionar" 
                        onclick="btnSalvar_Click"/>
                    &nbsp;

                    <asp:Button ID="btnCancelar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White"  Width="88px" Text="Cancelar" 
                        onclick="btnCancelar_Click"/>
                </td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>


        </table>
        </center>

    </form>
</body>
</html>
