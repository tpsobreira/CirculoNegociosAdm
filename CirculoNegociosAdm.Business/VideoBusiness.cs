using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class VideoBusiness
    {
        VideoDAL lObjVideoDAL = new VideoDAL();

        public List<VideoEntity> ConsultaTodosVideos()
        {
            return lObjVideoDAL.ConsultaTodosVideos();
        }

        public int InsereVideo(VideoEntity video)
        {
            return lObjVideoDAL.InsereVideo(video);
        }

        public string DeletaVideo(int idVideo)
        {
            bool ret = lObjVideoDAL.DeletaVideo(idVideo);

            if (ret)
                return "Vídeo Excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o vídeo!";
        }
    }
}
