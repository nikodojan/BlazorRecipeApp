using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRecipeApp.Models.MealPlan;

namespace BlazorRecipeApp.Services.MenuFactory
{
    public class MenuFactory : IMenuFactory
    {
        public Menu CreateMenu(string type)
        {
            return type switch
            {
                "empty" => CreateEmptyMenu(),
                "week" => CreateWeekMenu(),
                _ => new Menu(),
            };
        }

        public Menu CreateEmptyMenu()
        {
            Menu menu = new Menu() { Name = "Untitled menu" };
            Day day = new Day() { Name = "Unassigned dishes" };
            day.Meals.Add(new Meal());
            menu.Days.Add(day);
            return menu;
        }

        public Menu CreateWeekMenu()
        {
            Menu menu = CreateEmptyMenu();
            string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            for (int i = 0; i < 7; i++)
            {
                Day day = new Day() { Name = weekDays[i] };
                int insertIndex = menu.Days.IndexOf(menu.Days[^1]);
                menu.Days.Insert(insertIndex, day);
            }

            return menu;
        }

        //public Menu SortDishesDayLast(Menu menu)
        //{
        //    Day day = menu.Days.Find(d => d.Name == "Unassigned dishes");
        //    menu.Days.Remove(day);
        //    menu.Days.Add(day);
        //    return menu;
        //}
    }
}
