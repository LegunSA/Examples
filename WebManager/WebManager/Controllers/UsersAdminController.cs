using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebManager.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebManager.Controllers
{
    public class UsersAdminController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public UsersAdminController(UserManager<ApplicationUser> manager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = manager;
            _roleManager = roleManager;
        }

        #region UserRegion
        [Authorize(Roles = "admin")]
        public IActionResult Index() => View(_userManager.Users.ToList());


        [Authorize(Roles ="admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new Exception();
                }
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var model = new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Name;

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();
                    var addedRoles = model.UserRoles.Except(userRoles);
                    var removedRoles = userRoles.Except(model.UserRoles);
                    await _userManager.AddToRolesAsync(user, addedRoles);
                    await _userManager.RemoveFromRolesAsync(user, removedRoles);

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("Index");
        }
        #endregion UserRegion

        #region RoleRegion
        [Authorize(Roles = "admin")]
        public IActionResult RoleList() => View(_roleManager.Roles.ToList());

        [Authorize(Roles = "admin")]
        public IActionResult CreateRole() => View();

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    new Exception();
                }
            }
            return View(name);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return View(role);
        }

        [HttpPost, ActionName("DeleteRole")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RoleDeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("RoleList");
        }

        #endregion RoleRegion
    }
}