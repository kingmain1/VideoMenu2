using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuEntity;

namespace VideoMenuBLL
{
    public interface iVideoService
    {
        //C
        Videos Create(Videos vid);

        //R
        List<Videos> Getall();

        Videos Get(int Id);
        //U
        Videos Update(Videos vid);

        //D
        Videos Delete(int Id);
    }
}
