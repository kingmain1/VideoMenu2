using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Repositories;

namespace VideoMenuDAL.UOW
{
    class UnitOfWorkMem : iUnitOfWork
    {
        public iVideoRepostiory VideoRepostiory { get; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepostiory = new VideoRepositoriesEFMemory(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}

