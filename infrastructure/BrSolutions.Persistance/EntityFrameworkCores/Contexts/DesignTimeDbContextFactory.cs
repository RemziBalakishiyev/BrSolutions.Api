using BrSolution.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;

namespace BrSolutions.Persistance.EntityFrameworkCores.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BrSolutionContext>
    {
        public BrSolutionContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BrSolutionContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(CoreSetting.Instance.DatabaseSetting.BrSolutionDatabaseConnectionString);
            return new BrSolutionContext();
        }
    }
}
