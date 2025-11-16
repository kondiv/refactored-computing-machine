using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementService.App.Domain.Entities;

namespace ProjectManagementService.App.Infrastructure.Configurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Username).HasMaxLength(64);
        builder.Property(e => e.Role).HasMaxLength(64);

        builder.HasData(GenerateEmployeesList());
    }

    private static List<Employee> GenerateEmployeesList()
    {
        return [
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Username = "ivanov.ap", Role = "MANAGER" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Username = "petrova.ms", Role = "MANAGER" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Username = "sidorov.di", Role = "MANAGER" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), Username = "kozlova.av", Role = "ANALYST" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), Username = "fedorov.mo", Role = "ANALYST" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), Username = "nikitina.ed", Role = "ANALYST" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), Username = "orlov.sv", Role = "ANALYST" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111118"), Username = "volkov.aa", Role = "DEVELOPER" },
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111119"), Username = "zaitseva.oi", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111120"), Username = "pavlov.is", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111121"), Username = "semenova.tp", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111122"), Username = "morozov.av", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111123"), Username = "alekseev.vn", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111124"), Username = "kovaleva.ya", Role = "DEVELOPER"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111125"), Username = "grigorev.po", Role = "QA"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111126"), Username = "belova.nv", Role = "QA"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111127"), Username = "kiselev.ad", Role = "QA"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111128"), Username = "sokolova.ia", Role = "QA"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111129"), Username = "titov.rm", Role = "QA"},
            new Employee { Id = Guid.Parse("11111111-1111-1111-1111-111111111130"), Username = "medvedeva.sg", Role = "QA"}
        ];
    }
}
