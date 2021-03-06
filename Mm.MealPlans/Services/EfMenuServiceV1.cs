using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.MealPlans.Models;
using BlazorRecipeApp.Mm.Shared.Data;
using BlazorRecipeApp.Mm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeApp.Mm.MealPlans.Services
{
    public class EfMenuServiceV1 : IMenuService
    {
        private IDbContextFactory<ApplicationDbContext> _factory;
        private readonly ApplicationDbContext _context;

        public EfMenuServiceV1(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
            _context = _factory.CreateDbContext();
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _context.Menus
                .Include(menu=>menu.Days)
                .ThenInclude(day=>day.Meals)
                .ThenInclude(meal=>meal.Dishes)
                .ThenInclude(dish=>dish.Recipe)
                .ToListAsync();
        }

        public async Task CreateMenuAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int menuId)
        {
            return await _context.Menus
                .Include(menu => menu.Days)
                .ThenInclude(day => day.Meals)
                .ThenInclude(meal => meal.Dishes)
                .ThenInclude(dish => dish.Recipe)
                .FirstOrDefaultAsync(m=>m.Id == menuId);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(Menu menu)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
        }

        public async Task AddDish(int recipeId)
        {
            try
            {
                Console.WriteLine("Recipe id " + recipeId);
                Menu menu = _context.Menus.Include(menu => menu.Days)
                    .ThenInclude(day => day.Meals)
                    .ThenInclude(meal => meal.Dishes)
                    .ThenInclude(dish => dish.Recipe)
                    .ToList()[^1];
                

                Console.WriteLine("Menu id " + menu.Id);
                Dish dish = new Dish();
                dish.RecipeId = recipeId;
                // TODO: Add error handling: If menu doesn't contain days or meals,
                // throw exxception .. custom exception?
                menu.Days[0].Meals[0].Dishes.Add(dish);

                await UpdateMenuAsync(menu);
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
