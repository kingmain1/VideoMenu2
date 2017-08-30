using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL;
using VideoMenuEntity;

namespace VideoMenuBLL.Services
{
    class VideoService : iVideoService
    {
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

    public Videos Create(Videos vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepostiory.Create(vid);
                uow.Complete();
                return newVid;
            }
        }

        public List<Videos> Getall()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepostiory.Getall();

            }
        }

        public Videos Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepostiory.Get(Id);

            }
        }

        public Videos Update(Videos vid)
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
            return videosFromDb;
            }

        }

        public Videos Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepostiory.Delete(Id);
                uow.Complete();
                return newVid;
            }
        }
    }
}