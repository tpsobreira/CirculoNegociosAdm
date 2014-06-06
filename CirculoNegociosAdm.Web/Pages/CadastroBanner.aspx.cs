using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;
using System.IO;
using System.Web.Security;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroBanner : System.Web.UI.Page
    {
        BannerBusiness bannerBusiness = new BannerBusiness();
        BannerPrincipalBusiness bannerPrincipalBusiness = new BannerPrincipalBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheCombos();
                CarregaGridView();
            }
        }

        //Inclui banner comum
        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            BannerEntity banner = new BannerEntity();
            bool? ativo;

            banner.idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            banner.idTipoBanner = Convert.ToInt32(ddlTipoBanner.SelectedValue);
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            banner.Ativo = ativo;
            banner.dataAte = Convert.ToDateTime(txtDataHoraFinal.Text);
            banner.dataDe = Convert.ToDateTime(txtDataHoraInicial.Text);
            banner.estado = ddlEstado.SelectedValue;
            banner.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            banner.DataUltimaAlteracao = DateTime.Now;

            int idBanner = bannerBusiness.InsereBanner(banner);

            if (FileUpImagensBanner.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/Banners/" + idBanner)))
                    Directory.CreateDirectory(Server.MapPath(@"~/Banners/" + idBanner));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/Banners/" + idBanner));
                    Directory.CreateDirectory(Server.MapPath(@"~/Banners/" + idBanner));
                }

                string caminhoArquivo = Server.MapPath(@"~/Banners/" + idBanner) + @"\\" + FileUpImagensBanner.FileName;
                FileUpImagensBanner.SaveAs(caminhoArquivo);

                bannerBusiness.AtualizaFilePathImagemBanner(idBanner, caminhoArquivo);

            }
            else
            {
                bannerBusiness.DeletaBanner(idBanner);
                idBanner = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idBanner != 0)
            {
                Alert("Banner incluido com sucesso!");
                CarregaGridView();
            }
            else
                Alert("Ocorreu um erro ao incluir o Banner!");

        }

        

        private void CarregaGridView()
        {
            gdvBanners.DataSource = bannerBusiness.ConsultaTodosBanners();
            gdvBanners.DataBind();


            gdvBannersPrincipal.DataSource = bannerPrincipalBusiness.ConsultaTodosBannerPrincipals();
            gdvBannersPrincipal.DataBind();
        }

        protected void gdvBanners_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = bannerBusiness.DeletaBanner(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
        }



        #region ### Banner Principal


        protected void btnIncluirBannerPrincipal_Click(object sender, EventArgs e)
        {
            BannerPrincipalEntity banner = new BannerPrincipalEntity();
            bool? ativo;

            banner.idCliente = Convert.ToInt32(ddlClienteBannerPrincipal.SelectedValue);
            ativo = rdlAtivoBannerPrincipal.SelectedValue == "1" ? true : false;
            banner.Ativo = ativo;
            banner.dataAte = Convert.ToDateTime(txtDataHoraFinalBannerPrincipal.Text);
            banner.dataDe = Convert.ToDateTime(txtDataHoraInicialBannerPrincipal.Text);
            banner.estado = ddlEstadoBannerPrincipal.SelectedValue;

            int idBanner = bannerPrincipalBusiness.InsereBannerPrincipal(banner);

            if (FileUpImagensBanner.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/BannerPrincipal/" + idBanner)))
                    Directory.CreateDirectory(Server.MapPath(@"~/BannerPrincipal/" + idBanner));

                string caminhoArquivo = Server.MapPath(@"~/BannerPrincipal/" + idBanner) + @"/" + FileUpImagensBanner.FileName;
                FileUpImagensBanner.SaveAs(caminhoArquivo);

                bannerBusiness.AtualizaFilePathImagemBanner(idBanner, caminhoArquivo);

            }
            else
            {
                bannerBusiness.DeletaBanner(idBanner);
                idBanner = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idBanner != 0)
                Alert("Banner incluido com sucesso!");
            else
                Alert("Ocorreu um erro ao incluir o Banner!");

        }

        protected void gdvBannersPrincipal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = bannerPrincipalBusiness.DeletaBannerPrincipal(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
        }

        #endregion


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

            ddlTipoBanner.DataSource = new TipoBannerBusiness().ConsultaTodosTipoBanner();
            ddlTipoBanner.DataValueField = "id";
            ddlTipoBanner.DataTextField = "Nome";
            ddlTipoBanner.DataBind();
            ddlTipoBanner.Items.Insert(0, "Selecionar...");


            #region ### Banner Principal

            ddlClienteBannerPrincipal.DataSource = new ClientesBusiness().ConsultaTodosClientes();
            ddlClienteBannerPrincipal.DataValueField = "id";
            ddlClienteBannerPrincipal.DataTextField = "Nome";
            ddlClienteBannerPrincipal.DataBind();
            ddlClienteBannerPrincipal.Items.Insert(0, "Selecionar...");

            ddlEstadoBannerPrincipal.DataSource = new EstadoBusiness().ConsultaTodosEstados();
            ddlEstadoBannerPrincipal.DataValueField = "sigla";
            ddlEstadoBannerPrincipal.DataTextField = "Nome";
            ddlEstadoBannerPrincipal.DataBind();
            ddlEstadoBannerPrincipal.Items.Insert(0, "Selecionar...");

            #endregion



        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }
    }
}