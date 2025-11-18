using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.GetById;

public class GetEventByIdUseCase(PassInDbContext context)
{
    public ResponseEventJson Execute(Guid id)
    {
        var entity = context.Events.FirstOrDefault(e => e.Id == id);
        
        if(entity is null) 
            throw new NotFoundException("Event not found.");
        
        
        return new ResponseEventJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            MaximumAttendees = entity.Maximum_Attendees,
            AttendeesAmount = -1
        };
    }
}