using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class PromocaoDAL
    {
        public List<PromocaoEntity> ConsultaTodasPromocoes()
        {
            List<PromocaoEntity> lstPromocoesEntity = new List<PromocaoEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbPromocaos select p).ToList();
                lstPromocoesEntity = CastListPromocaoEntity(ret);
            }


            return lstPromocoesEntity;
        }

        public int InserePromocao(PromocaoEntity oferta)
        {
            int idPromocao = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbPromocao tb = CastPromocao(oferta);
                    context.tbPromocaos.AddObject(tb);
                    context.SaveChanges();

                    idPromocao = tb.id;

                }

                return idPromocao;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeletaPromocao(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbPromocao delete = (from p in context.tbPromocaos where p.id == id select p).First();
                    context.tbPromocaos.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private tbPromocao CastPromocao(PromocaoEntity promocao)
        {
            tbPromocao tb = new tbPromocao();

            tb.dataAte = promocao.dataAte;
            tb.dataDe = promocao.dataDe;
            tb.dataUltimaAlteracao = promocao.dataUltimaAlteracao;
            tb.idCliente = promocao.idCliente;
            tb.imagemFilePath = promocao.imagemFilePath;
            tb.link = promocao.link;
            tb.responsavelUltimaAlteracao = promocao.responsavelUltimaAlteracao;
            tb.titulo = promocao.titulo;

            return tb;
        }

        private List<PromocaoEntity> CastListPromocaoEntity(List<tbPromocao> tbPromocao)
        {
            List<PromocaoEntity> lstPromocaosEntity = new List<PromocaoEntity>();

            foreach (var item in tbPromocao)
            {
                PromocaoEntity obj = new PromocaoEntity();

                obj.dataAte = item.dataAte;
                obj.dataDe = item.dataDe;
                obj.dataUltimaAlteracao = item.dataUltimaAlteracao;
                obj.id = item.id;
                obj.idCliente = item.idCliente;
                obj.imagemFilePath = item.imagemFilePath;
                obj.link = item.link;
                obj.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                obj.titulo = item.titulo;

                lstPromocaosEntity.Add(obj);
            }

            return lstPromocaosEntity;
        }
    }
}
