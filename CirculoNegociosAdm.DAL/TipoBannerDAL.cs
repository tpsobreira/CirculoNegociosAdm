using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class TipoBannerDAL
    {
        public List<TipoBannerEntity> ConsultaTodosTipoBanner()
        {
            List<TipoBannerEntity> lstsTipoBanners = new List<TipoBannerEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbTipoBanners
                           select p).ToList();

                lstsTipoBanners = CastListsTipoBannerEntity(ret);
            }

            return lstsTipoBanners;
        }

        public bool InsereTipoBanner(TipoBannerEntity TipoBanner)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbTipoBanners.AddObject(CastTipoBanner(TipoBanner));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaTipoBanner(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbTipoBanner delete = (from p in context.tbTipoBanners where p.id == id select p).First();
                    context.tbTipoBanners.DeleteObject(delete);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<TipoBannerEntity> CastListsTipoBannerEntity(List<tbTipoBanner> tbTipoBanner)
        {
            List<TipoBannerEntity> lst = new List<TipoBannerEntity>();

            foreach (var TipoBanner in tbTipoBanner)
            {
                TipoBannerEntity tipoBanner = new TipoBannerEntity();

                tipoBanner.DataUltimaAlteracao = TipoBanner.DataUltimaAlteracao;
                tipoBanner.id = TipoBanner.id;
                tipoBanner.Nome = TipoBanner.Nome;
                tipoBanner.responsavelUltimaAlteracao = TipoBanner.responsavelUltimaAlteracao;

                lst.Add(tipoBanner);

            }

            return lst;
        }

        private tbTipoBanner CastTipoBanner(TipoBannerEntity TipoBanner)
        {
            tbTipoBanner tb = new tbTipoBanner();

            tb.DataUltimaAlteracao = TipoBanner.DataUltimaAlteracao;
            tb.id = TipoBanner.id;
            tb.Nome = TipoBanner.Nome;
            tb.responsavelUltimaAlteracao = TipoBanner.responsavelUltimaAlteracao;

            return tb;
        }
    }
}
