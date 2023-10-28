using Users.Domain.Entities;
using Users.Domain.Events;
using Users.Domain.IAntis;
using Users.Domain.IRepositories;
using Users.Domain.Results;
using Users.Domain.ValueObjects;

namespace Users.Domain.DomainServices
{
    public class UserDomainService
    {
        private readonly IUserDomainRepository userDomainRepository;
        private readonly ISmsCodeSender smsCodeSender;

        public UserDomainService(IUserDomainRepository userDomainRepository, ISmsCodeSender smsCodeSender)
        {
            this.userDomainRepository = userDomainRepository;
            this.smsCodeSender = smsCodeSender;
        }

        public void ResetAccessFail(User user)
        {
            user.UserAccessFail.Reset();
        }

        public bool IsLockOut(User user)
        {
            return user.UserAccessFail.IsLockOut();
        }

        public void AccessFail(User user)
        {
            user.UserAccessFail.Fail();
        }

        public async Task<UserAccessResult> CheckPassword(PhoneNumber phoneNumber, string password)
        {
            UserAccessResult result;
            var user = await userDomainRepository.FindOneAsync(phoneNumber);
            if (user == null)
            {
                result = UserAccessResult.PhoneNumberNotFound;
            }
            else if (IsLockOut(user))
            {
                result = UserAccessResult.Lockout;
            }
            else if (user.HasPassword() == false)
            {
                result = UserAccessResult.NoPassword;
            }
            else if (user.CheckPassword(password))
            {
                result = UserAccessResult.OK;
            }
            else
            {
                result = UserAccessResult.PasswordError;
            }
            if (user != null)
            {
                if (result == UserAccessResult.OK)
                    ResetAccessFail(user);
                else
                    AccessFail(user);
            }
            await userDomainRepository.PublishEventAsync(new UserAccessResultEvent(phoneNumber, result));
            return result;
        }

        public async Task<CheckCodeResult> CheckPhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            var user = await userDomainRepository.FindOneAsync(phoneNumber);
            UserAccessResult userAccessResult;
            CheckCodeResult checkCodeResult;
            if (user == null)
            {
                checkCodeResult = CheckCodeResult.PhoneNumberNotFound;
                userAccessResult = UserAccessResult.PhoneNumberNotFound;
            }
            else if (IsLockOut(user))
            {
                checkCodeResult = CheckCodeResult.Lockout;
                userAccessResult = UserAccessResult.Lockout;
            }
            string? codeInServer = await userDomainRepository.FindPhoneNumberCodeAsync(phoneNumber);
            if (string.IsNullOrEmpty(codeInServer))
            {
                checkCodeResult = CheckCodeResult.CodeError;
                userAccessResult = UserAccessResult.PasswordError;
            }
            if (code == codeInServer)
            {

                checkCodeResult = CheckCodeResult.OK;
                userAccessResult = UserAccessResult.OK;
                ResetAccessFail(user);
            }
            else
            {
                AccessFail(user);
                checkCodeResult = CheckCodeResult.CodeError;
                userAccessResult = UserAccessResult.PasswordError;
            }
            await userDomainRepository.PublishEventAsync(new UserAccessResultEvent(phoneNumber, userAccessResult));
            return checkCodeResult;
        }

        public async Task<UserAccessResult> SendCodeAsync(PhoneNumber phoneNumber)
        {
            var user = await userDomainRepository.FindOneAsync(phoneNumber);
            if (user == null)
            {
                return UserAccessResult.PhoneNumberNotFound;
            }
            if (IsLockOut(user))
            {
                return UserAccessResult.Lockout;
            }
            string code = Random.Shared.Next(1000, 9999).ToString();
            await userDomainRepository.SavePhoneNumberCodeAsync(phoneNumber, code);
            smsCodeSender.SendCode(phoneNumber, code);
            return UserAccessResult.OK;
        }
    }
}
