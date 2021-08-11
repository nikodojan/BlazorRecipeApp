using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.MealPlan;

namespace BlazorRecipeApp.Services.MenuFactory
{
    public interface IMenuFactory
    {
        Menu CreateMenu(string type);
    }
}
