<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="Steto.Administrador.Configuracoes.Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetPesquisa">
        <legend>Email</legend>
        <asp:GridView ID="GridEmail" 
        runat="server"
                CellPadding="4"
                AllowPaging="True"  
                PageSize="5"
                AutoGenerateColumns="False" 
                ShowFooter="True"
                AllowSorting="True"
                HorizontalAlign="Center" ForeColor="#333333" 
                       GridLines="None" onrowcommand="GridEmail_RowCommand" 
        >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="true" />
            <asp:BoundField DataField="TipoEmail" HeaderText="Tipo" ItemStyle-HorizontalAlign="Left" >
            <HeaderStyle Width="400px" />
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="Editar" 
            HeaderText="Edição" ControlStyle-Width="70"/>
        </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
