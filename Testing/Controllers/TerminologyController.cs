using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class TerminologyController : Controller
    {
        private readonly ITerminologyRepository repo;

        public TerminologyController (ITerminologyRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var terminology = repo.GetAllTerminologies();
            return View(terminology);
        }

        public IActionResult ViewTerminology (int id)
        {
            var terminology = repo.GetTerminology (id);
            return View(terminology);
        }

        public IActionResult UpdateTerminology(int id)
        {
            Terminology terminology = repo.GetTerminology(id);
            if (terminology == null)
            {
                return View("TerminologyNotFound");
            }
            return View(terminology);
        }

        public IActionResult UpdateTerminologyToDatabase(Terminology terminology)
        {
            repo.UpdateTerminology(terminology);

            return RedirectToAction("ViewTerminology", new { id = terminology.ID });
        }

        public IActionResult ViewAllOfCategory (string category) 
        {
            var terminology = repo.GetAllOfCategory(category);
            return View(terminology);
        }
        public IActionResult InsertTerminology()
        {
            var terminology = repo.AssignCategory();
            return View(terminology);
        }
        public IActionResult InsertTerminologyToDatabase(Terminology TerminologyToInsert)
        {
            repo.InsertTerminology(TerminologyToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTerminology(Terminology terminology)
        {
            repo.DeleteTerminology(terminology);
            return RedirectToAction("Index");
        }

    }
}
