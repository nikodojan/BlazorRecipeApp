using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Recipes.Models;
using BlazorRecipeApp.Mm.Shared.Data;
using BlazorRecipeApp.Mm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeApp.Mm.Recipes.Services
{
    public class EfRecipeServiceV1 : IRecipeService
    {
        private IDbContextFactory<ApplicationDbContext> _factory;
        private ApplicationDbContext _context;

        public EfRecipeServiceV1(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
            _context = factory.CreateDbContext();
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var recipes = await _context.Recipes.Include(r=>r.Ingredients).ToListAsync();
            return recipes;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            Recipe recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == recipeId);
            return recipe ?? new Recipe() { Id = 0, Title = "Recipe not found", Instructions = string.Empty };
        }

        public async Task<IEnumerable<Recipe>> GetByTitleAsync(string title)
        {
            return await _context.Recipes
                .Include(r => r.Ingredients)
                .Where(r => r.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllTitlesAsync()
        {
            return await _context.Recipes.Select(r => r.Title).ToListAsync();
        }
        public async Task<IEnumerable<object>> GetAllShortAsync()
        {
            return await _context.Recipes.Select(r =>
                new
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    ImgPath = r.ImgPath,
                    Portions = r.Portions,
                    Time = r.TimeInMinutes
                }).ToListAsync();
        }



        public async Task<int> AddRecipeAsync(Recipe recipe)
        {
            var result = _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task DeleteRecipeAsync(Recipe recipe)
        {
            //using (var ctx = _factory.CreateDbContext())
            //{
            //    ctx.Recipes.Remove(recipe);
            //    await ctx.SaveChangesAsync();
            //}

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            //using (var ctx = _factory.CreateDbContext())
            //{
            //    ctx.Recipes.Update(recipe);
            //    //delete, save, add, save
            //    //Recipe old = ctx.Recipes.Find(recipe.Id);
            //    //old = recipe;
            //    //ctx.Entry(old).CurrentValues.SetValues(recipe);
            //    await ctx.SaveChangesAsync();
            //}

            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

    }
}
