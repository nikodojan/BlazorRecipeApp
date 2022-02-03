using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorRecipeApp.Mm.Recipes.Models
{
    [Table("Grocery")]
    public class Grocery
    {
        [Key]
        [StringLength(50)]
        public string GroceryName { get; set; } //PK
        public int Category { get; set; } //FK

        [ForeignKey(nameof(Category))]
        [InverseProperty(nameof(GroceryCategory.Groceries))]
        public virtual GroceryCategory CategoryNavigation { get; set; }
    }
}
