using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MG.App.Controllers
{
    public class FormDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo1()
        {
            return View();
        }

        public IActionResult Demo2()
        {
            return View();
        }
    }
}