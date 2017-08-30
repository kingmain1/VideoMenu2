using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.Services;
using VideoMenuDAL;

namespace VideoMenuBLL
{
    public class BLLFacade
    {
        public iVideoService VideoService
        {
            get {return new VideoService(new DALFacade());}
        }
    }
}
