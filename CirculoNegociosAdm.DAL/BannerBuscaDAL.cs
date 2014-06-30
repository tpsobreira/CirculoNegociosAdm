using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class BannerBuscaDAL
    {
        public List<BannerBuscaEntity> ConsultaTodosBannerBuscas()
        {
            List<BannerBuscaEntity> lstBanners = new List<BannerBuscaEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from b in context.tbBannerBuscas
                           join c in context.tbClientes on b.idCliente equals c.id
                           join ca in context.tbCategoriaClientes on b.idCategoria equals ca.id
                           select new BannerBuscaEntity
                           {
                               id = b.id,
                               idCategoria = b.idCategoria,
                               idCliente = b.idCliente,
                               nomeCliente = c.nome,
                               nomeCategoria = ca.Nome,
                               Ativo = b.Ativo,
                               dataAte = b.dataAte,
                               dataDe = b.dataDe,
                               DataUltimaAlteracao = b.DataUltimaAlteracao,
                               estado = b.estado,
                               imagemFilePath = b.imagemFilePath,
                               responsavelUltimaAlteracao = b.responsavelUltimaAlteracao
                           }).ToList();


                foreach (var item in ret)
                {
                    BannerBuscaEntity obj = new BannerBuscaEntity();

                    obj.id = item.id;
                    obj.idCategoria = item.idCategoria;
                    obj.Ativo = item.Ativo;
                    obj.dataAte = item.dataAte;
                    obj.dataDe = item.dataDe;
                    obj.estado = item.estado;
                    obj.idCliente = item.idCliente;
                    obj.nomeCliente = item.nomeCliente;
                    obj.nomeCategoria = item.nomeCategoria;
                    obj.imagemFilePath = item.imagemFilePath;
                    obj.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                    obj.DataUltimaAlteracao = item.DataUltimaAlteracao;
               

                    lstBanners.Add(obj);
                }
            }

            return lstBanners;
        }

        public int InsereBannerBusca(BannerBuscaEntity banner)
        {
            int idBannerBusca = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerBusca tb = CastBannerBusca(banner);
                    context.tbBannerBuscas.AddObject(tb);
                    context.SaveChanges();

                    idBannerBusca = tb.id;

                }


                return idBannerBusca;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeletaBannerBusca(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerBusca delete = (from p in context.tbBannerBuscas where p.id == id select p).First();
                    context.tbBannerBuscas.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaFilePathImagemBannerBusca(int idBannerBusca, string filePath)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerBusca banner = (from p in context.tbBannerBuscas where p.id == idBannerBusca select p).First();
                    banner.imagemFilePath = filePath;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private tbBannerBusca CastBannerBusca(BannerBuscaEntity banner)
        {
            tbBannerBusca tb = new tbBannerBusca();
            tb.Ativo = banner.Ativo;
            tb.dataAte = banner.dataAte;
            tb.dataDe = banner.dataDe;
            tb.estado = banner.estado;
            tb.idCliente = banner.idCliente;
            tb.idCategoria = banner.idCategoria;
            tb.responsavelUltimaAlteracao = banner.responsavelUltimaAlteracao;
            tb.DataUltimaAlteracao = banner.DataUltimaAlteracao;

            return tb;
        }
    }
}
