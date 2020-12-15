<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente/Paciente.master" AutoEventWireup="true" CodeBehind="PacientePesquisa.aspx.cs" Inherits="Steto.Paciente.PacientePesquisa" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <fieldset class="fieldsetPesquisa">
            <legend>Pesquisa: </legend>
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlAtivoInativo" runat="server">
                                <asp:ListItem Value="2">  Todos  </asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">  Ativo  </asp:ListItem>
                                <asp:ListItem Value="0"> Inativo </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RadioButton ID="rbPaciente" runat="server"  Text="Paciente:"/>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaciente" runat="server" Width="250px" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:RadioButton ID="rbCPF" runat="server"  Text="CPF:"/>
                        </td>
                        <td>
                            <ajaxToolkit:MaskedEditExtender ID="meeCPF" runat="server" Mask="999,999,999-99"
                            MessageValidatorTip="true" CultureName="pt-BR"
                            TargetControlID="txtCPF" ClearMaskOnLostFocus="false"
                            MaskType="None" InputDirection="LeftToRight" Enabled="true">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:TextBox ID="txtCpf" runat="server" Width="150px" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" Width="88px" 
                                onclick="btnPesquisar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnLimpaPesquisa" runat="server" Width="88px" Text="Limpar"/>
                        </td>
                    </tr>

                </table>
        </fieldset>

        <fieldset class="fieldsetPesquisa" >
            <legend>Resultado: </legend>
                <asp:GridView ID="GridView" 
                runat="server" 
                CellPadding="4"
                AllowPaging="True"  
                PageSize="5"
                AutoGenerateColumns="False" 
                ShowFooter="True"
                AllowSorting="True"
                HorizontalAlign="Center" ForeColor="#333333" 
                GridLines="None" onpageindexchanging="GridView_PageIndexChanging" 
                onrowcommand="GridView_RowCommand" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns> 
                            <asp:BoundField DataField="Id" HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="true" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-HorizontalAlign="Left" >
                            <HeaderStyle Width="188px" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CPF" HeaderText="CPF" >
                            <HeaderStyle Width="150px" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="Editar" 
                                HeaderText="Opção" ControlStyle-Width="75"  />
                            <asp:ButtonField ButtonType="Button" Text="Visualizar" CommandName="Visualizar" 
                                HeaderText="Opção" ControlStyle-Width="75"  />
                            <asp:ButtonField ButtonType="Button" Text="Inativar" HeaderText="Inativar" 
                                CommandName="Inativar" ControlStyle-Width="75" />
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
        </fieldset>


</asp:Content>
