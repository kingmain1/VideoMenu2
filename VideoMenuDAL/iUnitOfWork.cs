using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuDAL
{
    public interface iUnitOfWork : IDisposable
    {
        iVideoRepostiory VideoRepostiory { get ; }

        int Complete();
    }
}
