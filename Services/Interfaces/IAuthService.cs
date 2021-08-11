using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.Auth;

namespace BlazorRecipeApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CurrentUser> CurrentUserInfo();
        Task Login(LoginRequest loginRequest);
        Task Logout();
    }
}
