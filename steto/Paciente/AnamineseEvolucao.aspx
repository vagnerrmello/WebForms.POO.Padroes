<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente/Paciente.master" AutoEventWireup="true" CodeBehind="AnamineseEvolucao.aspx.cs" Inherits="Steto.Paciente.AnamineseEvolucao" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblData" runat="server" Text="Data"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblMedico" runat="server" Text="Médico"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEspecialidade" runat="server" Text="Especialidade"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlTipo" runat="server" Width="90px">
                        <asp:ListItem Value="1" Selected="True">Anaminese</asp:ListItem>
                        <asp:ListItem Value="2">Evolução</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                                    <asp:TextBox ID="txtData" runat="server" Columns="10" 
                                        MaxLength="10" 
                                        Font-Bold="true"
                                        ForeColor="Crimson"
                                        BackColor="LightGoldenrodYellow"
                                        Width="90"/>
                                    <asp:Image ID="imgCalendario" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                    <ajaxToolkit:CalendarExtender 
                                        ID="clnData" 
                                        runat="server" 
                                        PopupButtonID="imgCalendario" 
                                        TargetControlID="txtData" 
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                </td>
                <td>
                    <asp:TextBox ID="txtMedico" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtEspecialidade" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPaciente" runat="server" Text="Paciente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPaciente" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblIdade" runat="server" Text="Idade :  "></asp:Label>

                    <asp:TextBox ID="txtIdade" runat="server"></asp:TextBox>
                </td>
            </tr>
            
        </table>

        <ajaxToolkit:HtmlEditorExtender ID="EditorAnaminese" runat="server" TargetControlID="txtEditor">
             <Toolbar>
                <ajaxToolkit:Undo />
                <ajaxToolkit:Redo />
                <ajaxToolkit:Copy />
                <ajaxToolkit:Paste />
                <ajaxToolkit:Cut />
                <ajaxToolkit:FontNameSelector />
                <ajaxToolkit:FontSizeSelector />
                <ajaxToolkit:Bold />
                <ajaxToolkit:Outdent />
                <ajaxToolkit:Indent />
                <ajaxToolkit:JustifyLeft />
                <ajaxToolkit:JustifyCenter />
                <ajaxToolkit:JustifyRight />
                <ajaxToolkit:JustifyFull />
                <ajaxToolkit:InsertOrderedList />
                <ajaxToolkit:InsertUnorderedList />
                
             </Toolbar>
        </ajaxToolkit:HtmlEditorExtender>
        <asp:TextBox ID="txtEditor" runat="server" Width="913px" Height="300px"></asp:TextBox>
        <table>
            <tr align="right">
                <td>
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" OnClick="btnSalvar_Click"/>
                </td>
                <td>
                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="88px"/>
                </td>
                <td>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" Width="88px" 
                        onclick="btnVoltar_Click"/>
                </td>
                <td>
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Width="88px"/>
                </td>
            </tr>
        </table>


</asp:Content>
