<%@ Page Title="" Language="C#" MasterPageFile="~/Estoque/ViknEstoque.Master" AutoEventWireup="true" CodeBehind="EstoqueVenda.aspx.cs" Inherits="Amago.Web.Estoque.Vendas.EstoqueVenda" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">


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
                    url: '<%=ResolveUrl("~/Estoque/Vendas/EstoqueVenda.aspx/GetClientes") %>',
                    data: "{ 'prefixo': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                               
                                label: item.split('-')[0],
                                val: item.split('-')[1],
                                val2: item
                                
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
                $("[id$=txtQuantidadeSolicitada]").val(i.item.val2);
                $("[id$=ListBox1]").val(i.item.val2);
            },
            minLength: 1
        });
    });

function SearchList()
    {
        //var l =  ;
        var tb = document.getElementById('<%= txtQuantidadeSolicitada.ClientID %>');
    for (var i=0; i < document.getElementById("txtQuantidadeSolicitada").options.length; i++)
            {
        if (document.getElementById("txtQuantidadeSolicitada").options[i].value.toLowerCase().match(tb.value.toLowerCase()))
                {
            document.getElementById("txtQuantidadeSolicitada").options[i].selected = true;
                    return false;
                }
                else
                {
                    ClearSelection();
                }
            }
    }
    function ClearSelection()
    {
        document.getElementById("txtQuantidadeSolicitada").selectedIndex = -1;
    }
 

    </script>
 
    <div class="submitButtonUsuarioCenter">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
    <fieldset class="fieldsetTabConteinerPaciente">
        <legend> 
            <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
            <br />
            Solicitação de Produtos em Estoque
        </legend>
                <asp:MultiView ID="MultiViewNota" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ViewPesquisa" runat="server">
                        
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDataSolicitacao" runat="server" Text="Data da Solicitação: " ForeColor="#336699" Font-Bold="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblDataAtualSolicitacao" runat="server" ForeColor="#336699" Font-Bold="true" />
                                </td>
                            </tr>
                        </table>
                        
                        <center>

                            <fieldset class="fieldsetPesquisa">
                                <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/imagens/Procurar Produtos.gif" Height="31px" Width="29px"/> </legend>
                                <center>
                                <table width="100%">
                                    <tr>
                                        <td align="left" ><asp:Label ID="lblDescricao" runat="server" Text="Descrição:" ForeColor="#336699" Font-Bold="true"></asp:Label>&nbsp;
                                            <asp:Label ID="lblCodigoProduto" runat="server" Font-Bold="true" ForeColor="#336699" Text="Valor Unitário:"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:Label ID="lblValorUnitario" runat="server" Font-Bold="true" ForeColor="#336699" Text="Valor Unitário:"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:TextBox ID="txtDescricaoPesquisa" runat="server" Width="412px" ></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblValor" runat="server" Font-Bold="true" ForeColor="#336699" ></asp:Label>

                                        </td>
                                    </tr>

                                    <tr >
                                        <td colspan="2" align="left">
                                            <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade Solicitada:" ForeColor="#336699" Font-Bold="true"></asp:Label>
                                            &nbsp;<asp:TextBox ID="txtQuantidadeSolicitada" runat="server" Width="60px" onkeyup="return SearchList();" xmlns:asp="#unknown"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                        <asp:Button ID="btnPesquisar" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                        &nbsp;<asp:Button ID="btnLimpaPesquisa" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="98px" Text="Limpar" OnClick="btnLimpaPesquisa_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr >
                                        <td  width="200">
                                            &nbsp;</td>
                                        
                                        <td colspan="2" >

                                            <asp:GridView ID="GridProdutosSolicitacao0" runat="server" AllowPaging="True" AllowSorting="True" 
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnRowCommand="GridProdutosSolicitacao_RowCommand" 
                                                PageSize="5" ShowFooter="True" Width="649px">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                    <HeaderStyle Width="70px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderStyle Width="300px" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Qtd" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr  >

                                        
                                        <td align="right" colspan="2">
                                            <table>
                                                <tr>
                                                    <td  width="400">Quantidade de Itens: </td>
                                                    <td width="200">
                                                        <asp:Label ID="lblQuantidadeItens" runat="server" Font-Bold="true" ForeColor="#336699" ></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>

                                                    <td>Valor Acréscimo: </td>
                                                    <td>
                                                        <asp:Label ID="lblValorAcrescimo" runat="server" Font-Bold="true" ForeColor="#336699" ></asp:Label>
                                                    </td>

                                                </tr>
                                                <tr>

                                                    <td>Valor Desconto: </td>
                                                    <td>
                                                        <asp:Label ID="lblValorDesconto" runat="server" Font-Bold="true" ForeColor="#336699" ></asp:Label>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td>Valor Total:</td>
                                                    <td>
                                                        <asp:Label ID="lblValorTotal" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Small"></asp:Label>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                    </tr>



                                </table>


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
                                        &nbsp;</td>

                                </tr>
                            </table>
                            </center>
                    </fieldset>
                            <br />
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnEnviarSolicitacao" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" Width="250px" Text="Enviar Solicitação  >>>" OnClick="btnEnviarSolicitacao_Click"  />
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b> <asp:Label ID="lblProdutosSolicitados" runat="server" Text="PRODUTOS SOLICITADOS" ForeColor="#000000" Visible="false"></asp:Label></b> 
                                    </td>
                                </tr>
                            </table>
                            
                            <br /><br />
                            <asp:GridView ID="GridProdutosSolicitacao" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" PageSize="5" ShowFooter="True" Width="822px" OnRowCommand="GridProdutosSolicitacao_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-HorizontalAlign="Center" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descricao" HeaderText="Produto" ItemStyle-HorizontalAlign="Left">
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QuantidadeRealEstoque" HeaderText="Qtd. Solicitada" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="120px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Excluir" HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" Text="Excluir" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>

                            <br />

                        </center>

                </asp:View>
                <asp:View ID="View1" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="right">

                                <asp:ImageButton ID="btnVisualizarImpressaoCliente" runat="server" Height="46px" ImageUrl="~/imagens/VisualizarImprimir.png"  Width="55px" OnClick="btnVisualizarImpressaoCliente_Click" />

                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmpresaImpressao" runat="server" Text="Empresa: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNomeEmpresaImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblSolicitacaoImpressao" runat="server" Text="Número da Solicitação: " ForeColor="#000000" Font-Bold="true" ></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNumeroSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDataSolicitacaoImpressao" runat="server" Text="Data da Solicitação: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDataExtensoSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStatusSolicitacaoImpressao" runat="server" Text="Status da Solicitacao: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblStatusResultadoSolicitacaoImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFuncionarioImpressao" runat="server" Text="Funcionário: " ForeColor="#000000" Font-Bold="true"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblNomeFuncionarioImpressao" runat="server"  ForeColor="#000000" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagens/Fluxos/Fluxo.Enviado.jpg" Height="68px" Width="537px" />
                                        <br /><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <b> <asp:Label ID="Label1" runat="server" Text="PRODUTOS SOLICITADOS DO ESTOQUE" ForeColor="#000000" ></asp:Label></b> 
                                    </td>
                                </tr>
                            </table>
                        <br />
                    <center>
                        <asp:Table ID="TbDinamica" runat="server" BorderStyle="Solid" Width="700px"></asp:Table>
                    </center>

                    <br /><br /><br /><br /><br />
                    <center>
                        <asp:Label ID="lblAssinaturaFuncionario0" runat="server" Text="Solicito os produtos acima listados" ForeColor="#000000" />
                        <br /><br /><br />
                        <asp:Label ID="lblAssinaturaFuncionario1" runat="server" Text="--------------------------------------------" ForeColor="#000000" />
                        <br />
                        <asp:Label ID="lblAssinaturaFuncionario2" runat="server" Text="Assinatura do solicitante" ForeColor="#000000" />
                    </center>
                </asp:View>
        </asp:MultiView>

    </fieldset>
        
</asp:Content>
