using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using social_network_platform_server.Application.Contracts.Accounts.Dtos;
using social_network_platform_server.Application.Contracts.Accounts.Interfaces;

namespace social_network_platform_server.Api.Controllers.Commands
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(
             IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _accountService.SignUp(signUpDto);
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            if (!ModelState.IsValid) return Unauthorized();
            var token = await _accountService.SignIn(signInDto);
            return Ok(new { token = token });
        }
    }
}
