using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using la_mia_pizzeria_crud_webapi.Context;
using la_mia_pizzeria_crud_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_webapi.Controllers.API
{
    [Route("api/[controller]/[action]/{param?}")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;

        public PizzaController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetPizzas()
        {
            var pizzas = _ctx.Pizzas.ToList();
            return Ok(pizzas);
        }
        
        [HttpGet]
        public IActionResult GetByName(string? name)
        {
            var pizzas = _ctx.Pizzas.AsQueryable();
            
            if (name is not null)
            {
                pizzas = pizzas.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                return NotFound();
            }

            return Ok(pizzas);
        }
        
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var pizza = _ctx.Pizzas.Find(id);
            if (pizza is null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }
    }
}
