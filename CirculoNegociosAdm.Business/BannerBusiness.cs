using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class BannerBusiness
    {
        BannerDAL lObjBannerDAL = new BannerDAL();

        public List<BannerEntity> ConsultaTodosBanners()
        {
            return lObjBannerDAL.ConsultaTodosBanners();
        }

        public int InsereBanner(BannerEntity banner)
        {
            return lObjBannerDAL.InsereBanner(banner);
        }

        public void AtualizaFilePathImagemBanner(int idBanner, string filePath)
        {
            lObjBannerDAL.AtualizaFilePathImagemBanner(idBanner, filePath);
        }

        public string DeletaBanner(int id)
        {
            bool ret = lObjBannerDAL.DeletaBanner(id);

            if (ret)
                return "Banner excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o Banner!";
        }
    }
}
