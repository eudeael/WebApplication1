using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ScoringController : Controller
    {
        // Stockage temporaire en mémoire (à remplacer par EF/BDD)
        private static List<ScoringModel> _scores = new List<ScoringModel>
        {
            new ScoringModel { Id = 1, EmployeNom = "Durand Alice", Critere = "Performance", Note = 85, Commentaire = "Très bon travail", DateEvaluation = DateTime.Now.AddDays(-10) },
            new ScoringModel { Id = 2, EmployeNom = "Martin Bob", Critere = "Ponctualité", Note = 70, Commentaire = "Quelques retards", DateEvaluation = DateTime.Now.AddDays(-5) }
        };

        // GET: Scoring
        public ActionResult Index()
        {
            return View(_scores);
        }

        // POST: Scoring/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoringModel score)
        {
            if (ModelState.IsValid)
            {
                score.Id = _scores.Count + 1;
                score.DateEvaluation = DateTime.Now;
                _scores.Add(score);
                return RedirectToAction("Index");
            }
            return View("Index", _scores);
        }
    }
}
