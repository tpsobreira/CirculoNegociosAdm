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
                            Imagem:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpImagensBanner" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnIncluir" runat="server" Text="Incluir" OnClick="btnIncluir_Click" />
                            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Visible="False" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvBanners" runat="server" OnRowCommand="gdvBanners_RowCommand"
                                Width="100%" AutoGenerateColumns="false">
                                <AlternatingRowStyle BackColor="#B4B3B3" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'>Editar</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeletar" runat="server" CommandName="Deletar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'>Deletar</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Literal ID="litId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"id") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID Tipo Banner">
                                        <ItemTemplate>
                                            <asp:Literal ID="litIdTipoBanner" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"idTipoBanner") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nome Cliente">
                                        <ItemTemplate>
                                            <asp:Literal ID="litNomeCliente" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"nomeCliente") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caminho Arquivo">
                                        <ItemTemplate>
                                            <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Inicio">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataInicio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataDe") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Fim">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataFim" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataAte") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Ultima Alteração">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataUltimaAlteracao" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DataUltimaAlteracao") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Responsavel Pela Ultima Alteração">
                                        <ItemTemplate>
                                            <asp:Literal ID="litResponsavel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"responsavelUltimaAlteracao") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ativo">
                                        <ItemTemplate>
                                            <asp:Literal ID="litAtivo" runat="server" Text='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Ativo")) == true ? "Sim" : "Não" %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
                            Imagens:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpImagensBannerPrincipal" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnIncluirBannerPrincipal" runat="server" Text="Incluir" OnClick="btnIncluirBannerPrincipal_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Alterar" Visible="False" />
                        </td>
                    </tr>
                </table>
                 <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvBannersPrincipal" runat="server" OnRowCommand="gdvBannersPrincipal_RowCommand"
                                Width="100%" AutoGenerateColumns="false">
                                <AlternatingRowStyle BackColor="#B4B3B3" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'>Editar</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeletar" runat="server" CommandName="Deletar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'>Deletar</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Literal ID="litId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"id") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Nome Cliente">
                                        <ItemTemplate>
                                            <asp:Literal ID="litNomeCliente" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"nomeCliente") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caminho Arquivo">
                                        <ItemTemplate>
                                            <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Inicio">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataInicio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataDe") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Fim">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataFim" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataAte") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Data Ultima Alteração">
                                        <ItemTemplate>
                                            <asp:Literal ID="litDataUltimaAlteracao" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DataUltimaAlteracao") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Responsavel Pela Ultima Alteração">
                                        <ItemTemplate>
                                            <asp:Literal ID="litResponsavel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"responsavelUltimaAlteracao") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ativo">
                                        <ItemTemplate>
                                            <asp:Literal ID="litAtivo" runat="server" Text='<%#Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Ativo")) == true ? "Sim" : "Não" %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
