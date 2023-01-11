using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserSaver.BLL;
using UserSaver.DAL.Model;
using UserSaver.Web.Models;

namespace UserSaver.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CrudOperations co = new CrudOperations();

        public HomeController(ILogger<HomeController> logger/*,CrudOperations co*/)
        {
            _logger = logger;
            //this.co = co;
        }

        public IActionResult Index() => View();
        
        public IActionResult Privacy() => View(co.GetAllUser());
        public IActionResult Create() => View();

        public IActionResult Edit(int id)
        {
            User? user = co.GetUser(id);
            return View(user);
        } 

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            co.Delete(id);
            return RedirectToAction("Privacy");
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            co.Create(user);
           return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            co.Update(user);
            return RedirectToAction("Privacy");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}