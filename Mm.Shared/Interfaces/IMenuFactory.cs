using BlazorRecipeApp.Mm.MealPlans.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IMenuFactory
    {
        Menu CreateMenu(string type);
    }
}
