using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JokesCore.Models;
using JokesCore.Data;
using Microsoft.AspNetCore.Identity;
using JokesCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace JokesCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
             TestJokeViewModel model = new TestJokeViewModel();
            //if (User.Identity.Name != null)
            //{
            //  userID = _userManager.GetUserId(User);
            //}

            //test
            
            List<Joke> k = await _context.Jokes.ToListAsync();
            model.Jokes = new List<Joke>(k.TakeLast(3).Reverse());
            model.Emails = new List<string>();
            foreach (Joke item in model.Jokes)
            {
                IdentityUser check;
                if (string.IsNullOrEmpty(item.AccountId))
                {
                    model.Emails.Add("Anoniem");
                }
                else
                {
                    check = await _userManager.FindByIdAsync(item.AccountId);
                    model.Emails.Add(check.Email);
                }
            }
             await _userManager.FindByEmailAsync("guigilles@gmail.com");
            model.NewJoke = new Joke() { Rating = 0 };
           
            model.NewJoke.Account = await _userManager.GetUserAsync(HttpContext.User);
         
             return View(model);
        }

        public IActionResult Privacy()
        {            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
