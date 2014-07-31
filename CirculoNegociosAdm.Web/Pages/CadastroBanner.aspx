<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroBanner.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroBanner" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function DataHora(evento, objeto) {
            var keypress = (window.event) ? event.keyCode : evento.which;
            campo = eval(objeto);
            if (campo.value == '00/00/0000 00:00:00') {
                campo.value = ""
            }

            caracteres = '0123456789';
            separacao1 = '-';
            separacao2 = ' ';
            separacao3 = ':';
            conjunto1 = 4;
            conjunto2 = 7;
            conjunto3 = 10;
            conjunto4 = 13;
            conjunto5 = 16;
//            conjunto1 = 4;
//            conjunto2 = 7;
//            conjunto3 = 10;
//            conjunto4 = 13;
//            conjunto5 = 16;
            if ((caracteres.search(String.fromCharCode(keypress)) != -1) && campo.value.length < (19)) {
                if (campo.value.length == conjunto1)
                    campo.value = campo.value + separacao1;
                else if (campo.value.length == conjunto2)
                    campo.value = campo.value + separacao1;
                else if (campo.value.length == conjunto3)
                    campo.value = campo.value + separacao2;
                else if (campo.value.length == conjunto4)
                    campo.value = campo.value + separacao3;
                else if (campo.value.length == conjunto5)
                    campo.value = campo.value + separacao3;
            }
            else
                event.returnValue = false;
        }
    </script>
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
                            <asp:TextBox ID="txtDataHoraInicial" onKeyPress="DataHora(event, this)" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataHoraFinal" onKeyPress="DataHora(event, this)" runat="server"></asp:TextBox>
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
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:Button ID="btnIncluir" runat="server" Text="Incluir" OnClick="btnIncluir_Click"
                                OnClientClick="document.getElementById('hiddenField1').value = document.getElementById('FileUpImagensBanner').value" />
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
                                            <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Substring(DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Banners"), DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Length - DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Banners")) %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UF">
                                        <ItemTemplate>
                                            <asp:Literal ID="litEstado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"estado") %>'></asp:Literal>
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
                            Descricao:
                        </td>
                        <td>
                            Texto Rodape 1:
                        </td>
                        <td>
                            Texto Rodape 2:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtDescricaoBannerPrincipal" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTextoRodape1BannerPrincial" runat="server" Width="250px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTextoRodape2BannerPrincial" runat="server" Width="250px"></asp:TextBox>
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
                            <asp:TextBox ID="txtDataHoraInicialBannerPrincipal" onKeyPress="DataHora(event, this)"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataHoraFinalBannerPrincipal" onKeyPress="DataHora(event, this)"
                                runat="server"></asp:TextBox>
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
                                            <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Substring(DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("BannerPrincipal"), DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Length - DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("BannerPrincipal")) %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UF">
                                        <ItemTemplate>
                                            <asp:Literal ID="litEstado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"estado") %>'></asp:Literal>
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
        <ajaxToolkit:TabPanel ID="AbaBannerBusca" runat="server" HeaderText="Cadastro Banner Busca">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            Categoria:
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
                            <asp:DropDownList ID="ddlCategoriaBannerBusca" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlClienteBannerBusca" runat="server" Width="250px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoBannerBusca" runat="server" Width="250px">
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
                            <asp:TextBox ID="txtDataHoraInicialBannerBusca" onKeyPress="DataHora(event, this)"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataHoraFinalBannerBusca" onKeyPress="DataHora(event, this)"
                                runat="server"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:RadioButtonList ID="rdlAtivoBannerBusca" runat="server" RepeatDirection="Horizontal">
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
                            <asp:FileUpload ID="FileUpBannerBusca" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnIncluirBannerBusca" runat="server" Text="Incluir" OnClick="btnIncluirBannerBusca_Click" />
                            <asp:Button ID="btnAlterarBannerBusca" runat="server" Text="Alterar" Visible="False" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gdvBannersBusca" runat="server" OnRowCommand="gdvBannersBusca_RowCommand"
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
                                    <asp:TemplateField HeaderText="Categoria">
                                        <ItemTemplate>
                                            <asp:Literal ID="litCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"nomeCategoria") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UF">
                                        <ItemTemplate>
                                            <asp:Literal ID="litEstado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"estado") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nome Cliente">
                                        <ItemTemplate>
                                            <asp:Literal ID="litNomeCliente" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"nomeCliente") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caminho Arquivo">
                                        <ItemTemplate>
                                            <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Substring(DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("BannerBusca"), DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Length - DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("BannerBusca")) %>'></asp:Literal>
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
