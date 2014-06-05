using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class NoticiaDAL
    {
        public List<NoticiaEntity> ConsultaTodosNoticias()
        {
            List<NoticiaEntity> lstNoticias = new List<NoticiaEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbNoticias
                           select p).ToList();

                lstNoticias = CastListNoticiaEntity(ret);
            }

            return lstNoticias;
        }

        public bool InsereNoticia(NoticiaEntity Noticia)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbNoticias.AddObject(CastNoticia(Noticia));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaNoticia(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbNoticia delete = (from p in context.tbNoticias where p.id == id select p).First();
                    context.tbNoticias.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<NoticiaEntity> CastListNoticiaEntity(List<tbNoticia> lstNoticias)
        {
            List<NoticiaEntity> lstNoticiasEntity = new List<NoticiaEntity>();

            foreach (var item in lstNoticias)
            {
                NoticiaEntity objNoticia = new NoticiaEntity();

                objNoticia.Ativo = item.Ativo;
                objNoticia.dataHoraAte = item.dataHoraAte;
                objNoticia.dataHoraDe = item.dataHoraDe;
                objNoticia.Descricao = item.Descricao;
                objNoticia.estado = item.estado;
                objNoticia.filePathImagens = item.filePathImagens;

                lstNoticiasEntity.Add(objNoticia);
            }

            return lstNoticiasEntity;
        }

        private tbNoticia CastNoticia(NoticiaEntity noticia)
        {
            tbNoticia tb = new tbNoticia();

            tb.Ativo = noticia.Ativo;
            tb.dataHoraAte = noticia.dataHoraAte;
            tb.dataHoraDe = noticia.dataHoraDe;
            tb.Descricao = noticia.Descricao;
            tb.estado = noticia.estado;
            tb.filePathImagens = noticia.filePathImagens;

            return tb;
        }
    }
}
