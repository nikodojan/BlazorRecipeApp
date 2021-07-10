using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Data.Interfaces;
using BlazorRecipeApp.Models;
using BlazorRecipeApp.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BlazorRecipeApp.Data.Services
{
    public class CustomAuthServiceV1 : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private DbContextFactory<ApplicationDbContext> _contextFactory;

        public CustomAuthServiceV1(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DbContextFactory<ApplicationDbContext> factory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextFactory = factory;
        }

        public async Task<SignInResult> LoginAsync(LoginRequest login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null) return null;

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);

            return signInResult;
        }
    }
}
