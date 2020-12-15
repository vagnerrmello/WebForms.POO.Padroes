<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastro/ViknCadastro.Master" AutoEventWireup="true" CodeBehind="DepartamentoCadastro.aspx.cs" Inherits="Steto.Cadastro.DepartamentoCadastro" %>
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
            Departamento
        </legend>

        <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewPesquisa" runat="server">
                <center>
                     <table>
                    <tr>
                         
                        <td><asp:Label ID="lblUsuario1" runat="server" Text="Insira o nome do Departamento:"></asp:Label></td>
                        <td rowspan="3">
                            <asp:ImageButton ID="btnAdd" runat="server" Height="53px" ImageUrl="~/imagens/add.jpg" Width="50px" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                       

                        <td>
                            <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="456px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="1">
                        <asp:Button ID="btnPesquisar" runat="server" Width="88px" Text="Pesquisar" />
                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" Width="88px" Text="Limpar" />
                        </td>
                    </tr>

                </table>
                    <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="3" ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descricao" HeaderText="Departamento" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Width="300px" />
                            <ItemStyle HorizontalAlign="Left" />
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
            </asp:View>
            <asp:View ID="ViewCadastro" runat="server">
                <center>
                    <table>
                        <tr>
                            <td align="right"><asp:Label ID="lblCodigoDepartamento" Text="Código: " runat="server"/></td>
                            <td align="left"><asp:Label ID="lblCodigoDepartamentoRecuperado"  runat="server"/></td>
                        </tr>
                        <tr>
                            <td align="right"><asp:Label ID="lblNome" Text="Nome: " runat="server"/></td>
                            <td align="left">
                                <asp:TextBox ID="txtNome" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right"><asp:Label ID="lblDepartamentoAtivo" runat="server" Text="Ativo:"></asp:Label></td>
                            <td align="left">
                                <asp:DropDownList ID="ddlDepartamentoAtivo" runat="server" Width="100px" > 
                                    <asp:ListItem Selected="True" Value="10">Selecione</asp:ListItem>
                                    <asp:ListItem Value="0">Não</asp:ListItem>
                                    <asp:ListItem Value="1">Sim</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                            <asp:Button ID="btnSalvar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Salvar"  />
                            &nbsp;<asp:Button ID="btnCancelar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Cancelar"  />
                            </td>
                        </tr>
                    </table>
                </center>
            </asp:View>
        </asp:MultiView>
    </fieldset>
</asp:Content>
