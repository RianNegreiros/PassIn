using System.Net.Mail;

using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.RegisterAttendee;

public class RegisterAttendeeOnEventUseCase
{
    private readonly PassInDbContext _dbContext = new();

    public ResponseRegisteredJson Execute(Guid id, RequestRegisterEventJson request)
    {
        Validate(id, request);

        var entity = new Attendee
        {
            Email = request.Email, Name = request.Name, Event_Id = id, Created_At = DateTime.UtcNow
        };

        _dbContext.Attendees.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson { Id = entity.Id };
    }

    private void Validate(Guid id, RequestRegisterEventJson request)
    {
        var entity = _dbContext.Events.Find(id);

        if (entity is null)
            throw new NotFoundException("Event not found.");
        
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ErrorOnValidationException("The name is invalid.");
        
        if (!EmailIsValid(request.Email))
            throw new ErrorOnValidationException("The e-mail is invalid.");

        var attendeesAlreadyRegistered = _dbContext
            .Attendees
            .Any(attendee => attendee.Email.Equals(request.Email) && attendee.Event_Id == id);

        if (attendeesAlreadyRegistered)
            throw new ErrorOnValidationException("You can not register twice on the same event");
        
        var attendeesOnEvent = _dbContext.Attendees.Count(e => e.Event_Id == id);

        if (attendeesOnEvent >= entity.Maximum_Attendees)
            throw new ErrorOnValidationException("Maximum attendees exceeded");
    }

    private bool EmailIsValid(string email)
    {
        try
        {
            new MailAddress(email);

            return true;
        }
        catch
        {
            return false;
        }
    }
}