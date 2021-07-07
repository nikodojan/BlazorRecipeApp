using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models.MealPlan
{
    [Table("Menu")]
    public class Menu
    {
        public Menu()
        {
            Days = new List<Day>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Notes { get; set; }

        [InverseProperty(nameof(Day.Menu))]
        public virtual List<Day> Days { get; set; }
    }
}
