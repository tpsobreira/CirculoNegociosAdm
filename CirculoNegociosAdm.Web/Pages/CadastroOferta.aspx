<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroOferta.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroOferta" %>

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
        Cadastro de Ofertas
        <br />
        <br />
    </h2>
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
                Titulo:
            </td>
             <td>
                Link de Destino:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtLinkDestino" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Descricão:
            </td>
           
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtDescricao" runat="server" Width="500px" TextMode="MultiLine" Height="190px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                Imagem:
            </td>
            <td>
                Data Hora De:
            </td>
            <td>
                Data Hora Até:
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="FileUpImagemOferta" runat="server" Width="250px" />
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraDe" onKeyPress="DataHora(event, this)" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraAte" onKeyPress="DataHora(event, this)" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ativo:
            </td>
        </tr>
        <tr>
            <td>
                <td valign="top">
                            <asp:RadioButtonList ID="rdlAtivo" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Não" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnIncluirOferta" runat="server" Text="Incluir" OnClick="btnIncluirOferta_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="BtnAlterarOferta" runat="server" Text="Alterar" Visible="False" OnClick="BtnAlterarOferta_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gdvOfertas" runat="server" OnRowCommand="gdvOfertas_RowCommand"
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
                        <asp:TemplateField HeaderText="Titulo">
                            <ItemTemplate>
                                <asp:Literal ID="litTitulo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"titulo") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Caminho Arquivo">
                            <ItemTemplate>
                                <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Substring(DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Ofertas"), DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Length - DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Ofertas")) %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link Destino">
                            <ItemTemplate>
                                <asp:Literal ID="litLinkDestino" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"link") %>'></asp:Literal>
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
</asp:Content>
