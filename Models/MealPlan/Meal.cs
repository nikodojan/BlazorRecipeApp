using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models.MealPlan
{
    [Table("Meal")]
    public class Meal
    { public Meal()
        {
            Dishes = new List<Dish>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int DayId { get; set; }

        [ForeignKey(nameof(DayId))]
        [InverseProperty("Meals")]
        [JsonIgnore]
        public virtual Day Day { get; set; }

        [InverseProperty(nameof(Dish.Meal))]
        public List<Dish> Dishes { get; set; }
    }
}
