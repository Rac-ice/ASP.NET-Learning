using Users.Domain.ValueObjects;

namespace Users.WebAPI.Requests
{
    public record SendLoginByPhoneAndCodeRequest(PhoneNumber PhoneNumber);
}
