using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Carriers> Carriers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CarrierConfigurations> CarrierConfigurations { get; set; }

        


    }
}
