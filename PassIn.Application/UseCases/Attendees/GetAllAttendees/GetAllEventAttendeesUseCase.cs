using Microsoft.EntityFrameworkCore;

using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Attendees.GetAllAttendees;

public class GetAllEventAttendeesUseCase
{
    public ResponseAllAttendeesJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext();

        var entity = dbContext.Events.Include(ev => ev.Attendees).ThenInclude(attendee => attendee.CheckIn).FirstOrDefault(e => e.Id == id);

        if (entity is null)
            throw new NotFoundException("Event not found.");

        return new ResponseAllAttendeesJson
        {
            Attendees = entity.Attendees.Select(attendee => new ResponseAttendeeJson
            {
                Id = attendee.Id,
                Name = attendee.Name,
                Email = attendee.Email,
                CreatedAt = attendee.Created_At,
                CheckedInAt = attendee.CheckIn?.Created_At
            }).ToList()
        };
    }
}