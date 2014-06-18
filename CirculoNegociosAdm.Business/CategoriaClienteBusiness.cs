using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class CategoriaClienteBusiness
    {
        CategoriaClienteDAL lObjCategoriaClienteDAL = new CategoriaClienteDAL();

        public List<CategoriaClienteEntity> ConsultaTodasCategoriasCliente()
        {
            return lObjCategoriaClienteDAL.ConsultaTodasCategoriasCliente();
        }

        public string InsereCategoriaCliente(CategoriaClienteEntity categoriaCliente)
        {
            bool ret = lObjCategoriaClienteDAL.InsereCategoriaCliente(categoriaCliente);

            if (ret)
                return "Categoria incluida com sucesso!";
            else
                return "Ocorreu um erro ao incluir a categoria!";

        }

        public string DeletaCategoriaCliente(int id)
        {
            bool ret = lObjCategoriaClienteDAL.DeletaCategoriaCliente(id);

            if (ret)
                return "Categoria excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a categoria!";

        }
    }
}
