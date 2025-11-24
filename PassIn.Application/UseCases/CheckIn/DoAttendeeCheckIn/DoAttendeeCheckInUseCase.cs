using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.CheckIn.DoAttendeeCheckIn;

public class DoAttendeeCheckInUseCase
{
    private readonly PassInDbContext _dbContext = new();

    public ResponseRegisteredJson Execute(Guid id)
    {
        Validate(id);

        var entity = new Infrastructure.Entities.CheckIn
        {
            Attendee_Id = id,
            Created_At = DateTime.UtcNow
        };

        _dbContext.CheckIns.Add(entity);
        _dbContext.SaveChanges();

        return new ResponseRegisteredJson { Id = entity.Id };
    }

    private void Validate(Guid id)
    {
        var existAttendee = _dbContext.Attendees.Any(attendee => attendee.Id == id);
        if (!existAttendee)
            throw new NotFoundException("The attendee with Id was not found.");

        var existCheckIn = _dbContext.CheckIns.Any(ch => ch.Attendee_Id == id);
        if (existCheckIn)
            throw new ConflictException("Attendee can not do checking twice in the same event");
    }
}