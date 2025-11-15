using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentService.App.Domain.ValueTypes.Result.Errors;
using TaskManagmentService.App.Features.AddAssignmentExecutor;
using TaskManagmentService.App.Features.AddAssignmentObserver;
using TaskManagmentService.App.Features.ChangeStatus;
using TaskManagmentService.App.Features.CreateAssignment;
using TaskManagmentService.App.Features.DeleteAssignment;
using TaskManagmentService.App.Features.GetAssignment;
using TaskManagmentService.App.Features.ListAssignments;
using TaskManagmentService.App.Features.UpdateAssignment;

namespace TaskManagmentService.App.Controllers;

[ApiController]
[Route("api/assignments/")]
public sealed class AssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<GetAssignmentDto>>> ListAsync(
        [FromQuery] int page = 1,
        [FromQuery] int maxPageSize = 10,
        [FromQuery] Guid? employeeId = null,
        [FromQuery] Guid? projectId = null,
        [FromQuery] Guid? assignmentGroupId = null,
        CancellationToken cancellationToken = default)
    {
        var request = new ListAssignmentsRequest(page, maxPageSize, employeeId, assignmentGroupId, projectId);

        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("{id:guid}", Name = "GetAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetAssignmentDto>> GetAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var request = new GetAssignmentRequest(id);

        var getResult = await _mediator.Send(request, cancellationToken);

        if (getResult.Succeeded)
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateAsync(CreateAssignmentApiRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAssignmentCommand(
            request.Title,
            request.Description,
            request.ProjectId,
            request.AssignmentGroupId,
            request.DeadLineUtc,
            request.AssignmentStatus,
            request.Priority);


        var createResult = await _mediator.Send(command, cancellationToken);

        if (createResult.Succeeded)
        {
            return CreatedAtRoute("GetAsync", new { id = createResult.Value.Id }, createResult.Value);
        }

        return createResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(createResult.Error.Message),
            _ => BadRequest(createResult.Error.Message)
        };
    }

    [HttpPost("{id:guid}/executors:add")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AddExecutorAsync([FromRoute] Guid id, [FromQuery] Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var command = new AddAssignmentExecutorCommand(id, employeeId);

        var addExecutorResult = await _mediator.Send(command, cancellationToken);

        if (addExecutorResult.Succeeded)
        {
            return NoContent();
        }

        return addExecutorResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(addExecutorResult.Error.Message),
            ErrorCode.DbUpdate => Conflict(addExecutorResult.Error.Message),
            _ => BadRequest(addExecutorResult.Error.Message)
        };
    }

    [HttpPost("{id:guid}/observers:add")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AddObserverAsync([FromRoute] Guid id, [FromQuery] Guid employeeId,
        CancellationToken cancellationToken = default)
    {
        var command = new AddAssignmentObserverCommand(id, employeeId);

        var addObserverResult = await _mediator.Send(command, cancellationToken);

        if (addObserverResult.Succeeded)
        {
            return NoContent();
        }

        return addObserverResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(addObserverResult.Error.Message),
            ErrorCode.DbUpdate => Conflict(addObserverResult.Error.Message),
            _ => BadRequest(addObserverResult.Error.Message)
        };
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, JsonPatchDocument<UpdateAssignmentDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateAssignmentCommand(id, patchDocument);

        var updateResult = await _mediator.Send(command, cancellationToken);

        if (updateResult.Succeeded)
        {
            return NoContent();
        }

        return updateResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(updateResult.Error.Message),
            _ => BadRequest(updateResult.Error.Message)
        };
    }

    [HttpPost("{id:guid}/status:change")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateStatusAsync([FromRoute] Guid id, [FromQuery] string status,
        CancellationToken cancellationToken = default)
    {
        var command = new ChangeStatusCommand(id, status);

        var updateStatusResult = await _mediator.Send(command, cancellationToken);

        if (updateStatusResult.Succeeded)
        {
            return NoContent();
        }

        var errorMessage = updateStatusResult.Error.Message;

        return updateStatusResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(errorMessage),
            ErrorCode.DbUpdateConcurrency => Conflict(errorMessage),
            _ => BadRequest(errorMessage)
        };
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteAssignmentCommand(id);

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
