using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurant:IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurant()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id=1,Name="Pizza Hut"},
                new Restaurant{Id=2,Name="Dominoes"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
