<%@ Page Title= "" Language="C#" MasterPageFile="~/Paciente/Paciente.master" AutoEventWireup="true" CodeBehind="PacienteFicha.aspx.cs" Inherits="Steto.Paciente.FichaPaciente" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>

        <fieldset class="fieldsetTabConteinerPaciente">
            <legend>Paciente</legend>
            <table>
               <tr>
                    <td style="width:70px" align="right"> 
                        <table>
                            <tr>
                                <td style="width:70px" align="right">
                                    <asp:Label ID="lblNome" runat="server" Text="Nome :"></asp:Label>
                                </td>
                                <td  align="right" colspan="5">
                                    <asp:TextBox ID="txtNome" runat="server" Width="610px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblRG" runat="server" Text="Identidade : "></asp:Label></td>
                                <td><asp:TextBox ID="txtRG" runat="server" Width="130px"></asp:TextBox></td>
                                <td align="right">
                                    <asp:Label ID="lblCPF" runat="server" Text="CPF :" Width="40px" ></asp:Label>
                                </td>
                                <td align="left">
                                    <ajaxToolkit:MaskedEditExtender ID="meeCPF" runat="server" Mask="999,999,999-99"
                                    MessageValidatorTip="true" CultureName="pt-BR"
                                    TargetControlID="txtCPF" ClearMaskOnLostFocus="false"
                                    MaskType="None" InputDirection="LeftToRight" Enabled="true">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <asp:TextBox ID="txtCPF" runat="server" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblNCartaoSaude" runat="server" Text="Cartão Nacional de Saúde :"  ></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCNS" runat="server" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                     </td>

                    <td rowspan="2"align="center">
                            <fieldset class="fieldsetImagemPaciente">
                                <legend>Paciente</legend>
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
                <legend>Endereço(s):</legend>


                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    CssClass="ajax__tab_xp" Width="680">

                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Residencial">
                            <HeaderTemplate>
                                Residencial
                            </HeaderTemplate>
                            <ContentTemplate> 

                                <table >
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTpLogradouro" runat="server" Text="Tipo logradouro:"></asp:Label>
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
                                                <asp:Button ID="btnAddTelefoneResidencial" runat="server" Text="+" 
                                                    onclick="btnAddTelefoneResidencial_Click" />
                                            </td>
                                            <td>
                            
                                                <asp:TextBox ID="txtEmailResidencial" runat="server" Width="180px"></asp:TextBox>
                                                <asp:Button ID="btnAddEmailResidencial" runat="server" Text="+" />
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
                    </ajaxToolkit:TabContainer>
            </fieldset>
                        </td>
                        <td></td>
                    </tr>
                </table>


            <ajaxToolkit:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" 
            CssClass="ajax__tab_xp" Width="880">
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Informações">
                    <ContentTemplate> 
                    <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSexo" runat="server" Text="Sexo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCor" runat="server" Text="Cor:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblReligiao" runat="server" Text="Religião:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblProfissao" runat="server" Text="Profissão:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNascimento" runat="server" Text="Nascimento:"></asp:Label>
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
                                    <asp:DropDownList ID="ddlCor" runat="server" Height="22px" Width="130px">
                                        <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                        <asp:ListItem Value="1" >Branca</asp:ListItem>
                                        <asp:ListItem Value="2" >Negra</asp:ListItem>
                                        <asp:ListItem Value="2" >Parda</asp:ListItem>
                                        <asp:ListItem Value="2" >Amarela</asp:ListItem>
                                        <asp:ListItem Value="2" >Indígena</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReligiao" runat="server" Height="22px" Width="193px"></asp:DropDownList>
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
                            </tr>

                    </table>
                    <table>
                            <tr>
                                <td>
                                    
                                </td>
                                <td>
                                    <asp:Label ID="lblConvênio" runat="server" Text="Convênio:"></asp:Label>
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
                                    <asp:DropDownList ID="ddlConvenio" runat="server" Height="22px" Width="193px"></asp:DropDownList>
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