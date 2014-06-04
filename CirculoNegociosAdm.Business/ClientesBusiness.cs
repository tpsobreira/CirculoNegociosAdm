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

        public string InsereCliente(ClienteEntity cliente)
        {
            bool ret = lObjClientesDAL.InsereCliente(cliente);

            if (ret)
                return "Cliente incluido com sucesso!";
            else
                return "Ocorreu um erro ao incluir o cliente!";
            
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
