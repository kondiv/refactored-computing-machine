using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Infrastructure.Configurations;

internal sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedNever();

        builder
            .Property(a => a.Title)
            .HasMaxLength(128);

        builder
            .Property(a => a.Description)
            .HasMaxLength(512);

        builder
            .Property(a => a.DeadlineUtc)
            .ValueGeneratedNever();

        builder
            .Property(a => a.CreatedAtUtc)
            .HasDefaultValueSql("now()");

        builder
            .Property(a => a.AssignmentStatus)
            .HasConversion<string>()
            .IsConcurrencyToken();

        builder
            .HasOne<Project>()
            .WithMany()
            .HasForeignKey(a => a.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<AssignmentGroup>()
            .WithMany()
            .HasForeignKey(a => a.AssignmentGroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(a => a.Priority)
            .HasConversion<string>();

        builder
            .Ignore(a => a.Observers)
            .Ignore(a => a.Executors);

        builder.HasData(GenerateAssignmentsList());
    }

    private static List<Assignment> GenerateAssignmentsList()
    {
        return [
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "Title1",
                Description = "Description1",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 11, 16, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 5, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Title = "Title2",
                Description = "Description2",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 11, 17, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 10, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Title = "Title3",
                Description = "Description3",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 11, 18, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 15, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Title = "Title4",
                Description = "Description4",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 20, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                Title = "Title5",
                Description = "Description5",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 20, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 25, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111116"),
                Title = "Title6",
                Description = "Description6",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 30, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111117"),
                Title = "Title7",
                Description = "Description7",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222205"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 11, 22, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 35, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111118"),
                Title = "Title8",
                Description = "Description8",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 11, 23, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 40, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                Title = "Title9",
                Description = "Description9",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 24, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 45, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                Title = "Title10",
                Description = "Description10",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                DeadlineUtc = new DateTime(2025, 11, 25, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 50, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                Title = "Title11",
                Description = "Description11",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 26, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 0, 55, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                Title = "Title12",
                Description = "Description12",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 11, 27, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 0, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                Title = "Title13",
                Description = "Description13",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222204"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                DeadlineUtc = new DateTime(2025, 11, 28, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 5, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                Title = "Title14",
                Description = "Description14",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                DeadlineUtc = new DateTime(2025, 11, 29, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 10, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                Title = "Title15",
                Description = "Description15",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111115"),
                DeadlineUtc = new DateTime(2025, 11, 30, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 15, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                Title = "Title16",
                Description = "Description16",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 12, 1, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 20, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111127"),
                Title = "Title17",
                Description = "Description17",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                DeadlineUtc = new DateTime(2025, 12, 2, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 25, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111128"),
                Title = "Title18",
                Description = "Description18",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 12, 3, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 30, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111129"),
                Title = "Title19",
                Description = "Description19",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 12, 4, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 35, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            },
            new Assignment
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111130"),
                Title = "Title20",
                Description = "Description20",
                ProjectId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                AssignmentGroupId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                DeadlineUtc = new DateTime(2025, 12, 5, 0, 0, 0, DateTimeKind.Utc),
                CreatedAtUtc = new DateTime(2025, 11, 15, 1, 40, 0, DateTimeKind.Utc),
                AssignmentStatus = Domain.Enums.AssignmentStatus.Backlog,
                Priority = Domain.Enums.Priority.Medium
            }
        ];
    }
}
