<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoquePesquisarNota.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoquePesquisarNota" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


    <style type="text/css">
        .auto-style2 {
            height: 29px;
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
            Pesquisar Notas
        </legend>
        <center>

                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                    <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblEstoqueNumeroNota" runat="server" Text="Número da Nota:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEstoqueNotaDataVencimento" runat="server" Text="Data Vencimento:"  Font-Bold="True" ForeColor="#336699"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td rowspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">
                                            <asp:TextBox ID="txtEstoqueNumeroNota" runat="server" Width="187px"></asp:TextBox>
                                        </td>
                                        <td class="auto-style2">
                                            <asp:TextBox ID="txtEstoqueNotaDataPagamento" runat="server" Width="187px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderCadastro" runat="server" Enabled="True" TargetControlID="txtEstoqueNotaDataPagamento">
                                            </ajaxToolkit:CalendarExtender>
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


                        </center>

                

    </fieldset>
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
                            <asp:GridView ID="GridPesquisa" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center" OnRowCommand="GridPesquisa_RowCommand" PageSize="3" ShowFooter="True" Width="762px" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Nota" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Valor" HeaderText="Valor Parcela" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="" Text="  Editar Nota  " ItemStyle-HorizontalAlign="Center"/>
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
</asp:Content>
