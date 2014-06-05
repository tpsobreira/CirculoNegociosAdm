using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.Business;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroEstado : System.Web.UI.Page
    {
        EstadoBusiness estadoBusiness = new EstadoBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
            }
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            EstadoEntity estadoEntity = new EstadoEntity();
            string retorno = string.Empty;

            estadoEntity.sigla = txtSigla.Text;
            estadoEntity.nome = txtNome.Text;

            retorno = estadoBusiness.InsereEstado(estadoEntity);
            CarregaGridView();
            Alert(retorno);
            
        }

        protected void gdvEstados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = estadoBusiness.DeletaEstado(e.CommandArgument.ToString());

                this.Alert(retorno);

                CarregaGridView();
            }
        }

        private void CarregaGridView()
        {
            gdvEstados.DataSource = estadoBusiness.ConsultaTodosEstados();
            gdvEstados.DataBind();
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