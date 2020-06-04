using CiResultAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Models.DbContexts
{
    public class TrxResultsContext : DbContext
    {
        public TrxResultsContext(DbContextOptions<TrxResultsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Result> Results { get; set; }
        public DbSet<ErrorImage> ErrorImages { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<CIExecution> CIExecutions { get; set; }
    }
}
