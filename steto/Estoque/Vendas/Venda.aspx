<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="Venda.aspx.cs" Inherits="Amago.Web.Estoque.Vendas.Venda" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
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
            height:450px;
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
        .campo
        {
            border: #FFFFFF;
            color: #797979;
            border-color:#FFFFFF;
            outline-color:#FFFFFF;
        }
        .modalpopupMenor
        {
            padding:20px 0px 24px 10px;
            position:relative;
            width:450px;
            height:100px;
            background-color:white;
            border:1px solid black;
        }
        .auto-style1 {
            width: 177%;
        }
    </style>





</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
     <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
     
    <script type="text/javascript">
        function SelecionaTodosChecks(spanChk){
            var oItem = spanChk.children;
            var theBox= (spanChk.type=="checkbox") ?
            spanChk : spanChk.children.item[0];
            xState=theBox.checked;
            elm=theBox.form.elements;
            for(i=0;i<elm.length;i++)
            if(elm[i].type=="checkbox" &&
            elm[i].id!=theBox.id)
            {
                if(elm[i].checked!=xState)
                elm[i].click();
            }
        }
    $(function () {
        $("[id$=txtDescricaoPesquisa]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/Estoque/Vendas/Venda.aspx/GetClientes") %>',
                    data: "{ 'prefixo': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1],
                                vlr: item.split('-')[2]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("[id$=hfCustomerId]").val(i.item.val);
                $("[id$=txtCodigoProduto]").val(i.item.val);
                $("[id$=txtValorProduto]").val(i.item.vlr);

            },
            minLength: 1
        });
    });
    </script>


    <center>
    <fieldset >
        <legend > 
            <table width="100%">
                <tr>
                    <td width="400px"> <asp:Label ID="lblEmpresa" runat="server" ForeColor="#336699" Font-Bold="true"/> - <asp:Label ID="lblEmpresaCodigo" runat="server" ForeColor="#336699" Font-Bold="true"/></td>
                    <td width="400px" align="right">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuário: " ForeColor="#336699" Font-Bold="true"/> - <asp:Label ID="lblCodigoNomeUsuario" runat="server" ForeColor="#336699" Font-Bold="true"/>
                    </td>
                </tr>
            </table>
             
        </legend>

                                    <center>
                                        <table>
                                            <tr>
                                                <td >
                                                    <asp:Label ID="lblCodigoConta" runat="server" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <asp:Label ID="lblCliente" runat="server" Text="Cliente:" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:DropDownList ID="ddlClientes" runat="server" Width="542px"></asp:DropDownList>
                                                &nbsp;<asp:Button ID="btnFormaPagamento" runat="server" BackColor="Red" Font-Bold="True" ForeColor="White" Width="165px" Text="Forma Pagamento" Height="33px" OnClick="btnFormaPagamento_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <asp:Label ID="lblCodigoProduto" runat="server" Text="Código:" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:Label ID="lblProdutoPesquisa" runat="server" Text="Produto:" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <asp:TextBox ID="txtCodigoProduto" runat="server" Width="100px" CssClass="campo" Font-Bold="True" ></asp:TextBox>
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="728px"  ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade:" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtQuantidadeSolicitada" runat="server" Width="80px" onkeyup="return SearchList();" xmlns:asp="#unknown"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                            </center>
                                    <%--</fieldset>--%>

                                <table width="100%">
                                    <tr >
                                        <td  width="200" valign="top">
                                            <table>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right">

                                                    <asp:ImageButton ID="btnAdd" runat="server" Height="88px" ImageUrl="~/imagens/add.jpg" Width="86px" OnClick="btnAdd_Click" />

                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td colspan="2" >
                                            <div style="height: 250px; overflow: auto;">
                                                <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" 
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnRowCommand="GridPoduto_RowCommand" 
                                                PageSize="1000" ShowFooter="True" Width="649px" ClientIDMode="Static" PageIndex="1">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true"  HeaderStyle-HorizontalAlign="Center">
                                                        <HeaderStyle Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Width="300px" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>

                                                <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Qtd" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="70px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ValorUnitario" HeaderText="VL UN R$" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle Width="70px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                                <table width="100%">
                                    <tr  >
                                        <td align="right" colspan="2">
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="Button3" runat="server" Text="Quantidade Itens" BackColor="White" Font-Bold="True" ForeColor="#336699" CssClass="campo" Width="195px" Font-Size="Large" />
                                                    </td>
                                                    <td align="right" >
                                                        <asp:Label ID="lblQuantidadeItens" runat="server" Font-Bold="True" ForeColor="#336699" Font-Size="Large" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td align="right">: 
                                                        <asp:Button ID="btnValorAcrescimo" runat="server" Text="Valor do Acréscimo" BackColor="White" Font-Bold="True" ForeColor="#336699" CssClass="campo" Width="217px" Font-Size="Large" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblValorAcrescimo" runat="server" Font-Bold="True" ForeColor="#336699" Font-Size="Large" ></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>

                                                    <td align="right">
                                                        <asp:Button ID="btnValorDesconto" runat="server" Text="Valor do desconto" BackColor="White" Font-Bold="True" ForeColor="#336699" CssClass="campo" OnClick="btnValorDesconto_Click" Width="205px" Font-Size="Large" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblValorDesconto" runat="server" Font-Bold="True" ForeColor="#336699" Font-Size="Large" ></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="Button1" runat="server" Text="Valor Total" BackColor="White" Font-Bold="True" ForeColor="#336699" CssClass="campo" Width="140px" Font-Size="Large" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblValorTotal" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="Button6" runat="server" Text="Valor a Pagar" BackColor="White" Font-Bold="True" ForeColor="#336699" CssClass="campo" Width="259px" Font-Size="XX-Large" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblValorAPagar" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="XX-Large"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                            <asp:Button ID="btnEnviarVencimentos0" runat="server" Text="Finalisar Compra"  BackColor="#336699" Font-Bold="True" ForeColor="White" Width="176px"  Height="35px" OnClick="btnEnviarVencimentos0_Click1"  />
                                        </td>
                                    </tr>
                                </table>





        <center>
            <table>





                <tr>
                    <td colspan="5" align="left">
                            <br />
                        <center>

                        <asp:Panel ID="Panel1" runat="server" CssClass="modalpopupMenor">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEnviarDesconto" runat="server" Text="Valor Desconto:" Font-Bold="True" ForeColor="#336699" Font-Size="Large"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEnviarDesconto" runat="server" Font-Size="Large"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Button ID="btnEnviarVencimentos" runat="server" Text="Enviar"  BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" OnClick="btnEnviarVencimentos_Click" Height="35px"  />&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="Cancelar"  BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Height="35px"/>
                            <br />

                        </asp:Panel>

                        <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server"
                                TargetControlID="btnValorDesconto"
                                PopupControlID="Panel1"
                                CancelControlID="Button2" BackgroundCssClass="modalBackground"/>

                            </center>
                        <br />
                        
                    </td>
                </tr>

                <tr>
                    <td colspan="5" align="left">
                        <center>
                        

                        <asp:Panel ID="Panel3" runat="server" CssClass="modalpopup">
                            <asp:Label ID="Label1" Text="Forma de Pagamento" runat="server" Font-Bold="True" ForeColor="#336699" Font-Size="Large" ></asp:Label>
                            <br />
                            <table>
                                <tr>
                                    <td align="right"><asp:Label ID="lblFormaPagamento" runat="server" Text="Forma de Pagamento: "/></td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rblFormaPagamento" runat="server" RepeatDirection="Horizontal"  AutoPostBack="True" OnSelectedIndexChanged="rblFormaPagamento_SelectedIndexChanged">
                                            <asp:ListItem Value="DE">Débito</asp:ListItem>
                                            <asp:ListItem Value="CR">Crédito</asp:ListItem>
                                            <asp:ListItem Value="DI" Selected="True">Dinheiro</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblEstoqueNotaDataVencimento" runat="server" Text="Data Vencimento:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEstoqueNotaDataVencimento" runat="server" Width="187px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderCadastro" runat="server" TargetControlID="txtEstoqueNotaDataVencimento" Enabled="True"></ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td rowspan="2" valign="top">

                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" ImageUrl="~/imagens/calc02.png" OnClick="ImageButton1_Click" Width="29px" />

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                        
                                        <asp:Label ID="lblEstoqueNotaQuantidadeParcelamento" runat="server" Text="Nº de Parcela(s):"></asp:Label>
                                    </td>
                                    <td align="left">

                                         <asp:DropDownList ID="ddlEstoqueNotaQuantidadeParcelamento" runat="server" Width="100px" OnSelectedIndexChanged="ddlEstoqueNotaQuantidadeParcelamento_SelectedIndexChanged" AutoPostBack="True" > 
                                            <asp:ListItem Selected="True" Value="0">  Selecione  </asp:ListItem>
                                            <asp:ListItem Value="1"> 1 </asp:ListItem>
                                            <asp:ListItem Value="2"> 2 </asp:ListItem>
                                            <asp:ListItem Value="3"> 3 </asp:ListItem>
                                            <asp:ListItem Value="4"> 4 </asp:ListItem>
                                            <asp:ListItem Value="5"> 5 </asp:ListItem>
                                            <asp:ListItem Value="6"> 6 </asp:ListItem>
                                            <asp:ListItem Value="7"> 7 </asp:ListItem>
                                            <asp:ListItem Value="8"> 8 </asp:ListItem>
                                            <asp:ListItem Value="9"> 9 </asp:ListItem>
                                            <asp:ListItem Value="10"> 10 </asp:ListItem>
                                            <asp:ListItem Value="11"> 11 </asp:ListItem>
                                            <asp:ListItem Value="12"> 12 </asp:ListItem>
                                        </asp:DropDownList>
                                         &nbsp;</td>

                                </tr>
                            </table>

                            <br />
                            <asp:GridView ID="GridFP" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" 
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

                            <asp:Button ID="Button4" runat="server" Text="Enviar"  BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Height="35px" OnClick="btnEnviarVencimentos_Click"  />&nbsp;&nbsp; <asp:Button ID="Button5" runat="server" Text="Cancelar"  BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Height="35px"/>
                            <br />

                        </asp:Panel>

                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server"
                                TargetControlID="btnFormaPagamento"
                                PopupControlID="Panel3"
                                CancelControlID="Button5" BackgroundCssClass="modalBackground"/>

                            </center>
                    </td>
                </tr>
            </table>
        </center>
    </fieldset>
        </center>

</asp:Content>
