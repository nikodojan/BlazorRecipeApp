using Microsoft.AspNetCore.Identity;

namespace BlazorRecipeApp.Mm.Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public int SelectedMenu {get;set;}

        //public List<Menu> Menus {get;set;}
    }
}
