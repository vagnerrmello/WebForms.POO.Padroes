<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoquePesquisa.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoquePesquisa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<%@ Register tagPrefix="ajaxToolkit" assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend>Estoque </legend>
        <center>

        <fieldset class="fieldsetPesquisa">
            <legend>Pesquisa: </legend>
            <center>
            <table>
                <tr>
                    <td><asp:Label ID="lblProdutoPesquisa" runat="server" Text="Produto:"></asp:Label></td>
                    <td><asp:Label ID="lblUsuario1" runat="server" Text="Insira o nome do Produto:"></asp:Label></td>
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
                    <asp:Button ID="btnPesquisar" runat="server" Width="88px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                    &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" Width="88px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                    </td>
                </tr>

            </table>
                </center>
        </fieldset>



                                <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="3" ShowFooter="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                        <HeaderStyle Width="300px" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ValorUnitario" HeaderText="Vlr Unitário" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Em Estoque" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>


                                        <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Edição" Text="Editar" />
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
    </fieldset>
        </center>
                    <asp:MultiView ID="MultiViewProduto" runat="server" ActiveViewIndex="0">
                        <asp:View ID="ViewEdita" runat="server">
                <center>
                <table>
                    <tr>
                        <td>
                            <center>
                                <center>
                                    <iframe id="I1" class="auto-style1" name="I1" src="EstoqueEntradas.aspx" width="809px"></iframe>
                                </center>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="BtnFecharCadastro" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Sair do Cadastro" OnClick="BtnFecharCadastro_Click" />

                        </td>
                    </tr>
                </table>
                    </center>
                        </asp:View>
                    </asp:MultiView>

</asp:Content>
