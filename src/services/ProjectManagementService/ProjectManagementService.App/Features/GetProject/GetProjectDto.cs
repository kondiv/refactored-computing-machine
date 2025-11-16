using ProjectManagementService.App.Domain.Entities;

namespace ProjectManagementService.App.Features.GetProject;

public sealed class GetProjectDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Employee? Supervisor { get; set; }
    
    public Employee? Manager { get; set; }

}
