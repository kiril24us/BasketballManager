namespace BasketballManager.Web.ViewModels.Players
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using BasketballManager.Data.Models;
    using BasketballManager.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class AddPlayerViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 80)]
        public int Age { get; set; }

        [Required]
        [Range(1, 300)]
        public double Height { get; set; }

        [Required]
        [Range(1, 200)]
        public double Kilos { get; set; }

        [Required]
        [Range(0, 99)]
        public int Number { get; set; }

        [Required]
        public string PositionType { get; set; }

        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}
