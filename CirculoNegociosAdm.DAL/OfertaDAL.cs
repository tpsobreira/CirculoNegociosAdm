using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class OfertaDAL
    {
        public List<OfertaEntity> ConsultaTodasOfertas()
        {
            List<OfertaEntity> lstOfertasEntity = new List<OfertaEntity>();

            using (var context = new CirculoNegocioEntities())
            {

                var ret = (from p in context.tbOfertas
                           join c in context.tbClientes on p.idCliente equals c.id
                           select new OfertaEntity
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

                lstOfertasEntity = ret;
            }


            return lstOfertasEntity;
        }

        public int InsereOferta(OfertaEntity oferta)
        {
            int idOferta = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbOferta tb = CastOferta(oferta);
                    context.tbOfertas.AddObject(tb);
                    context.SaveChanges();

                    idOferta = tb.id;

                }

                return idOferta;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool DeletaOferta(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbOferta delete = (from p in context.tbOfertas where p.id == id select p).First();
                    context.tbOfertas.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaFilePathImagemOferta(int idOferta, string filePath)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbOferta oferta = (from p in context.tbOfertas where p.id == idOferta select p).First();
                    oferta.imagemFilePath = filePath;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private tbOferta CastOferta(OfertaEntity oferta)
        {
            tbOferta tb = new tbOferta();

            tb.dataAte = oferta.dataAte;
            tb.dataDe = oferta.dataDe;
            tb.dataUltimaAlteracao = oferta.dataUltimaAlteracao;
            tb.descricao = oferta.descricao;
            tb.idCliente = oferta.idCliente;
            tb.imagemFilePath = oferta.imagemFilePath;
            tb.link = oferta.link;
            tb.responsavelUltimaAlteracao = oferta.responsavelUltimaAlteracao;
            tb.titulo = oferta.titulo;
            tb.estado = oferta.estado;
            tb.Ativo = oferta.Ativo;

            return tb;
        }

        private List<OfertaEntity> CastListOfertaEntity(List<tbOferta> tbOferta)
        {
            List<OfertaEntity> lstOfertasEntity = new List<OfertaEntity>();

            foreach (var item in tbOferta)
            {
                OfertaEntity obj = new OfertaEntity();

                obj.dataAte = item.dataAte;
                obj.dataDe = item.dataDe;
                obj.dataUltimaAlteracao = item.dataUltimaAlteracao;
                obj.descricao = item.descricao;
                obj.id = item.id;
                obj.idCliente = item.idCliente;
                obj.imagemFilePath = item.imagemFilePath;
                obj.link = item.link;
                obj.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                obj.titulo = item.titulo;

                lstOfertasEntity.Add(obj);
            }

            return lstOfertasEntity;
        }
    }
}
