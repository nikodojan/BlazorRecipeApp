using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Recipes.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();
        //IEnumerable<Recipe> GetRecipes();
        Task<Recipe> GetRecipeByIdAsync(int? recipeId);
        Task AddRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
    }
}
