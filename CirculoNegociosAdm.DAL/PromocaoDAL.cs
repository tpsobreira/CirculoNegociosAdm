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
                var ret = (from p in context.tbPromocoes
                           join c in context.tbClientes on p.idCliente equals c.id
                           select new PromocaoEntity
                           {
                               Ativo = p.Ativo,
                               dataDe = p.dataDe,
                               dataAte = p.dataAte,
                               dataUltimaAlteracao = p.dataUltimaAlteracao,
                               estado = p.estado,
                               id = p.id,
                               idCliente = p.idCliente,
                               imagemFilePath = p.imagemFilePath,
                               link = p.link,
                               nomeCliente = c.nome,
                               responsavelUltimaAlteracao = p.responsavelUltimaAlteracao,
                               titulo = p.titulo
                           }).ToList();

                lstPromocoesEntity = ret;
            }


            return lstPromocoesEntity;
        }

        public int InserePromocao(PromocaoEntity promocao)
        {
            int idPromocao = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbPromoco tb = CastPromocao(promocao);
                    context.tbPromocoes.AddObject(tb);
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
                    tbPromoco delete = (from p in context.tbPromocoes where p.id == id select p).First();
                    context.tbPromocoes.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaFilePathImagemPromocao(int idPromocao, string filePath)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbPromoco promocao = (from p in context.tbPromocoes where p.id == idPromocao select p).First();
                    promocao.imagemFilePath = filePath;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private tbPromoco CastPromocao(PromocaoEntity promocao)
        {
            tbPromoco tb = new tbPromoco();

            tb.dataAte = promocao.dataAte;
            tb.dataDe = promocao.dataDe;
            tb.dataUltimaAlteracao = promocao.dataUltimaAlteracao;
            tb.idCliente = promocao.idCliente;
            tb.imagemFilePath = promocao.imagemFilePath;
            tb.link = promocao.link;
            tb.responsavelUltimaAlteracao = promocao.responsavelUltimaAlteracao;
            tb.titulo = promocao.titulo;
            tb.estado = promocao.estado;

            return tb;
        }

        private List<PromocaoEntity> CastListPromocaoEntity(List<tbPromoco> tbPromocao)
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
