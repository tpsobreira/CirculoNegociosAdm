using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class EstadoDAL
    {
        public List<EstadoEntity> ConsultaTodosEstados()
        {
            List<EstadoEntity> lstEstado = new List<EstadoEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbEstados
                           select p).ToList();

                lstEstado = CastListEstadoEntity(ret);
            }

            return lstEstado;
        }

        public bool InsereEstado(EstadoEntity Estado)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbEstados.AddObject(CastEstado(Estado));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaEstado(string sigla)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbEstado delete = (from p in context.tbEstados where p.sigla == sigla select p).First();
                    context.tbEstados.DeleteObject(delete);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private List<EstadoEntity> CastListEstadoEntity(List<tbEstado> tbEstado)
        {
            List<EstadoEntity> lstEstado = new List<EstadoEntity>();

            foreach (var item in tbEstado)
            {
                EstadoEntity objEstado = new EstadoEntity();
                objEstado.sigla = item.sigla;
                objEstado.nome = item.nome;

                lstEstado.Add(objEstado);
            }

            return lstEstado;
        }

        private tbEstado CastEstado(EstadoEntity estado)
        {
            tbEstado tb = new tbEstado();

            tb.sigla = estado.sigla;
            tb.nome = estado.nome;

            return tb;
        }
        
    }
}
