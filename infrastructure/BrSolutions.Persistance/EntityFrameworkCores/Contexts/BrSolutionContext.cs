using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BrSolutions.Persistance.EntityFrameworkCores.Contexts;

public class BrSolutionContext : DbContext
{


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(CoreSetting.Instance.DatabaseSetting.BrSolutionDatabaseConnectionString);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DbInitialize.Init(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
