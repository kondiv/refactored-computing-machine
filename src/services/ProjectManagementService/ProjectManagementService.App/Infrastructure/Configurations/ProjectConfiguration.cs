using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementService.App.Domain.Entities;

namespace ProjectManagementService.App.Infrastructure.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedNever();

        builder
            .Property(p => p.Name)
            .HasMaxLength(128);

        builder
            .Property(p => p.Description)
            .HasMaxLength(1024);

        builder
            .HasOne(p => p.Supervisor)
            .WithMany()
            .HasForeignKey(p => p.SupervisorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(p => p.Manager)
            .WithMany()
            .HasForeignKey(p => p.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(GenerateProjectsList());
    }

    private static List<Project> GenerateProjectsList()
    {
        return [
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                Name = "Name1",
                Description = "Description1",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                Name = "Name2",
                Description = "Description2",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222203"),
                Name = "Name3",
                Description = "Description3",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222204"),
                Name = "Name4",
                Description = "Description4",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222205"),
                Name = "Name5",
                Description = "Description5",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222206"),
                Name = "Name6",
                Description = "Description6",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222207"),
                Name = "Name7",
                Description = "Description7",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222208"),
                Name = "Name8",
                Description = "Description8",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222209"),
                Name = "Name9",
                Description = "Description9",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222210"),
                Name = "Name10",
                Description = "Description10",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222211"),
                Name = "Name11",
                Description = "Description11",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222212"),
                Name = "Name12",
                Description = "Description12",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222213"),
                Name = "Name13",
                Description = "Description13",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222214"),
                Name = "Name14",
                Description = "Description14",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222215"),
                Name = "Name15",
                Description = "Description15",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222216"),
                Name = "Name16",
                Description = "Description16",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222217"),
                Name = "Name17",
                Description = "Description17",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222218"),
                Name = "Name18",
                Description = "Description18",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222219"),
                Name = "Name19",
                Description = "Description19",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111112")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222220"),
                Name = "Name20",
                Description = "Description20",
                SupervisorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                ManagerId = Guid.Parse("11111111-1111-1111-1111-111111111113")
            }
        ];
    }
}
