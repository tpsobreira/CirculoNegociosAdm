using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class BannerPrincipalDAL
    {
        public List<BannerPrincipalEntity> ConsultaTodosBannerPrincipals()
        {
            List<BannerPrincipalEntity> lstBanners = new List<BannerPrincipalEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = context.tbBannerPrincipals.Join(context.tbClientes, b => b.idCliente, c => c.id, (b, c) => new { b.id, b.idCliente, c.nome, b.Ativo, b.dataAte, b.dataDe, b.DataUltimaAlteracao, b.estado, b.imagemFilePath, b.responsavelUltimaAlteracao, b.Descricao, b.Rodape1, b.Rodape2 }).ToList();

                foreach (var item in ret)
                {
                    BannerPrincipalEntity obj = new BannerPrincipalEntity();

                    obj.id = item.id;
                    obj.Ativo = item.Ativo;
                    obj.dataAte = item.dataAte;
                    obj.dataDe = item.dataDe;
                    obj.estado = item.estado;
                    obj.idCliente = item.idCliente;
                    obj.nomeCliente = item.nome;
                    obj.imagemFilePath = item.imagemFilePath;
                    obj.Descricao = item.Descricao;
                    obj.Rodape1 = item.Rodape1;
                    obj.Rodape2 = item.Rodape2;

                    lstBanners.Add(obj);
                }
            }

            return lstBanners;
        }

        public int InsereBannerPrincipal(BannerPrincipalEntity banner)
        {
            int idBannerPrincipal = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerPrincipal tb = CastBannerPrincipal(banner);
                    context.tbBannerPrincipals.AddObject(tb);
                    context.SaveChanges();

                    idBannerPrincipal = tb.id;

                }


                return idBannerPrincipal;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeletaBannerPrincipal(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerPrincipal delete = (from p in context.tbBannerPrincipals where p.id == id select p).First();
                    context.tbBannerPrincipals.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaFilePathImagemBannerPrincipal(int idBannerPrincipal, string filePath)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbBannerPrincipal banner = (from p in context.tbBannerPrincipals where p.id == idBannerPrincipal select p).First();
                    banner.imagemFilePath = filePath;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private tbBannerPrincipal CastBannerPrincipal(BannerPrincipalEntity banner)
        {
            tbBannerPrincipal tb = new tbBannerPrincipal();
            tb.Ativo = banner.Ativo;
            tb.dataAte = banner.dataAte;
            tb.dataDe = banner.dataDe;
            tb.estado = banner.estado;
            tb.idCliente = banner.idCliente;
            tb.responsavelUltimaAlteracao = banner.responsavelUltimaAlteracao;
            tb.DataUltimaAlteracao = banner.DataUltimaAlteracao;
            tb.Descricao = banner.Descricao;
            tb.Rodape1 = banner.Rodape1;
            tb.Rodape2 = banner.Rodape2;

            return tb;
        }
        
    }
}
