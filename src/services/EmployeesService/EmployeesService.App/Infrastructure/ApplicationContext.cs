using EmployeesService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesService.App.Infrastructure;

internal sealed class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
