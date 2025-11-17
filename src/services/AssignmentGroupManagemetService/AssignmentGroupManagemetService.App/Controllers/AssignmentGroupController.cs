using AssignmentGroupManagemetService.App.Domain.Result.Errors;
using AssignmentGroupManagemetService.App.Features.CreateAssignmentGroup;
using AssignmentGroupManagemetService.App.Features.DeleteAssignmentGroup;
using AssignmentGroupManagemetService.App.Features.GetAssignmentGroup;
using AssignmentGroupManagemetService.App.Features.ListAssignmentGroups;
using AssignmentGroupManagemetService.App.Features.UpdateAssignmentGroup;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentGroupManagemetService.App.Controllers;

[ApiController]
[Route("api/assignment-groups/")]
public sealed class AssignmentGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}", Name = "GetAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetAssignmentGroupDto>> GetAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetAssignmentGroupRequest(id);

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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyList<GetAssignmentGroupDto>>> ListAsync(
        [FromQuery] int page = 1,
        [FromQuery] int maxPageSize = 10,
        CancellationToken cancellationToken = default)
    {
        if(page < 1 || maxPageSize < 1)
        {
            return BadRequest();
        }

        var request = new ListAssignmentGroupsRequest(page, maxPageSize);

        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreatedAssignmentGroupDto>> CreateAsync(
        CreateAssignmentGroupApiRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateAssignmentGroupCommand(request.Name);

        var createResult = await _mediator.Send(command, cancellationToken);

        if (createResult.Succeeded)
        {
            return CreatedAtRoute("GetAsync", new { id = createResult.Value.Id }, createResult.Value);
        }

        return createResult.Error.ErrorCode switch
        {
            _ => BadRequest(createResult.Error.Message)
        };
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id,
        JsonPatchDocument<UpdateAssignmentGroupDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateAssignmentGroupCommand(id, patchDocument);

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

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteAssignmentGroupCommand(id);

        var deleteResult = await _mediator.Send(command, cancellationToken);

        if (deleteResult.Succeeded)
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
