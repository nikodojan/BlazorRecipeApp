using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlazorRecipeApp.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FistName { get; set; }
        public string LastName { get; set; }

        //public int SelectedMenu {get;set;}

        //public List<Menu> Menus {get;set;}
    }
}
