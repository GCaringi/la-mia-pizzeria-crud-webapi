﻿using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_webapi.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Pizza>? Pizzas { get; set; }

    public Ingredient()
    {
        
    }
}