using EmployeesService.App.Domain.ValueTypes.Result.Errors;
using EmployeesService.App.Features.CreateEmployee;
using EmployeesService.App.Features.DeleteEmployee;
using EmployeesService.App.Features.GetEmployee;
using EmployeesService.App.Features.ListEmployees;
using EmployeesService.App.Features.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesService.App.Controllers;

[Route("api/employees/")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<GetEmployeeDto>>> ListAsync(
        [FromQuery] int page = 1,
        [FromQuery] int maxPageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var request = new ListEmployeesRequest(page, maxPageSize);

        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("{id:guid}", Name = "GetAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetEmployeeDto>> GetAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetEmployeeRequest(id);

        var getResult = await _mediator.Send(request, cancellationToken);

        if(getResult.Succeeded)
        {
            return Ok(getResult.Value);
        }

        return getResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(getResult.Error.Message),
            _ => BadRequest(getResult.Error.Message)
        };
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateAsync(
        [FromBody] CreateEmployeeRequestDto createDto, 
        CancellationToken cancellationToken = default)
    {
        var command = new CreateEmployeeCommand(
            createDto.Surname,
            createDto.Name,
            createDto.Patronymic,
            createDto.Username,
            createDto.Role);

        var createResult = await _mediator.Send(command, cancellationToken);

        if(createResult.Succeeded)
        {
            return CreatedAtRoute("GetAsync", new { id = createResult.Value.Id }, createResult.Value);
        }

        return createResult.Error.ErrorCode switch
        {
            ErrorCode.DbUpdate => Conflict(createResult.Error.Message),
            _ => BadRequest(createResult.Error.Message)
        };
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid id,
        JsonPatchDocument<UpdateEmployeeDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateEmployeeCommand(id, patchDocument);

        var updateResult = await _mediator.Send(command, cancellationToken);

        if(updateResult.Succeeded)
        {
            return NoContent();
        }

        return updateResult.Error.ErrorCode switch
        {
            ErrorCode.DbUpdate => Conflict(updateResult.Error.Message),
            _ => BadRequest(updateResult.Error.Message)
        };
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id, 
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteEmployeeCommand(id);

        var deleteResult = await _mediator.Send(command, cancellationToken);

        if(deleteResult.Succeeded)
        {
            return NoContent();
        }

        return deleteResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(deleteResult.Error.Message),
            _ => BadRequest(deleteResult.Error.Message)
        };
    }
}
