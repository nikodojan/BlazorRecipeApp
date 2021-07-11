using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.Auth;
using BlazorRecipeApp.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRecipeApp.Services.Services
{
    public class MmStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _api;
        private CurrentUser _currentUser;

        public MmStateProvider(IAuthService api)
        {
            _api = api;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetCurrentUser();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }.Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<CurrentUser> GetCurrentUser()
        {
            if (_currentUser != null && _currentUser.IsAuthenticated) return _currentUser;
            _currentUser = await _api.CurrentUserInfo();
            return _currentUser;
        }

        public async Task Logout()
        {
            await _api.Logout();
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task Login(LoginRequest loginParameters)
        {
            await _api.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
