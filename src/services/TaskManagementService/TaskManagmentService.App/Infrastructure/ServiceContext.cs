using Microsoft.EntityFrameworkCore;
using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Infrastructure;

internal sealed class ServiceContext : DbContext
{
    public DbSet<Assignment> Assignments => Set<Assignment>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<AssignmentEmployee> AssignmentEmployees => Set<AssignmentEmployee>();

    public DbSet<AssignmentGroup> AssignmentGroups => Set<AssignmentGroup>();
    
    public DbSet<Project> Projects => Set<Project>();

    public ServiceContext(DbContextOptions<ServiceContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
