<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroSubCategoriaCliente.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroSubCategoriaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        Cadastro de Sub-Categoria de Cliente
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Categoria Pai:
            </td>
            <td>
                Nome Sub-Categoria:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtNomeSubCategoria" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" 
                    onclick="btnIncluir_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                    onclick="btnCancelar_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Visible="false" 
                    onclick="btnAlterar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
