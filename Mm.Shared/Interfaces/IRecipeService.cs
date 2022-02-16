using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Recipes.Models;

namespace BlazorRecipeApp.Mm.Shared.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        //IEnumerable<Recipe> GetRecipes();
        Task<Recipe> GetRecipeByIdAsync(int recipeId);
        Task<IEnumerable<Recipe>> GetByTitleAsync(string title);
        Task<IEnumerable<string>> GetAllTitlesAsync();

        Task<IEnumerable<object>> GetAllShortAsync();
        Task AddRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
    }
}
