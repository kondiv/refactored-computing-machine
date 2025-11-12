using EmployeesService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesService.App.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Username).IsUnique();

        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder
            .Property(e => e.Surname)
            .HasMaxLength(128)
            .HasColumnName("surname");

        builder
            .Property(e => e.Name)
            .HasMaxLength(128)
            .HasColumnName("name");
        
        builder
            .Property(e => e.Patronymic)
            .HasMaxLength(128)
            .HasColumnName("patronymic");
        
        builder
            .Property(e => e.Username)
            .HasMaxLength(64)
            .HasColumnName("username");
        
        builder
            .Property(e => e.Role)
            .HasConversion<string>()
            .HasColumnName("role");
    }
}
