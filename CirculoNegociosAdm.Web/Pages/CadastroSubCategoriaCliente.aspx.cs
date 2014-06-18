using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;
using System.Web.Security;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroSubCategoriaCliente : System.Web.UI.Page
    {
        SubCategoriaClienteBusiness categoriaClienteBusiness = new SubCategoriaClienteBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
                PreencheCombo();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            SubCategoriaClienteEntity objSubCategoriaCliente = new SubCategoriaClienteEntity();

            objSubCategoriaCliente.Nome = txtNomeSubCategoria.Text;
            objSubCategoriaCliente.idCategoria = Convert.ToInt32(ddlCategoria.SelectedValue);
            objSubCategoriaCliente.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objSubCategoriaCliente.DataUltimaAlteracao = DateTime.Now;

            string retorno = string.Empty;

            retorno = categoriaClienteBusiness.InsereSubCategoriaCliente(objSubCategoriaCliente);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();
        }

        private void CarregaGridView()
        {
            gdvSubCategoriasCliente.DataSource = categoriaClienteBusiness.ConsultaTodasSubCategoriasCliente();
            gdvSubCategoriasCliente.DataBind();

        }

        private void PreencheCombo()
        {
            ddlCategoria.DataSource = new CategoriaClienteBusiness().ConsultaTodasCategoriasCliente();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "Nome";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "Selecionar...");
        }

        protected void gdvSubCategoriasCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = categoriaClienteBusiness.DeletaSubCategoriaCliente(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);
                CarregaGridView();
            }
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        private void RestauraControles()
        {
            txtNomeSubCategoria.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {

        }
    }
}