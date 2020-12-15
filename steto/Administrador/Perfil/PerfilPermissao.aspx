<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/StetoAdm.Master" AutoEventWireup="true" CodeBehind="PerfilPermissao.aspx.cs" Inherits="Steto.Administrador.Perfil.PerfilPermissao" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script type="text/javascript">


    function OnTreeClick(evt) {
        var src = window.event != window.undefined ? window.event.srcElement : evt.target;
        var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
        if (isChkBoxClick) {
            var parentTable = GetParentByTagName("table", src);
            var nxtSibling = parentTable.nextSibling;
            if (nxtSibling && nxtSibling.nodeType == 1)//check if nxt sibling is not null & is an element node
            {
                if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                {
                    //check or uncheck children at all levels
                    CheckUncheckChildren(parentTable.nextSibling, src.checked);
                }
            }
            //check or uncheck parents at all levels
            CheckUncheckParents(src, src.checked);
        }
    }

    function CheckUncheckChildren(childContainer, check) {
        var childChkBoxes = childContainer.getElementsByTagName("input");
        var childChkBoxCount = childChkBoxes.length;
        for (var i = 0; i < childChkBoxCount; i++) {    
            childChkBoxes[i].checked = check;
        }
    }

    function CheckUncheckParents(srcChild, check) {
        var parentDiv = GetParentByTagName("div", srcChild);
        var parentNodeTable = parentDiv.previousSibling;

        if (parentNodeTable) {
            var checkUncheckSwitch;

            if (check) //checkbox checked
            {
                var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                if (isAllSiblingsChecked)
                    checkUncheckSwitch = true;
                else
                    return; //do not need to check parent if any child is not checked
            }
            else //checkbox unchecked
            {
                checkUncheckSwitch = false;
            }

            var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
            if (inpElemsInParentTable.length > 0) {
                var parentNodeChkBox = inpElemsInParentTable[0];
                parentNodeChkBox.checked = checkUncheckSwitch;
                //do the same recursively
                CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
            }
        }
    }

    function AreAllSiblingsChecked(chkBox) {
        var parentDiv = GetParentByTagName("div", chkBox);
        var childCount = parentDiv.childNodes.length;
        for (var i = 0; i < childCount; i++) {
            if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
            {
                if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                    var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                    //if any of sibling nodes are not checked, return false
                    if (!prevChkBox.checked) {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    //utility function to get the container of an element by tagname
    function GetParentByTagName(parentTagName, childElementObj) {
        var parent = childElementObj.parentNode;
        while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
            parent = parent.parentNode;
        }
        return parent;
    }
   </script>



        <div>
            <h2>
                Delegar permissões ao perfil
            </h2>
        </div>
        <div class="submitButtonUsuarioCenter">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <fieldset class="fieldsetPesquisa">
            <div class="submitButtonUsuario2">
                <asp:Label ID="Label1" runat="server" Text="Perfil: "></asp:Label>&nbsp
                <asp:DropDownList ID="ddlPerfil" runat="server" Width="300px" 
                    AutoPostBack="True" onselectedindexchanged="ddlPerfil_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnSalvar" runat="server" Text="Salvar" Width="88px" 
                    onclick="btnSalvar_Click"/>
            </div>
        </fieldset>
        <fieldset class="fieldsetPesquisa">
            <legend>Selecione as permissões</legend>
            <div class="submitButtonUsuario2"> 
                <asp:TreeView  
                    
                        ID="Tree"  
                        runat="server"  
                        ExpandDepth="0" 
                        ShowLines="True" ShowCheckBoxes="All"> 
                </asp:TreeView>          
            </div> 
        </fieldset>
</asp:Content>
