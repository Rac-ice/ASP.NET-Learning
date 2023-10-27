using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Users.Domain.Entities;
using Users.Domain.Events;
using Users.Domain.IRepositories;
using Users.Domain.ValueObjects;
using Users.Infrastructure.DbContexts;

namespace Users.Infrastructure.Repositories
{
    public class UserRepository : IUserDomainRepository
    {
        private readonly UserDbContext userDbContext;
        private readonly IDistributedCache distributedCache;
        private readonly IMediator mediator;

        public UserRepository(UserDbContext userDbContext, IDistributedCache distributedCache, IMediator mediator)
        {
            this.userDbContext = userDbContext;
            this.distributedCache = distributedCache;
            this.mediator = mediator;
        }

        public async Task AddNewLoginHistoryAsync(PhoneNumber phoneNumber, string message)
        {
            User? user = await FindOneAsync(phoneNumber);
            Guid? userId = null;
            if (user!=null)
            {
                userId = user.Id;
            }
            userDbContext.UserLoginHistories.Add(new UserLoginHistory(userId, phoneNumber, message));
        }

        public async Task<User?> FindOneAsync(PhoneNumber phoneNumber)
        {
            return await userDbContext.Users.Include(u=>u.UserAccessFail).SingleOrDefaultAsync(ExpressionHelper.MakeEqual((User u) => u.PhoneNumber, phoneNumber));
        }

        public async Task<User?> FindOneAsync(Guid userId)
        {
            return await userDbContext.Users.Include(u => u.UserAccessFail).SingleOrDefaultAsync(u => u.Id == userId);
        }

        public Task<string?> FindPhoneNumberCodeAsync(PhoneNumber phoneNumber)
        {
            string fullNumber = phoneNumber.RegionCode + phoneNumber.Number;
            string cacheKey = $"LoginByPhoneAndCode_Code_{fullNumber}";
            string? code = distributedCache.GetString(cacheKey);
            distributedCache.Remove(cacheKey);
            return Task.FromResult(code);
        }

        public Task PublishEventAsync(UserAccessResultEvent _event)
        {
            return mediator.Publish(_event);
        }

        public Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            string fullNumber = phoneNumber.RegionCode + phoneNumber.Number;
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
            distributedCache.SetString($"LoginByPhoneAndCode_Code_{fullNumber}", code, options);
            return Task.CompletedTask;
        }
    }
}