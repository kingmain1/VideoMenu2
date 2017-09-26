using System.Collections.Generic;
using VideoMenuDal.Entities;

namespace VideoMenuDAL
{
    public interface iVideoRepostiory
    {
        //C
        Videos Create(Videos vid);
        //R
        List<Videos> Getall();
        Videos Get(int Id);
        //U
        // No Update for repostiory, it will be the task of Unit of Work
        //D
        Videos Delete(int Id);
    }
}
