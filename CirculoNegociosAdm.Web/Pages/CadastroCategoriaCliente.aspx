<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCategoriaCliente.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroCategoriaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Categoria Cliente
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Nome:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNome" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" OnClick="btnIncluir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Visible="false" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gdvCategoriasCliente" runat="server" OnRowCommand="gdvCategoriasCliente_RowCommand"
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
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Literal ID="litNome" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Nome") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data da Ultima Alteração">
                            <ItemTemplate>
                                <asp:Literal ID="litData" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"DataUltimaAlteracao") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responsavel Pela Ultima Alteração">
                            <ItemTemplate>
                                <asp:Literal ID="litResponsavel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"responsavelUltimaAlteracao") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
