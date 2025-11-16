using Microsoft.EntityFrameworkCore;
using ProjectManagementService.App.Domain.Entities;

namespace ProjectManagementService.App.Infrastructure;

internal sealed class ServiceContext : DbContext
{
    public DbSet<Project> Projects => Set<Project>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Assignment> Assignments => Set<Assignment>();

    public ServiceContext(DbContextOptions<ServiceContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
