using Microsoft.Extensions.Logging;
using Users.Domain.IAntis;
using Users.Domain.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            SendCode sendCode = new SendCode() { RegionCode = phoneNumber.RegionCode, Number = phoneNumber.Number, Code = code };
            logger.LogInformation($"向 +{sendCode.RegionCode} {sendCode.Number} 发送验证码 {code}");
        }
    }

    class SendCode
    {
        public string RegionCode { get; set; }
        public string Number {  get; set; }
        public string Code { get; set; }
    }
}
