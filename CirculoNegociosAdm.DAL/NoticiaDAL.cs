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

        public int InsereNoticia(NoticiaEntity Noticia)
        {
            int idNoticia = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbNoticia tb = CastNoticia(Noticia);
                    context.tbNoticias.AddObject(tb);
                    context.SaveChanges();

                    idNoticia = tb.id;
                }

                return idNoticia;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public void AtualizaImagensNoticia(int idNoticia, string imgHome, string img1, string img2, string img3)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbNoticia noticia = (from p in context.tbNoticias where p.id == idNoticia select p).First();
                    
                    noticia.imagemHome = imgHome;
                    noticia.imagem1 = img1;
                    noticia.imagem2 = img2;
                    noticia.imagem3 = img3;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
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
                objNoticia.idCategoria = item.idCategoria;
                objNoticia.Descricao = item.Descricao;
                objNoticia.titulo = item.titulo;
                objNoticia.dataHoraAte = item.dataHoraAte;
                objNoticia.dataHoraDe = item.dataHoraDe;
                objNoticia.Sinopse = item.Sinopse;
                objNoticia.estado = item.estado;
                //objNoticia.filePathImagens = item.filePathImagens;
                objNoticia.id = item.id;

                lstNoticiasEntity.Add(objNoticia);
            }

            return lstNoticiasEntity;
        }

        private tbNoticia CastNoticia(NoticiaEntity noticia)
        {
            tbNoticia tb = new tbNoticia();

            tb.Ativo = noticia.Ativo;
            tb.idCategoria = noticia.idCategoria;
            tb.Descricao = noticia.Descricao;
            tb.titulo = noticia.titulo;
            tb.dataHoraAte = noticia.dataHoraAte;
            tb.dataHoraDe = noticia.dataHoraDe;
            tb.Sinopse = noticia.Sinopse;
            tb.estado = noticia.estado;
            //tb.filePathImagens = noticia.filePathImagens;

            return tb;
        }
    }
}
