using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Identity.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IAuthService
    {
        Task<CurrentUser> CurrentUserInfo();
        Task Login(LoginRequest loginRequest);
        Task Logout();

        Task Register(RegisterRequest registerRequest);
    }
}
