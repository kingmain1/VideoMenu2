using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDal.Entities;
using VideoMenuDAL;


namespace VideoMenuBLL.Services
{
    class VideoService : iVideoService
    {
        VideoConverter conv = new VideoConverter();
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

    public VideosBO Create(VideosBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepostiory.Create(conv.Convert(vid));
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public List<VideosBO> Getall()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepostiory.Getall().Select(c => conv.Convert(c)).ToList();

            }
        }

        public VideosBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepostiory.Get(Id));

            }
        }

        public VideosBO Update(VideosBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videosFromDb = uow.VideoRepostiory.Get(vid.Id);
                if (videosFromDb == null)
            
            {
                throw new InvalidOperationException("Video not found");
            }
            videosFromDb.Titel = vid.Titel;
            videosFromDb.Director = vid.Director;
            videosFromDb.Playtime = vid.Playtime;
            uow.Complete();
            return conv.Convert(videosFromDb);
            }

        }


        public VideosBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepostiory.Delete(Id);
                uow.Complete();
                return conv.Convert(newVid);
            }
        }
    }
}