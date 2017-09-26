using System.Collections.Generic;
using VideoMenuDAL.Context;
using System.Linq;
using VideoMenuDal.Entities;

namespace VideoMenuDAL.Repositories
{
    class VideoRepositoriesEFMemory : iVideoRepostiory
    {
        InMemoryContext _context;

        public VideoRepositoriesEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Videos Create(Videos vid)
        {
            
            _context.Videos.Add(vid);
            return vid;
        }

        public List<Videos> Getall()
        {
            return _context.Videos.ToList();
        }

        public Videos Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public Videos Delete(int Id)
        {
            var vid = Get(Id);
            _context.Videos.Remove(vid);
            return vid;
        }
    }

}
