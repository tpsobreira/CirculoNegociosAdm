<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCliente.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Cliente
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Razão Social:
            </td>
            <td>
                Nome Fantasia:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtRazaoSocial" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtNomeFantasia" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Nome:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNome" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td>
                Cpf ou Cnpj:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCpfCnpj" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Inscrição Estadual:
            </td>
            <td>
                Responsável:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtIncricaoEstadual" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtResponsavel" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                CEP:
            </td>
            <td>
                Endereço:
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCep" runat="server" Width="220px"></asp:TextBox>
                <asp:LinkButton
                    ID="lnkCep" runat="server" onclick="lnkCep_Click">Pesquisa CEP</asp:LinkButton>
            </td>
            <td>
                <asp:TextBox ID="txtEndereco" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Bairro:
            </td>
            <td>
                Cidade:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtBairro" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtCidade" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Estado:
            </td>
            <td>
                Complemento:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEstado" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtComplemento" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Telefone 1:
            </td>
            <td>
                Telefone 2:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtTelefone1" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtTelefone2" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Site:
            </td>
            <td>
                Categoria:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtSite" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Sub-Categoria:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSubCategoria" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Serviços:
            </td>
            <td>
                Funcionamento:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtServicos" TextMode="MultiLine" runat="server" Width="300px" Height="100px"></asp:TextBox>
            </td>
            <td>
                Segunda à Sexta&nbsp;
                <asp:TextBox ID="txtHoraSemanaDe" runat="server" Width="80px"></asp:TextBox>até<asp:TextBox
                    ID="txtHoraSemanaAte" runat="server" Width="80px"></asp:TextBox>
                <br />
                Finais de Semana
                <asp:TextBox ID="txtHoraFdsDe" runat="server" Width="80px"></asp:TextBox>até<asp:TextBox
                    ID="txtHoraFdsAte" runat="server" Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Observações:
            </td>
            <td>
                Ativo:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtObservacoes" TextMode="MultiLine" runat="server" Width="300px"
                    Height="100px"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RadioButtonList ID="rdlAtivo" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Não" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnConcluir" runat="server" Text="Concluir" OnClick="btnConcluir_Click" />
                &nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            </td>
        </tr>
    </table>
    <table width="98%">
        <tr>
            <td>
                <asp:GridView ID="gdvClientes" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowCommand="gdvClientes_RowCommand">
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
                        <asp:TemplateField HeaderText="Nome PF">
                            <ItemTemplate>
                                <asp:Literal ID="litNome" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"nome") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Razão Social">
                            <ItemTemplate>
                                <asp:Literal ID="litRazaoSocial" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"razaoSocial") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Literal ID="litEmail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"email") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contato Responsável">
                            <ItemTemplate>
                                <asp:Literal ID="litContato" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"contatoResponsavel") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Endereço">
                            <ItemTemplate>
                                <asp:Literal ID="litEndereco" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"endereco") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cidade">
                            <ItemTemplate>
                                <asp:Literal ID="litCidade" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"cidade") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UF">
                            <ItemTemplate>
                                <asp:Literal ID="litEstado" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"estado") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefone 1">
                            <ItemTemplate>
                                <asp:Literal ID="litTelefone1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"telefone1") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefone 2">
                            <ItemTemplate>
                                <asp:Literal ID="litTelefone2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"telefone2") %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ativo">
                            <ItemTemplate>
                                <asp:Literal ID="litAtivo" runat="server" Text='<%#Convert.ToInt32(DataBinder.Eval(Container.DataItem,"ativo")) == 1 ? "Ativo" : "Inativo" %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
