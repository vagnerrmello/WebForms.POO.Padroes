﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="UsuarioPesquisa.aspx.cs" Inherits="Steto.Administrador.PainelDeControle" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server">
</script>
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <fieldset class="fieldsetPesquisa">
            <legend>Pesquisa: </legend>
               <div class="submitButtonUsuario2">
                    <asp:Label ID="Label1" runat="server" Text="Ativo?:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblUsuario1" runat="server" Text="Insira o nome do usuário do sistema:"></asp:Label>
               </div>
                <div class="submitButtonUsuario2">
                    <asp:DropDownList ID="ddlAtivoInativo" runat="server">
                        <asp:ListItem Value="2">  Todos  </asp:ListItem>
                        <asp:ListItem Selected="True" Value="1">  Ativo  </asp:ListItem>
                        <asp:ListItem Value="0"> Inativo </asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtPesquisa" runat="server" Width="250px" ></asp:TextBox>
                    <asp:Button ID="btnPesquisar" runat="server" Width="88px" Text="Pesquisar" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpaPesquisa" runat="server" Width="88px" Text="Limpar" 
                        onclick="btnLimpaPesquisa_Click"/>
                </div>

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
                onpageindexchanging="GridView_PageIndexChanging"
                onrowcommand="GridView_RowCommand" HorizontalAlign="Center" ForeColor="#333333" 
                GridLines="None" onrowdatabound="GridView_RowDataBound" OnSelectedIndexChanged="1" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns> 
                            <asp:BoundField DataField="Id" HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="true" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" ItemStyle-HorizontalAlign="Left" >
                            <HeaderStyle Width="188px" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" >
                            <HeaderStyle Width="188px" />
                            </asp:BoundField> 
                            <asp:BoundField DataField="Login" HeaderText="Login" >
                            <HeaderStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Ativo" HeaderText="Status" ItemStyle-HorizontalAlign="Center" Visible="true" />
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

