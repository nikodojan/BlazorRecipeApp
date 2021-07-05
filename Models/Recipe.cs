﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRecipeApp.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        public Recipe()
        {
            //Dishes = new List<Dish>();
            Ingredients = new List<Ingredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(50)]
        public string ImgPath { get; set; }

        [Required]
        [StringLength(2000)]
        public string Instructions { get; set; }

        public int? Portions { get; set; }

        public int? TimeInMinutes { get; set; }

        [InverseProperty(nameof(Ingredient.Recipe))]
        public virtual List<Ingredient> Ingredients { get; set; }
    }
}