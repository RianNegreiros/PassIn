using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.Register;

public class RegisterEventUseCase(PassInDbContext context)
{
    public ResponseRegisterEventJson Execute(RequestEventJson request)
    {
        var entity = new Event
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "-")
        };

        context.Events.Add(entity);
        context.SaveChanges();

        return new ResponseRegisterEventJson
        {
            Id = entity.Id
        };

    }
}