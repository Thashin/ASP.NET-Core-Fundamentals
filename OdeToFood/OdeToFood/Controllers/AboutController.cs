using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController:Controller
    { 
        //default Route
        [Route("")]
        public string Phone()
        {
        return "0412345678";
        }
        
        public string Address()
        {
            return "AU";
        }
    }
}