using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ITerminologyRepository repo;

        public CategoriesController(ITerminologyRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var categories = repo.GetCategories();

            return View(categories);
        }
    }
}
