using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Identity.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
    }
}
