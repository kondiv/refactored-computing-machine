namespace ProjectManagementService.App.Features.CreateProject;

public sealed record CreateProjectApiRequest(string Name, string Description, Guid SupervisorId, Guid ManagerId);

