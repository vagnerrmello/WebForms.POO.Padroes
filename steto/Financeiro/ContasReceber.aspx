<%@ Page Title="" Language="C#" MasterPageFile="~/Financeiro/ViknFinanceiro.Master" AutoEventWireup="true" CodeBehind="ContasReceber.aspx.cs" Inherits="Steto.Financeiro.ContasReceber" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend> 
            <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
            <br />
            Lançamento de Conta a Receber:
        </legend>
        <center>
            <table>
                <tr>
                    <td align="right"><asp:Label ID="lblLabelCodigoPagamento" runat="server" Text="Código Pagamento: "/></td>
                    <td align="left"><asp:Label ID="lblCodigoPagamento" runat="server" /></td>
                </tr>
                <tr>
                    <td align="right"><asp:Label ID="lblNumeroDocumento" runat="server" Text="Número do Documento: "/></td>
                    <td align="left">
                        <asp:TextBox ID="txtNumeroDocumento" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td align="right"><asp:Label ID="lblFormaPagamento" runat="server" Text="Forma de Pagamento: "/></td>
                    <td align="left">
                        <asp:RadioButtonList ID="rblFormaPagamento" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblFormaPagamento_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="DE">Débito</asp:ListItem>
                            <asp:ListItem Value="CR">Crédito</asp:ListItem>
                            <asp:ListItem Value="DI">Dinheiro</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCliente" runat="server" Text="Cliente: " Width="163px"/>
                    </td>
                    <td colspan="2" align="left">
                        <asp:DropDownList ID="ddlClientes" runat="server" Width="400px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDataEmissao" runat="server" Text="Data de Emissão: " Width="163px"/>
                    </td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtDataEmissao" runat="server" Width="120px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEtxtEmissao" runat="server" TargetControlID="txtDataEmissao" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDataVencimento" runat="server" Text="Data de Vencimento: " Width="163px"/>
                    </td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtDataVencimento" runat="server" Width="120px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEtxtDataVencimento" runat="server" TargetControlID="txtDataVencimento" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDataPagamento" runat="server" Text="Data de Pagamento: " Width="163px"/>
                    </td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtDataPagamento" runat="server" Width="120px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEtxtDataPagamento" runat="server" TargetControlID="txtDataPagamento" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                                    <asp:Label ID="lblParcela" runat="server" Text="Nº de Parcela(s):"></asp:Label>
                       </td>
                    <td colspan="2" align="left">
                        
                                     <asp:DropDownList ID="ddlQuantidadeParcela" runat="server" Width="120px" > 
                                        <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                                        <asp:ListItem Value="2"> 2 </asp:ListItem>
                                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                                        <asp:ListItem Value="3"> 4 </asp:ListItem>
                                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                                        <asp:ListItem Value="6"> 6 </asp:ListItem>
                                        <asp:ListItem Value="7"> 7 </asp:ListItem>
                                        <asp:ListItem Value="8"> 8 </asp:ListItem>
                                        <asp:ListItem Value="9"> 9 </asp:ListItem>
                                        <asp:ListItem Value="10"> 10 </asp:ListItem>
                                        <asp:ListItem Value="11"> 11 </asp:ListItem>
                                        <asp:ListItem Value="12"> 12 </asp:ListItem>
                                    </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                <td colspan="2">
                    <table width="0%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblValorDocumento" runat="server" Text="Valor do Documento: " Width="163px"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDesconto" runat="server" Text="Desconto: " Width="163px"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAcrescimo" runat="server" Text="Acréscimos: " Width="163px"/>
                            </td>
                            <td>
                                <asp:Label ID="lblTotalReceber" runat="server" Text="Total à Receber: " Width="163px"/>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:TextBox ID="txtValorDocumento" runat="server" Width="154px"></asp:TextBox>
                            </td>
                            <td >
                                <asp:TextBox ID="txtDesconto" runat="server" Width="154px"></asp:TextBox>
                            </td>
                            <td >
                                <asp:TextBox ID="txtAcrescimo" runat="server" Width="154px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalReceber" runat="server" Width="154px" BackColor="LightGoldenrodYellow" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="right">
                                <asp:Button ID="btnCalcular" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Calcular" OnClick="btnCalcular_Click"  />
                            </td>
                        </tr>
            </table>
                </td>
            </tr>

            <tr>
                <td align="right">
                    <asp:Label ID="lblObservacao" runat="server" Text="Observação : " Width="163px"/>
                </td>
                <td colspan="2"  align="left">
                    <asp:TextBox ID="txtObservacao" runat="server" Width="391px"></asp:TextBox>
                </td>
                    
            </tr>
            <tr>
                <td align="right">
                        
                </td>
                <td colspan="2">
                    <asp:Label ID="lblEmitirComprovanteEmail" runat="server" Text="Emitir comprovante por e-mail?:" />
                         
                    <asp:RadioButtonList ID="rbComprovanteEmailSim" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Não</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnEnviarContaReceberAnalise" runat="server" BackColor="#2E8B57" Font-Bold="True" ForeColor="White" Width="153px" Text="Enviar" OnClick="btnEnviarContaReceberAnalise_Click"    />
                </td>
            </tr>
            <tr>
                <td colspan="2"  align="center">

                    <table>
                        <tr>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:GridView ID="GridVencimentos" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" 
                                PageSize="12" ShowFooter="True" Width="300px">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Parcela" ItemStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Título" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Left" />
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

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Button ID="btnCadastrar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Cadastrar" OnClick="btnCadastrar_Click" Visible="false" />
                </td>
            </tr>

            </table>
        </center>
    </fieldset>
</asp:Content>
