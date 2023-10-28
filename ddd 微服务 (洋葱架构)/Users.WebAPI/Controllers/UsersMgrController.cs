using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Domain.DomainServices;
using Users.Domain.Entities;
using Users.Domain.IRepositories;
using Users.Domain.ValueObjects;
using Users.Infrastructure.DbContexts;
using Users.WebAPI.Requests;
using Users.WebAPI.UnitOfWork;

namespace Users.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersMgrController : ControllerBase
    {
        private readonly UserDbContext context;
        private readonly UserDomainService userDomainService;
        private readonly IUserDomainRepository userDomainRepository;

        public UsersMgrController(UserDbContext context, UserDomainService userDomainService, IUserDomainRepository userDomainRepository)
        {
            this.context = context;
            this.userDomainService = userDomainService;
            this.userDomainRepository = userDomainRepository;
        }

        [HttpPost]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> AddNew(PhoneNumber phoneNumber)
        {
            if ((await userDomainRepository.FindOneAsync(phoneNumber))!=null)
                return BadRequest("手机号已经存在");
            User user = new User(phoneNumber);
            context.Users.Add(user);
            return Ok("成功");
        }

        [HttpPut]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest req)
        {
            var user = await userDomainRepository.FindOneAsync(req.Id);
            if (user == null) return BadRequest("用户不存在");
            user.ChangePassowrd(req.Password);
            return Ok("成功");
        }

        [HttpPut]
        [Route("{id}")]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> Unlock(Guid id)
        {
            var user = await userDomainRepository.FindOneAsync(id);
            if (user == null) return BadRequest("用户不存在");
            userDomainService.ResetAccessFail(user);
            return Ok("成功");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
