using AssignmentGroupManagemetService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssignmentGroupManagemetService.App.Infrastructure.Configurations;

internal sealed class AssignmentGroupConfiguration : IEntityTypeConfiguration<AssignmentGroup>
{
    public void Configure(EntityTypeBuilder<AssignmentGroup> builder)
    {
        builder.HasKey(ag => ag.Id);

        builder.Property(ag => ag.Name).HasMaxLength(128);

        builder.HasData(GenerateAssignmentGroupLists());
    }

    private static List<AssignmentGroup> GenerateAssignmentGroupLists()
    {
        return [
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Name1" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Name = "Name2" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Name = "Name3" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), Name = "Name4" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), Name = "Name5" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), Name = "Name6" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), Name = "Name7" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111118"), Name = "Name8" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111119"), Name = "Name9" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111120"), Name = "Name10" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111121"), Name = "Name11" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111122"), Name = "Name12" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111123"), Name = "Name13" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111124"), Name = "Name14" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111125"), Name = "Name15" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111126"), Name = "Name16" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111127"), Name = "Name17" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111128"), Name = "Name18" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111129"), Name = "Name19" },
            new AssignmentGroup{ Id = Guid.Parse("11111111-1111-1111-1111-111111111130"), Name = "Name20" }
            ];
    }
}
