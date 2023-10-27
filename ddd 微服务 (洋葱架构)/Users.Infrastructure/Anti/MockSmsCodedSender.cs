using Microsoft.Extensions.Logging;
using Users.Domain.IAntis;
using Users.Domain.ValueObjects;

namespace Users.Infrastructure.Anti
{
    public class MockSmsCodedSender : ISmsCodeSender
    {
        private readonly ILogger<MockSmsCodedSender> logger;

        public MockSmsCodedSender(ILogger<MockSmsCodedSender> logger)
        {
            this.logger = logger;
        }

        public void SendCode(PhoneNumber phoneNumber, string code)
        {
            SendCode sendCode = new SendCode() { PhoneNumber = phoneNumber, Code = code };
            logger.LogInformation($"向{phoneNumber}发送验证吗{code}",sendCode);
        }
    }

    class SendCode
    {
        public PhoneNumber PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
