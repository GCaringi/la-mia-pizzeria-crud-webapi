using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using la_mia_pizzeria_crud_webapi.Context;
using la_mia_pizzeria_crud_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_crud_webapi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;
        
        public HomeController(ApplicationDbContext ctx)
        {
            _ctx = new ApplicationDbContext();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            List<Pizza> pizzas = _ctx.Pizzas.ToList();
            return Ok(pizzas);
        }
    }
}
