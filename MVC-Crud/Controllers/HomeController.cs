﻿using Microsoft.AspNetCore.Mvc;

namespace MVC_Crud.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
