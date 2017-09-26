using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDal.Entities;

namespace VideoMenuBLL
{
    public interface iVideoService
    {
        //C
        VideosBO Create(VideosBO vid);

        //R
        List<VideosBO> Getall();

        VideosBO Get(int Id);
        //U
        VideosBO Update(VideosBO vid);        

        //D
        VideosBO Delete(int Id);
    }
}
