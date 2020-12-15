<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="SolicitacaoAnalise.aspx.cs" Inherits="Steto.Estoque.Gerencia.SolicitacaoAnalise" %>
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
            Análise de Solicitação de Produtos em Estoque
        </legend>
            <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">
                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                    <table>
                                        <tr>
                                            <td align="left" colspan="3" style="background-color:#F7F6F3">
                                                <asp:Label ID="lblFiltroSolicitacoes" runat="server" Text="Filtros:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color:#F7F6F3">
                                            <td>
                                                <asp:Label ID="lblStatusSolicitacaoPesquisa" runat="server" Text="Status:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEstoqueNumeroNota" runat="server" Text="Número da Nota:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEstoqueNotaDataVencimento" runat="server" Text="Data Vencimento:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="background-color:#F7F6F3">
                                            <td>
                                                <asp:DropDownList ID="ddlStatuSolicitacaoPesquisa" runat="server" Width="100px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="S">Selecione</asp:ListItem>
                                                    <asp:ListItem Value="P">Pendente</asp:ListItem>
                                                    <asp:ListItem Value="A">Aprovada</asp:ListItem>
                                                    <asp:ListItem Value="R">Rejeitada</asp:ListItem>
                                                    <asp:ListItem Value="E">Entregue</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtNumeroSolicitacaoPesquisa" runat="server" Width="187px"></asp:TextBox>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:TextBox ID="txtDataSolicitacaoPesquisa" runat="server" Width="187px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CEDataSolicitacaoPesquisa" runat="server" Enabled="True" TargetControlID="txtDataSolicitacaoPesquisa"></ajaxToolkit:CalendarExtender>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="right" colspan="3">
                                            <asp:Button ID="btnPesquisar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                            &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>

                                <center>
                                    <table>
                                        <tr>
                                            <td >
                                                <b> <asp:Label ID="lblResultadoPesquisa" runat="server" Text="Resultado da Pesquisa" Font-Bold="True" ForeColor="#336699" Visible="false"></asp:Label></b> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridPesquisa" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center" PageSize="3" ShowFooter="True" Width="584px" ForeColor="#333333" GridLines="None" OnRowCommand="GridPesquisa_RowCommand">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Id" HeaderText="Numero" ItemStyle-HorizontalAlign="Center" Visible="true"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                                        <asp:BoundField DataField="Funcionario.Nome" HeaderText="Colaborador" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle Width="500px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Data_Solicitacao" HeaderText="Data" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}">
                                                            <HeaderStyle Width="150px" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="Center"><HeaderStyle Width="120px" /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

                                                        <asp:ButtonField ButtonType="Button" CommandName="Visualizar" HeaderText="" Text="Visualizar" ItemStyle-HorizontalAlign="Center"/>
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
                    </asp:View>
                    <asp:View ID="viewSolicitacao" runat="server">
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
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblQuantidadeProduto" runat="server" Text="Quantidade de Produto(s): " Font-Bold="True" ForeColor="#336699"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblQuantidadeProdutoDaSolicitacao" runat="server"  ForeColor="#000000" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br /><br />
                        <center>
                            <asp:Label ID="Label1" runat="server" Text="Lista de Produto(s)"  ForeColor="#000000" Font-Bold="True"></asp:Label>

                            <asp:GridView ID="GridProdutosSolicitacao" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" PageSize="5" ShowFooter="True" Width="822px">
                                <Columns>
                                    <asp:BoundField DataField="Estoque.Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true"><ItemStyle HorizontalAlign="Center" Width="100px"/></asp:BoundField>
                                    <asp:BoundField DataField="Produto.Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left"><HeaderStyle Width="300px" HorizontalAlign="Center"/><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                                    <asp:BoundField DataField="Quantidade" HeaderText="Qtd. Solicitada" ItemStyle-HorizontalAlign="Center"><HeaderStyle Width="120px"  /><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                </Columns>
                            </asp:GridView>


                        </center>
                        <br /><br />
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblStatus" runat="server" Text="Status: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="P">Pendente</asp:ListItem>
                                        <asp:ListItem Value="A">Aprovada</asp:ListItem>
                                        <asp:ListItem Value="R">Rejeitada</asp:ListItem>
                                        <asp:ListItem Value="E">Entregue</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnImprimeTermoEntrega" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="308px" Text="Imprimir Termo de Entrega" Visible="true"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblObservacao" runat="server" Text="Oberservação: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtObservacao" runat="server" MaxLength="250" TextMode="MultiLine" Width="540px" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" align="right">
                                    <asp:Button ID="btnEnviaAnalise" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Enviar Análise" OnClick="btnEnviaAnalise_Click" />
                                    &nbsp;<asp:Button ID="BtnNovaNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Cancelar" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    </asp:MultiView>
        </fieldset>
</asp:Content>
