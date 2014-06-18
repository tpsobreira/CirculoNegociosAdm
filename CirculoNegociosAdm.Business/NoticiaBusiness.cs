using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class NoticiaBusiness
    {
        NoticiaDAL lObjNoticiaDAL = new NoticiaDAL();

        public List<NoticiaEntity> ConsultaTodosNoticias()
        {
            return lObjNoticiaDAL.ConsultaTodosNoticias();
        }

        public int InsereNoticia(NoticiaEntity noticia)
        {
            return lObjNoticiaDAL.InsereNoticia(noticia);
        }

        public string DeletaNoticia(int id)
        {
            bool ret = lObjNoticiaDAL.DeletaNoticia(id);

            if (ret)
                return "Noticia excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a Noticia!";
        }
    }
}
