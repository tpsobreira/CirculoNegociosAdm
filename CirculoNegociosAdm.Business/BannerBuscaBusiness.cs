using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class BannerBuscaBusiness
    {
        BannerBuscaDAL lObjBannerBuscaDAL = new BannerBuscaDAL();

        public List<BannerBuscaEntity> ConsultaTodosBannerBuscas()
        {
            return lObjBannerBuscaDAL.ConsultaTodosBannerBuscas();
        }

        public int InsereBannerBusca(BannerBuscaEntity banner)
        {
            return lObjBannerBuscaDAL.InsereBannerBusca(banner);
        }

        public void AtualizaFilePathImagemBannerBusca(int idBannerBusca, string filePath)
        {
            lObjBannerBuscaDAL.AtualizaFilePathImagemBannerBusca(idBannerBusca, filePath);
        }

        public string DeletaBannerBusca(int id)
        {
            bool ret = lObjBannerBuscaDAL.DeletaBannerBusca(id);

            if (ret)
                return "BannerBusca excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o BannerBusca!";
        }
    }
}
