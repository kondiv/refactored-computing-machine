using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Infrastructure.Configurations;

internal sealed class AssignmentGroupConfiguration : IEntityTypeConfiguration<AssignmentGroup>
{
    public void Configure(EntityTypeBuilder<AssignmentGroup> builder)
    {
        builder.HasKey(ag => ag.Id);

        builder.HasData(GenerateAssignmentGroupList());
    }

    private static List<AssignmentGroup> GenerateAssignmentGroupList()
    {
        return [
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111112") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111113") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111114") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111115") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111116") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111117") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111118") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111119") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111120") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111121") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111122") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111123") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111124") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111125") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111126") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111127") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111128") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111129") },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111130") }
        ];
    }
}
