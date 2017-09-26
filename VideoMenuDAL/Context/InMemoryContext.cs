using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using VideoMenuDal.Entities;

namespace VideoMenuDAL.Context
{
    class InMemoryContext : DbContext
    {
        private static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;
        public InMemoryContext() : base(options)
        {
        }

        public DbSet<Videos> Videos { get; set; }
}
}
