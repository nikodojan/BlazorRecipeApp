using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.MealPlans.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task CreateMenuAsync(Menu menu);
        Task<Menu> GetMenuByIdAsync(int menuId);

        Task UpdateMenuAsync(Menu menu);

        Task DeleteMenuAsync(Menu menu);

        Task AddDish(int recipeId);
    }
}
