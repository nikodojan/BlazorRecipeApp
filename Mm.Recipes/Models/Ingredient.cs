using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BlazorRecipeApp.Mm.Recipes.Models
{
    [Table("ingredient")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "double(6, 2)")]
        public double? Amount { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string PartOfDish { get; set; }

        public int RecipeId { get; set; }
    }
}
