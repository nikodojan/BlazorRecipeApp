using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models.MealPlan
{
    [Table("Dish")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        
        public int MealId { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [ForeignKey(nameof(MealId))]
        [InverseProperty("Dishes")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        public int? RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public Recipe Recipe { get; set; }
    }
}
