using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            RoleViewModel RVM = new RoleViewModel();
            RVM.Roles = roleManager.Roles.ToList();
            RVM.AllUsers = userManager.Users.ToList();
            return View(RVM);
        }
        public IActionResult RoleIndex()
        {
            RoleViewModel RVM = new RoleViewModel();
            RVM.Roles = roleManager.Roles.ToList();
            RVM.AllUsers = userManager.Users.ToList();
            return PartialView("_RoleListPartial",RVM);
        }
        public async Task<IActionResult> AddUserToRole(string RoleName, string UserName) 
        {
            //var role = await roleManager.FindByNameAsync(RoleName);
            var user = await userManager.FindByNameAsync(UserName);
            await userManager.AddToRoleAsync(user,RoleName);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel Model)
        {
            IdentityRole identityRole = new IdentityRole { Name = Model.CreateRoleViewModel.Name };
            var result = await roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string ID)
        {
            CreateRoleViewModel CRVM = new CreateRoleViewModel();
            var role = await roleManager.FindByIdAsync(ID);
            CRVM.ID = role.Id;
            CRVM.Name = role.Name;
            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    CRVM.RoleUsers.Add(user);
                }
            }
            return View(CRVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateRoleViewModel crvm)
        {
            var role = await roleManager.FindByIdAsync(crvm.ID);
            role.Name = crvm.Name;
            await roleManager.UpdateAsync(role);
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, crvm.Name))
                {
                    crvm.RoleUsers.Add(user);
                }
            }
            return View(crvm);
        }
        public async Task<IActionResult> RoleDetails(string RoleName)
        {
            CreateRoleViewModel CRVM = new CreateRoleViewModel();
            var role = await roleManager.FindByNameAsync(RoleName);
            CRVM.ID = role.Id;
            CRVM.Name = RoleName;
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    CRVM.RoleUsers.Add(user);
                }
            }
            return PartialView("_RoleDetailsPartial", CRVM);
        }
        public async Task<IActionResult> Delete(string RoleName)
        {
            var role = await roleManager.FindByNameAsync(RoleName);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}
