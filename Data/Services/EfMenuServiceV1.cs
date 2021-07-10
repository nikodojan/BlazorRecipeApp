using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Data.Interfaces;
using BlazorRecipeApp.Models.MealPlan;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace BlazorRecipeApp.Data.Services
{
    public class EfMenuServiceV1 : IMenuService
    {
        private IDbContextFactory<ApplicationDbContext> _factory;

        public EfMenuServiceV1(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            using (var ctx = _factory.CreateDbContext())
            {
                return await ctx.Menus
                    .Include(menu=>menu.Days)
                    .ThenInclude(day=>day.Meals)
                    .ThenInclude(meal=>meal.Dishes)
                    .ThenInclude(dish=>dish.Recipe)
                    .ToListAsync();
            }
        }

        public async Task CreateMenuAsync(Menu menu)
        {
            using var ctx = _factory.CreateDbContext();
            {
                await ctx.Menus.AddAsync(menu);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<Menu> GetMenuByIdAsync(int menuId)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                return await ctx.Menus
                    .Include(menu => menu.Days)
                    .ThenInclude(day => day.Meals)
                    .ThenInclude(meal => meal.Dishes)
                    .ThenInclude(dish => dish.Recipe)
                    .FirstOrDefaultAsync(m=>m.Id == menuId);
            }
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                ctx.Menus.Update(menu);
                await ctx.SaveChangesAsync();
            }
            
        }

        public async Task DeleteMenuAsync(Menu menu)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                ctx.Menus.Remove(menu);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
