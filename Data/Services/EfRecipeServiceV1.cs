using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeApp.Data.Services
{
    public class EfRecipeServiceV1
    {
        private ApplicationDbContext _context;

        public EfRecipeServiceV1(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            var recipes = _context.Recipes.AsNoTracking();
            return recipes;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            return recipe ?? new Recipe() {Id = 0, Title = "Recipe not found", Instructions = string.Empty};
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
