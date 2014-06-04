<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroNoticia.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroNoticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Noticia
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Categoria da Noticia:
            </td>
            <td>
                Estado:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCategoriaNoticia" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlUF" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Titulo:
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtTitulo" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Sinopse:
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtSinopse" runat="server" TextMode="MultiLine" Width="600px" Height="70px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Descrição:
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" Width="600px"
                    Height="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Data e Hora Incial:
            </td>
            <td>
                Data e Hora Final:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDataHoraDe" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraAte" runat="server" Width="300px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                Ativa:
            </td>
        </tr>
        <tr>
        <td valign="top">
                <asp:RadioButtonList ID="rdlAtiva" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Não" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            </tr>
        
        <tr>
            <td>
                Imagens:
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fileUpImagens" runat="server" Width="300px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir Noticia" 
                    onclick="btnIncluir_Click" />
            </td>
            
        </tr>
    </table>
</asp:Content>
