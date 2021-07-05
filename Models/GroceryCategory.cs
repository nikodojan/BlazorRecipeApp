using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models
{
    [Table("GroceryCategory")]
    public class GroceryCategory
    {
        public GroceryCategory()
        {
            Groceries = new HashSet<Grocery>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Grocery.CategoryNavigation))]
        public virtual ICollection<Grocery> Groceries { get; set; }
    }
}
