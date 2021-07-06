using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Data.Interfaces;
using BlazorRecipeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeApp.Data.Services
{
    public class EfRecipeServiceV1 : IRecipeService
    {
        private IDbContextFactory<ApplicationDbContext> _factory;
        private ApplicationDbContext _context;

        public EfRecipeServiceV1(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
            _context = _factory.CreateDbContext();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            var recipes = _context.Recipes;
            return recipes;
            
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            Recipe recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            return recipe ?? new Recipe() { Id = 0, Title = "Recipe not found", Instructions = string.Empty };
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            //_context.Recipes.Add(recipe);
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            //_context.Recipes.Remove(recipe);
            //await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            //_context.Recipes.Update(recipe);
            //await _context.SaveChangesAsync();
        }

    }
}
