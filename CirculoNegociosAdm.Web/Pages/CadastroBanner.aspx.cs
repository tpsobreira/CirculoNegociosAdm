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
        BannerBuscaBusiness bannerBuscaBusiness = new BannerBuscaBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencheCombos();
                CarregaGridView();
            }
        }

        #region ### Banner Home

        //Inclui banner comum
        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            BannerEntity banner = new BannerEntity();
            bool? ativo;

            banner.idCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            banner.idTipoBanner = Convert.ToInt32(ddlTipoBanner.SelectedValue);
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            banner.Ativo = ativo;
            banner.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraFinal.Text).ToString("s"));
            banner.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraInicial.Text).ToString("s"));
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

                string caminhoArquivo = Server.MapPath(@"~/Banners/" + idBanner) + @"\" + FileUpImagensBanner.FileName;
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

            CarregaGridView();

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

        #endregion

        #region ### Banner Principal


        protected void btnIncluirBannerPrincipal_Click(object sender, EventArgs e)
        {
            BannerPrincipalEntity banner = new BannerPrincipalEntity();
            bool? ativo;

            banner.idCliente = Convert.ToInt32(ddlClienteBannerPrincipal.SelectedValue);
            ativo = rdlAtivoBannerPrincipal.SelectedValue == "1" ? true : false;
            banner.Ativo = ativo;
            banner.Descricao = txtDescricaoBannerPrincipal.Text;
            banner.Rodape1 = txtTextoRodape1BannerPrincial.Text;
            banner.Rodape2 = txtTextoRodape2BannerPrincial.Text;
            banner.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraFinalBannerPrincipal.Text).ToString("s"));
            banner.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraInicialBannerPrincipal.Text).ToString("s"));

            banner.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraFinalBannerPrincipal.Text).ToString("s"));
            banner.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraInicialBannerPrincipal.Text).ToString("s"));

            banner.estado = ddlEstadoBannerPrincipal.SelectedValue;
            banner.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            banner.DataUltimaAlteracao = DateTime.Now;

            int idBanner = bannerPrincipalBusiness.InsereBannerPrincipal(banner);

            if (FileUpImagensBannerPrincipal.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/BannerPrincipal/" + idBanner)))
                    Directory.CreateDirectory(Server.MapPath(@"~/BannerPrincipal/" + idBanner));

                string caminhoArquivo = Server.MapPath(@"~/BannerPrincipal/" + idBanner) + @"\" + FileUpImagensBannerPrincipal.FileName;
                FileUpImagensBannerPrincipal.SaveAs(caminhoArquivo);

                bannerPrincipalBusiness.AtualizaFilePathImagemBannerPrincipal(idBanner, caminhoArquivo);

            }
            else
            {
                bannerPrincipalBusiness.DeletaBannerPrincipal(idBanner);
                idBanner = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idBanner != 0)
                Alert("Banner principal incluido com sucesso!");
            else
                Alert("Ocorreu um erro ao incluir o Banner principal!");

            CarregaGridView();
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

        #region ### Banner Busca

        protected void btnIncluirBannerBusca_Click(object sender, EventArgs e)
        {
            BannerBuscaEntity banner = new BannerBuscaEntity();
            bool? ativo;

            banner.idCliente = Convert.ToInt32(ddlClienteBannerBusca.SelectedValue);
            ativo = rdlAtivoBannerBusca.SelectedValue == "1" ? true : false;
            banner.Ativo = ativo;
            banner.idCategoria = Convert.ToInt32(ddlCategoriaBannerBusca.SelectedValue);
            banner.dataAte = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraFinalBannerBusca.Text).ToString("s"));
            banner.dataDe = Convert.ToDateTime(Convert.ToDateTime(txtDataHoraInicialBannerBusca.Text).ToString("s"));
            banner.estado = ddlEstadoBannerBusca.SelectedValue;
            banner.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            banner.DataUltimaAlteracao = DateTime.Now;

            int idBanner = bannerBuscaBusiness.InsereBannerBusca(banner);

            if (FileUpBannerBusca.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/BannerBusca/" + idBanner)))
                    Directory.CreateDirectory(Server.MapPath(@"~/BannerBusca/" + idBanner));

                string caminhoArquivo = Server.MapPath(@"~/BannerBusca/" + idBanner) + @"\" + FileUpBannerBusca.FileName;
                FileUpBannerBusca.SaveAs(caminhoArquivo);

                bannerBuscaBusiness.AtualizaFilePathImagemBannerBusca(idBanner, caminhoArquivo);

            }
            else
            {
                bannerBuscaBusiness.DeletaBannerBusca(idBanner);
                idBanner = 0;
                Alert("É obrigatório selecionar a imagem!");
            }

            if (idBanner != 0)
                Alert("Banner busca incluido com sucesso!");
            else
                Alert("Ocorreu um erro ao incluir o Banner busca!");

            CarregaGridView();

        }

        protected void gdvBannersBusca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = bannerBuscaBusiness.DeletaBannerBusca(Convert.ToInt32(e.CommandArgument));

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


            #region ### Banner Busca

            ddlClienteBannerBusca.DataSource = new ClientesBusiness().ConsultaTodosClientes();
            ddlClienteBannerBusca.DataValueField = "id";
            ddlClienteBannerBusca.DataTextField = "Nome";
            ddlClienteBannerBusca.DataBind();
            ddlClienteBannerBusca.Items.Insert(0, "Selecionar...");

            ddlEstadoBannerBusca.DataSource = new EstadoBusiness().ConsultaTodosEstados();
            ddlEstadoBannerBusca.DataValueField = "sigla";
            ddlEstadoBannerBusca.DataTextField = "Nome";
            ddlEstadoBannerBusca.DataBind();
            ddlEstadoBannerBusca.Items.Insert(0, "Selecionar...");

            ddlCategoriaBannerBusca.DataSource = new CategoriaClienteBusiness().ConsultaTodasCategoriasCliente();
            ddlCategoriaBannerBusca.DataValueField = "id";
            ddlCategoriaBannerBusca.DataTextField = "Nome";
            ddlCategoriaBannerBusca.DataBind();
            ddlCategoriaBannerBusca.Items.Insert(0, "Selecionar...");

            #endregion


        }

        private void CarregaGridView()
        {
            gdvBanners.DataSource = bannerBusiness.ConsultaTodosBanners();
            gdvBanners.DataBind();

            gdvBannersPrincipal.DataSource = bannerPrincipalBusiness.ConsultaTodosBannerPrincipals();
            gdvBannersPrincipal.DataBind();

            gdvBannersBusca.DataSource = bannerBuscaBusiness.ConsultaTodosBannerBuscas();
            gdvBannersBusca.DataBind();

        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }
    }
}