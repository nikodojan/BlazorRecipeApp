using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace BlazorRecipeApp.Data.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> LoginAsync(LoginRequest login);
    }
}
