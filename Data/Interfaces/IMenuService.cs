using BlazorRecipeApp.Models.MealPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Data.Interfaces
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
