using System.Collections.Generic;
using System.Linq;
using VideoMenuDal.Entities;

namespace VideoMenuDAL.Repositories
{
    class VideoRepositoriesFakeDB : iVideoRepostiory
    {
        private static int Id = 1;
        private static List<Videos> Videos = new List<Videos>();

        public Videos Create(Videos vid)
        {
            Videos newVid;
            Videos.Add(newVid = new Videos()
            {
                Id = Id++,
                Titel = vid.Titel,
                Director = vid.Director,
                Playtime = vid.Playtime

            });
            return newVid;
        }

        public List<Videos> Getall()
        {
            return new List<Videos>(Videos);
        }

        public Videos Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public Videos Delete(int Id)
        {
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }
    }
}
