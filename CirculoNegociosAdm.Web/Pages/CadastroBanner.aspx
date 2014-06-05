<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroBanner.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroBanner" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Banners
        <br />
        <br />
    </h2>
    <ajaxToolkit:TabContainer ID="Abas" runat="server">
        <ajaxToolkit:TabPanel ID="AbaBanner" runat="server" HeaderText="Cadastro Banner">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            Tipo de Banner:
                        </td>
                        <td>
                            Cliente:
                        </td>
                        <td>
                            Estado:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlTipoBanner" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCliente" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data/Hora Inicial:
                        </td>
                        <td>
                            Data/Hora Final:
                        </td>
                        <td>
                            Ativo:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDataHoraInicial" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataHoraFinal" runat="server"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:RadioButtonList ID="rdlAtivo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Não" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnIncluir" runat="server" Text="Incluir" 
                                onclick="btnIncluir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Visible="False" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="AbaBannerPrincipal" runat="server" HeaderText="Cadastro Banner Principal">
            <ContentTemplate>
                <table>
                    <tr>
                        
                        <td>
                            Cliente:
                        </td>
                        <td>
                            Estado:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlClienteBannerPrincipal" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoBannerPrincipal" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data/Hora Inicial:
                        </td>
                        <td>
                            Data/Hora Final:
                        </td>
                        <td>
                            Ativo:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDataHoraInicialBannerPrincipal" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataHoraFinalBannerPrincipal" runat="server"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:RadioButtonList ID="rdlAtivoBannerPrincipal" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Não" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnIncluirBannerPrincipal" runat="server" Text="Incluir" 
                                onclick="btnIncluirBannerPrincipal_Click" />
                <asp:Button ID="Button2" runat="server" Text="Alterar" Visible="False" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
