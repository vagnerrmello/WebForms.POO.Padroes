<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoqueNotaEdicao.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoqueNotaEdicao" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    <style type="text/css">
        .auto-style1 {
            width: 809px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend> 
            <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
            <br />
            Cadastro de Notas
        </legend>
        <center>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueCodigoNota" runat="server" Text="Codigo:"></asp:Label>

                    </td>
                    <td >
                        <asp:Label ID="lblEstoqueisCodigoNota" runat="server" ></asp:Label>

                    </td>
                    <td colspan="2">
                        <asp:FileUpload runat="server" Width="300px" ID="UploadImagem" Enabled="False"></asp:FileUpload>
                    </td>
                    <td >
                        
                        <asp:ImageButton ID="EnviarImagem" runat="server" ImageUrl="~/imagens/nuvem01.jpg" Enabled="False" Height="25px" Width="51px" OnClick="EnviarImagem_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNumeroNota" runat="server" Text="Nº da Nota:"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueNumeroNota" runat="server" Width="187px" Enabled="False"></asp:TextBox>

                    </td>
                    <td align="right">
                        <asp:Label ID="lblFornecedor" runat="server" Text="Fornecedor:"></asp:Label>

                    </td>
                    <td align="left"> 
                        <asp:DropDownList ID="ddlFornecedor" runat="server" Width="190px" > 
                        </asp:DropDownList>
                    </td>

                    <td rowspan="3">
                        <asp:ImageButton ID="imgNota" runat="server" Height="72px" Width="58px"  ImageUrl="~/imagens/invoice_icon.jpg" OnClick="imgNota_Click"/>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNotaQuantidadeParcelamento" runat="server" Text="Nº de Parcela(s):"></asp:Label>

                    </td>
                    <td align="left">
                         <asp:DropDownList ID="ddlEstoqueNotaQuantidadeParcelamento" runat="server" Width="100px" > 
                            <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                            <asp:ListItem Value="1"> 1 </asp:ListItem>
                            <asp:ListItem Value="2"> 2 </asp:ListItem>
                            <asp:ListItem Value="3"> 3 </asp:ListItem>
                            <asp:ListItem Value="3"> 4 </asp:ListItem>
                            <asp:ListItem Value="5"> 5 </asp:ListItem>
                            <asp:ListItem Value="6"> 6 </asp:ListItem>
                            <asp:ListItem Value="7"> 7 </asp:ListItem>
                            <asp:ListItem Value="8"> 8 </asp:ListItem>
                            <asp:ListItem Value="9"> 9 </asp:ListItem>
                            <asp:ListItem Value="10"> 10 </asp:ListItem>
                            <asp:ListItem Value="11"> 11 </asp:ListItem>
                            <asp:ListItem Value="12"> 12 </asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td align="right">
                        <asp:Label ID="lblEstoqueValorParcelaNota" runat="server" Text="Valor Parcela:"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueValorParcelaNota" runat="server" Width="187px" ></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNotaDataVencimento" runat="server" Text="Data Vencimento:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueNotaDataPagamento" runat="server" Width="187px"></asp:TextBox>

                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderCadastro" runat="server" TargetControlID="txtEstoqueNotaDataPagamento" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>
                    <td colspan="2" align="right">
                         <b> <asp:CheckBox ID="chkEstoqueNotaLancarContasAPagar" runat="server" Text="Lançar Nota Em Contas A Pagar?" TextAlign="Left" /></b>

                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="left">
                        <asp:Label ID="lblObsNota" runat="server" Text="Breve Descrição (Identificação):"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="left">
                        <asp:TextBox ID="txtObsNota" runat="server" Width="675px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <asp:Button ID="btnCriarNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Alterar Nota" OnClick="btnCriarNota_Click" />
                        &nbsp;<asp:Button ID="BtnNovaNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Cancelar" OnClick="BtnNovaNota_Click" />
                    </td>
                </tr>

            </table>
        </center>

                <asp:MultiView ID="MultiViewNota" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">
                        <center>

                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                <table>
                                    <tr>
                                        <td><asp:Label ID="lblProdutoPesquisa" runat="server" Text="Produto:" ForeColor="#A55129" Font-Bold="true"></asp:Label></td>
                                        <td><asp:Label ID="lblUsuario1" runat="server" Text="Pesquise para Inserir o Produto na Nota:" ForeColor="#A55129" Font-Bold="true"></asp:Label>&nbsp;
                                        </td>
                                        <td rowspan="3">
                                            <asp:ImageButton ID="btnAdd" runat="server" Height="53px" ImageUrl="~/imagens/add.jpg" Width="50px" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlEstoqueProduto" runat="server" Width="100px" > 
                                                <asp:ListItem Selected="True" Value="10">  Selecione  </asp:ListItem>
                                                <asp:ListItem Value="0"> Venda </asp:ListItem>
                                                <asp:ListItem Value="1"> Consumo Interno </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="456px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                        <asp:Button ID="btnPesquisar" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" Width="98px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" Width="98px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                        &nbsp;<asp:Button ID="btnCancelarPesquisaProduto" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" Width="98px" Text="Cancelar" OnClick="btnCancelarPesquisaProduto_Click" />
                                        </td>
                                    </tr>

                                </table>
                                    </center>
                            </fieldset>

                            <table>
                                <tr>
                                    <td >
                                       <b> <asp:Label ID="lblResultadoPesquisa" runat="server" Text="Resultado da Pesquisa" ForeColor="#A55129" Visible="false"></asp:Label></b> </td>
                                    <td></td>
                                    <td >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" OnRowCommand="GridPoduto_RowCommand" PageSize="3" ShowFooter="True" Width="666px" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
                                                <asp:TemplateField HeaderText="Entrada" SortExpression="ValorEntrada">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtValorEntrada" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Entrada") %>' Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:ButtonField ButtonType="Button" CommandName="Entrada" HeaderText="" Text="Inserir &gt;&gt;" />
                                            </Columns>
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                                        </asp:GridView>
                                    </td>
                                    <td></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>

                            <br />

                        </center>

                </asp:View>




            <asp:View ID="ViewCadastro" runat="server">
                <center>
                <table>
                    <tr>
                        <td>
                            <center>
                                <center>
                                    <iframe id="I1" class="auto-style1" name="I1" src="EstoqueEntradas.aspx"></iframe>
                                </center>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="BtnFecharCasdro" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Voltar para Nota" OnClick="BtnFecharCasdro_Click" />

                        </td>
                    </tr>
                </table>
                    </center>
            </asp:View>
                    <asp:View ID="ViewItens" runat="server">

                        <center>
                            <br />
                            <b>
                                <asp:Label ID="lblItensInseridos" runat="server" Text="Itens Inseridos na Nota: "></asp:Label><br />
                            <asp:Button ID="btnPesquisarProduto" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Pesquisar Produto" Width="174px" OnClick="btnPesquisarProduto_Click" />
                            </b>
                            <br /><br />
                            <asp:GridView ID="GridProdutoNota" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="3" ShowFooter="True" Width="725px" OnRowCommand="GridProdutoNota_RowCommand">
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
                                <asp:ButtonField ButtonType="Button" CommandName="Excluir" HeaderText="Excluir" Text="Excluir" />
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
                        </center>
                    </asp:View>
        </asp:MultiView>

    </fieldset>
        </center>
</asp:Content>
