using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Identity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorRecipeApp.Mm.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest parameters)
        {
            var user = new ApplicationUser() 
            { 
                Email = parameters.Email,
                UserName = parameters.Email,
                FirstName = parameters.FirstName,
                LastName = parameters.LastName
            };

            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);
            return await Login(new LoginRequest
            {
                Email = parameters.Email,
                Password = parameters.Password
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");
            //await _signInManager.SignInAsync(user, request.RememberMe);

            var authenticationProperties = new AuthenticationProperties()
            {
                IsPersistent = request.RememberMe, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddYears(1)
            };

            await _signInManager.SignInAsync(user, authenticationProperties);


            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            return new CurrentUser
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                Claims = User.Claims
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }

        private AuthenticationProperties GetAuthenticationProperties(bool isPersistent)
        {
            return new AuthenticationProperties()
            {
                IsPersistent = isPersistent
            };
        }
    }
}
