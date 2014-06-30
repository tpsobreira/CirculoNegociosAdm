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

            ddlEstado.DataSource = new EstadoBusiness().ConsultaTodosEstados();
            ddlEstado.DataValueField = "sigla";
            ddlEstado.DataTextField = "Nome";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, "Selecionar...");
        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        protected void btnIncluirPromocao_Click(object sender, EventArgs e)
        {
            PromocaoEntity objPromocao = new PromocaoEntity();
            bool? ativo;

            objPromocao.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraAte.Text).ToString("s"));
            objPromocao.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraDe.Text).ToString("s"));
            objPromocao.dataUltimaAlteracao = DateTime.Now;
            objPromocao.idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            objPromocao.estado = ddlEstado.SelectedValue;
            objPromocao.link = txtLinkDestino.Text;
            objPromocao.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objPromocao.titulo = txtTitulo.Text;
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            objPromocao.Ativo = ativo;

            int idPromocao = promocaoBusiness.InserePromocao(objPromocao);

            if (FileUpImagemPromocao.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/Promocoes/" + idPromocao)))
                    Directory.CreateDirectory(Server.MapPath(@"~/Promocoes/" + idPromocao));

                string caminhoArquivo = Server.MapPath(@"~/Promocoes/" + idPromocao) + @"\" + FileUpImagemPromocao.FileName;
                FileUpImagemPromocao.SaveAs(caminhoArquivo);

                promocaoBusiness.AtualizaFilePathImagemPromocao(idPromocao, caminhoArquivo);

            }
            else
            {
                promocaoBusiness.DeletaPromocao(idPromocao);
                idPromocao = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idPromocao != 0)
            {
                Alert("Promoção incluida com sucesso!");
                RestauraControles();
                CarregaGridView();
            }
            else
                Alert("Ocorreu um erro ao incluir a promoção!");

            

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlterarPromocao_Click(object sender, EventArgs e)
        {

        }

        private void RestauraControles()
        {
            txtDataHoraAte.Text = string.Empty;
            txtDataHoraDe.Text = string.Empty;
            txtLinkDestino.Text = string.Empty;
            txtTitulo.Text = string.Empty;

            ddlCliente.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;
        }
    }
}