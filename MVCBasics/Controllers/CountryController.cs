using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        ICountryService CS;
        public CountryController(ICountryService _CS)
        {
            CS = _CS;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CountryIndex(string search)
        {
            CountryViewModel CVM = new CountryViewModel();
            CVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(CVM.SearchPhrase))
            {
                return PartialView("_CountryListPartial", CS.All());
            }
            return PartialView("_CountryListPartial", CS.FindBy(CVM));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryViewModel m)
        {
            CS.Add(m.CreateCountry);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult CountryDetails(int ID)
        {
            CreateCountryViewModel CVPM = new CreateCountryViewModel();
            CVPM.Model = CS.FindBy(ID);
            return PartialView("_CountryDetailsPartial", CVPM);
        }
        public IActionResult Delete(int ID)
        {
            if (CS.Remove(ID))
            {
                ViewBag.Message = "Deleted";
                return Accepted();
            }
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }
    }
}
