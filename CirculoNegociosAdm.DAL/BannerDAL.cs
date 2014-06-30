using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class BannerDAL
    {

        public List<BannerEntity> ConsultaTodosBanners()
        {
            List<BannerEntity> lstBanners = new List<BannerEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = context.tbBanners.Join(context.tbClientes, b => b.idCliente, c => c.id, (b, c) => new { b.id, b.idCliente, c.nome, b.Ativo, b.dataAte, b.dataDe, b.DataUltimaAlteracao, b.estado, b.idTipoBanner, b.imagemFilePath, b.responsavelUltimaAlteracao }).ToList();


                foreach (var item in ret)
                {
                    BannerEntity obj = new BannerEntity();

                    obj.id = item.id;
                    obj.Ativo = item.Ativo;
                    obj.dataAte = item.dataAte;
                    obj.dataDe = item.dataDe;
                    obj.estado = item.estado;
                    obj.idCliente = item.idCliente;
                    obj.nomeCliente = item.nome;
                    obj.idTipoBanner = item.idTipoBanner;
                    obj.imagemFilePath = item.imagemFilePath;
                    obj.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                    obj.DataUltimaAlteracao = item.DataUltimaAlteracao;

                    lstBanners.Add(obj);
                }
            }

            return lstBanners;
        }

        public int InsereBanner(BannerEntity banner)
        {
            int idBanner = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBanner tb = CastBanner(banner);
                    context.tbBanners.AddObject(tb);
                    context.SaveChanges();

                    idBanner = tb.id;

                }


                return idBanner;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeletaBanner(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBanner delete = (from p in context.tbBanners where p.id == id select p).First();
                    context.tbBanners.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaFilePathImagemBanner(int idBanner, string filePath)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBanner banner = (from p in context.tbBanners where p.id == idBanner select p).First();
                    banner.imagemFilePath = filePath;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private tbBanner CastBanner(BannerEntity banner)
        {
            tbBanner tb = new tbBanner();
            tb.Ativo = banner.Ativo;
            tb.dataAte = banner.dataAte;
            tb.dataDe = banner.dataDe;
            tb.estado = banner.estado;
            tb.idCliente = banner.idCliente;
            tb.idTipoBanner = banner.idTipoBanner;
            tb.responsavelUltimaAlteracao = banner.responsavelUltimaAlteracao;
            tb.DataUltimaAlteracao = banner.DataUltimaAlteracao;

            return tb;
        }

    }
}
