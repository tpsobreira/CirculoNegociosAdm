using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;
using System.IO;

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
                noticia.dataHoraAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraAte.Text).ToString("s"));
                noticia.dataHoraDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraDe.Text).ToString("s"));

                int idNoticia = noticiaBusiness.InsereNoticia(noticia);

                SalvaImagens(idNoticia);


                if (idNoticia != 0)
                {
                    Alert("Noticia incluida com sucesso");
                }

                CarregaGridView();
                RestauraControles();
            }
            else
            {
                Alert("É obrigatório preencher todos os campos!");
            }

        }

        private void SalvaImagens(int idNoticia)
        {
            string caminhoHome = string.Empty;
            string caminhoImg1 = string.Empty;
            string caminhoImg2 = string.Empty;
            string caminhoImg3 = string.Empty;


            if (fileUpImagemHome.HasFile && FileUpImagem1.HasFile && FileUpImagem2.HasFile && FileUpImagem3.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/HomeNoticia/" + idNoticia)))
                    Directory.CreateDirectory(Server.MapPath(@"~/HomeNoticia/" + idNoticia));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/HomeNoticia/" + idNoticia));
                    Directory.CreateDirectory(Server.MapPath(@"~/HomeNoticia/" + idNoticia));
                }

                caminhoHome = Server.MapPath(@"~/HomeNoticia/" + idNoticia) + @"\" + fileUpImagemHome.FileName;
                fileUpImagemHome.SaveAs(caminhoHome);

                if (!Directory.Exists(Server.MapPath(@"~/Noticias/" + idNoticia)))
                    Directory.CreateDirectory(Server.MapPath(@"~/Noticias/" + idNoticia));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/Noticias/" + idNoticia));
                    Directory.CreateDirectory(Server.MapPath(@"~/Noticias/" + idNoticia));
                }

                caminhoImg1 = Server.MapPath(@"~/Noticias/" + idNoticia) + @"\" + FileUpImagem1.FileName;
                caminhoImg2 = Server.MapPath(@"~/Noticias/" + idNoticia) + @"\" + FileUpImagem2.FileName;
                caminhoImg3 = Server.MapPath(@"~/Noticias/" + idNoticia) + @"\" + FileUpImagem3.FileName;

                FileUpImagem1.SaveAs(caminhoImg1);
                FileUpImagem2.SaveAs(caminhoImg2);
                FileUpImagem3.SaveAs(caminhoImg3);

                noticiaBusiness.AtualizaImagensNoticia(idNoticia, caminhoHome, caminhoImg1, caminhoImg2, caminhoImg3);

            }
            else
            {
                Alert("É obrigatório selecionar todas as imagens, se não tiver 3 imagens diferentes, pode colocar a mesma imagem, apenas mudando o nome do arquivo!");
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
            txtDataHoraAte.Text = string.Empty;
            txtDataHoraDe.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtSinopse.Text = string.Empty;
            txtTitulo.Text = string.Empty;
        }
    }
}