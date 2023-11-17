
using social_network_platform_server.Application.Contracts.Accounts.Dtos;

namespace social_network_platform_server.Application.Contracts.Accounts.Interfaces
{
    public interface IAccountService
    {
        Task<bool> SignUp(SignUpDto signInDto);
        Task<string> SignIn(SignInDto signInDto);
    }
}
