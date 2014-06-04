using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class CategoriaNoticiaBusiness
    {
        CategoriaNoticiaDAL lObjCategoriaNoticiaDAL = new CategoriaNoticiaDAL();

        public List<CategoriaNoticiaEntity> ConsultaTodasCategoriasNoticia()
        {
            return lObjCategoriaNoticiaDAL.ConsultaTodasCategoriasNoticia();
        }

        public string InsereNoticia(CategoriaNoticiaEntity categoriaNoticia)
        {
            bool ret = lObjCategoriaNoticiaDAL.InsereCategoriaNoticia(categoriaNoticia);

            if (ret)
                return "Categoria incluida com sucesso!";
            else
                return "Ocorreu um erro ao incluir a categoria!";

        }

        public string DeletaCategoriaNoticia(int id)
        {
            bool ret = lObjCategoriaNoticiaDAL.DeletaCategoriaNoticia(id);

            if (ret)
                return "Categoria excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a categoria!";

        }
    }
}
