using Users.Domain.ValueObjects;

namespace Users.WebAPI.Requests
{
    public record CheckLoginByPhoneAndCodeRequest(PhoneNumber PhoneNumber,string Code);
}
