using BlazorRecipeApp.Mm.MealPlans.Models;
using BlazorRecipeApp.Mm.MealPlans.Services;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IMenuFactory
    {
        Menu CreateMenu(MenuType type);
    }
}
