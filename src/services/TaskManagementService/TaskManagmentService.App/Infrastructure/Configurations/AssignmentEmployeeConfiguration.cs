using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Infrastructure.Configurations;

internal sealed class AssignmentEmployeeConfiguration : IEntityTypeConfiguration<AssignmentEmployee>
{
    public void Configure(EntityTypeBuilder<AssignmentEmployee> builder)
    {
        builder.ToTable("assignment_employee");

        builder.HasKey(ae => new { ae.AssignmentId, ae.EmployeeId });

        builder
            .Property(ae => ae.EmployeeId)
            .HasColumnName("employee_id");

        builder
            .Property(ae => ae.AssignmentId)
            .HasColumnName("assignment_id");

        builder
            .Property(ae => ae.AssignmentRole)
            .HasConversion<string>()
            .HasColumnName("assignment_role");

        builder
            .HasOne(ae => ae.Assignment)
            .WithMany(a => a.AssignmentEmployees)
            .HasForeignKey(ae => ae.AssignmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ae => ae.Employee)
            .WithMany()
            .HasForeignKey(ae => ae.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(GenerateAssignmentEmployeesList());
    }

    private static List<AssignmentEmployee> GenerateAssignmentEmployeesList()
    {
        return [
            // Задача 1 - 3 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111118"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111119"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111114"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 2 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111112"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111120"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111112"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111115"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 3 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111113"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111121"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111113"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111116"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 4 - 3 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111114"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111122"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111114"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111117"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111114"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111125"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 5 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111115"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111123"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111115"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111126"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 6 - 1 сотрудник
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111116"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111124"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },

            // Задача 7 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111117"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111127"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111117"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111128"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 8 - 1 сотрудник
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111118"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111129"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },

            // Задача 9 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111119"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111130"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111119"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111118"), AssignmentRole = Domain.Enums.AssignmentRole.Observer },

            // Задача 10 - 2 сотрудника
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111120"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111119"), AssignmentRole = Domain.Enums.AssignmentRole.Executor },
            new AssignmentEmployee { AssignmentId = Guid.Parse("11111111-1111-1111-1111-111111111120"), EmployeeId = Guid.Parse("11111111-1111-1111-1111-111111111120"), AssignmentRole = Domain.Enums.AssignmentRole.Observer }
        ];
    }
}