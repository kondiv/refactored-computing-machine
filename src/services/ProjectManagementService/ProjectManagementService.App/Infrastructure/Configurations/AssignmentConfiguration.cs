using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementService.App.Domain.Entities;

namespace ProjectManagementService.App.Infrastructure.Configurations;

internal sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Status).HasMaxLength(64);

        builder
            .HasOne<Project>()
            .WithMany()
            .HasForeignKey(a => a.ProjectId);

        builder.HasData(GenerateAssignmentsList());
    }

    private static List<Assignment> GenerateAssignmentsList()
    {
        return [
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111116"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111117"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222205"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111118"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222204"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111127"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111128"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111129"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                Status = "Backlog"
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111130"),
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Status = "Backlog"
            }
        ];
    }
}
