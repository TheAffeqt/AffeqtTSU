using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstLab.Models;
using FirstLab.Services;

namespace FirstLab.Controllers
{
    public class CalcController : Controller
    {
        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsingModelCalc()
        {
            CalcModel calcModel = Calculate();
            return View(calcModel);
        }

        public IActionResult ViewDataCalc()
        {
            ViewData["data"] = Calculate();
            return View();
        }

        public IActionResult ViewBagCalc()
        {
            ViewBag.data = Calculate();
            return View();
        }

        public IActionResult ServiceInjectionCalc()
        {
            return View();
        }

        public CalcModel Calculate()
        {
            var rand = new Random();
            int value = rand.Next(0, 10);
            int value2 = rand.Next(0, 10);

            int div;
            try
            {
                div = value / value2;
            }
            catch (DivideByZeroException)
            {
                div = -1;
            }

            return new CalcModel
            {
                first = value,
                second = value2,
                resAdd = value + value2,
                resSub = value - value2,
                resDiv = div,
                resMult = value * value2
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
