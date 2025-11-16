namespace ProjectManagementService.App.Features.CreateProject;

public sealed record CreatedProjectDto(Guid Id, string Name, DateTime CreatedAtUtc);
