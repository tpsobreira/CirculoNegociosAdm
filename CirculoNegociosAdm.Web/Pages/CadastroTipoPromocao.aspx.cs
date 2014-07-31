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
    public partial class CadastroTipoPromocao : System.Web.UI.Page
    {
        TipoPromocaoBusiness tipoPromocaoBusiness = new TipoPromocaoBusiness();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            TipoPromocaoEntity objTipoPromocao = new TipoPromocaoEntity();

            objTipoPromocao.Nome = txtNome.Text;
            objTipoPromocao.responsavelUltimaAlteracao = Membership.GetUser().UserName;
            objTipoPromocao.DataUltimaAlteracao = DateTime.Now;

            string retorno = string.Empty;

            retorno = tipoPromocaoBusiness.InsereTipoPromocao(objTipoPromocao);

            this.Alert(retorno);

            CarregaGridView();
            RestauraControles();
        }

        private void CarregaGridView()
        {
            gdvTipoPromocao.DataSource = tipoPromocaoBusiness.ConsultaTodosTipoPromocao();
            gdvTipoPromocao.DataBind();

        }

        protected void gdvTipoPromocao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = tipoPromocaoBusiness.DeletaTipoPromocao(Convert.ToInt32(e.CommandArgument));

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