using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    //This class is used to avoid post overloading when submitting forms
    //This is a type of an input viewmodel
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType cuisineType { get; set; }
    }
}
