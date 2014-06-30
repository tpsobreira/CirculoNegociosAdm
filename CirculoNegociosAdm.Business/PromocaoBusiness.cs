using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class PromocaoBusiness
    {
        PromocaoDAL lObjPromocaoDAL = new PromocaoDAL();

        public List<PromocaoEntity> ConsultaTodasPromocoes()
        {
            return lObjPromocaoDAL.ConsultaTodasPromocoes();
        }

        public int InserePromocao(PromocaoEntity promocao)
        {
            return lObjPromocaoDAL.InserePromocao(promocao);
        }

        public string DeletaPromocao(int id)
        {
            bool ret = lObjPromocaoDAL.DeletaPromocao(id);

            if (ret)
                return "Promocao excluida com sucesso!";
            else
                return "Ocorreu um erro ao excluir a Promocao!";
        }

        public void AtualizaFilePathImagemPromocao(int idPromocao, string filePath)
        {
            lObjPromocaoDAL.AtualizaFilePathImagemPromocao(idPromocao, filePath);
        }
    }
}
