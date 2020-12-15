<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoqueNota.aspx.cs" Inherits="Amago.Web.Estoque.Gerencia.EstoqueNota" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 809px;
        }
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
        .auto-style2 {
            height: 25px;
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
                    url: '<%=ResolveUrl("~/Estoque/Gerencia/EstoqueNota.aspx/GetClientes") %>',
                    data: "{ 'prefixo': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
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
            },
            minLength: 1
        });
    });
    </script>


    <center>
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend> 
            <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
            <br />
            Cadastro de Notas
        </legend>
        <center>
            <table>
                <tr>
                    <td align="right"><asp:Label ID="lblDataCadastro" runat="server" Text="Cadastro:"></asp:Label></td>
                    <td align="left"><asp:Label ID="lblDataDoCadastro" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueCodigoNota" runat="server" Text="Codigo:"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:Label ID="lblEstoqueisCodigoNota" runat="server" ></asp:Label>

                    </td>
                    <td colspan="2">
                        <asp:FileUpload runat="server" Width="300px" ID="UploadImagem" Enabled="False"></asp:FileUpload>
                    </td>
                    <td >
                        
                        <asp:ImageButton ID="EnviarImagem" runat="server" ImageUrl="~/imagens/nuvem01.jpg" Enabled="False" Height="25px" Width="51px" OnClick="EnviarImagem_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNumeroNota" runat="server" Text="Nº do Documento:"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueNumeroNota" runat="server" Width="187px"></asp:TextBox>

                    </td>
                    <td align="right">
                        <asp:Label ID="lblFornecedor" runat="server" Text="Fornecedor:"></asp:Label>

                    </td>
                    <td align="left"> 
                        <asp:DropDownList ID="ddlFornecedor" runat="server" Width="209px" > 
                        </asp:DropDownList>
                    </td>

                    <td rowspan="3">
                        <asp:ImageButton ID="imgNota" runat="server" Height="72px" Width="58px"  ImageUrl="~/imagens/invoice_icon.jpg" OnClick="imgNota_Click"/>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNotaDataEmissao" runat="server" Text="Data Emissão:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueNotaDataEmissao" runat="server" Width="187px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CEtxtEstoqueNotaDataEmissao" runat="server" TargetControlID="txtEstoqueNotaDataEmissao" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>
                    <td></td>
                    <td></td>
                </tr>

                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueNotaDataVencimento" runat="server" Text="Data Vencimento:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueNotaDataVencimento" runat="server" Width="187px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderCadastro" runat="server" TargetControlID="txtEstoqueNotaDataVencimento" Enabled="True"></ajaxToolkit:CalendarExtender>
                    </td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEstoqueValorParcelaNota" runat="server" Text="Valor:"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEstoqueValorParcelaNota" runat="server" Width="187px" ></asp:TextBox>

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
                    </td>
                    <td colspan="2" align="right">
                         <b> <asp:CheckBox ID="chkEstoqueNotaLancarContasAPagar" runat="server" Text="Lançar Nota Em Contas A Pagar?" TextAlign="Left" Font-Bold="True" ForeColor="Blue" /></b>

                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="left">
                        <asp:Button ID="btnAlterarDataVencimento" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="300px" Text="Alterar Data de Vencimento" Enabled="false" OnClick="btnAlterarDataVencimento_Click" />
                            <br />
                        <center>
                        

                        <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                            Altere as Datas abaixo: 
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
                            <asp:Button ID="btnEnviarVencimentos" runat="server" Text="Enviar" Width="100px" OnClick="btnEnviarVencimentos_Click"  />&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="Cancelar" />
                            <br />

                        </asp:Panel>

                        <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server"
                                TargetControlID="btnAlterarDataVencimento"
                                PopupControlID="Panel1"
                                CancelControlID="Button2" BackgroundCssClass="modalBackground"/>

                            </center>
                        <br />
                        
                    </td>
                </tr>

                <tr>
                    <td colspan="5" align="right">
                        <asp:Button ID="btnCriarNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Salvar" OnClick="btnCriarNota_Click" />
                        &nbsp;<asp:Button ID="BtnNovaNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="153px" Text="Nova Nota" OnClick="BtnNovaNota_Click" />
                    </td>
                </tr>

            </table>
        </center>

                <asp:MultiView ID="MultiViewNota" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">


                        <center>


                            </center>





                </asp:View>




            <asp:View ID="ViewCadastro" runat="server">
                <center>
                <table>
                    <tr>
                        <td>
                            <center>
                                <center>
                                    <iframe id="I1" class="auto-style1" name="I1" src="EstoqueEntradas.aspx"></iframe>
                                </center>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="BtnFecharCasdro" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Voltar para Nota" OnClick="BtnFecharCasdro_Click" />

                        </td>
                    </tr>
                </table>
                    </center>
            </asp:View>
                    <asp:View ID="ViewItens" runat="server">

                        <center>
                            <br />
                                   <asp:Button ID="btnPesquisarProduto" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Pesquisar Produto" Width="174px" OnClick="btnPesquisarProduto_Click" />
                            <br />
                            

                                <asp:Button ID="btnupe" runat="server" Text="Button" style="display:none;"/>

                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" 
                                    BackgroundCssClass="modalBackground" runat="server" 
                                    CancelControlID="btncancel1" TargetControlID="btnupe" PopupControlID="Panel2" >

                                </ajaxToolkit:ModalPopupExtender>

                                <asp:Panel ID="Panel2" runat="server" CssClass="modalpopupPesquisa"   >

                                <asp:HiddenField ID="HiddenField1" runat="server" Value="" />

                                <asp:FileUpload ID="flpup" runat="server" Visible="false"/>

                                <asp:Button ID="btnfileupload" runat="server" Text="Upload resume" OnClick="resumeupload" Visible="false"/>

                                <br />

                                


                            
                                <center>

                                 <%--   <fieldset class="fieldsetPesquisaModal">
                                        <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>--%>
                                        <center>
                                        <table>
                                            <tr>
                                                <td class="auto-style2"><asp:Label ID="lblProdutoPesquisa" runat="server" Text="Produto:" ForeColor="#A55129" Font-Bold="true"></asp:Label></td>
                                                <td class="auto-style2"><asp:Label ID="lblUsuario1" runat="server" Text="Pesquise para Inserir o Produto na Nota:" ForeColor="#A55129" Font-Bold="true"></asp:Label>&nbsp;
                                                </td>
                                                <td rowspan="3">
                                                    <asp:ImageButton ID="btnAdd" runat="server" Height="53px" ImageUrl="~/imagens/add.jpg" Width="50px" OnClick="btnAdd_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlEstoqueProduto" runat="server" Width="100px" > 
                                                        <asp:ListItem Selected="True" Value="10">  Selecione  </asp:ListItem>
                                                        <asp:ListItem Value="0"> Venda </asp:ListItem>
                                                        <asp:ListItem Value="1"> Consumo Interno </asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="412px" ></asp:TextBox>
                                                    &nbsp;&nbsp;<asp:Button ID="btnPesquisar" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" OnClick="btnPesquisar_Click" Text="Pesquisar" Width="98px" />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" Width="98px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                                </td>
                                            </tr>

                                        </table>
                                            </center>
                                    <%--</fieldset>--%>

                                    <table>
                                        <tr>
                                            <td >
                                               <b> <asp:Label ID="lblResultadoPesquisa" runat="server" Text="Resultado da Pesquisa" ForeColor="#A55129" Visible="false"></asp:Label></b> </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                
                                                <asp:GridView ID="GridPoduto" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" HorizontalAlign="Center" OnRowCommand="GridPoduto_RowCommand" PageSize="3" ShowFooter="True" Width="790px" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
                                                        <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderStyle Width="300px" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Em Estoque" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Qtd.Entrada" >
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtValorEntrada" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("Entrada") %>' Width="80px"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Vlr.Entrada" >
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtValorUnitario" runat="server" Enabled="True" MaxLength="10" Text='<%# Bind("ValorUnitario") %>' Width="80px" DataFormatString="{0:C2}"></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Select">
                                                            <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderTemplate>
                                                            <input id="chkAll" onclick="javascript:SelecionaTodosChecks(this);" runat="server" type="checkbox" />
                                                            </HeaderTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                </asp:GridView>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <br />
                                                <asp:Button ID="btnSelecionar" runat="server" BackColor="#A55129" Font-Bold="True" ForeColor="White" Width="201px" Text="Enviar" OnClick="btnSelecionar_Click"  />
                                            </td>
                                        </tr>
                                    </table>

                                    <br /><br />

                                    <asp:Button ID="btncancel1" runat="server" Text="Fechar" />

                                </center>






                                </asp:Panel>

                                <br /><br />
                            <asp:GridView ID="GridProdutoNota" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="3" ShowFooter="True" Width="851px" OnRowCommand="GridProdutoNota_RowCommand" OnRowDataBound="GridProdutoNota_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                <HeaderStyle Width="290px" />
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Estoque Atual" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="120px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Entrada" HeaderText="Qtd. Entrada" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Entrada" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:C2}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ValorTotal" HeaderText="Total" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:C2}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Ativo" HeaderText="Ativo" ItemStyle-HorizontalAlign="Center" >
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:ButtonField ButtonType="Button" CommandName="Excluir" HeaderText="Excluir" Text="Excluir" ItemStyle-HorizontalAlign="Center"/>
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

                        <table width="100%">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblLabelTotal" runat="server" Text="Total: " ForeColor="Red" Font-Bold="True" Font-Size="X-Large"></asp:Label>

                                    &nbsp;

                                    <asp:Label ID="lblTotalValorEntradas" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="7" align="right">
                                    <br />
                                    <b>
                                    <asp:Button ID="btnEnviarParaNota" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Text="Enviar e Finalizar" Width="174px" OnClick="btnEnviarParaNota_Click" Visible="false" />
                                    </b>

                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View1" runat="server">
                        <center>

                        </center>
                    </asp:View>
        </asp:MultiView>

    </fieldset>
        </center>
</asp:Content>
