using Users.Domain.ValueObjects;

namespace Users.Domain.IAntis
{
    public interface ISmsCodeSender
    {
        void SendCode(PhoneNumber phoneNumber, string code);
    }
}
