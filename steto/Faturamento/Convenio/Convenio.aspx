<%@ Page Title="" Language="C#" MasterPageFile="~/Faturamento/Faturamento.master" AutoEventWireup="true" CodeBehind="Convenio.aspx.cs" Inherits="Steto.CID.Convênio.Convenio" Culture="auto" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadFaturamentoContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 297px;
        }
        .style2
        {
            width: 560px;
        }
        .style3
        {
            width: 564px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainFaturamentoContent" runat="server">

            <div class="submitButtonUsuarioCenter">
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
            <fieldset class="fieldsetInteriorConvenio">
                <legend>Convênio</legend>
                <table>
                     <tr>
                        <td> 
                            <asp:Label ID="lblNome" runat="server" Text="Nome :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="591px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCNPJ" runat="server" Text="CNPJ :" Width="40px" ></asp:Label>
                        </td>
                        <td align="left" style="margin-left: 40px">
                            <ajaxToolkit:MaskedEditExtender ID="meeCNPJ" runat="server" Mask="99,999,999/9999-99"
                            MessageValidatorTip="true" CultureName="pt-BR"
                            TargetControlID="txtCNPJ" ClearMaskOnLostFocus="false"
                            MaskType="None" InputDirection="LeftToRight" Enabled="true">
                            </ajaxToolkit:MaskedEditExtender>
                            <asp:TextBox ID="txtCNPJ" runat="server" Width="114px" Height="25px"></asp:TextBox>
                        </td>
                        <td align="left"><asp:Label ID="lblANS" runat="server" Text="Inscrição ANS : "></asp:Label></td>
                        <td><asp:TextBox ID="txtANS" runat="server" Width="121px"></asp:TextBox></td>
                        <td></td>
                    </tr>
                </table>
            </fieldset>

        <asp:Menu ID="tabMenu" runat="server" CssClass="menu" Orientation="Horizontal" OnMenuItemClick="tabMenu_MenuItemClick">
            <Items>
                <asp:MenuItem Text="Informações" Value="Info" />
                <asp:MenuItem Text="Guias" Value="Guias" />
                <asp:MenuItem Text="WebServices" Value="WebServices" />
                <asp:MenuItem Text="Procedimento Exceção" Value="Procedimento" />
                <asp:MenuItem Text="Pacotes" Value="Pacotes" />
                <asp:MenuItem Text="Módulos de interfaces" Value="ModInterfaces" />
                <asp:MenuItem Text="Preferências" Value="Preferencias" />
            </Items>

        </asp:Menu>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">

                    <fieldset class="fieldsetInteriorConvenio">
                        <legend>Endereço: </legend>
                        <table >
                            <tr>
                                <td>
                                    <asp:Label ID="lblTpLogradouro" runat="server" Text="Tipo logradouro:"></asp:Label>
                                &nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="lblLogradouro" runat="server" Text="Logradouro:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblComplemento" runat="server" Text="Complemento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNumero" runat="server" Text="Número:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlTipoLogradouro" runat="server" Height="22px" 
                                        Width="70px"></asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtLogradouro" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtComplemento" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumero" runat="server" Width="80px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPais" runat="server" Text="País:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblUf" runat="server" Text="UF:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCidade" runat="server" Text="Cidade:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCep" runat="server" Text="Cep:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                <asp:DropDownList ID="ddlPais" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlUf" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlCidade" runat="server" Height="22px" Width="169px"></asp:DropDownList>
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlBairro" runat="server" Height="22px" Width="193px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCep" runat="server" Width="80px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fieldsetInteriorConvenio">
                        <legend>Contato: </legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResponsavel" runat="server" Text="Responsável(is):"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTelefone" runat="server" Text="Telefone(s):"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmail" runat="server" Text="Email(s):"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtResponsavel" runat="server" Width="180px"></asp:TextBox>
                                        <asp:Button ID="btnAdicionaResponsavel" runat="server" Text="+" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTelefone" runat="server" Width="180px"></asp:TextBox>
                                        <asp:Button ID="btnTelefone" runat="server" Text="+" />
                                    </td>
                                    <td>
                            
                                        <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox>
                                        <asp:Button ID="btnEmail" runat="server" Text="+" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="lstResponsavel" runat="server" Width="215px"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="lstTelefone" runat="server" Width="215px"></asp:ListBox>
                                    </td>
                                    <td>
                                        <asp:ListBox ID="lstEmail" runat="server" Width="215px"></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        
                        <table>
                        <tr>
                            <td class="style2">
                                <fieldset class="fieldsetRepasse">
                                    <legend>Repasse e contrato</legend>
                                    <table>
                                        <tr >
                                            <td>
                                                <asp:Label ID="lblTipoRepasse" runat="server" Text="Tipo de repasse:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblContrato" runat="server" Text="Contrato:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlTipoRepasse" runat="server" Height="22px" 
                                                    Width="103px"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContrato" runat="server" Height="22px" Width="119px"></asp:TextBox>
                                            </td>
                                            <td class="style1">
                                                <asp:TextBox ID="txtEmpresa" runat="server" Height="22px" Width="268px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                            <td>
                                <fieldset class="fieldsetIndiceAnual">
                                    <legend>Maior índice anual</legend>
                                    <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblIndiceAnual" runat="server" Text="Data (MM/AAAA-W)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtIndiceAnual" runat="server" Height="22px" Width="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        </table>
                        <table border ="0">
                            <tr>
                                <td>
                                    <fieldset class="fieldsetConvenioRepasse">
                                        <legend>Cronograma de faturamento</legend>
                                        <table border="0">
                                            <tr>
                                                <td>
                                                <asp:Label ID="lblEntrega" runat="server" Text="Entrega:"></asp:Label>
                                                </td>
                                                    <td>

                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender1"  
                                                            runat="server"  
                                                            TargetControlID="txtEntrega1"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtEntrega1"  
                                                            runat="server" Width="10px"
                                                            ></asp:TextBox>  

                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="Label2" runat="server" Text="OU:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender2"  
                                                            runat="server"  
                                                            TargetControlID="txtEntrega2"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtEntrega2"  
                                                            runat="server"  Width="10px"
                                                            >  
                                                        </asp:TextBox>  
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="Label4" runat="server" Text="OU:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender3"  
                                                            runat="server"  
                                                            TargetControlID="txtEntrega3"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtEntrega3"  
                                                            runat="server" Width="10px"
                                                            >  
                                                        </asp:TextBox>  
                                                    </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                <asp:Label ID="Label1" runat="server" Text="Pagamento:"></asp:Label>
                                                </td>
                                                    <td>

                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender4"  
                                                            runat="server"  
                                                            TargetControlID="txtPagamento1"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtPagamento1"  
                                                            runat="server" Width="10px"
                                                            >  
                                                        </asp:TextBox>  

                                                    </td>
                                                    <td  align="left">
                                                        <asp:Label ID="Label5" runat="server" Text="OU:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender5"  
                                                            runat="server"  
                                                            TargetControlID="txtPagamento2"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtPagamento2"  
                                                            runat="server" Width="10px"
                                                            >  
                                                        </asp:TextBox>  
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="Label6" runat="server" Text="OU:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender6"  
                                                            runat="server"  
                                                            TargetControlID="txtPagamento3"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="50"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtPagamento3"  
                                                            runat="server" Width="10px" 
                                                            >  
                                                        </asp:TextBox>  
                                                    </td>
                                            </tr>



                                            <tr>
                                                <td colspan="2" align="left">
                                                <asp:Label ID="Label3" runat="server" Text="Retorno de consulta:"></asp:Label>
                                                </td>
                                                    <td colspan="2">

                                                        <ajaxToolkit:NumericUpDownExtender   
                                                            ID="NumericUpDownExtender7"  
                                                            runat="server"  
                                                            TargetControlID="txtRetorno"  
                                                            Minimum="1"  
                                                            Maximum="31"  
                                                            Width="80"  
                                                            >  
                                                        </ajaxToolkit:NumericUpDownExtender>  
                                                        <asp:TextBox   
                                                            ID="txtRetorno"  
                                                            runat="server"  
                                                            Width="10px"
                                                            >  
                                                        </asp:TextBox>  

                                                    </td>

                                                    <td>

                                                    </td>
                                                    <td>

                                                    </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2" align="left">
                                                <asp:Label ID="Label7" runat="server" Text="Fatura atual:"></asp:Label>
                                                </td>
                                                    <td colspan="4" align="left">


                                                        <asp:TextBox ID="txtData" runat="server" Columns="10" 
                                                        MaxLength="10" 
                                                        Font-Bold="true"
                                                        ForeColor="Crimson"
                                                        BackColor="LightGoldenrodYellow"
                                                        Width="160"/>
                                                        <asp:Image ID="imgCalendario" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                        <ajaxToolkit:CalendarExtender 
                                                        ID="clnData" 
                                                        runat="server" 
                                                        PopupButtonID="imgCalendario" 
                                                        TargetControlID="txtData" 
                                                        Format="MM/yyyy">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>


                                            </tr>


                                        </table>
                                    </fieldset>
                                </td>

                                <td>
                                    <fieldset class="fieldsetConvenioLogo">
                                        <legend>Logotipo</legend>
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    <asp:Image ID="imgLogo" 
                                                    runat="server"
                                                    ImageUrl="~/imagens/logo_unimed2.jpg"
                                                    Width="250"
                                                    Height="110" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="fUploadLogo" runat="server" />
                                                </td>
                                            </tr>                                        
                                        
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <fieldset class="fieldsetInteriorConvenio">
                                        <legend>Informações de faturamento</legend>
                                            <table border="0">
                                            <tr>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2" align="center">Deflatores</td>
                                            </tr>
                                            <tr>
                                               <td > 
                                                    <asp:Label ID="lblTabela" runat="server" Text="Tabela" Width="80"></asp:Label>
                                               </td> 
                                               <td  align="left">
                                                    <asp:Label ID="lblClassificacaoTISS" runat="server" Text="Classificação TISS" ></asp:Label>
                                               </td> 
                                            <td>
                                                <asp:Label ID="lblHonorarios" runat="server" Text="% Honorários"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblC_Operacional" runat="server" Text="% C. Operacional"></asp:Label>
                                            </td>
                                            </tr>
                                            <tr>
                                               <td >
                                                    
                                                    <asp:DropDownList ID="ddlTabela" runat="server" Width="200px"></asp:DropDownList>
                                               </td> 
                                               <td  align="left">
                                                    <asp:DropDownList ID="ddlClassificacaoTISS" runat="server" Width="200px"></asp:DropDownList>
                                               </td> 
                                            <td>
                                                    <ajaxToolkit:NumericUpDownExtender   
                                                        ID="NumericUpDownExtenderHonorario"  
                                                        runat="server"  
                                                        TargetControlID="txtHonorario"   
                                                        Minimum="0"  
                                                        Maximum="100"
                                                        Width="80"  
                                                        >  
                                                    </ajaxToolkit:NumericUpDownExtender>  
                                                    <asp:TextBox   
                                                        ID="txtHonorario"  
                                                        runat="server"  
                                                        Width="5px"
                                                        >  
                                                    </asp:TextBox>  
                                            </td>
                                            <td>
                                                    <ajaxToolkit:NumericUpDownExtender   
                                                        ID="NumericUpDownExtenderC_Operacional"  
                                                        runat="server"  
                                                        TargetControlID="txtC_Operacional"   
                                                        Minimum="0"  
                                                        Maximum="100"
                                                        Width="80"  
                                                        >  
                                                    </ajaxToolkit:NumericUpDownExtender>  
                                                    <asp:TextBox   
                                                        ID="txtC_Operacional"  
                                                        runat="server"  
                                                        Width="5px"
                                                        >  
                                                    </asp:TextBox>  
                                            </td>
                                            </tr>
                                            </table>
                                    </fieldset>
                                </td>

                            </tr>
                        </table>

                    </asp:View>
                <asp:View ID="View2" runat="server">
                    Guias
                </asp:View>
                <asp:View ID="View3" runat="server">
                    WebServices
                </asp:View>
                <asp:View ID="View4" runat="server">
                    Procedimento e Exceção
                </asp:View>
                <asp:View ID="View5" runat="server">
                    Pacotes
                </asp:View>
                <asp:View ID="View6" runat="server">
                    Módulos de interfaces
                </asp:View>
                <asp:View ID="View7" runat="server">
                    Preferências
                </asp:View>
            </asp:MultiView>

</asp:Content>
