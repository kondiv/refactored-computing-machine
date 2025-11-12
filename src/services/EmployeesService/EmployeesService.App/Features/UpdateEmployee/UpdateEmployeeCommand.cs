using EmployeesService.App.Domain.ValueTypes.Result;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeesService.App.Features.UpdateEmployee;

internal sealed record UpdateEmployeeCommand(Guid Id, JsonPatchDocument<UpdateEmployeeDto> PatchDocument) 
    : IRequest<Result>;
