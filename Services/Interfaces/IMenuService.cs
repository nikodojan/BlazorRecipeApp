using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.MealPlan;

namespace BlazorRecipeApp.Services.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task CreateMenuAsync(Menu menu);
        Task<Menu> GetMenuByIdAsync(int menuId);

        Task UpdateMenuAsync(Menu menu);

        Task DeleteMenuAsync(Menu menu);
    }
}
