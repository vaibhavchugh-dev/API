using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rwaAPI.Data.Models;

namespace rwaAPI.Data
{
    public class rwaAPIContext : DbContext
    {
        public rwaAPIContext (DbContextOptions<rwaAPIContext> options) : base(options)  {}

        

        public DbSet<rwaAPI.Data.Models.towers> towers { get; set; }

        

        public DbSet<rwaAPI.Data.Models.owners> owners { get; set; }

        public DbSet<rwaAPI.Data.Models.ownerList> ownerlist { get; set; }

    }
}
