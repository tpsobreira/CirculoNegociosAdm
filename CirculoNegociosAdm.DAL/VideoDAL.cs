using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class VideoDAL
    {
        public List<VideoEntity> ConsultaTodosVideos()
        {
            List<VideoEntity> lstVideos = new List<VideoEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbVideos
                           select p).ToList();

                lstVideos = CastListEntityVideo(ret);
            }

            return lstVideos;
        }

        public int InsereVideo(VideoEntity video)
        {
            int idVideo = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbVideo tb = CastVideoEntity(video);
                    context.tbVideos.AddObject(tb);
                    context.SaveChanges();

                    idVideo = tb.id;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idVideo;
        }

        public bool DeletaVideo(int idVideo)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbVideo delete = (from p in context.tbVideos where p.id == idVideo select p).First();
                    context.tbVideos.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private tbVideo CastVideoEntity(VideoEntity objVideo)
        {
            tbVideo video = new tbVideo();

            video.ativo = objVideo.ativo;
            video.dataUltimaAlteracao = objVideo.dataUltimaAlteracao;
            video.descricao = objVideo.descricao;
            video.estado = objVideo.estado;
            video.id = objVideo.id;
            video.imagemHomeFilePath = objVideo.imagemHomeFilePath;
            video.responsavelUltimaAlteracao = objVideo.responsavelUltimaAlteracao;
            video.titulo = objVideo.titulo;
            video.videoFilePath = objVideo.videoFilePath;

            return video;
        }

        private List<VideoEntity> CastListEntityVideo(List<tbVideo> lstEntityVideos)
        {
            List<VideoEntity> lst = new List<VideoEntity>();

            foreach (var item in lstEntityVideos)
            {
                VideoEntity obj = new VideoEntity();

                obj.ativo = item.ativo;
                obj.dataUltimaAlteracao = item.dataUltimaAlteracao;
                obj.descricao = item.descricao;
                obj.estado = item.estado;
                obj.id = item.id;
                obj.imagemHomeFilePath = item.imagemHomeFilePath;
                obj.responsavelUltimaAlteracao = item.responsavelUltimaAlteracao;
                obj.titulo = item.titulo;
                obj.videoFilePath = item.videoFilePath;

                lst.Add(obj);
            }

            return lst;
        }
    }
}
