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
             IdentityUser check = await _userManager.FindByEmailAsync("guigilles@gmail.com");
            model.Joke = _context.Jokes.Where(x => x.AccountId == check.Id).FirstOrDefault();
            model.Email = check.Email;
             return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
