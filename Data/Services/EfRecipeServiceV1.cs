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

        public EfRecipeServiceV1(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            using (var ctx = _factory.CreateDbContext())
            {
                var recipes = await ctx.Recipes.ToListAsync();
                return recipes;
            }
        }

        public async Task<Recipe> GetRecipeByIdAsync(int? recipeId)
        {
            if (recipeId == null) return new Recipe() {Id = 0, Title = "No recipe found", Description = ""};
            using (var ctx = _factory.CreateDbContext())
            {
                Recipe recipe = await ctx.Recipes
                    .Include(r=>r.Ingredients)
                    .FirstOrDefaultAsync(r => r.Id == recipeId);
                return recipe ?? new Recipe() { Id = 0, Title = "Recipe not found", Instructions = string.Empty };
            }
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                ctx.Recipes.Add(recipe);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            //_context.Recipes.Remove(recipe);
            //await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                ctx.Recipes.Update(recipe);
                await ctx.SaveChangesAsync();
            }
        }

    }
}
