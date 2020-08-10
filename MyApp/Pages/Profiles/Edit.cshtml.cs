using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Profiles
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public User UserProfile { get; set; }

        public SelectList SelectCountry { get; set; }
        public void OnGet(int id,[FromServices] AppDbContext db)
        {
            UserProfile = db.Users.Find(id);

            var countries = db.Countries.ToList();
            SelectCountry = new SelectList(countries, "Name", "Name");

        }

        public IActionResult OnPost([FromServices] AppDbContext db)
        {
            var userProfile = db.Users.Find(UserProfile.Id);

            userProfile.Name = UserProfile.Name;
            userProfile.Country = UserProfile.Country;

            db.SaveChanges();

            return RedirectToPage("/index");
        }
    }
}
