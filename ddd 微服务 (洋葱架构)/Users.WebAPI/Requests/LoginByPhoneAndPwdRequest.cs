using Users.Domain.ValueObjects;

namespace Users.WebAPI.Requests
{
    public record LoginByPhoneAndPwdRequest(PhoneNumber PhoneNumber,string Password);
}
