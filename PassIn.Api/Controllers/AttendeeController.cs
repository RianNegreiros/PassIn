using Microsoft.AspNetCore.Mvc;

using PassIn.Application.UseCases.Attendees.GetAllAttendees;
using PassIn.Application.UseCases.Events.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendeeController : ControllerBase
{
    [HttpPost]
    [Route("{eventId:guid}/register")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Register(Guid eventId, [FromBody] RequestRegisterEventJson request)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();

        var response = useCase.Execute(eventId, request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{eventId:guid}")]
    [ProducesResponseType(typeof(ResponseAllAttendeesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAll(Guid eventId)
    {
        var useCase = new GetAllEventAttendeesUseCase();

        var response = useCase.Execute(eventId);

        return Ok(response);
    }
}