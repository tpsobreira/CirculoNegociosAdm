using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroPromocao : System.Web.UI.Page
    {
        PromocaoBusiness promocaoBusiness = new PromocaoBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
                PreencheCombos();
            }
        }

        protected void gdvPromocoes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = promocaoBusiness.DeletaPromocao(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
        }

        private void CarregaGridView()
        {
            gdvPromocoes.DataSource = promocaoBusiness.ConsultaTodasPromocoes();
            gdvPromocoes.DataBind();
        }

        private void PreencheCombos()
        {
            ddlCliente.DataSource = new ClientesBusiness().ConsultaTodosClientes();
            ddlCliente.DataValueField = "id";
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, "Selecionar...");
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        protected void btnIncluirPromocao_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlterarPromocao_Click(object sender, EventArgs e)
        {

        }
    }
}