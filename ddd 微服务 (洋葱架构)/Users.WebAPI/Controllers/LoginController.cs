using Microsoft.AspNetCore.Mvc;
using Users.Domain.DomainServices;
using Users.Infrastructure.DbContexts;
using Users.WebAPI.Requests;
using Users.WebAPI.UnitOfWork;

namespace Users.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDomainService userDomainService;

        public LoginController(UserDomainService userDomainService)
        {
            this.userDomainService = userDomainService;
        }

        [HttpPut]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> LoginByPhoneAndPwd(LoginByPhoneAndPwdRequest req)
        {
            if (req.Password.Length < 6) return BadRequest("密码长度不能小于6");
            var phoneNumber = req.PhoneNumber;
            var result = await userDomainService.CheckPassword(phoneNumber, req.Password);
            switch (result)
            {
                case Domain.Results.UserAccessResult.OK:
                    return Ok("登录成功");
                    break;
                case Domain.Results.UserAccessResult.Lockout:
                    return BadRequest("用户被锁定，请稍后再试");
                    break;
                case Domain.Results.UserAccessResult.PhoneNumberNotFound:
                case Domain.Results.UserAccessResult.NoPassword:
                case Domain.Results.UserAccessResult.PasswordError:
                    return BadRequest("手机号或者密码错误");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendCodeByPhone(SendLoginByPhoneAndCodeRequest req)
        {
            var result = await userDomainService.SendCodeAsync(req.PhoneNumber);
            switch (result)
            {
                case Domain.Results.UserAccessResult.OK:
                    return Ok("验证码已发出");
                    break;
                case Domain.Results.UserAccessResult.Lockout:
                    return BadRequest("用户被锁定，请稍后再试");
                    break;
                default:
                    return BadRequest("请求错误");
            }
        }

        [HttpPost]
        [UnitOfWork(typeof(UserDbContext))]
        public async Task<IActionResult> CheckCode(CheckLoginByPhoneAndCodeRequest req)
        {
            var result = await userDomainService.CheckPhoneNumberCodeAsync(req.PhoneNumber, req.Code);
            switch (result)
            {
                case Domain.Results.CheckCodeResult.OK:
                    return Ok("登录成功");
                    break;
                case Domain.Results.CheckCodeResult.PhoneNumberNotFound:
                    return BadRequest("请求错误");
                    break;
                case Domain.Results.CheckCodeResult.Lockout:
                    return BadRequest("用户被锁定，请稍后再试");
                    break;
                case Domain.Results.CheckCodeResult.CodeError:
                    return BadRequest("验证码错误");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
