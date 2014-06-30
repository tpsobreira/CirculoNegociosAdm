using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;
using System.Web.Security;
using System.IO;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroOferta : System.Web.UI.Page
    {
        OfertaBusiness ofertaBusiness = new OfertaBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheCombos();
                CarregaGridView();
            }
        }

        protected void btnIncluirOferta_Click(object sender, EventArgs e)
        {
            OfertaEntity objOferta = new OfertaEntity();
            bool? ativo;

            objOferta.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraAte.Text).ToString("s"));
            objOferta.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraDe.Text).ToString("s"));
            objOferta.dataUltimaAlteracao = DateTime.Now;
            objOferta.titulo = txtTitulo.Text;
            objOferta.descricao = txtDescricao.Text;
            objOferta.idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            objOferta.link = txtLinkDestino.Text;
            objOferta.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objOferta.estado = ddlEstado.SelectedValue;
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            objOferta.Ativo = ativo;

            int idOferta = ofertaBusiness.InsereOferta(objOferta);

            if (FileUpImagemOferta.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/Ofertas/" + idOferta)))
                    Directory.CreateDirectory(Server.MapPath(@"~/Ofertas/" + idOferta));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/Ofertas/" + idOferta));
                    Directory.CreateDirectory(Server.MapPath(@"~/Ofertas/" + idOferta));
                }

                string caminhoArquivo = Server.MapPath(@"~/Ofertas/" + idOferta) + @"\" + FileUpImagemOferta.FileName;
                FileUpImagemOferta.SaveAs(caminhoArquivo);

                ofertaBusiness.AtualizaFilePathImagemOferta(idOferta, caminhoArquivo);

            }
            else
            {
                ofertaBusiness.DeletaOferta(idOferta);
                idOferta = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idOferta != 0)
            {
                Alert("Oferta incluida com sucesso!");
                CarregaGridView();
                RestauraControles();
            }
            else
                Alert("Ocorreu um erro ao incluir a Oferta!");
           

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlterarOferta_Click(object sender, EventArgs e)
        {

        }

        private void RestauraControles()
        {
            txtDataHoraAte.Text = string.Empty;
            txtDataHoraDe.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtLinkDestino.Text = string.Empty;
            txtTitulo.Text = string.Empty;

            ddlCliente.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;
        }

        private void PreencheCombos()
        {
            ddlCliente.DataSource = new ClientesBusiness().ConsultaTodosClientes();
            ddlCliente.DataValueField = "id";
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, "Selecionar...");

            ddlEstado.DataSource = new EstadoBusiness().ConsultaTodosEstados();
            ddlEstado.DataValueField = "sigla";
            ddlEstado.DataTextField = "Nome";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, "Selecionar...");
        }

        private void CarregaGridView()
        {
            gdvOfertas.DataSource = ofertaBusiness.ConsultaTodasOfertas();
            gdvOfertas.DataBind();
        }

        protected void gdvOfertas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = ofertaBusiness.DeletaOferta(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }
    }
}