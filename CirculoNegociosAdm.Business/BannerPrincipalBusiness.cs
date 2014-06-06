using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DAL;

namespace CirculoNegociosAdm.Business
{
    public class BannerPrincipalBusiness
    {
        BannerPrincipalDAL lObjBannerPrincipalDAL = new BannerPrincipalDAL();

        public List<BannerPrincipalEntity> ConsultaTodosBannerPrincipals()
        {
            return lObjBannerPrincipalDAL.ConsultaTodosBannerPrincipals();
        }

        public int InsereBannerPrincipal(BannerPrincipalEntity banner)
        {
            return lObjBannerPrincipalDAL.InsereBannerPrincipal(banner);
        }

        public void AtualizaFilePathImagemBannerPrincipal(int idBannerPrincipal, string filePath)
        {
            lObjBannerPrincipalDAL.AtualizaFilePathImagemBannerPrincipal(idBannerPrincipal, filePath);
        }

        public string DeletaBannerPrincipal(int id)
        {
            bool ret = lObjBannerPrincipalDAL.DeletaBannerPrincipal(id);

            if (ret)
                return "BannerPrincipal excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o BannerPrincipal!";
        }
    }
}
