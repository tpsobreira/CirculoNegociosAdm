using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;

namespace CirculoNegociosAdm.DAL
{
    public class PlanoDAL
    {
        public List<PlanoEntity> ConsultaTodosPlanos()
        {
            List<PlanoEntity> lstPlanos = new List<PlanoEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbPlanos
                           select p).ToList();

                lstPlanos = CastEntityPlanos(ret);
            }

            return lstPlanos;
        }

        private List<PlanoEntity> CastEntityPlanos(List<tbPlano> planos)
        {
            List<PlanoEntity> lst = new List<PlanoEntity>();

            foreach (var item in planos)
            {
                PlanoEntity plano = new PlanoEntity();

                plano.dataExpira = item.dataExpira;
                plano.DataUltimaAlteracao = item.DataUltimaAlteracao;
                plano.id = item.id;
                plano.Nome = item.Nome;
                plano.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                plano.Valor = item.Valor;

                lst.Add(plano);
            }

            return lst;
        }
    }
}
