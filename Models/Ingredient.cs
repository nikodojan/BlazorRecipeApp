using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models
{
    [Table("Ingredient")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "double(6, 2)")]
        public double? Amount { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey(nameof(RecipeId))]
        [InverseProperty("Ingredients")]
        public virtual Recipe Recipe { get; set; }
    }
}
