using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly MyPortfolioContext _context;

        public ExperienceController(MyPortfolioContext context)
        {
            _context = context;
        }
        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value != null)
            {
                _context.Experiences.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("ExperienceList");
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("ExperienceList");

        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
           _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

    }
}
