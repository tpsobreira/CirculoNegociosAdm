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
    public partial class CadastroCategoriaCliente : System.Web.UI.Page
    {
        CategoriaClienteBusiness categoriaClienteBusiness = new CategoriaClienteBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            CategoriaClienteEntity objCategoriaCliente = new CategoriaClienteEntity();
                
            objCategoriaCliente.Nome = txtNome.Text;
            objCategoriaCliente.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objCategoriaCliente.DataUltimaAlteracao = DateTime.Now;

            string retorno = string.Empty;

            retorno = categoriaClienteBusiness.InsereCliente(objCategoriaCliente);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();
        }

        private void CarregaGridView()
        {
            gdvCategoriasCliente.DataSource = categoriaClienteBusiness.ConsultaTodasCategoriasCliente();
            gdvCategoriasCliente.DataBind();

        }

        protected void gdvCategoriasCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = categoriaClienteBusiness.DeletaCategoriaCliente(Convert.ToInt32(e.CommandArgument));

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
            txtNome.Text = string.Empty;
        }
    }
}