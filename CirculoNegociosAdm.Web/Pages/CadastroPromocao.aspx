<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPromocao.aspx.cs" Inherits="CirculoNegociosAdm.Pages.CadastroPromocao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cadastro de Promoções
        <br />
        <br />
    </h2>
    <table>
        <tr>
            <td>
                Cliente:
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlCliente" runat="server" Width="250px">
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
                <asp:FileUpload ID="FileUpImagemPromocao" runat="server" Width="250px" />
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraDe" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txtDataHoraAte" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnIncluirPromocao" runat="server" Text="Incluir" 
                    onclick="btnIncluirPromocao_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                    onclick="btnCancelar_Click"  />
                <asp:Button ID="BtnAlterarPromocao" runat="server" Text="Alterar" 
                    Visible="False" onclick="BtnAlterarPromocao_Click"  />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="gdvPromocoes" runat="server" OnRowCommand="gdvPromocoes_RowCommand"
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
                                <asp:Literal ID="litCaminhoArquivo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Substring(DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Banners"), DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().Length - DataBinder.Eval(Container.DataItem,"imagemFilePath").ToString().LastIndexOf("Banners")) %>'></asp:Literal>
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
