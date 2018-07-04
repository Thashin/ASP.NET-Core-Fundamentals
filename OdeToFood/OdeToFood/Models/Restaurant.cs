using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name="Restaurant name")]
        [Required,MaxLength(80)]
        public string Name { get; set; }
        public CuisineType cuisineType { get; set; }
    }
}
