using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
{
    public class DALFacade
    {
        public iVideoRepostiory VideoRepostiory
        {
            //get { return new VideoRepositoriesFakeDB(); } 
            get { return new VideoRepositoriesEFMemory(
                                new InMemoryContext()); }

        }

        public iUnitOfWork UnitOfWork
        {

            get
            {
                return new UnitOfWorkMem();
            }

        }



    }
}
