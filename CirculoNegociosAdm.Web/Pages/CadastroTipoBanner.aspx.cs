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
    public partial class CadastroTipoBanner : System.Web.UI.Page
    {
        TipoBannerBusiness tipoBannerBusiness = new TipoBannerBusiness();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            TipoBannerEntity objTipoBanner = new TipoBannerEntity();

            objTipoBanner.Nome = txtNome.Text;
            objTipoBanner.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objTipoBanner.DataUltimaAlteracao = DateTime.Now;

            string retorno = string.Empty;

            retorno = tipoBannerBusiness.InsereTipoBanner(objTipoBanner);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();
        }

        private void CarregaGridView()
        {
            gdvTipoBanner.DataSource = tipoBannerBusiness.ConsultaTodosTipoBanner();
            gdvTipoBanner.DataBind();

        }

        protected void gdvTipoBanner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = tipoBannerBusiness.DeletaTipoBanner(Convert.ToInt32(e.CommandArgument));

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