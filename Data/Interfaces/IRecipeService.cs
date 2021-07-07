using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models;

namespace BlazorRecipeApp.Data.Interfaces
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
