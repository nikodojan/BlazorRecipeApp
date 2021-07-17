using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models;

namespace BlazorRecipeApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
    }
}
