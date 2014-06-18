using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class SubCategoriaClienteBusiness
    {
        SubCategoriaClienteDAL lObjSubCategoriaClienteDAL = new SubCategoriaClienteDAL();

        public List<SubCategoriaClienteEntity> ConsultaTodasSubCategoriasCliente()
        {
            return lObjSubCategoriaClienteDAL.ConsultaTodasSubCategoriasCliente();
        }

        public List<SubCategoriaClienteEntity> ConsultaSubCategoriasClientebyCategoriaPai(int idCategoriaPai)
        {
            return lObjSubCategoriaClienteDAL.ConsultaSubCategoriasClientebyCategoriaPai(idCategoriaPai);
        }

        public string InsereSubCategoriaCliente(SubCategoriaClienteEntity categoriaCliente)
        {
            bool ret = lObjSubCategoriaClienteDAL.InsereSubCategoriaCliente(categoriaCliente);

            if (ret)
                return "SubCategoria incluida com sucesso!";
            else
                return "Ocorreu um erro ao incluir a categoria!";

        }

        public string DeletaSubCategoriaCliente(int id)
        {
            bool ret = lObjSubCategoriaClienteDAL.DeletaSubCategoriaCliente(id);

            if (ret)
                return "SubCategoria excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a categoria!";

        }
    }
}
