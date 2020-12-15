<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Steto.Administrador.Configuracoes.Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                <fieldset class="fieldsetTabConteinerPaciente">
                <legend> Dados da Empresa </legend>
                    <table style="margin: 0px auto;">

                        <tr>
                            <td>Código Empresa:</td>
                            <td>
                                <asp:Label ID="lblCodigoEmpresa" runat="server" Width="100px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Nome:</td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Cpf/Cnpj:</td>
                            <td>
                                <asp:TextBox ID="txtCpf_Cnpj" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Oficial:</td>
                            <td>
                                <asp:TextBox ID="txtOficial" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Oficial Substituto</td>
                            <td>
                                <asp:TextBox ID="txtOficialSubstituto" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Escrevente1</td>
                            <td>
                                <asp:TextBox ID="txtEscrevente1" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Escrevente2</td>
                            <td>
                                <asp:TextBox ID="txtEscrevente2" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Escrevente3</td>
                            <td>
                                <asp:TextBox ID="txtEscrevente3" runat="server" Width="150px"></asp:TextBox>
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
            <tr align="right">
                <td colspan="2">
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" 
                         Enabled="true" OnClick="btnSalvar_Click"/>



                </td>
            </tr>
                    </table>
            </fieldset>


</asp:Content>
