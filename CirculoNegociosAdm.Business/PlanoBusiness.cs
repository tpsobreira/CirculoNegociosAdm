using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class PlanoBusiness
    {
        PlanoDAL lObjPlanoDAL = new PlanoDAL();

        public List<PlanoEntity> ConsultaTodosPlanos()
        {
            return lObjPlanoDAL.ConsultaTodosPlanos();
        }
    }
}
