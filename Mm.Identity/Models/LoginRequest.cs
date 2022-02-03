﻿using System.ComponentModel.DataAnnotations;

namespace BlazorRecipeApp.Mm.Identity.Models
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
