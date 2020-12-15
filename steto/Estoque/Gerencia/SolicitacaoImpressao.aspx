<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitacaoImpressao.aspx.cs" Inherits="Steto.Estoque.Gerencia.SolicitacaoImpressao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpresaImpressao" runat="server" Text="Empresa: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNomeEmpresaImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSolicitacaoImpressao" runat="server" Text="Número da Solicitação: " ForeColor="#000000" Font-Bold="true" ></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNumeroSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDataSolicitacaoImpressao" runat="server" Text="Data da Solicitação: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDataExtensoSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStatusSolicitacaoImpressao" runat="server" Text="Status da Solicitacao: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStatusResultadoSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFuncionarioImpressao" runat="server" Text="Funcionário: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNomeFuncionarioImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/Fluxos/Fluxo.Enviado.jpg" Height="68px" Width="537px" />
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <b> <asp:Label ID="Label1" runat="server" Text="PRODUTOS SOLICITADOS DO ESTOQUE" ForeColor="#000000" ></asp:Label></b> 
                                    </td>
                                </tr>
                            </table>
                        <br />
                    <center>
                        <asp:Table ID="TbDinamica" runat="server" BorderStyle="Solid" Width="700px"></asp:Table>
                    </center>

                    <br /><br /><br /><br /><br />
                    <center>
                        <asp:Label ID="lblAssinaturaFuncionario0" runat="server" Text="Solicito os produtos acima listados" ForeColor="#000000" />
                        <br /><br /><br />
                        <asp:Label ID="lblAssinaturaFuncionario1" runat="server" Text="--------------------------------------------" ForeColor="#000000" />
                        <br />
                        <asp:Label ID="lblAssinaturaFuncionario2" runat="server" Text="Assinatura do solicitante" ForeColor="#000000" />
                    </center>
    </div>
    </form>
</body>
</html>
