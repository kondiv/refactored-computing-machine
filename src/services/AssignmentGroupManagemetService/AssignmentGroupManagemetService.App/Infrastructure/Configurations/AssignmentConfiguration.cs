using AssignmentGroupManagemetService.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssignmentGroupManagemetService.App.Infrastructure.Configurations;

internal sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Status).HasMaxLength(64);

        builder.HasData(GenerateAssignmentsList());
    }

    private static List<Assignment> GenerateAssignmentsList()
    {
        return [
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111116"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111117"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111118"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111127"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111128"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111129"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111130"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Status = "Backlog"
            }
        ];
    }
}
