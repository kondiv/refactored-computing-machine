using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementService.App.Domain.ValueTypes.Result.Errors;
using ProjectManagementService.App.Features.CreateProject;
using ProjectManagementService.App.Features.DeleteProject;
using ProjectManagementService.App.Features.GetProject;
using ProjectManagementService.App.Features.ListProjects;
using ProjectManagementService.App.Features.UpdateProject;

namespace ProjectManagementService.App.Controllers;

[ApiController]
[Route("api/projects/")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IReadOnlyCollection<GetProjectDto>>> ListAsync(
        [FromQuery] int page = 1,
        [FromQuery] int maxPageSize = 10,
        CancellationToken cancellationToken = default)
    {
        if(page < 1 || maxPageSize < 1)
        {
            return BadRequest("Invalid page or max page size");
        }

        var request = new ListProjectsRequest(page, maxPageSize);

        return Ok(await _mediator.Send(request, cancellationToken));
    }

    [HttpGet("{id:guid}", Name = "GetAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetProjectDto>> GetAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetProjectRequest(id);

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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreatedProjectDto>> CreateAsync(
        CreateProjectApiRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateProjectCommand(request.Name, request.Description, request.SupervisorId, request.ManagerId);

        var createResult = await _mediator.Send(command, cancellationToken);

        if(createResult.Succeeded)
        {
            return CreatedAtRoute("GetAsync", new { id = createResult.Value.Id }, createResult.Value);
        }

        return createResult.Error.ErrorCode switch
        {
            ErrorCode.NotFound => NotFound(createResult.Error.Message),
            _ => BadRequest(createResult.Error.Message)
        };
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync([FromRoute] Guid id,
        JsonPatchDocument<UpdateProjectDto> patchDocument,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateProjectCommand(id, patchDocument);

        var updateResult = await _mediator.Send(command, cancellationToken);

        if(updateResult.Succeeded)
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteProjectCommand(id);

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
