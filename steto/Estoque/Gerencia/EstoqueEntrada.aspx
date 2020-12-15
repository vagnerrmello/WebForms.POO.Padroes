<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoqueEntrada.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoqueEntrada" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>

    <fieldset class="fieldsetTabConteinerPaciente">
        <legend>Estoque</legend>
        <center>
        <table>
            

            <tr>
                <td align="left" colspan="5"><b><asp:Label ID="lblEstoqueProduto" runat="server" Text="Adicionar Produto ao Estoque:"></asp:Label></b></td>
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
                                        <td align="right"><asp:Label ID="lblEstoqueProdutoValorUnitario" runat="server" Text="Valor Venda:"></asp:Label></td>
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
                    <asp:Button ID="btnSalvar" runat="server" Text="Adicionar" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px"
                        onclick="btnSalvar_Click" style="height: 29px"/>
                    &nbsp;

                    <asp:Button ID="btnCancelar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Cancelar" 
                        onclick="btnCancelar_Click"/>
                    &nbsp;

                    <asp:Button ID="btnNovoProduto" runat="server" Text="Novo" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px"
                        style="height: 29px" OnClick="btnNovoProduto_Click"/>
                    
                </td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>


        </table>


                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                    <table>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="lblUsuario1" runat="server" Text="Pesquisa por Descrição ou Código do Produto:" ForeColor="#336699" Font-Bold="true"></asp:Label>&nbsp;
                                        </td>
                                        <td rowspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtProdutoPesquisa" runat="server" Width="456px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                        <asp:Button ID="btnPesquisar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                        </td>
                                    </tr>

                                </table>
                                </center>
                            </fieldset>
                            <asp:GridView ID="GridProduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="3" ShowFooter="True" Width="725px" OnRowCommand="GridProduto_RowCommand">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
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
                                                <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="" Text=" Editar " />
                                                <asp:ButtonField ButtonType="Button" CommandName="Desativar" HeaderText="" Text=" Desativar "  ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"/>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
        
                <asp:MultiView ID="MultiViewProduto" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewEdita" runat="server">
                        <table>
                            <tr>
                                <td align="left" colspan="5"><b><asp:Label ID="Label1" runat="server" Text="Alterar Produto ao Estoque:"></asp:Label></b></td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <table>
                                        <tr>
                                            <td align="right"><asp:Label ID="lbllblCodigoAlterar" runat="server" Text="Código:"></asp:Label></td>
                                            <td  align="left"><asp:Label ID="lblCodigoAlterar" runat="server" ></asp:Label></td>
                                        </tr>
                                       <tr>
                                            <td align="right"><asp:Label ID="Label4" runat="server" Text="Descrição:"></asp:Label></td>
                                            <td  colspan="5"><asp:TextBox ID="txtDescricaoProdutoAlterar" runat="server" Width="540px"></asp:TextBox></td>
                                        </tr>
                                            <tr>
                                                <td align="right"><asp:Label ID="Label5" runat="server" Text="Unid. Medida:"></asp:Label></td>
                                                <td >
                                                    <asp:DropDownList ID="ddlUnidadeMedidaAlterar" runat="server" Width="100px" > 
                                                        <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                                        <asp:ListItem Value="un"> un - unidade </asp:ListItem>
                                                        <asp:ListItem Value="m"> m - metro </asp:ListItem>
                                                        <asp:ListItem Value="l"> l -litro </asp:ListItem>
                                                        <asp:ListItem Value="kg"> kg -quilograma </asp:ListItem>
                                                        <asp:ListItem Value="m2"> m² -metro quadrado </asp:ListItem>
                                                        <asp:ListItem Value="m3"> m³ -metro cúbico </asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right"><asp:Label ID="Label6" runat="server" Text="Valor Unitário:"></asp:Label></td>
                                                <td><asp:TextBox ID="txtValorUnitarioAlterar" runat="server" Width="100px"></asp:TextBox></td>
                                                <td align="right">
                                                    &nbsp;</td>
                                                <td><asp:Label ID="Label7" runat="server" Text="Estoque Mínimo:"></asp:Label><asp:TextBox ID="txtQuantidadeMinimoAlterar" runat="server" Width="100px"></asp:TextBox></td>
                                            </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <b> <asp:CheckBox ID="chkConsumoInternoAlterarProduto" runat="server" Text="Produto Para Consumo Interno?" TextAlign="Left" /></b>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnAlterarProduto" runat="server" Text="Alterar" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" OnClick="btnAlterarProduto_Click"
                                        />
                                    &nbsp;

                                    <asp:Button ID="btnCancelarAlterarProduto" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Cancelar" OnClick="btnCancelarAlterarProduto_Click" 
                                       />
                                </td>
                            </tr>
                            <tr>
                                <td>

                                </td>
                            </tr>


                        </table>
                    </asp:View>


                    <asp:View ID="ViewExcluir" runat="server">
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMensagemDesativar" runat="server" Text="Tem certeza que deseja EXCLUIR o Produto?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnCancelarExcluirProduto" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="203px" Text="Cancelar" OnClick="btnCancelarExcluirProduto_Click" />
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Código do Produto:"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblCodigoProdutoExclusao" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescricaoProdutoExclusao" runat="server" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnConfirmarExclusaoProduto" runat="server" BackColor="Red" Font-Bold="True" ForeColor="White" Width="203px" Text="Desativar Produto" OnClick="btnConfirmarExclusaoProduto_Click" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </asp:View>
                </asp:MultiView>
        
        </center>

    </fieldset>
        </center>
</asp:Content>
