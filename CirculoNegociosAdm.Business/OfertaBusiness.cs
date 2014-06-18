using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class OfertaBusiness
    {
        OfertaDAL lObjOfertaDAL = new OfertaDAL();

        public List<OfertaEntity> ConsultaTodasOfertas()
        {
            return lObjOfertaDAL.ConsultaTodasOfertas();
        }

        public int InsereOferta(OfertaEntity oferta)
        {
            return lObjOfertaDAL.InsereOferta(oferta);
        }

        public string DeletaOferta(int id)
        {
            bool ret = lObjOfertaDAL.DeletaOferta(id);

            if (ret)
                return "Oferta excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a Oferta!";
        }
    }
}
