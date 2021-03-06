﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroCliente.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroCliente"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Cliente
        <br />
        <br />
    </h2>
    <table>
        <asp:HiddenField ID="hdIdClienteEdit" runat="server" />
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
                <asp:LinkButton ID="lnkCep" runat="server" OnClick="lnkCep_Click">Pesquisa CEP</asp:LinkButton>
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
                Latitude:
            </td>
            <td>
                Longitude:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtLatitude" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtLongitude" runat="server" Width="300px"></asp:TextBox>
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
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="300px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Sub-Categoria:
            </td>
            <td>
                Plano:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlSubCategoria" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlPlanos" runat="server" Width="300px">
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
                Sábado:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtHoraSabDe" runat="server" Width="80px"></asp:TextBox>até<asp:TextBox
                    ID="txtHoraSabAte" runat="server" Width="80px"></asp:TextBox><asp:CheckBox ID="chkSabado"
                        runat="server" Text="Não Abre" />
                <br />
                Domingo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtHoraDomingoDe" runat="server" Width="80px"></asp:TextBox>até<asp:TextBox
                    ID="txtHoraDomingoAte" runat="server" Width="80px"></asp:TextBox><asp:CheckBox ID="chkDomingo"
                        runat="server" Text="Não Abre" />
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
            <td>
                Logotipo:
            </td>
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
                <asp:FileUpload ID="FileUpLogo" runat="server" />
                <asp:HiddenField ID="hdLogoEdit" runat="server" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpImg1" runat="server" />
                <asp:HiddenField ID="hdImg1Edit" runat="server" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpImg2" runat="server" />
                <asp:HiddenField ID="hdImg2Edit" runat="server" />
            </td>
            <td>
                <asp:FileUpload ID="FileUpImg3" runat="server" />
                <asp:HiddenField ID="hdImg3Edit" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnIncluir" runat="server" Text="Concluir" OnClick="btnIncluir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlterar_Click"
                    Visible="false" />
                &nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
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
                                <asp:LinkButton ID="lnkDeletar" runat="server" CommandName="Deletar" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="return confirm('Deseja Mesmo Deletar o Cliente');">Deletar</asp:LinkButton>
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
