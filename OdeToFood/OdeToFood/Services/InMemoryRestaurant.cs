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

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }
    }
}
