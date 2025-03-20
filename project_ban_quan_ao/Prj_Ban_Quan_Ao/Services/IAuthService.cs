using Prj_Ban_Quan_Ao.Models;

namespace IdentityTest_3.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(Account user);
        Task<bool> Login(Account user);
        Task<bool> RegisterUser(Account user);
    }
}