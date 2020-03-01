using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManager.Areas.Identity.Data;
using FlightManager.Areas.Identity.Pages.Account;
using FlightManager.Data;
using FlightManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {

        private readonly UserManager<FlightManagerUser> _userManager;

        public AdministrationController(
            UserManager<FlightManagerUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: Administration
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        // GET: Administration/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Administration/Create
        public IActionResult Create()
        {
            return LocalRedirect("/Identity/Account/Register");
        }

        // POST: Administration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Username,Email,EGN,Name,Surname,PhoneNumber,Adress")] FlightManagerUser user)
        {
            return LocalRedirect("/Identity/Account/Register");
        }

        // GET: Administration/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Username,Email,EGN,Name,Surname,PhoneNumber,Adress")] FlightManagerUser user)
        {
            var redactedUser = _userManager.Users.FirstOrDefault(u => u.Id == id);

            if (id != user.Id)
            {
                return NotFound();
            }

            //for debug
            var errors = ModelState
                            .Where(x => x.Value.Errors.Count > 0)
                            .Select(x => new { x.Key, x.Value.Errors })
                            .ToArray();

            //if (ModelState.IsValid)
            //{
            try
            {
                redactedUser.Name = user.Name;
                redactedUser.UserName = user.UserName;
                redactedUser.Email = user.Email;
                redactedUser.EGN = user.EGN;
                redactedUser.Surname = user.Surname;
                redactedUser.PhoneNumber = user.PhoneNumber;
                redactedUser.Adress = user.Adress;
            }
            catch (Exception)
            {
            }
            await _userManager.UpdateAsync(redactedUser);
            return RedirectToAction(nameof(Index));
            //}
            //return View(user);
        }

        // GET: Administration/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Administration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(string id)
        {
            var deactivatedUser = _userManager.Users.FirstOrDefault(u => u.Id == id);
            await _userManager.DeleteAsync(deactivatedUser);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}