using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models;

namespace BlazorRecipeApp.Data.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetRecipes();
        Task<Recipe> GetRecipeByIdAsync(int recipeId);
        Task AddRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
    }
}
