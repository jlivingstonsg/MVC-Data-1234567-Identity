using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguageController : Controller
    {
        ILanguageService LS;
        private readonly IPeopleService ps;

        public LanguageController(ILanguageService _LS, IPeopleService _ps)
        {
            LS = _LS;
            ps = _ps;
        }
        public IActionResult Index()
        {
            LanguageViewModel LVM = new LanguageViewModel();
            LVM.AllPeople = ps.All().people;
            return View(LVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LanguageViewModel m)
        {
            LS.Add(m.CreateLanguage);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult AddToPerson(int LID,string PersonName)
        {
            LS.AddToPerson(LID, PersonName);
            return RedirectToAction("Index");
        }
        public IActionResult LanguageIndex(string search)
        {
            LanguageViewModel LVM = new LanguageViewModel();
            LVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(LVM.SearchPhrase))
            {
                return PartialView("_LanguageListPartial", LS.All());
            }
            return PartialView("_LanguageListPartial", LS.FindBy(LVM));
        }
        public IActionResult LanguageDetails(int ID)
        {
            CreateLanguageViewModel LVPM = new CreateLanguageViewModel();
            LVPM.Model = LS.FindBy(ID);
            return PartialView("_LanguageDetailsPartial", LVPM);
        }
        public async Task<IActionResult> Delete(int ID)
        {
            if (await LS.Remove(ID))
            {
                
                ViewBag.Message = "Deleted";
                return Accepted();
                //return Json(new { success = true, responseText = "deleted" });
            }
            //return RedirectToAction("Index");
            //return Json(new { success = false, responseText = "not deleted" });
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }
    }
}
