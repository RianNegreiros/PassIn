using Microsoft.AspNetCore.Mvc;

using PassIn.Application.UseCases.CheckIn.DoAttendeeCheckIn;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckInController : ControllerBase
{
    [HttpPost]
    [Route("{attendeeId:guid}")]
    [ProducesResponseType(typeof(ResponseRegisteredJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult CheckIn(Guid attendeeId)
    {
        var useCase = new DoAttendeeCheckInUseCase();
        var response = useCase.Execute(attendeeId);

        return Created(String.Empty, response);
    }
}