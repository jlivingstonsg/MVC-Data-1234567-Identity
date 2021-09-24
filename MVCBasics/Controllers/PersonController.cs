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
    [Authorize]
    public class PersonController : Controller
    {
        //Constructor Injection--Fetching IPeopleService Object from Startup ConfigureServices
        IPeopleService ps;
        private readonly ICityService CS;
        private readonly ILanguageService lS;
        PeopleViewModel PV = new PeopleViewModel();
        public PersonController(IPeopleService _ps,ICityService _CS,ILanguageService LS)
        {
            ps = _ps;
            CS = _CS;
            lS = LS;
        }
        public async Task<IActionResult> Index(PeopleViewModel search)
        {
            //Use Below Code For Table Data If Not Using AJAX
            //if (string.IsNullOrEmpty(search.SearchPhrase))
            //{
            //    return View(ps.All());
            //}
            //return View(ps.FindBy(search));
            
            PV.AllCities = CS.All().Cities;
            var pvm = await lS.All();
            PV.AllLanguages = pvm.Languages;
            return View(PV);
        }
        public async Task<IActionResult> AddToPerson(string LID, int PID)
        {
            var task = ps.AddToPerson(LID, PID);
            task.Wait();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PeopleViewModel m)
        {
            ps.Add(m.CreatePerson);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ID)
        {
            CreatePersonViewModel CVPM = new CreatePersonViewModel();
            CVPM.Model = ps.FindBy(ID);
            return View(CVPM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreatePersonViewModel p)
        {
            ps.Edit(p.ID, p.Model);
            return View(p);
        }
        public IActionResult Delete(int ID)
        {
            if(ps.Remove(ID))
            {
                //return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                ViewBag.Message = "Deleted";
                return Accepted();
                //return Json(new { success = true, responseText = "deleted" });
            }
            //return RedirectToAction("Index");
            //return Json(new { success = false, responseText = "not deleted" });
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }

        ///////////////////////// ACTIONS for AJAX
        ///
        public IActionResult PeopleIndex(string search)
        {
            PV.SearchPhrase = search;
            if (string.IsNullOrEmpty(PV.SearchPhrase))
            {
                return PartialView("_PeopleIndex", ps.All());
            }
            return PartialView("_PeopleIndex", ps.FindBy(PV));
        }
        public async Task<IActionResult> PersonDetails(int ID)
        {
            PV.CreatePerson = new CreatePersonViewModel();
            PV.CreatePerson.Model = ps.FindBy(ID);
            PV.CreatePerson.ID = ID;
            var pvm = await lS.All();
            PV.AllLanguages = pvm.Languages;
            return PartialView("_PersonDetails",PV);
        }
    }
}
