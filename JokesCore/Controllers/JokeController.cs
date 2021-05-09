using JokesCore.Data;
using JokesCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesCore.Controllers
{
    public class JokeController : Controller
    {
        // GET: JokeController
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public JokeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: JokeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: JokeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: JokeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(TestJokeViewModel model)
        {
           
                try
                {
                if (ModelState.IsValid)
                {
                    if (User.Identity.Name != null)
                    {
                        model.NewJoke.Account = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                        model.NewJoke.AccountId = model.NewJoke.Account.Id;
                    }
                    await _context.Jokes.AddAsync(model.NewJoke);
                    int ok = await _context.SaveChangesAsync();
                    if (ok > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
         
            
        }

        // GET: JokeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JokeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JokeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JokeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
