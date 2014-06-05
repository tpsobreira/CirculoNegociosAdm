<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastrosAuxiliares.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastrosAuxiliares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastros Auxiliares
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                <a href="CadastroCategoriaCliente.aspx">Cadastro de Categoria de Cliente</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="CadastroCategoriaNoticia.aspx">Cadastro de Categoria de Noticia</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="CadastroTipoBanner.aspx">Cadastro de Tipo de Banner</a>
            </td>
        </tr>

        <tr>
            <td>
                <a href="CadastroEstado.aspx">Cadastro de Estados</a>
            </td>
        </tr>

    </table>
</asp:Content>
