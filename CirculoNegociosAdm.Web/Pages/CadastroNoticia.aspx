<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroNoticia.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroNoticia" %>

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
                <asp:TextBox ID="txtDataHoraDe" onKeyPress="DataHora(event, this)" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraAte" onKeyPress="DataHora(event, this)" runat="server" Width="300px"></asp:TextBox>
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
                Imagem Home:
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fileUpImagemHome" runat="server" Width="300px" />
            </td>
        </tr>
        <tr>
            <td>
                Imagem 1:
            </td>
            <td>
                Imagem 2:
            </td>
            <td>
                Imagem 3:
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="FileUpImagem1" runat="server" />   
            </td>
            <td>
                <asp:FileUpload ID="FileUpImagem2" runat="server" />   
            </td>
            <td>
                <asp:FileUpload ID="FileUpImagem3" runat="server" />   
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir Noticia" OnClick="btnIncluir_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gdvNoticias" runat="server" OnRowCommand="gdvNoticias_RowCommand"
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
                        <asp:TemplateField HeaderText="Titulo">
                            <ItemTemplate>
                                <asp:Literal ID="litTitulo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"titulo") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sinopse">
                            <ItemTemplate>
                                <asp:Literal ID="litSinopse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sinopse") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Literal ID="litEstado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"estado") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Categoria">
                            <ItemTemplate>
                                <asp:Literal ID="litIdCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"idCategoria") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data Inicio">
                            <ItemTemplate>
                                <asp:Literal ID="litDataInicio" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataHoraDe") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data Fim">
                            <ItemTemplate>
                                <asp:Literal ID="litDataFim" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dataHoraAte") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Data Ultima Alteração">
                            <ItemTemplate>
                                <asp:Literal ID="litDataUltimaAlteracao" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DataUltimaAlteracao") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responsavel Pela Ultima Alteração">
                            <ItemTemplate>
                                <asp:Literal ID="litResponsavel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"responsavelUltimaAlteracao") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
</asp:Content>
