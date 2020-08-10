using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Pages.Profiles
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User UserProfile { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost([FromServices] AppDbContext db)
        {
            db.Users.Add(UserProfile);
            db.SaveChanges();

            return RedirectToPage("/index");
        }
    }
}
