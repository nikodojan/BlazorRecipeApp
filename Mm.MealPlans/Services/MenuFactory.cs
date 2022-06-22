using System;
using BlazorRecipeApp.Mm.MealPlans.Models;
using BlazorRecipeApp.Mm.Shared.Interfaces;

namespace BlazorRecipeApp.Mm.MealPlans.Services
{
    public class MenuFactory : IMenuFactory
    {
        public Menu CreateMenu(MenuType type)
        {
            return type switch
            {
                MenuType.Empty => CreateEmptyMenu(),
                MenuType.Week => CreateWeekMenu(),
                _ => new Menu(),
            };
        }

        public Menu CreateEmptyMenu()
        {
            Menu menu = new Menu() { Name = "Untitled menu", CreatedDateTime = DateTime.Now };
            Day day = new Day() { Name = "Unassigned dishes" };
            day.Meals.Add(new Meal());
            menu.Days.Add(day);
            return menu;
        }

        public Menu CreateWeekMenu()
        {
            Menu menu = new Menu() { Name = "Untitled menu", CreatedDateTime = DateTime.Now };
            string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            for (int i = 0; i < 7; i++)
            {
                Day day = new Day() { Name = weekDays[i] };
                int insertIndex = menu.Days.IndexOf(menu.Days[^1]);
                menu.Days.Insert(insertIndex, day);
            }

            return menu;
        }
    }
}
