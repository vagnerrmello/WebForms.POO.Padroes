<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoqueSaida.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoqueSaida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend> 
            <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
            <br />
            Solicitação de Produtos em Estoque
        </legend>
                <asp:MultiView ID="MultiViewNota" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">
                        
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDataSolicitacao" runat="server" Text="Data da Solicitação: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDataAtualSolicitacao" runat="server" ForeColor="#336699" Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartamento" runat="server" Width="300px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSolicitante" runat="server" Text="Solicitante: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSolicitante" runat="server" Width="400px"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        
                        <center>

                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                <table>
                                    <tr>
                                        <td><asp:Label ID="lblUsuario1" runat="server" Text="Pesquise o PRODUTO para saída do estoque:" ForeColor="#336699" Font-Bold="true"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="456px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                        <asp:Button ID="btnPesquisar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                        </td>
                                    </tr>

                                </table>


                            <table>
                                <tr>
                                    <td >
                                       <b> <asp:Label ID="lblResultadoPesquisa" runat="server" Text="Resultado da Pesquisa" ForeColor="#336699" Visible="false"></asp:Label></b> </td>
                                    <td></td>
                                    <td >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center" OnRowCommand="GridPoduto_RowCommand" PageSize="3" ShowFooter="True" Width="666px" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="txtCodigo" SortExpression="txtCodigo" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCodigo" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Id") %>' Visible="false" Width="9px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="300px" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Em Estoque" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Qtd Solicitada" SortExpression="ValorEntrada">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtValorEntrada" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Entrada") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Button" CommandName="Solicitar" HeaderText="" Text="Solicitar &gt;&gt;" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    </td>

                                </tr>
                            </table>
                            </center>
                    </fieldset>
                            <br />
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnEnviarSolicitacao" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="250px" Text="Enviar Solicitação  >>>" OnClick="btnEnviarSolicitacao_Click"  />
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b> <asp:Label ID="lblProdutosSolicitados" runat="server" Text="PRODUTOS SOLICITADOS" ForeColor="#000000" Visible="false"></asp:Label></b> 
                                    </td>
                                </tr>
                            </table>
                            
                            <br /><br />
                            <asp:GridView ID="GridProdutosSolicitacao" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" PageSize="5" ShowFooter="True" Width="822px" OnRowCommand="GridProdutosSolicitacao_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Qtd. Solicitada" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Excluir" HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" Text="Excluir" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>

                            <br />

                        </center>

                </asp:View>
                <asp:View ID="View1" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="right">

                                <asp:ImageButton ID="btnVisualizarImpressaoCliente" runat="server" Height="46px" ImageUrl="~/imagens/VisualizarImprimir.png"  Width="55px" OnClick="btnVisualizarImpressaoCliente_Click" />

                            </td>
                        </tr>
                    </table>
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
                </asp:View>
        </asp:MultiView>

    </fieldset>
        
</asp:Content>
