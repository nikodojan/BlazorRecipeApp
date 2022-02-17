using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BlazorRecipeApp.Mm.Recipes.Models;

namespace BlazorRecipeApp.Mm.MealPlans.Models
{
    [Table("dish")]
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
