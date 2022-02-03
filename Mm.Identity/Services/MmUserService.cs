using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Identity.Models;
using BlazorRecipeApp.Mm.Shared.Interfaces;

namespace BlazorRecipeApp.Mm.Identity.Services
{
    public class MmUserService : IUserService
    {
        private HttpClient _httpClient;

        public MmUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
        {
            ApplicationUser user = null;
            var response = await _httpClient.GetAsync($"api/user/{username}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<ApplicationUser>();
            }

            return user;
        }
    }
}
