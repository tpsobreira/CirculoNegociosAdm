using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class ClientesBusiness
    {
        ClientesDAL lObjClientesDAL = new ClientesDAL();

        public List<ClienteEntity> ConsultaTodosClientes()
        {
            return lObjClientesDAL.ConsultaTodosClientes();
        }

        public ClienteEntity ConsultaClienteById(int idCliente)
        {
            return lObjClientesDAL.ConsultaClienteById(idCliente);
        }

        public int InsereCliente(ClienteEntity cliente, out string mensagem)
        {
            int ret = lObjClientesDAL.InsereCliente(cliente);

            if (ret != 0)
                mensagem = "Cliente incluido com sucesso!";
            else
                mensagem = "Ocorreu um erro ao incluir o cliente!";

            return ret;
            
        }

        public string AtualizaCliente(int idCliente, ClienteEntity cliente)
        {
            bool ret = lObjClientesDAL.AtualizaCliente(idCliente, cliente);

            if (ret)
                return "Cliente Atualizado com Sucesso!";
            else
                return "Ocorreu um erro ao atualizar o cliente!";
        }

        public void AtualizaImagensCliente(int idCliente, string logo, string img1, string img2, string img3)
        {
            lObjClientesDAL.AtualizaImagensCliente(idCliente, logo, img1, img2, img3);
        }

        public string DeletaCliente(int id)
        {
            bool ret = lObjClientesDAL.DeletaCliente(id);

            if (ret)
                return "Cliente excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o cliente!";

        }


    }
}
