using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class TipoPromocaoDAL
    {
        public List<TipoPromocaoEntity> ConsultaTodosTipoPromocao()
        {
            List<TipoPromocaoEntity> lstsTipoPromocaos = new List<TipoPromocaoEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbTipoPromocaos
                           select p).ToList();

                lstsTipoPromocaos = CastListsTipoPromocaoEntity(ret);
            }

            return lstsTipoPromocaos;
        }

        public bool InsereTipoPromocao(TipoPromocaoEntity TipoPromocao)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbTipoPromocaos.AddObject(CastTipoPromocao(TipoPromocao));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaTipoPromocao(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbTipoPromocao delete = (from p in context.tbTipoPromocaos where p.id == id select p).First();
                    context.tbTipoPromocaos.DeleteObject(delete);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<TipoPromocaoEntity> CastListsTipoPromocaoEntity(List<tbTipoPromocao> tbTipoPromocao)
        {
            List<TipoPromocaoEntity> lst = new List<TipoPromocaoEntity>();

            foreach (var TipoPromocao in tbTipoPromocao)
            {
                TipoPromocaoEntity tipoPromocao = new TipoPromocaoEntity();

                tipoPromocao.DataUltimaAlteracao = TipoPromocao.DataUltimaAlteracao;
                tipoPromocao.id = TipoPromocao.id;
                tipoPromocao.Nome = TipoPromocao.Nome;
                tipoPromocao.responsavelUltimaAlteracao = TipoPromocao.responsavelUltimaAlteracao;

                lst.Add(tipoPromocao);

            }

            return lst;
        }

        private tbTipoPromocao CastTipoPromocao(TipoPromocaoEntity TipoPromocao)
        {
            tbTipoPromocao tb = new tbTipoPromocao();

            tb.DataUltimaAlteracao = TipoPromocao.DataUltimaAlteracao;
            tb.id = TipoPromocao.id;
            tb.Nome = TipoPromocao.Nome;
            tb.responsavelUltimaAlteracao = TipoPromocao.responsavelUltimaAlteracao;

            return tb;
        }
    }
}
