using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models.MealPlan
{
    [Table("Day")]
    public class Day
    {
        public Day()
        {
            Meals = new List<Meal>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int MenuId { get; set; }

        [ForeignKey(nameof(MenuId))]
        [InverseProperty("Days")]
        [JsonIgnore]
        public virtual Menu Menu { get; set; }

        [InverseProperty(nameof(Meal.Day))]
        public List<Meal> Meals { get; set; }
    }
}
