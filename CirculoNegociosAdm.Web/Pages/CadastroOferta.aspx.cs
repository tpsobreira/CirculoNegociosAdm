﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;

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
            }
        }

        protected void btnIncluirOferta_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAlterarOferta_Click(object sender, EventArgs e)
        {

        }

        private void RestauraControles()
        { }

        private void PreencheCombos()
        {
            ddlCliente.DataSource = new ClientesBusiness().ConsultaTodosClientes();
            ddlCliente.DataValueField = "id";
            ddlCliente.DataTextField = "Nome";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, "Selecionar...");
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