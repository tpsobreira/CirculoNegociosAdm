using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class TipoPromocaoBusiness
    {
        TipoPromocaoDAL lObjTipoPromocaoDAL = new TipoPromocaoDAL();

        public List<TipoPromocaoEntity> ConsultaTodosTipoPromocao()
        {
            return lObjTipoPromocaoDAL.ConsultaTodosTipoPromocao();
        }

        public string InsereTipoPromocao(TipoPromocaoEntity categoriaCliente)
        {
            bool ret = lObjTipoPromocaoDAL.InsereTipoPromocao(categoriaCliente);

            if (ret)
                return "Tipo Promocao incluido com sucesso!";
            else
                return "Ocorreu um erro ao incluir o Tipo de Promocao!";

        }

        public string DeletaTipoPromocao(int id)
        {
            bool ret = lObjTipoPromocaoDAL.DeletaTipoPromocao(id);

            if (ret)
                return "Tipo Promocao excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o Tipo de Promocao!";

        }
    }
}
