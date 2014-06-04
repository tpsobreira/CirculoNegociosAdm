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
    public partial class CadastroCategoriaNoticia : System.Web.UI.Page
    {
        CategoriaNoticiaBusiness categoriaNoticiaBusiness = new CategoriaNoticiaBusiness();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            CategoriaNoticiaEntity objCategoriaNoticia = new CategoriaNoticiaEntity();

            objCategoriaNoticia.Nome = txtNome.Text;
            objCategoriaNoticia.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objCategoriaNoticia.DataUltimaAlteracao = DateTime.Now;

            string retorno = string.Empty;

            retorno = categoriaNoticiaBusiness.InsereNoticia(objCategoriaNoticia);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();
        }

        private void CarregaGridView()
        {
            gdvCategoriasNoticia.DataSource = categoriaNoticiaBusiness.ConsultaTodasCategoriasNoticia();
            gdvCategoriasNoticia.DataBind();

        }

        protected void gdvCategoriasNoticia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = categoriaNoticiaBusiness.DeletaCategoriaNoticia(Convert.ToInt32(e.CommandArgument));

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