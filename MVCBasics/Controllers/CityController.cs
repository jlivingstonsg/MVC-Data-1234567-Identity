using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;

namespace MVCBasics.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CityController : Controller
    {
        ICityService CS;
        private readonly ICountryService cos;

        public CityController(ICityService _CS,ICountryService Cos)
        {
            CS = _CS;
            cos = Cos;
        }
        public IActionResult Index()
        {
            CityViewModel CVM = new CityViewModel();
            CVM.Countries = cos.All().Countries;
            return View(CVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CityViewModel m)
        {
            CS.Add(m.CreateCity);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult CityIndex(string search)
        {
            CityViewModel CVM = new CityViewModel();
            CVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(CVM.SearchPhrase))
            {
                return PartialView("_CityListPartial", CS.All());
            }
            return PartialView("_CityListPartial", CS.FindBy(CVM));
        }
        public IActionResult CityDetails(int ID)
        {
            CreateCityViewModel CVPM = new CreateCityViewModel();
            CVPM.Model = CS.FindBy(ID);
            return PartialView("_CityDetailsPartial", CVPM);
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
