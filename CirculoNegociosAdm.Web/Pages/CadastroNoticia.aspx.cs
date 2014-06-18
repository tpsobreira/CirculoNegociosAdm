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
        NoticiaBusiness noticiaBusiness = new NoticiaBusiness();
        CategoriaNoticiaBusiness categoriaNoticiaBusiness = new CategoriaNoticiaBusiness();
        EstadoBusiness estadoBusiness = new EstadoBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheCombos();
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                NoticiaEntity noticia = new NoticiaEntity();
                bool? ativo;

                noticia.titulo = txtTitulo.Text;
                noticia.Sinopse = txtSinopse.Text;
                noticia.Descricao = txtDescricao.Text;
                noticia.estado = ddlUF.SelectedValue;
                noticia.idCategoria = Convert.ToInt32(ddlCategoriaNoticia.SelectedValue);
                ativo = rdlAtiva.SelectedValue == "1" ? true : false;
                noticia.Ativo = ativo;
                noticia.dataHoraDe = Convert.ToDateTime(txtDataHoraDe.Text);
                noticia.dataHoraAte = Convert.ToDateTime(txtDataHoraAte.Text);

                int idNoticia = noticiaBusiness.InsereNoticia(noticia);

                if (idNoticia != 0 )
                {
                    Alert("Noticia incluida com sucesso");
                }

                CarregaGridView();
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

        private void CarregaGridView()
        {
            gdvNoticias.DataSource = noticiaBusiness.ConsultaTodosNoticias();
            gdvNoticias.DataBind();
        }

        protected void gdvNoticias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = noticiaBusiness.DeletaNoticia(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
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