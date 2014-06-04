using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class CategoriaNoticiaDAL
    {
        public List<CategoriaNoticiaEntity> ConsultaTodasCategoriasNoticia()
        {
            List<CategoriaNoticiaEntity> lstCategoriasNoticias = new List<CategoriaNoticiaEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbCategoriaNoticias
                           select p).ToList();

                lstCategoriasNoticias = CastListCategoriasNoticiaEntity(ret);
            }

            return lstCategoriasNoticias;
        }

        public bool InsereCategoriaNoticia(CategoriaNoticiaEntity CategoriaNoticia)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbCategoriaNoticias.AddObject(CastCategoriaNoticia(CategoriaNoticia));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaCategoriaNoticia(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCategoriaNoticia delete = (from p in context.tbCategoriaNoticias where p.id == id select p).First();
                    context.tbCategoriaNoticias.DeleteObject(delete);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<CategoriaNoticiaEntity> CastListCategoriasNoticiaEntity(List<tbCategoriaNoticia> tbCategoriaNoticia)
        {
            List<CategoriaNoticiaEntity> lst = new List<CategoriaNoticiaEntity>();

            foreach (var categoriaNoticia in tbCategoriaNoticia)
            {
                CategoriaNoticiaEntity categoria = new CategoriaNoticiaEntity();

                categoria.DataUltimaAlteracao = categoriaNoticia.DataUltimaAlteracao;
                categoria.id = categoriaNoticia.id;
                categoria.Nome = categoriaNoticia.Nome;
                categoria.responsavelUltimaAlteracao = categoriaNoticia.responsavelUltimaAlteracao;

                lst.Add(categoria);

            }

            return lst;
        }

        private tbCategoriaNoticia CastCategoriaNoticia(CategoriaNoticiaEntity categoriaNoticia)
        {
            tbCategoriaNoticia tb = new tbCategoriaNoticia();

            tb.DataUltimaAlteracao = categoriaNoticia.DataUltimaAlteracao;
            tb.id = categoriaNoticia.id;
            tb.Nome = categoriaNoticia.Nome;
            tb.responsavelUltimaAlteracao = categoriaNoticia.responsavelUltimaAlteracao;

            return tb;
        }
    }
}
