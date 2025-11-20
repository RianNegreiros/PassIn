using Microsoft.AspNetCore.Mvc;

using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(
        GetEventByIdUseCase getEventByIdUseCase,
        RegisterEventUseCase registerEventUseCase
        ) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterEventJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
        var response = registerEventUseCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var response = getEventByIdUseCase.Execute(id);

        return Ok(response);
    }
}