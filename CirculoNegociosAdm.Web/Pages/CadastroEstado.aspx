<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroEstado.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Estados
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Sigla:
            </td>
            <td>
                Nome:
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtSigla" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" 
                    onclick="btnIncluir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Visible="false" />
            </td>
        </tr>
    </table>

     <table>
        <tr>
            <td>
            <br />
                <asp:GridView ID="gdvEstados" runat="server" OnRowCommand="gdvEstados_RowCommand"
                    Width="100%" AutoGenerateColumns="false">
                    <AlternatingRowStyle BackColor="#B4B3B3" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"sigla") %>'>Editar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDeletar" runat="server" CommandName="Deletar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"sigla") %>'>Deletar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sigla">
                            <ItemTemplate>
                                <asp:Literal ID="litSigla" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"sigla") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nome">
                            <ItemTemplate>
                                <asp:Literal ID="litNome" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Nome") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
