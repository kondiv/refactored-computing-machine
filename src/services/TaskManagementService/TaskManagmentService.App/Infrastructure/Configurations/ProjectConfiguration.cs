using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagmentService.App.Domain.Entities;

namespace TaskManagmentService.App.Infrastructure.Configurations;

internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasData(GenerateProjectList());
    }

    private static List<Project> GenerateProjectList()
    {
        return [
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222201")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222202")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222203")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222204")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222205")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222206")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222207")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222208")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222209")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222210")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222211")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222212")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222213")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222214")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222215")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222216")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222217")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222218")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222219")
            },
            new Project {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222220")
            }
            ];
    }
}
