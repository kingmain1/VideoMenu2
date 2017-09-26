using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuDal.Entities;

namespace VideoMenuBLL.Converters
{
    class VideoConverter
    {

        internal Videos Convert(VideosBO vid)
        {
            return new Videos()
            {
                Id = vid.Id,
                Titel = vid.Titel,
                Director = vid.Director,
                Playtime = vid.Playtime                
            };
        }

        internal VideosBO Convert(Videos vid)
        {
            return new VideosBO()
            {
                Id = vid.Id,
                Titel = vid.Titel,
                Director = vid.Director,
                Playtime = vid.Playtime
            };
        }
    }
}
