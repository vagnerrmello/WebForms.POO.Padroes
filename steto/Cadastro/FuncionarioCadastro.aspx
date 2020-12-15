<%@ Page Title= "" Language="C#" MasterPageFile="~/Cadastro/ViknCadastro.Master" AutoEventWireup="true" CodeBehind="FuncionarioCadastro.aspx.cs" Inherits="Steto.Cadastro.FuncionarioCadastro" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>

        <fieldset class="fieldsetTabConteinerPaciente">
            <legend>
                <asp:Label ID="lblEmpresa" runat="server"/> - <asp:Label ID="lblEmpresaCodigo" runat="server"/>
                <br />
                Funcionário(a)
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
                                    <asp:Label ID="lblCodigoFuncionario" runat="server" Width="70px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="lblNome" runat="server" Text="Nome :" Width="70px"></asp:Label>
                                </td>
                                <td  align="right" colspan="5">
                                    <asp:TextBox ID="txtNomeFuncionario" runat="server" Width="570px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNCartaoSaude" runat="server" Text="Cartão Nacional de Saúde :"  ></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCNS" runat="server" Width="130px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            </table>
                     </td>


                    <td rowspan="2"align="center">
                            <fieldset class="fieldsetImagemPaciente">
                                <legend>Funcionário(a)</legend>
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
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                                    CssClass="ajax__tab_xp" Width="650">
                                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Residencial">
                                            <HeaderTemplate>
                                                Residencial
                                            </HeaderTemplate>
                                            <ContentTemplate> 

                                                <table >

                                                    <tr>
                                                        <td colspan="4">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTpLogradouro" runat="server" Text="Tipo logradouro:"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
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
                                                                    <td>
                                                                        <asp:TextBox ID="txtLogradouro" runat="server" Width="250px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtComplemento" runat="server" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtNumero" runat="server" Width="80px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>

                                                    </tr>
                                                    <tr>
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
                                        <ajaxToolkit:TabPanel ID="TabPanel8" runat="server" HeaderText="Histórico">
                                            <ContentTemplate>
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblHistoricoNacionalidade" runat="server" Text="Nacionalidade:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlHistoricoNacionalidade" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblHistoricoNaturalidade" runat="server" Text="Naturalidade:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlHistoricoNaturalidade" runat="server" Height="22px" Width="70px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlHistoricoCidadeNascimento" runat="server" Height="22px" Width="169px"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblHistoricoNascimento" runat="server" Text="Nascimento:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtHistoricoNascimento" runat="server" Columns="10" 
                                                                MaxLength="10" 
                                                                Font-Bold="True"
                                                                ForeColor="Crimson"
                                                                BackColor="LightGoldenrodYellow"
                                                                Width="90px"/>
                                                            <asp:Image ID="imgCalendario" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                            <ajaxToolkit:CalendarExtender 
                                                                ID="clnData" 
                                                                runat="server" 
                                                                PopupButtonID="imgCalendario" 
                                                                TargetControlID="txtHistoricoNascimento" 
                                                                Format="dd/MM/yyyy" Enabled="True">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblHistoricoGrauInstrucao" runat="server" Text="Grau Instrução:"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="ddlHistoricoGrauInstrucao" runat="server" Width="300px">
                                                                <asp:ListItem Value="1" Selected="True">1 - Analfabeto</asp:ListItem>
                                                                <asp:ListItem Value="2" >2 - Ensino Fundamental Incompleto (1º-5º incompl.)</asp:ListItem>
                                                                <asp:ListItem Value="3" >3 - Ensino Fundamental Incompleto (5º ano compl.)</asp:ListItem>
                                                                <asp:ListItem Value="4" >4 - Ensino Fundamental Incompleto (6º-9º incompl.)</asp:ListItem>
                                                                <asp:ListItem Value="5" >5 - Ensino Fundamental Completo</asp:ListItem>
                                                                <asp:ListItem Value="6" >6 - Ensino Médio Incompleto</asp:ListItem>
                                                                <asp:ListItem Value="7" >7 - Ensino Médio Incompleto</asp:ListItem>
                                                                <asp:ListItem Value="8" >8 - Educação Superior Incompleta</asp:ListItem>
                                                                <asp:ListItem Value="9" >9 - Educação Superior Completa</asp:ListItem>
                                                                <asp:ListItem Value="10" >10 - Mestrado Completo</asp:ListItem> 
                                                                <asp:ListItem Value="11" >11 - Doutorado Completo</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblHistoricoEstadoCivil" runat="server" Text="Estado Civil:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlHistoricoEstadoCivil" runat="server" Width="120px">
                                                                <asp:ListItem Value="1" Selected="True">Solteiro(a)</asp:ListItem>
                                                                <asp:ListItem Value="2" >Casado(a)</asp:ListItem>
                                                                <asp:ListItem Value="2" >Divorciado(a)</asp:ListItem>
                                                                <asp:ListItem Value="2" >Separado(a) Judicialmente</asp:ListItem>
                                                                <asp:ListItem Value="2" >União Estável</asp:ListItem>
                                                                <asp:ListItem Value="3" >Viúvo(a)</asp:ListItem>
                                                                <asp:ListItem Value="4" >Outros</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblHistoricoAdmissao" runat="server" Text="Admissão:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtHistoricoAdmissao" runat="server" Columns="10" 
                                                                MaxLength="10" 
                                                                Font-Bold="True"
                                                                ForeColor="Crimson"
                                                                BackColor="LightGoldenrodYellow"
                                                                Width="90px"/>
                                                            <asp:Image ID="Image6" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                            <ajaxToolkit:CalendarExtender 
                                                                ID="CalendarExtender7" 
                                                                runat="server" 
                                                                PopupButtonID="imgCalendario" 
                                                                TargetControlID="txtHistoricoAdmissao" 
                                                                Format="dd/MM/yyyy" Enabled="True">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>
                                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Documentos">
                                            <ContentTemplate> 
                                                <br />
                                                <table >
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosCarteiraIdentidade" runat="server" Text="Carteira de Identidade:"></asp:Label>
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:TextBox ID="txtDocumentosCarteiraIdentidade" runat="server" Width="214px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosOrgaoEmissorRG" runat="server" Text="Órgão Emissor RG:"></asp:Label>
                                                        </td>
                                                        <td >
                                                            <asp:TextBox ID="txtDocumentosOrgaoEmissorRG" runat="server" Width="50px"></asp:TextBox>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosEmissaoRG" runat="server" Text="Emissão:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDocumentosEmissaoRG" runat="server" Columns="10" 
                                                                MaxLength="10" 
                                                                Font-Bold="True"
                                                                ForeColor="Crimson"
                                                                BackColor="LightGoldenrodYellow"
                                                                Width="90px"/>
                                                            <asp:Image ID="Image3" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                            <ajaxToolkit:CalendarExtender 
                                                                ID="CalendarExtender3" 
                                                                runat="server" 
                                                                PopupButtonID="imgCalendario" 
                                                                TargetControlID="txtDocumentosEmissaoRG" 
                                                                Format="dd/MM/yyyy" Enabled="True">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </td>
                                                        <td align="right"><asp:Label ID="lblDocumentosUfRG" runat="server" Text="UF:"></asp:Label></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDocumentosUfRG" runat="server" Height="22px" Width="70px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosCPF" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <ajaxToolkit:MaskedEditExtender ID="meeCPF" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                            TargetControlID="txtDocumentosCPF" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                            <asp:TextBox ID="txtDocumentosCPF" runat="server" Width="130px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosPIS" runat="server" Text="PIS :" Width="40px" ></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDocumentosPIS" runat="server" Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDocumentosEmissaoPIS" runat="server" Text="Emissão PIS:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDocumentosEmissaoPIS" runat="server" Columns="10" 
                                                                MaxLength="10" 
                                                                Font-Bold="True"
                                                                ForeColor="Crimson"
                                                                BackColor="LightGoldenrodYellow"
                                                                Width="90px"/>
                                                            <asp:Image ID="Image4" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                            <ajaxToolkit:CalendarExtender 
                                                                ID="CalendarExtender4" 
                                                                runat="server" 
                                                                PopupButtonID="imgCalendario" 
                                                                TargetControlID="txtDocumentosEmissaoPIS" 
                                                                Format="dd/MM/yyyy" Enabled="True">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosTitulo" runat="server" Text="Título Eleitor :"  ></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtDocumentosTitulo" runat="server" Width="130px"></asp:TextBox>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosTituloZona" runat="server" Text="Zona:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDocumentosTituloZona" runat="server" Width="49px" />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumentosTituloSecao" runat="server" Text="Seção:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDocumentosTituloSecao" runat="server" Width="49px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumetosNumeroCarteiraTrabalho" runat="server" Text="Carteira de Trabalho :"  ></asp:Label>
                                                        </td>
                                                        <td colspan="5" align="left">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDocumetosNumeroCarteiraTrabalho" runat="server" Width="85px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDocumetosNumeroCarteiraSerie" runat="server" Text="Série:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDocumetosNumeroCarteiraSerie" runat="server" Width="40px" />-
                                                                        <asp:TextBox ID="txtDocumetosNumeroCarteiraSerieDigito" runat="server" Width="10px" MaxLength="2"/>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDocumetosNumeroCarteiraData" runat="server" Text="Data:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDocumetosNumeroCarteiraData" runat="server" MaxLength="10" 
                                                                            Font-Bold="True"
                                                                            ForeColor="Crimson"
                                                                            BackColor="LightGoldenrodYellow"
                                                                            Width="90px" />
                                                                        <asp:Image ID="Image5" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                                        <ajaxToolkit:CalendarExtender 
                                                                            ID="CalendarExtender5" 
                                                                            runat="server" 
                                                                            PopupButtonID="imgCalendario" 
                                                                            TargetControlID="txtDocumetosNumeroCarteiraData" 
                                                                            Format="dd/MM/yyyy" Enabled="True">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                    </td>
                                                                    <td align="right"><asp:Label ID="lblDocumetosNumeroCarteiraUf" runat="server" Text="UF:"></asp:Label></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDocumetosNumeroCarteiraUf" runat="server" Width="60px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDocumetosCNH" runat="server" Text="CNH :"  ></asp:Label>
                                                        </td>
                                                        <td colspan="5">
                                                            <table>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtDocumetosCNH" runat="server" Width="100px"></asp:TextBox>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDocumetosCNHCategoria" runat="server" Text="Categoria:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDocumetosCNHCategoria" runat="server" Width="40px" />
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblDocumetosCNHVencimento" runat="server" Text="Vencimento CNH:"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDocumetosCNHVencimento" runat="server" MaxLength="10" 
                                                                            Font-Bold="True"
                                                                            ForeColor="Crimson"
                                                                            BackColor="LightGoldenrodYellow"
                                                                            Width="90px" />
                                                                        
                                                                        <ajaxToolkit:CalendarExtender 
                                                                            ID="CalendarExtender6" 
                                                                            runat="server" 
                                                                            PopupButtonID="imgCalendario" 
                                                                            TargetControlID="txtDocumetosCNHVencimento" 
                                                                            Format="dd/MM/yyyy" Enabled="True">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                    </td>
                                                                    
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="3">
                                                            <b> <asp:CheckBox ID="chkDocumetosAlvaraJudicial" runat="server" Text="Alvará Judicial" TextAlign="Right" /></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblCertificadoReservista" runat="server" Text="Certificado Reservista :"  ></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCertificadoReservista" runat="server" Width="130px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Parentes">
                                            <ContentTemplate> 
                                                    <br />

                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblNomePai" runat="server" Text="Pai :" Width="70px" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtNomePai" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblIdentidadePai" runat="server" Text="Identidade : "></asp:Label></td>
                                                            <td><asp:TextBox ID="txtIdentidadePai" runat="server" Width="160px"></asp:TextBox></td>
                                                            <td align="right">
                                                                <asp:Label ID="lblCpfPai" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="999,999,999-99" CultureName="pt-BR"
                                                                TargetControlID="txtCPFPai" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtCPFPai" runat="server" Width="130px"></asp:TextBox>
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
                                                                <asp:Label ID="lblMae" runat="server" Text="Mãe :" Width="70px" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td  align="right" colspan="3">
                                                                <asp:TextBox ID="txtMae" runat="server" Width="350px"></asp:TextBox>
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
                                                <br /><hr align="center" width="550" size="1" color="blue">
                                                    <table>
                                                        <tr>
                                                            <td align="right" >
                                                                <asp:Label ID="lblNomeConjuge" runat="server" Text="Cônjuge :" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td  align="right">
                                                                <asp:TextBox ID="txtNomeConjuge" runat="server" Width="350px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table>

                                                        <tr>
                                                            <td><asp:Label ID="lblCidadeNascimentoConjuge" runat="server" Text="Cidade de Nascimento do Cônjuge : "></asp:Label></td>
                                                            
                                                            <td >
                                                                <asp:Label ID="lblNaturalidadeConjuge" runat="server" Text="Naturalidade :"  ></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:TextBox ID="txtCidadeNascimentoConjuge" runat="server" Width="330px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlEstado" runat="server" Height="22px" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>



                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblContatoConjuge" runat="server" Text="Contato :"  ></asp:Label></td>
                                                            <td><asp:TextBox ID="txtContatoConjuge" runat="server" Width="350px"></asp:TextBox></td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDaNascimentoConjuge" runat="server" Text="Nascimento :"  ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNascimentoConjugeFuncionaio" runat="server" Columns="10" 
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
                                                                    TargetControlID="txtNascimentoConjugeFuncionaio" 
                                                                    Format="dd/MM/yyyy" Enabled="True">
                                                                </ajaxToolkit:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                    </table>

                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="FGTS/GPS">
                                            <ContentTemplate> 
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td align="right" >
                                                            <asp:Label ID="lblFGTSGPSDataOpcao" runat="server" Text="Data Opção :" Font-Bold="True"></asp:Label>
                                                        </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFGTSGPSDataOpcao" runat="server" Columns="10" 
                                                                    MaxLength="10" 
                                                                    Font-Bold="True"
                                                                    ForeColor="Crimson"
                                                                    BackColor="LightGoldenrodYellow"
                                                                    Width="90px"/>
                                                                <asp:Image ID="Image2" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                                                <ajaxToolkit:CalendarExtender 
                                                                    ID="CalendarExtender2" 
                                                                    runat="server" 
                                                                    PopupButtonID="imgCalendario" 
                                                                    TargetControlID="txtFGTSGPSDataOpcao" 
                                                                    Format="dd/MM/yyyy" Enabled="True">
                                                                </ajaxToolkit:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblFGTSGPSContaBancaria" runat="server" Text="Conta Bancária :"  ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFGTSGPSContaBancaria" runat="server" Width="105px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblFGTSGPSCategoria" runat="server" Text="Categoria :"  ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFGTSGPSCategoria" runat="server" Height="22px" Width="474px">
                                                                    <asp:ListItem Value="1" >1 – Empregado</asp:ListItem>
                                                                    <asp:ListItem Value="2" >2 – Trabalhador Avulso</asp:ListItem>
                                                                    <asp:ListItem Value="3" >3 – Empregado Afastado por prestar Serviço Militar</asp:ListItem>
                                                                    <asp:ListItem Value="4" >4 – Empregado sob Contrato de Trabalho por Prazo Determinado</asp:ListItem>
                                                                    <asp:ListItem Value="5" >5 – Diretor não Empregado com FGTS (Empresário)</asp:ListItem>
                                                                    <asp:ListItem Value="6" >6 – Empregado Doméstico</asp:ListItem>
                                                                    <asp:ListItem Value="7" >7 – Trabalhador de 14 a 18 anos com Contrato de Aprendizagem</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblFGTSGPSPercentualFGTS" runat="server" Text="Percentual FGTS :" ></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                TargetControlID="txtFGTSGPSPercentualFGTS" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                                <asp:TextBox ID="txtFGTSGPSPercentualFGTS" runat="server" Width="130px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Label ID="lblFGTSGPSOcorrencia" runat="server" Text="Ocorrência :"  ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFGTSGPSOcorrencia" runat="server" Height="22px" Width="474px">
                                                                    <asp:ListItem Value="1" >1 – Não exposto a agentes nocivo</asp:ListItem>
                                                                    <asp:ListItem Value="2" >2 – Exposição a agentes nocivos (aposentadoria especial 15 anos de serviço)</asp:ListItem>
                                                                    <asp:ListItem Value="3" >3 - Exposição a agentes nocivos (aposentadoria especial 20 anos de serviço)</asp:ListItem>
                                                                    <asp:ListItem Value="4" >4 - Exposição a agentes nocivos (aposentadoria especial 25 anos de serviço)</asp:ListItem>
                                                                    <asp:ListItem Value="5" >5 – Não exposto a agentes nocivos</asp:ListItem>
                                                                    <asp:ListItem Value="6" >6 – Exposição a agentes nocivos (aposentadoria especial 15 anos de serviço)</asp:ListItem>
                                                                    <asp:ListItem Value="7" >7 - Exposição a agentes nocivos (aposentadoria especial 20 anos de serviço)</asp:ListItem>
                                                                    <asp:ListItem Value="8" >8 - Exposição a agentes nocivos (aposentadoria especial 25 anos de serviço)</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                </table>
                                            </ContentTemplate>
                                        </ajaxToolkit:TabPanel>

                                        <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="Cálculo">
                                            <ContentTemplate> 
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFuncionarioFormaPagamento" runat="server" Text="Forma Pagam. :"  Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left" colspan="3">
                                                                        <asp:DropDownList ID="ddlCalculoFuncionarioFormaPagamento" runat="server" Height="22px" Width="150px">
                                                                            <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Mensal</asp:ListItem>
                                                                            <asp:ListItem Value="2" >Quinzenal</asp:ListItem>
                                                                            <asp:ListItem Value="3" >Semanal</asp:ListItem>
                                                                            <asp:ListItem Value="4" >Diário</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFundionarioTipo" runat="server" Text="Tipo de Funcionário :"  Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left" colspan="3">
                                                                        <asp:DropDownList ID="ddlCalculoFundionarioTipo" runat="server" Height="22px" Width="150px">
                                                                            <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Mensalista</asp:ListItem>
                                                                            <asp:ListItem Value="2" >Diarista</asp:ListItem>
                                                                            <asp:ListItem Value="3" >Horista</asp:ListItem>
                                                                            <asp:ListItem Value="4" >Comissionado</asp:ListItem>
                                                                            <asp:ListItem Value="4" >Horista Especial</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFuncionarioSalarioBase" runat="server" Text="Salário Base :" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left" colspan="3">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioSalarioBase" runat="server" Width="111px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioSalarioBase" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFuncionarioHorasMenSemDir" runat="server" Text="Horas Men/Sem/Dir:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioHorasMen" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioHorasMen" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioHorasSem" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioHorasSem" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtlblCalculoFuncionarioHorasDir" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtlblCalculoFuncionarioHorasDir" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblAdicionalInsalub" runat="server" Text="Adicional Insalub. %:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioAdicionalInsalub" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioAdicionalInsalub" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td  align="left">
                                                                            <asp:Label ID="lblCalculoFuncionarioIncidicendiaInsalubridade" runat="server" Text="Incidência:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:DropDownList ID="ddlCalculoFuncionarioIncidicendiaInsalubridade" runat="server" Height="22px" Width="150px">
                                                                            <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Salário Base</asp:ListItem>
                                                                            <asp:ListItem Value="2" >Salário Mínimo</asp:ListItem>
                                                                            <asp:ListItem Value="3" > Piso Salarial</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFuncionarioAdicionalPericul" runat="server" Text="Adicional Pericul. %:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioAdicionalPericul" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioAdicionalPericul" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td  align="left">
                                                                            <asp:Label ID="lblCalculoFuncionarioIncidicendiaPericul" runat="server" Text="Incidência:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:DropDownList ID="ddlCalculoFuncionarioIncidicendiaPericul" runat="server" Height="22px" Width="150px">
                                                                            <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Salário Base</asp:ListItem>
                                                                            <asp:ListItem Value="2" >Salário Mínimo</asp:ListItem>
                                                                            <asp:ListItem Value="3" > Piso Salarial</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="right" >
                                                                        <asp:Label ID="lblCalculoFuncionarioAdicionalNoturno" runat="server" Text="Adicional Noturno. %:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:TextBox ID="txtCalculoFuncionarioAdicionalNoturno" runat="server" Width="50px"></asp:TextBox>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender9" runat="server" Mask="999,999,999.99" CultureName="pt-BR"
                                                                        TargetControlID="txtCalculoFuncionarioAdicionalNoturno" ClearMaskOnLostFocus="False" Enabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="R$" CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="," CultureThousandsPlaceholder="." CultureTimePlaceholder=":">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td  align="left">
                                                                            <asp:Label ID="lblCalculoFuncionarioIncidicendiaNoturno" runat="server" Text="Incidência:" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td  align="left">
                                                                        <asp:DropDownList ID="ddlCalculoFuncionarioIncidicendiaNoturno" runat="server" Height="22px" Width="150px">
                                                                            <asp:ListItem Value="0" Selected="True"> Nenhuma</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Salário Base</asp:ListItem>
                                                                            <asp:ListItem Value="2" >Salário Mínimo</asp:ListItem>
                                                                            <asp:ListItem Value="3" > Piso Salarial</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="3">
                                                                        <b> <asp:CheckBox ID="chkEstoqueNotaLancarContasAPagar" runat="server" Text="Receber Vale Refeição" TextAlign="Right" /></b>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td></td>
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
                                <td>
                                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProfissao" runat="server" Text="Profissão:"></asp:Label>
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
                                    <asp:DropDownList ID="ddlProfissao" runat="server" Height="22px" Width="193px"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtTipoSanguineo" runat="server" Width="130px" ></asp:TextBox>
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
                                        Width="90px"/>
                                    <asp:Image ID="imgCalendarioValidade" ImageUrl="~/imagens/images.jpg" runat="server" Width="20px" Height="20px" />
                                    <ajaxToolkit:CalendarExtender
                                    ID="ceValidadade"
                                    runat="server"
                                    PopupButtonID="imgCalendarioValidade"
                                    TargetControlID="txtValidade"
                                    Format="dd/MM/yyyy" Enabled="True"
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
