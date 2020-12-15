<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="GerenciaFornecedor.aspx.cs" Inherits="Steto.Estoque.Gerencia.GerenciaFornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                <fieldset class="fieldsetTabConteinerPaciente">
                <legend> Dados do Fornecedor </legend>

                <asp:MultiView ID="MultiViewNota" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">

                                <center>
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblUsuario1" runat="server" Font-Bold="true" ForeColor="#336699" Text="Digite para pesquisa do Fornecedor:"></asp:Label>
                                        </td>
                                        <td rowspan="3">
                                            <asp:ImageButton ID="btnAdd" runat="server" Height="53px" ImageUrl="~/imagens/add.jpg" Width="50px" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFornecedorPesquisa" runat="server" Width="456px" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="1">
                                        <asp:Button ID="btnPesquisar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                        </td>
                                    </tr>

                                </table>
                                    <br />


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
                                        <asp:GridView ID="GridFornecedores" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center" OnRowCommand="GridFornecedores_RowCommand" PageSize="3" ShowFooter="True" Width="666px" ForeColor="#333333" GridLines="None">
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
                                                <asp:BoundField DataField="Empresa.Nome" HeaderText="Fornecedor" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="330px" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Empresa.Cpf_Cnpj" HeaderText="Cpf/Cnpj" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="" Text=" Editar " />
                                                <asp:ButtonField ButtonType="Button" CommandName="Excluir" HeaderText="" Text=" Excluir "  ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true"/>
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
                                    <td></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>


                                    </center>


                        </asp:View>

                    <asp:View ID="ViewAlterar" runat="server">
                    <center>
                        <table style="margin: 0px auto;">

                        <tr>
                            <td align="right">Código:</td>

                            <td align="left">
                                <asp:Label ID="lblCodigoFornecedor" runat="server" Text="" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Nome:</td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Cpf/Cnpj:</td>
                            <td align="left">
                                <asp:TextBox ID="txtCpf_Cnpj" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Inscrição Estadual:</td>
                            <td align="left">
                                <asp:TextBox ID="txtInscricaoEstadual" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Pessoa Física/Jurídica:</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPessoaFisicaJurida" runat="server" Width="100px" > 
                                    <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                    <asp:ListItem Value="F"> Física </asp:ListItem>
                                    <asp:ListItem Value="J"> Jurídica </asp:ListItem>
                                </asp:DropDownList>                            
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2"><b> Endereço:</b></td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>Logradouro</td>
                                        <td>Bairro</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtLogradouro" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBairro" runat="server" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>

                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>Cep</td>
                                        <td>Cidade</td>
                                        <td>Estado</td>
                                        <td>Telefone</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCep" runat="server" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCidade" runat="server" Width="240px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtEstado" runat="server" Width="50px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTelefone" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                E-mail
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtEmail" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnSalvarFornecedor" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Salvar" OnClick="btnSalvarFornecedor_Click" />
                                                                        &nbsp;
                                    <asp:Button ID="btnVoltarAtualizar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Voltar" OnClick="btnVoltarAtualizar_Click" />
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>

                    </table>
                    </center>

                    </asp:View>
                    

                    
                    <asp:View ID="ViewCriar" runat="server">
                    <center>
                        <table style="margin: 0px auto;">

                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Nome:</td>
                            <td>
                                <asp:TextBox ID="txtNomeInsere" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Cpf/Cnpj:</td>
                            <td align="left">
                                <asp:TextBox ID="ttxtCpf_CnpjInsere" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Inscrição Estadual:</td>
                            <td align="left">
                                <asp:TextBox ID="txtInscricaoEstadualInsere" runat="server" Width="196px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Pessoa Física/Jurídica:</td>
                            <td align="left">
                                <asp:DropDownList ID="ddlPessoaFisicaJuridaInsere" runat="server" Width="100px" > 
                                    <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                    <asp:ListItem Value="F"> Física </asp:ListItem>
                                    <asp:ListItem Value="J"> Jurídica </asp:ListItem>
                                </asp:DropDownList>                            
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2"><b> Endereço:</b></td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>Logradouro</td>
                                        <td>Bairro</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtLogradouroInsere" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBairroInsere" runat="server" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>

                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>Cep</td>
                                        <td>Cidade</td>
                                        <td>Estado</td>
                                        <td>Telefone</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCepInsere" runat="server" Width="80px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCidadeInsere" runat="server" Width="240px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtEstadoInsere" runat="server" Width="50px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTelefoneInsere" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                E-mail
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:TextBox ID="txtEmailInsere" runat="server" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                            <tr>
                                <td  colspan="2" align="right">
                                    <asp:Button ID="InserirFornecedor" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Inserir" OnClick="InserirFornecedor_Click"  />
                                    &nbsp;
                                    <asp:Button ID="btnVoltar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Voltar" OnClick="btnVoltar_Click" />
                                </td>
                            </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                    </table>
                    </center>

                    </asp:View>

                    <asp:View ID="ViewExcluir" runat="server">
                        <center>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Tem certeza que deseja EXCLUIR o Fornecedor?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnVoltarPesquisaExclusao" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="203px" Text="Cancelar" OnClick="btnVoltarPesquisaExclusao_Click" />
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Código do Fornecedor:"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblCodigoFornecedorExclusao" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNomeForcedorExluir" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTituloCpf_CnpjExcluir" runat="server" Text="Cpf_Cnpj:"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblCpf_CnpjExcluir" runat="server" Text="" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnConfirmarExclusaoFornecedor" runat="server" BackColor="Red" Font-Bold="True" ForeColor="White" Width="153px" Text="Excluir" OnClick="btnConfirmarExclusaoFornecedor_Click"   />
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </asp:View>
                </asp:MultiView>

            </fieldset>


</asp:Content>
