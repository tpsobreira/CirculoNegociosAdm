using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        ClientesBusiness clienteBusiness = new ClientesBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
                PreencheCombos();
            }
        }

        private void CarregaGridView()
        {
            gdvClientes.DataSource = clienteBusiness.ConsultaTodosClientes();
            gdvClientes.DataBind();
        }

        protected void btnConcluir_Click(object sender, EventArgs e)
        {
            ClienteEntity objCliente = new ClienteEntity();
            bool? ativo = false;

            objCliente.anexoImagem1Path = "";
            objCliente.anexoImagem2Path = "";
            objCliente.anexoImagem3Path = "";
            objCliente.anexoLogoPath = "";
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            objCliente.ativo = ativo;
            objCliente.cep = txtCep.Text;
            objCliente.cidade = txtCidade.Text;
            objCliente.complemento = txtComplemento.Text;
            objCliente.contatoResponsavel = txtResponsavel.Text;
            objCliente.cpfCnpj = txtCpfCnpj.Text;
            objCliente.email = txtEmail.Text;
            objCliente.endereco = txtEndereco.Text;
            objCliente.estado = txtEstado.Text;
            objCliente.Funcionamento = string.Format("Util: {0} as {1} | Final: {2} as {3}", txtHoraSemanaDe.Text, txtHoraSemanaAte.Text, txtHoraFdsDe.Text, txtHoraFdsAte.Text);
            objCliente.idCategoriaCliente = Convert.ToInt32(ddlCategoria.SelectedValue);
            objCliente.inscricaoEstadual = txtIncricaoEstadual.Text;
            objCliente.nome = txtNome.Text;
            objCliente.nomeFantasia = txtNomeFantasia.Text;
            objCliente.observacoes = txtObservacoes.Text;
            objCliente.razaoSocial = txtRazaoSocial.Text;
            objCliente.servicos = txtServicos.Text;
            objCliente.site = txtSite.Text;
            objCliente.telefone1 = txtTelefone1.Text;
            objCliente.telefone2 = txtTelefone2.Text;

            string retorno = clienteBusiness.InsereCliente(objCliente);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();

        }

        protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = clienteBusiness.DeletaCliente(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        
        protected void lnkCep_Click(object sender, EventArgs e)
        {
            LogradouroBusiness logradouroBusiness = new LogradouroBusiness();

            var logradouroInfo = logradouroBusiness.ConsultaCep(txtCep.Text);

            txtEndereco.Text = logradouroInfo.endereco;
            txtCidade.Text = logradouroInfo.cidade;
            txtEstado.Text = logradouroInfo.uf;
            txtBairro.Text = logradouroInfo.bairro;

        }

        private void RestauraControles()
        {
            txtNome.Text = string.Empty;
        }

        private void PreencheCombos()
        {
            ddlCategoria.DataSource = new CategoriaClienteBusiness().ConsultaTodasCategoriasCliente();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataValueField = "Nome";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "Selecione...");

        }
    }
}