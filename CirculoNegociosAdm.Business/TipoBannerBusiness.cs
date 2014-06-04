using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class TipoBannerBusiness
    {
        TipoBannerDAL lObjTipoBannerDAL = new TipoBannerDAL();

        public List<TipoBannerEntity> ConsultaTodosTipoBanner()
        {
            return lObjTipoBannerDAL.ConsultaTodosTipoBanner();
        }

        public string InsereTipoBanner(TipoBannerEntity categoriaCliente)
        {
            bool ret = lObjTipoBannerDAL.InsereTipoBanner(categoriaCliente);

            if (ret)
                return "Tipo Banner incluido com sucesso!";
            else
                return "Ocorreu um erro ao incluir o Tipo de Banner!";

        }

        public string DeletaTipoBanner(int id)
        {
            bool ret = lObjTipoBannerDAL.DeletaTipoBanner(id);

            if (ret)
                return "Tipo Banner excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o Tipo de Banner!";

        }
    }
}
