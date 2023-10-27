using MediatR;
using Users.Domain.Results;
using Users.Domain.ValueObjects;

namespace Users.Domain.Events
{
    public record class UserAccessResultEvent(PhoneNumber PhoneNumber,UserAccessResult Result):INotification;
}
