#region

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RedFox.Application.Service.Infrastructure;
using RedFox.Domain.Entities;

#endregion

namespace RedFox.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Address> Addresses => Set<Address>();

    public DbSet<Geo> Geos => Set<Geo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}