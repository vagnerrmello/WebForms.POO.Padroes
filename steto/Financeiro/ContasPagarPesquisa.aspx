<%@ Page Title="" Language="C#" MasterPageFile="~/Financeiro/ViknFinanceiro.Master" AutoEventWireup="true" CodeBehind="ContasPagarPesquisa.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.ContasPagarPesquisa" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .modalBackground
        {
            background-color:black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 !important;
            z-index:20;
        }
        .modalpopup
        {
            padding:20px 0px 24px 10px;
            position:relative;
            width:450px;
            height:500px;
            background-color:white;
            border:1px solid black;
        }
        .modalpopupPesquisa
        {
            padding:20px 0px 24px 10px;
            position:center;
            width:900px;
            height:850px;
            background-color:white;
            border:1px solid black;
        }
        .modalBackground2
        {
            background-color: #C0C0C0;

            filter: alpha(opacity=80);

            opacity: 0.8;

            z-index: 10000;

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
            Pesquisar Contas (Pagar/Receber)</legend>
        <center>

                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                    <table>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="lblUsuario1" runat="server" Text="Pesquise Pelo Número do Documento:" ForeColor="#336699" Font-Bold="true"></asp:Label>&nbsp;
                                        </td>
                                        <td rowspan="3">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="456px" ></asp:TextBox>
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

                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridContas" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="4" ShowFooter="True" Width="725px" OnRowCommand="GridContas_RowCommand" OnRowDataBound="GridContas_RowDataBound" OnSelectedIndexChanged="GridContas_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NumeroDocumento" HeaderText="Título" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NumeroParcela" HeaderText="N.Parcela" ItemStyle-HorizontalAlign="Left">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Observacao" HeaderText="Pago S/N" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:ButtonField ButtonType="Image" CommandName="Duplicar" HeaderText="Duplicar Título" ImageUrl="~/imagens/copiar04.png" FooterStyle-Width="30px" ControlStyle-Height="30px"  />
                                                <asp:ButtonField ButtonType="Image" CommandName="Comprovante" HeaderText="Baixar Título" ImageUrl="~/imagens/Lupa02.png" FooterStyle-Width="30px" ControlStyle-Height="30px"  />
                                                
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
                                    </td>
                                </tr>
                            </table>

        </center>

<asp:Button ID="btnupe" runat="server" Text="Button" style="display:none;"/>
        <asp:Button ID="btnupe1" runat="server" Text="Button" style="display:none;"/>

        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" 
            BackgroundCssClass="modalBackground" runat="server" 
            CancelControlID="btncancel1" TargetControlID="btnupe" PopupControlID="Panel1" >

        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="Panel1" runat="server" CssClass="modalpopupPesquisa"   style="height:170px;">
            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
            <center>
                <asp:Label ID="lblTituloBaixa" runat="server" ForeColor="#336699" Font-Bold="true" Text="Baixa de Título"></asp:Label>
                    <br />
            <table width="70%">
                <tr>
                    <td colspan="7" align="center" BGCOLOR="#5D7B9D">
                        <asp:Label ID="lblTxtDados" runat="server" Text="Dados do Título" ForeColor="White" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr BGCOLOR="#F7F6F3">
                    <td align="center"><asp:Label ID="lblTextoCodigo" runat="server" Text="Código" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTextoTitulo" runat="server" Text="Título" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTextoParcela" runat="server" Text="Parcela" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTextoVencimento" runat="server" Text="Vencimento" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTextoValor" runat="server" Text="Valor" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTextoPagoSN" runat="server" Text="Pago S/N" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    
                    <td rowspan="2">
                        <asp:Button ID="btnBaixarTitulo" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Baixar" Height="49px" Width="73px" OnClick="btnBaixarTitulo_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center"><asp:Label ID="lblCodigo" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblTitulo" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblParcela" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblVencimento" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblValor" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    <td align="center"><asp:Label ID="lblPagoSN" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label></td>
                    
                </tr>

                <tr>
                    <td colspan="3">
                        <asp:FileUpload ID="flpup" runat="server" />
                    </td>
                    <td rowspan="2">
                        <asp:ImageButton ID="imgNota" runat="server" Height="72px" ImageUrl="~/imagens/invoice_icon.jpg" OnClick="imgNota_Click" Width="58px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnfileupload" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" OnClick="resumeupload" Text="Importar Comprovante" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btncancel1" runat="server" Text="Sair" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="155px"/>
                    </td>
                    <td colspan="6" align="right">
                        <asp:Button ID="btnSalvarBaixa" runat="server" BackColor="#2E8B57" Font-Bold="True" ForeColor="White" Text="Salvar Baixa" Width="180px" OnClick="btnSalvarBaixa_Click" />
                    
                    </td>
                </tr>
            </table>
            </center>
                <br /><br />
            
            <br />

        </asp:Panel>
        <br /><br /><br /><br />

                        <asp:Panel ID="Panel2" runat="server" CssClass="modalpopup">
                           
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblDuplicarTituloCodigoContaLabel" runat="server" Text="Codigo da Conta:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblDuplicarTituloCodigoConta" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="LblDuplicarTituloNumeroLabel" runat="server" Text="Nº Título:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblDuplicarTituloNumero" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDuplicarValorDocumentoLabel" runat="server" Text="Valor Documento:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDuplicarValorDocumento" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDataVencimentoLabel" runat="server" Text="Data de Vencimento:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDataVencimento" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblEstoqueNotaQuantidadeParcelamento" runat="server" Text="Nº de Parcela(s):"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEstoqueNotaQuantidadeParcelamento" runat="server" Width="100px"  > 
                                            <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="right" colspan="2">
                                        <asp:Button ID="btnDadosDuplicacao" runat="server" Text="Confirmar" BackColor="#336699" Font-Bold="True" ForeColor="White" OnClick="btnDadosDuplicacao_Click"/>
                                    </td>
                                </tr>
                            </table>
                            
                            <br />
                                <asp:Label ID="lblAltereDadosSeNecessarios" runat="server" Text="Altere as dados abaixo se necessário:" Visible="false" Font-Bold="true"></asp:Label>
                            <br />
                            <br />
                            <asp:GridView ID="GridVencimentos" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" 
                                PageSize="12" ShowFooter="True" Width="300px">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Parcela" ItemStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Vencimento" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtVencimento" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Vencimento", "{0:dd/MM/yyyy}") %>' Width="100px" ></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CEGridVencimento" runat="server" TargetControlID="txtVencimento" Enabled="True"></ajaxToolkit:CalendarExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Valor" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtValorParcela" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Valor") %>' Width="60px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnConfirmarDuplicacao" runat="server" Text="Confirmar Duplicação" Width="200px" Enable="false" BackColor="#2E8B57" Font-Bold="True" ForeColor="White" OnClick="btnConfirmarDuplicacao_Click"/>&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="Sair" Width="155px" BackColor="#336699" Font-Bold="True" ForeColor="White"/>
                            <br />

                        </asp:Panel>

                        <ajaxToolkit:ModalPopupExtender ID="MPEDuplicata" runat="server"
                                TargetControlID="btnupe1"
                                PopupControlID="Panel2"
                                CancelControlID="Button2" BackgroundCssClass="modalBackground"/>

    </fieldset>
        </center>
</asp:Content>
