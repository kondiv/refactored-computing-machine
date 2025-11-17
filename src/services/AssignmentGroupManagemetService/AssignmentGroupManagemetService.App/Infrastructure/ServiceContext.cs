using AssignmentGroupManagemetService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssignmentGroupManagemetService.App.Infrastructure;

internal sealed class ServiceContext : DbContext
{
    public DbSet<AssignmentGroup> AssignmentGroups => Set<AssignmentGroup>();
    
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
