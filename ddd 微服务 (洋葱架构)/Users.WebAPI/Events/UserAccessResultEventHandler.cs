using MediatR;
using Users.Domain.Events;
using Users.Domain.IRepositories;

namespace Users.WebAPI.Events
{
    public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
    {
        private readonly IUserDomainRepository userDomainRepository;

        public UserAccessResultEventHandler(IUserDomainRepository userDomainRepository)
        {
            this.userDomainRepository = userDomainRepository;
        }

        public Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
        {
            var result = notification.Result;
            var phoneNumber = notification.PhoneNumber;
            string msg;
            switch (result)
            {
                case Domain.Results.UserAccessResult.OK:
                    msg = $"{phoneNumber}：登陆成功";
                    break;
                case Domain.Results.UserAccessResult.PhoneNumberNotFound:
                    msg = $"{phoneNumber}：登陆失败，用户不存在";
                    break;
                case Domain.Results.UserAccessResult.Lockout:
                    msg = $"{phoneNumber}：登陆失败，被锁定";
                    break;
                case Domain.Results.UserAccessResult.NoPassword:
                    msg = $"{phoneNumber}：登陆失败，没有设置密码";
                    break;
                case Domain.Results.UserAccessResult.PasswordError:
                    msg = $"{phoneNumber}：登陆失败，密码错误";
                    break;
                default:
                    throw new NotImplementedException();
            }
            return userDomainRepository.AddNewLoginHistoryAsync(phoneNumber, msg);
        }
    }
}
