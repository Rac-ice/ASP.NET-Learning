using Common;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities
{
    public record User : IAggregateRoot
    {
        public Guid Id { get; init; }
        public PhoneNumber PhoneNumber { get; private set; }
        private string? passwordHash;
        public UserAccessFail UserAccessFail { get; private set; }
        private User() { }
        public User(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            this.Id = Guid.NewGuid();
            this.UserAccessFail = new UserAccessFail(this);
        }
        public bool HasPassword()
        {
            return !string.IsNullOrEmpty(this.passwordHash);
        }
        public void ChangePassowrd(string password)
        {
            if (password.Length < 6)
                throw new ArgumentOutOfRangeException("密码长度必须大于或等于6");
            this.passwordHash = HashHelper.ComputeMd5Hash(password);
        }
        public bool CheckPassword(string password)
        {
            return this.passwordHash == HashHelper.ComputeMd5Hash(password);
        }
        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
    }
}
