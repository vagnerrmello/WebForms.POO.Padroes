<%@ Page Title= "" Language="C#" MasterPageFile="~/Cadastro/ViknCadastro.Master" AutoEventWireup="true" CodeBehind="ClienteCadastro.aspx.cs" Inherits="Steto.Cadastro.ClienteCadastro" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>

        <fieldset class="fieldsetTabConteinerPaciente">
            <legend>
                <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
                <br />
                Cliente
            </legend>
            <table>
               <tr>
                    <td style="width:70px" > 
                        <table>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="lblRotuloCodigoCliente" runat="server" Text="Código :" Width="70px"></asp:Label>
                                </td>
                                <td  align="left" colspan="5">
                                    <asp:Label ID="lblCodigoCliente" runat="server" Width="70px"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblDataCadastroCliente" runat="server" Width="70px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="lblNome" runat="server" Text="Nome :" Width="70px"></asp:Label>
                                </td>
                                <td  align="right" colspan="5">
                                    <asp:TextBox ID="txtNome" runat="server" Width="570px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                     </td>

                    <td rowspan="2"align="center">
                            <fieldset class="fieldsetImagemPaciente">
                                <legend>Cliente</legend>
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="imgPaciente" 
                                            runat="server"
                                            ImageUrl="~/Paciente/imagens/PacienteFicha/paciente.jpg"
                                            Width="140"
                                            Height="110" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnUploadImagemPaciente" runat="server" Text="Enviar" 
                                                onclick="btnUploadImagemPaciente_Click"/>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="100px" />
                                        </td>
                                    </tr>    
                                    </table>
                            </fieldset>
                    </td>
                </tr>
                    <tr>
                        <td>
                            <fieldset class="fieldsetInteriorTabConteiner">
                                <legend>Dados:</legend>
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                                    CssClass="ajax__tab_xp" Width="650">
                                        <ajaxToolkit:TabPanel ID="TabPanel0" runat="server" HeaderText="Financeiro">
                                            <ContentTemplate> 
                                                    <br />
                                                    <table>
                                                        <table>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblTipoPessoa" runat="server" Text="Tipo de Pessoa :" Width="110px"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="0">
                                                                    <asp:DropDownList ID="ddlTipoPessoa" runat="server" Height="22px" Width="130px">
                                                                        <asp:ListItem Selected="True" Value="0">Selecione</asp:ListItem>
                                                                        <asp:ListItem  Value="1">JURÍDICA</asp:ListItem>
                                                                        <asp:ListItem Value="2">FÍSICA</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="lblDataAbertura" runat="server" Text="Data Abertura :" Width="130px"></asp:Label>
                                                                </td>
                                                                <td align="right" >
                                                                    <asp:TextBox ID="TextBox2" runat="server" Columns="10" 
                                                                        MaxLength="10" 
                                                                        Font-Bold="True"
                                                                        ForeColor="Crimson"
                                                                        BackColor="LightGoldenrodYellow"
                                                                        Width="90px"/>
                                                                    <asp:Image ID="Image1" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                                    <ajaxToolkit:CalendarExtender 
                                                                        ID="CalendarExtender1" 
                                                                        runat="server" 
                                                                        PopupButtonID="imgCalendario" 
                                                                        TargetControlID="TextBox2" 
                                                                        Format="dd/MM/yyyy" Enabled="True">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblRazaoSocial" runat="server" Text="Razão Social :" Width="130px"></asp:Label>
                                                                </td>
                                                                <td colspan="3">

                                                                    <asp:TextBox ID="txtRazaoSocial" runat="server" Width="400px"></asp:TextBox>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblNFatasia" runat="server" Text="N.Fatasia :" Width="130px"></asp:Label>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:TextBox ID="txtNFatasia" runat="server" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr >
                                                                <td align="right"><asp:Label ID="lblInscEstadual" runat="server" Text="Insc.Estadual : "></asp:Label></td>
                                                                <td><asp:TextBox ID="txtInscEstadual" runat="server" Width="130px"></asp:TextBox></td>
                                                                <td align="right"><asp:Label ID="lblCnpj" runat="server" Text="CNPJ : "></asp:Label></td>
                                                                <td><asp:TextBox ID="txtCnpj" runat="server" Width="130px"></asp:TextBox></td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblRAtividade" runat="server" Text="R.Atividade :" Width="130px"></asp:Label>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtRAtividad" runat="server" Width="200px"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblSituacaoCdr" runat="server" Text="Situação cdr :" Width="110px"></asp:Label>
                                                                </td>
                                                                <td align="left" colspan="0">
                                                                    <asp:DropDownList ID="ddlSituacaoCd" runat="server" Height="22px" Width="130px">
                                                                        <asp:ListItem Selected="True" Value="0">Selecione</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Label ID="LblConvenio" runat="server" Text="Convênio :" Width="130px"></asp:Label>
                                                                </td>
                                                                <td align="right" >
                                                                    <asp:DropDownList ID="ddlConvencio" runat="server" Height="22px" Width="130px">
                                                                        <asp:ListItem Selected="True" Value="0">Selecione</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblRG" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtRG" runat="server" Width="130px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCPF" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="meeCPF" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCPF" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCPF" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                        
                                            <fieldset class="fieldsetTabConteinerContato">
                                                <legend>Contato: </legend>

                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text="Telefone(s):"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label4" runat="server" Text="Email(s):"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtAddTelefoneResponsavelFinanceiro" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddTelefoneResponsavelFinanceiro" runat="server" Text="+"  
                                                                     />
                                                            </td>
                                                            <td>
                            
                                                                <asp:TextBox ID="txtAddEmailResponsavelFinanceiro" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddEmailResponsavelFinanceiro" runat="server" Text="+"  />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="lstTelefoneResponsavelFinanceiro" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lstEmailResponsavelFinanceiro" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                
                                            </fieldset>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="Referências">
                                            <HeaderTemplate>
                                                Referências
                                            </HeaderTemplate>
                                            <ContentTemplate> 
                                                <table>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="3"></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="3"></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>

                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Residencial">
                                            <HeaderTemplate>
                                                Residencial
                                            </HeaderTemplate>

                                            <ContentTemplate> 

                                                <table >
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
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
                                                            &nbsp;</td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtLogradouro" runat="server" Width="250px" MaxLength="250"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtComplemento" runat="server" Width="180px" MaxLength="150"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNumero" runat="server" Width="80px" MaxLength="15"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
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
                                                            &nbsp;</td>
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
                                                            <asp:TextBox ID="txtCep" runat="server" Width="80px" MaxLength="9"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            <fieldset class="fieldsetTabConteinerContato">
                                                <legend>Contato: </legend>

                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTelefoneResidencial" runat="server" Text="Telefone(s):"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmailResidencial" runat="server" Text="Email(s):"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtTelefoneResidencial" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddTelefoneResidencial" runat="server" Text="+" OnClick="btnAddTelefoneResidencial_Click" 
                                                                     />
                                                            </td>
                                                            <td>
                            
                                                                <asp:TextBox ID="txtEmailResidencial" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddEmailResidencial" runat="server" Text="+" OnClick="btnAddEmailResidencial_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="lstTelefoneResidencial" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lstEmailResidencial" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                
                                            </fieldset>

                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Comercial">
                                            <ContentTemplate> 
                                                <table >
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTpLogradouro_Comercial" runat="server" Text="Tipo logradouro:"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblLogradouro_Comercial" runat="server" Text="Logradouro:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblComplemento_Comercial" runat="server" Text="Complemento:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblNumero_Comercial" runat="server" Text="Número:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTipoLogradouro_Comercial" runat="server" Height="22px" 
                                                                Width="70px"></asp:DropDownList>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtLogradouro_Comercial" runat="server" Width="250px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtComplemento_Comercial" runat="server" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNumero_Comercial" runat="server" Width="80px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblPais_Comercial" runat="server" Text="País:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUf_Comercial" runat="server" Text="UF:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCidade_Comercial" runat="server" Text="Cidade:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBairro_Comercial" runat="server" Text="Bairro:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCep_Comercial" runat="server" Text="Cep:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPais_Comercial" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlUf_Comercial" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCidade_Comercial" runat="server" Height="22px" Width="169px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBairro_Comercial" runat="server" Height="22px" Width="193px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCep_Comercial" runat="server" Width="80px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            <fieldset class="fieldsetTabConteinerContato">
                                                <legend>Contato: </legend>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTelefone" runat="server" Text="Telefone(s):"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEmail" runat="server" Text="Email(s):"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtTelefoneComercial" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddTelefoneComercial" runat="server" Text="+" 
                                                                    onclick="btnAddTelefoneComercial_Click" />
                                                            </td>
                                                            <td>
                            
                                                                <asp:TextBox ID="txtEmailComercial" runat="server" Width="180px"></asp:TextBox>
                                                                <asp:Button ID="btnAddEmailComercial" runat="server" Text="+" 
                                                                    onclick="btnAddEmailComercial_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="lstTelefoneComercial" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lstEmailComercial" runat="server" Width="215px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>

                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Responsáveis">
                                            <ContentTemplate> 
                                                    <br />

                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblNomePai" runat="server" Text="Pai :" Width="70px" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtNomePai" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="Label3" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtIdentidadePai" runat="server" Width="160px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCpfPai" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCPFResponsavelPai" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCPFResponsavelPai" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="lblContatoPai" runat="server" Text="Contato :"  ></asp:Label></td>
                                                            <td colspan="3"><asp:TextBox ID="txtContatoPai" runat="server" Width="350px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>

                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblResponsávelMae" runat="server" Text="Mãe :" Width="70px" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtResponsávelMae" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblIdentidadeMae" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtIdentidadeMae" runat="server" Width="150px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCpfMae" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCpfMae" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCpfMae" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="lblContatoMae" runat="server" Text="Contato :"  ></asp:Label></td>
                                                            <td colspan="3"><asp:TextBox ID="txtContatoMae" runat="server" Width="350px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                <br />
                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblNomeResponsavel01" runat="server" Text="Resp. :" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtNomeResponsavel01" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblIdentidadeResponsavel01" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtIdentidadeResponsavel01" runat="server" Width="150px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCpfResponsavel01" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCpfResponsavel01" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCpfResponsavel01" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="lblContatoResponsavel01" runat="server" Text="Contato :"  ></asp:Label></td>
                                                            <td colspan="3"><asp:TextBox ID="txtContatoResponsavel01" runat="server" Width="350px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>

                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblResponsável02" runat="server" Text="Resp. :" Font-Bold="true"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtNomeResponsável02" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblIdentidadeResponsável02" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtIdentidadeResponsável02" runat="server" Width="150px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCpfResponsável02" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCpfResponsavel02" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCpfResponsavel02" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:Label ID="lblConttoResponsavel02" runat="server" Text="Contato :"  ></asp:Label></td>
                                                            <td colspan="3"><asp:TextBox ID="txtContatoResponsavel02" runat="server" Width="350px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                           
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="Documentos">
                                            <ContentTemplate> 
                                                <br />
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:FileUpload ID="flpup" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNomeDocumento" runat="server" Width="214px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>

                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnfileupload" runat="server" BackColor="#336699" Font-Bold="True" ForeColor="White" OnClick="resumeupload" Text="Enviar Arquivo" />
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td colspan="2">
                                                            
                                                            <asp:GridView ID="GridContas" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center"   
                                                                 PageSize="4" ShowFooter="True" Width="502px">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Id" HeaderText="Código">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle Width="30px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NumeroNota" HeaderText="Documento" >
                                                                    <HeaderStyle Width="180px" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:ButtonField ButtonType="Image" CommandName="Comprovante" ImageUrl="~/imagens/Lupa02.png" >
                                                                    <ControlStyle Height="30px" />
                                                                    <FooterStyle Width="30px" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                    </ajaxToolkit:TabContainer>
                            </fieldset>
                        </td>
                        <td></td>
                    </tr>
                </table>


            <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
            CssClass="ajax__tab_xp" Width="850">
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Informações">
                    <ContentTemplate> 
                        <br />
                    <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblNCartaoSaude" runat="server" Text="Cartão Nacional de Saúde :"  ></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCNS" runat="server" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil:"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lblProfissao" runat="server" Text="Profissão:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNascimento" runat="server" Text="Nascimento:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTipoSanguineo" runat="server" Text="Tipo Sanguíneo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDeficiencia" runat="server" Text="Deficiência:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSexo" runat="server" Height="22px" Width="90px">
                                        <asp:ListItem Value="1" Selected="True">Masculino</asp:ListItem>
                                        <asp:ListItem Value="2" >Feminino</asp:ListItem>
                                        <asp:ListItem Value="3" >Outros</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoCivil" runat="server" Height="22px" Width="100px">
                                        <asp:ListItem Value="1" Selected="True">Solteiro(a)</asp:ListItem>
                                        <asp:ListItem Value="2" >Casado(a)</asp:ListItem>
                                        <asp:ListItem Value="3" >Viúvo(a)</asp:ListItem>
                                        <asp:ListItem Value="4" >Outros</asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlProfissao" runat="server" Height="22px" Width="193px"></asp:DropDownList>
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
                                    <asp:TextBox ID="txtTipoSanguineo" runat="server" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDeficienciaFuncionario" runat="server" Height="22px" Width="100px">
                                        <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                        <asp:ListItem Value="1" >Física</asp:ListItem>
                                        <asp:ListItem Value="2" >Auditiva</asp:ListItem>
                                        <asp:ListItem Value="3" >Visual</asp:ListItem>
                                        <asp:ListItem Value="4" >Mental</asp:ListItem>
                                        <asp:ListItem Value="5" >Múltipla</asp:ListItem>
                                        <asp:ListItem Value="6" > Reabilitado</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                    </table>
                    <table>
                            <tr>
                                <td>
                                    
                                </td>

                                <td>
                                    <asp:Label ID="lblPlano" runat="server" Text="Plano:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMatriculaCarteirinha" runat="server" Text="Matricula/Carteirinha:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDataValidade" runat="server" Text="Data Validade:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTitular" runat="server" Text="Titular:"></asp:Label>
                                </td>
                             </tr>
                             <tr>
                                <td>
                                    <asp:RadioButton ID="RadioButton1" runat="server" />
                                </td>

                                <td>
                                    <asp:TextBox ID="txtPlano" runat="server" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMatriculaCarteirinha" runat="server" ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtValidade" runat="server" Columns="10" 
                                        MaxLength="10" 
                                        Width="90"/>
                                    <asp:Image ID="imgCalendarioValidade" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                    <ajaxToolkit:CalendarExtender
                                    ID="ceValidadade"
                                    runat="server"
                                    PopupButtonID="imgCalendarioValidade"
                                    TargetControlID="txtValidade"
                                    Format="dd/MM/yyyy"
                                    ></ajaxToolkit:CalendarExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitular" runat="server" ></asp:TextBox>
                                </td>
                             </tr>
                    </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Observações">
                    <ContentTemplate> 
                        <br />
                        <table>
                            <tr>
                                <td><asp:Label ID="lblAlergia" runat="server" Text="Alergia :"  ></asp:Label></td>
                                <td ><asp:TextBox ID="txtAlergia" runat="server" Width="551px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblObservacoes" runat="server" Text="Observações :"  ></asp:Label></td>
                                <td ><asp:TextBox ID="txtObservacoes" runat="server" Width="551px" Height="70px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </fieldset>    

        <table>
            <tr align="right">
                <td>
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" 
                        onclick="btnSalvar_Click"/>
                </td>
                <td>
                    <asp:Button ID="btnNovo" runat="server" Text="Novo" Width="88px"/>
                </td>
            </tr>
        </table>

</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</asp:Content>
