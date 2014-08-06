using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CirculoNegociosAdm.Business;
using CirculoNegociosAdm.Entity;
using System.IO;

namespace CirculoNegociosAdm.Pages
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        ClientesBusiness clienteBusiness = new ClientesBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridView();
                PreencheCombos();
            }
        }

        private void CarregaGridView()
        {
            gdvClientes.DataSource = clienteBusiness.ConsultaTodosClientes();
            gdvClientes.DataBind();
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            ClienteEntity objCliente = new ClienteEntity();
            bool? ativo = false;

            objCliente.anexoImagem1Path = "";
            objCliente.anexoImagem2Path = "";
            objCliente.anexoImagem3Path = "";
            objCliente.anexoLogoPath = "";
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            objCliente.ativo = ativo;
            objCliente.cep = txtCep.Text;
            objCliente.cidade = txtCidade.Text;
            objCliente.complemento = txtComplemento.Text;
            objCliente.contatoResponsavel = txtResponsavel.Text;
            objCliente.cpfCnpj = txtCpfCnpj.Text;
            objCliente.email = txtEmail.Text;
            objCliente.endereco = txtEndereco.Text;
            objCliente.estado = txtEstado.Text;
            objCliente.bairro = txtBairro.Text;
            objCliente.Funcionamento = string.Format("Util: {0} as {1} | Final: {2} as {3}", txtHoraSemanaDe.Text, txtHoraSemanaAte.Text, txtHoraSabDe.Text, txtHoraSabAte.Text);
            objCliente.idCategoriaCliente = Convert.ToInt32(ddlCategoria.SelectedValue);
            objCliente.idSubCategoriaCliente = Convert.ToInt32(ddlSubCategoria.SelectedValue);
            objCliente.inscricaoEstadual = txtIncricaoEstadual.Text;
            objCliente.nome = txtNome.Text;
            objCliente.nomeFantasia = txtNomeFantasia.Text;
            objCliente.observacoes = txtObservacoes.Text;
            objCliente.razaoSocial = txtRazaoSocial.Text;
            objCliente.servicos = txtServicos.Text;

            objCliente.idPlano = Convert.ToInt32(ddlPlanos.SelectedValue);

            objCliente.latitude = txtLatitude.Text;
            objCliente.longitude = txtLongitude.Text;

            if (chkSabado.Checked)//Nao trabalha no Sabado
            {
                objCliente.horaFdsAte = "99:99";
                objCliente.horaFdsDe = "99:99";
            }
            else
            {
                objCliente.horaFdsAte = txtHoraSabAte.Text;
                objCliente.horaFdsDe = txtHoraSabDe.Text;
            }

            objCliente.horaSemanaAte = txtHoraSemanaAte.Text;
            objCliente.horaSemanaDe = txtHoraSemanaDe.Text;

            if (chkDomingo.Checked)//Nao trabalha Domingo
            {
                objCliente.horaDomingoAte = "99:99";
                objCliente.horaDomingoDe = "99:99";
            }
            else
            {
                objCliente.horaDomingoAte = txtHoraDomingoAte.Text;
                objCliente.horaDomingoDe = txtHoraDomingoDe.Text;
            }

            objCliente.site = txtSite.Text;
            objCliente.telefone1 = txtTelefone1.Text;
            objCliente.telefone2 = txtTelefone2.Text;

            string mensagem = string.Empty;

            int idCliente = clienteBusiness.InsereCliente(objCliente, out mensagem);

            SalvaImagensCliente(idCliente);

            this.Alert(mensagem);

            CarregaGridView();
            RestauraControles();

        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            ClienteEntity objCliente = new ClienteEntity();
            bool? ativo = false;

            //objCliente.anexoImagem1Path = "";
            //objCliente.anexoImagem2Path = "";
            //objCliente.anexoImagem3Path = "";
            //objCliente.anexoLogoPath = "";
            ativo = rdlAtivo.SelectedValue == "1" ? true : false;
            objCliente.ativo = ativo;
            objCliente.cep = txtCep.Text;
            objCliente.cidade = txtCidade.Text;
            objCliente.complemento = txtComplemento.Text;
            objCliente.contatoResponsavel = txtResponsavel.Text;
            objCliente.cpfCnpj = txtCpfCnpj.Text;
            objCliente.email = txtEmail.Text;
            objCliente.endereco = txtEndereco.Text;
            objCliente.estado = txtEstado.Text;
            objCliente.bairro = txtBairro.Text;
            objCliente.Funcionamento = string.Format("Util: {0} as {1} | Final: {2} as {3}", txtHoraSemanaDe.Text, txtHoraSemanaAte.Text, txtHoraSabDe.Text, txtHoraSabAte.Text);
            

            objCliente.idCategoriaCliente = Convert.ToInt32(ddlCategoria.SelectedValue);
            objCliente.idSubCategoriaCliente = Convert.ToInt32(ddlSubCategoria.SelectedValue);
            objCliente.inscricaoEstadual = txtIncricaoEstadual.Text;
            objCliente.nome = txtNome.Text;
            objCliente.nomeFantasia = txtNomeFantasia.Text;
            objCliente.observacoes = txtObservacoes.Text;
            objCliente.razaoSocial = txtRazaoSocial.Text;
            objCliente.servicos = txtServicos.Text;

            objCliente.latitude = txtLatitude.Text;
            objCliente.longitude = txtLongitude.Text;

            if (chkSabado.Checked)//Nao trabalha no Sabado
            {
                objCliente.horaFdsAte = "99:99";
                objCliente.horaFdsDe = "99:99";
            }
            else
            {
                objCliente.horaFdsAte = txtHoraSabAte.Text;
                objCliente.horaFdsDe = txtHoraSabDe.Text;
            }

            objCliente.horaSemanaAte = txtHoraSemanaAte.Text;
            objCliente.horaSemanaDe = txtHoraSemanaDe.Text;

            if (chkDomingo.Checked)//Nao trabalha Domingo
            {
                objCliente.horaDomingoAte = "99:99";
                objCliente.horaDomingoDe = "99:99";
            }
            else
            {
                objCliente.horaDomingoAte = txtHoraDomingoAte.Text;
                objCliente.horaDomingoDe = txtHoraDomingoDe.Text;
            }

            objCliente.site = txtSite.Text;
            objCliente.telefone1 = txtTelefone1.Text;
            objCliente.telefone2 = txtTelefone2.Text;

            AlteraImagensCliente(Convert.ToInt32(hdIdClienteEdit.Value));

            string mensagem = clienteBusiness.AtualizaCliente(Convert.ToInt32(hdIdClienteEdit.Value), objCliente);

            this.Alert(mensagem);

            CarregaGridView();
            RestauraControles();

            btnAlterar.Visible = false;
            btnIncluir.Visible = true;
        }

        protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deletar")
            {
                string retorno = clienteBusiness.DeletaCliente(Convert.ToInt32(e.CommandArgument));

                this.Alert(retorno);

                CarregaGridView();
            }
            else if (e.CommandName == "Editar")
            {
                btnAlterar.Visible = true;
                btnIncluir.Visible = false;
                ClienteEntity objCliente = clienteBusiness.ConsultaClienteById(Convert.ToInt32(e.CommandArgument));

                hdIdClienteEdit.Value = e.CommandArgument.ToString();

                PreencheControlesEditar(objCliente);

            }

        }

        private void AlteraImagensCliente(int idCliente)
        {
            string caminhoLogo = string.Empty;
            string caminhoImg1 = string.Empty;
            string caminhoImg2 = string.Empty;
            string caminhoImg3 = string.Empty;

            if (FileUpLogo.HasFile)
            {
                caminhoLogo = Server.MapPath(@"~/LogotipoClientes/" + idCliente) + @"\" + FileUpLogo.FileName;
                File.Delete(hdLogoEdit.Value);
                FileUpLogo.SaveAs(caminhoLogo);
            }

            if (FileUpImg1.HasFile)
            {
                caminhoImg1 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg1.FileName;
                File.Delete(hdImg1Edit.Value);
                FileUpImg1.SaveAs(caminhoImg1);
            }

            if (FileUpImg2.HasFile)
            {
                caminhoImg2 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg2.FileName;
                File.Delete(hdImg2Edit.Value);
                FileUpImg2.SaveAs(caminhoImg2);
            }

            if (FileUpImg3.HasFile)
            {
                caminhoImg3 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg3.FileName;
                File.Delete(hdImg3Edit.Value);
                FileUpImg3.SaveAs(caminhoImg3);
            }

            if (string.IsNullOrEmpty(caminhoLogo))
                caminhoLogo = hdLogoEdit.Value;

            if (string.IsNullOrEmpty(caminhoImg1))
                caminhoImg1 = hdImg1Edit.Value;

            if (string.IsNullOrEmpty(caminhoImg2))
                caminhoImg2 = hdImg2Edit.Value;

            if (string.IsNullOrEmpty(caminhoImg3))
                caminhoImg3 = hdImg3Edit.Value;

            clienteBusiness.AtualizaImagensCliente(idCliente, caminhoLogo, caminhoImg1, caminhoImg2, caminhoImg3);
        }

        private void SalvaImagensCliente(int idCliente)
        {
            string caminhoLogo = string.Empty;
            string caminhoImg1 = string.Empty;
            string caminhoImg2 = string.Empty;
            string caminhoImg3 = string.Empty;


            if (FileUpLogo.HasFile && FileUpImg1.HasFile && FileUpImg2.HasFile && FileUpImg3.HasFile)
            {
                if (!Directory.Exists(Server.MapPath(@"~/LogotipoClientes/" + idCliente)))
                    Directory.CreateDirectory(Server.MapPath(@"~/LogotipoClientes/" + idCliente));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/LogotipoClientes/" + idCliente));
                    Directory.CreateDirectory(Server.MapPath(@"~/LogotipoClientes/" + idCliente));
                }

                caminhoLogo = Server.MapPath(@"~/LogotipoClientes/" + idCliente) + @"\" + FileUpLogo.FileName;
                FileUpLogo.SaveAs(caminhoLogo);

                if (!Directory.Exists(Server.MapPath(@"~/ImgClientes/" + idCliente)))
                    Directory.CreateDirectory(Server.MapPath(@"~/ImgClientes/" + idCliente));
                else
                {
                    Directory.Delete(Server.MapPath(@"~/ImgClientes/" + idCliente));
                    Directory.CreateDirectory(Server.MapPath(@"~/ImgClientes/" + idCliente));
                }

                caminhoImg1 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg1.FileName;
                caminhoImg2 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg2.FileName;
                caminhoImg3 = Server.MapPath(@"~/ImgClientes/" + idCliente) + @"\" + FileUpImg3.FileName;

                FileUpImg1.SaveAs(caminhoImg1);
                FileUpImg2.SaveAs(caminhoImg2);
                FileUpImg3.SaveAs(caminhoImg3);

                clienteBusiness.AtualizaImagensCliente(idCliente, caminhoLogo, caminhoImg1, caminhoImg2, caminhoImg3);

            }
            else
            {
                Alert("É obrigatório selecionar todas as imagens, se não tiver 3 imagens diferentes, pode colocar a mesma imagem, apenas mudando o nome do arquivo!");
            }


        }

        private void Alert(string mensagem)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }


        protected void lnkCep_Click(object sender, EventArgs e)
        {
            LogradouroBusiness logradouroBusiness = new LogradouroBusiness();

            var logradouroInfo = logradouroBusiness.ConsultaCep(txtCep.Text);

            txtEndereco.Text = logradouroInfo.endereco;
            txtCidade.Text = logradouroInfo.cidade;
            txtEstado.Text = logradouroInfo.uf;
            txtBairro.Text = logradouroInfo.bairro;

        }

        private void RestauraControles()
        {
            txtBairro.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtCpfCnpj.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtHoraSabAte.Text = string.Empty;
            txtHoraSabDe.Text = string.Empty;
            txtHoraSemanaAte.Text = string.Empty;
            txtHoraSemanaDe.Text = string.Empty;
            txtIncricaoEstadual.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNomeFantasia.Text = string.Empty;
            txtObservacoes.Text = string.Empty;
            txtRazaoSocial.Text = string.Empty;
            txtResponsavel.Text = string.Empty;
            txtServicos.Text = string.Empty;
            txtSite.Text = string.Empty;
            txtTelefone1.Text = string.Empty;
            txtTelefone2.Text = string.Empty;

            ddlCategoria.SelectedIndex = 0;

            ddlSubCategoria.SelectedIndex = 0;

            rdlAtivo.SelectedValue = "0";
        }

        private void PreencheControlesEditar(ClienteEntity objCliente)
        {
            txtBairro.Text = objCliente.bairro;
            txtCep.Text = objCliente.cep;
            txtCidade.Text = objCliente.cidade;
            txtComplemento.Text = objCliente.complemento;
            txtCpfCnpj.Text = objCliente.cpfCnpj;
            txtEmail.Text = objCliente.email;
            txtEndereco.Text = objCliente.endereco;
            txtEstado.Text = objCliente.estado;
            txtHoraSabAte.Text = objCliente.horaFdsAte;
            txtHoraSabDe.Text = objCliente.horaFdsDe;

            txtHoraDomingoAte.Text = objCliente.horaDomingoAte;
            txtHoraDomingoDe.Text = objCliente.horaDomingoDe;

            txtLatitude.Text = objCliente.latitude;
            txtLongitude.Text = objCliente.longitude;

            txtHoraSemanaAte.Text = objCliente.horaSemanaAte;
            txtHoraSemanaDe.Text = objCliente.horaSemanaDe;
            txtIncricaoEstadual.Text = objCliente.inscricaoEstadual;
            txtNome.Text = objCliente.nome;
            txtNomeFantasia.Text = objCliente.nomeFantasia;
            txtObservacoes.Text = objCliente.observacoes;
            txtRazaoSocial.Text = objCliente.razaoSocial;
            txtResponsavel.Text = objCliente.contatoResponsavel;
            txtServicos.Text = objCliente.servicos;
            txtSite.Text = objCliente.site;
            txtTelefone1.Text = objCliente.telefone1;
            txtTelefone2.Text = objCliente.telefone2;

            ddlCategoria.SelectedValue = objCliente.idCategoriaCliente.ToString();

            ddlSubCategoria.DataSource = new SubCategoriaClienteBusiness().ConsultaSubCategoriasClientebyCategoriaPai(Convert.ToInt32(objCliente.idCategoriaCliente));
            ddlSubCategoria.DataValueField = "id";
            ddlSubCategoria.DataTextField = "Nome";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, "Selecione...");

            ddlSubCategoria.SelectedValue = objCliente.idSubCategoriaCliente.ToString();
            ddlPlanos.SelectedValue = objCliente.idPlano.ToString();

            rdlAtivo.SelectedValue = Convert.ToInt32(objCliente.ativo).ToString();

            hdImg1Edit.Value = objCliente.anexoImagem1Path;
            hdImg2Edit.Value = objCliente.anexoImagem2Path;
            hdImg3Edit.Value = objCliente.anexoImagem3Path;
            hdLogoEdit.Value = objCliente.anexoLogoPath;
        }

        private void PreencheCombos()
        {
            ddlCategoria.DataSource = new CategoriaClienteBusiness().ConsultaTodasCategoriasCliente();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "Nome";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "Selecione...");

            ddlPlanos.DataSource = new PlanoBusiness().ConsultaTodosPlanos();
            ddlPlanos.DataValueField = "id";
            ddlPlanos.DataTextField = "Nome";
            ddlPlanos.DataBind();
            ddlPlanos.Items.Insert(0, "Selecione...");
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategoria.DataSource = new SubCategoriaClienteBusiness().ConsultaSubCategoriasClientebyCategoriaPai(Convert.ToInt32(ddlCategoria.SelectedValue));
            ddlSubCategoria.DataValueField = "id";
            ddlSubCategoria.DataTextField = "Nome";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, "Selecione...");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            RestauraControles();
        }
    }
}