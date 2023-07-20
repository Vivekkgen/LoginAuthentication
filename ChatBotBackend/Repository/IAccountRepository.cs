using ChatBotBackend.Data;
using Microsoft.AspNetCore.Identity;

namespace ChatBotBackend.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(UserDto employee);
        Task<RespnseDto> LoginAsync(LoginDto loginDto);
    }
}
