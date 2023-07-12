using BottomDrawer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BottomDrawer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ProjectModel project = new ProjectModel("test", "test", "test");
            project.Save();


            List<ProjectModel> projects = ProjectModel.GetAll();

            return View(projects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}