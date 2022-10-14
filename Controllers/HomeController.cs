﻿using System.Diagnostics;
using la_mia_pizzeria_crud_webapi.Context;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_webapi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        List<Pizza> pizzas = new();
        using (ApplicationDbContext db = new ApplicationDbContext())
        {
            pizzas = db.Pizzas.Include("Category").Include("Ingredients").ToList();
        }
        return View(pizzas);
    }
}