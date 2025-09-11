using FutureValue.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValue.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Prefill with friendly defaults so the form isn’t blank
            var model = new FutureValueModel
            {
                MonthlyInvestment = 100,
                YearlyInterestRate = 5,
                Years = 10
            };
            ViewBag.FV = (decimal?)null;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FV = model.CalculateFutureValue();
            }
            else
            {
                ViewBag.FV = null;
            }
            return View(model);
        }
    }
}
