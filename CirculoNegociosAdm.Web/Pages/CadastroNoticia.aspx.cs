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
    public partial class CadastroNoticia : System.Web.UI.Page
    {
        CategoriaNoticiaBusiness categoriaNoticiaBusiness = new CategoriaNoticiaBusiness();
        EstadoBusiness estadoBusiness = new EstadoBusiness();
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                
            }
            else
            {
                Alert("É obrigatório preencher todos os campos!");
            }

        }

        private void PreencheCombos()
        {
            ddlCategoriaNoticia.DataSource = categoriaNoticiaBusiness.ConsultaTodasCategoriasNoticia();
            ddlCategoriaNoticia.DataValueField = "id";
            ddlCategoriaNoticia.DataTextField = "Nome";
            ddlCategoriaNoticia.DataBind();
            ddlCategoriaNoticia.Items.Insert(0, "Selecionar...");

            ddlUF.DataSource = estadoBusiness.ConsultaTodosEstados();
            ddlUF.DataValueField = "sigla";
            ddlUF.DataTextField = "Nome";
            ddlUF.DataBind();
            ddlUF.Items.Insert(0, "Selecionar...");
        }

        private bool ValidaCampos()
        {
            if (ddlCategoriaNoticia.SelectedValue != "Selecionar..." && ddlUF.SelectedValue != "Selecionar" && !string.IsNullOrEmpty(txtDataHoraAte.Text) &&
                !string.IsNullOrEmpty(txtDataHoraDe.Text) && !string.IsNullOrEmpty(txtDescricao.Text) && !string.IsNullOrEmpty(txtSinopse.Text) &&
                !string.IsNullOrEmpty(txtTitulo.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        private void RestauraControles()
        {
            txtTitulo.Text = string.Empty;
        }
    }
}