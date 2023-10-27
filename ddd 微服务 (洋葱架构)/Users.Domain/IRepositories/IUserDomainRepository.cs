using Users.Domain.Entities;
using Users.Domain.Events;
using Users.Domain.ValueObjects;

namespace Users.Domain.IRepositories
{
    public interface IUserDomainRepository
    {
        Task<User?> FindOneAsync(PhoneNumber phoneNumber);
        Task<User?> FindOneAsync(Guid userId);
        Task AddNewLoginHistoryAsync(PhoneNumber phoneNumber, string message);
        Task PublishEventAsync(UserAccessResultEvent _event);
        Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code);
        Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber);
    }
}
