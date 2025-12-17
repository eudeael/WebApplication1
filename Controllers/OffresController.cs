using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class OffresController : Controller
    {
        // Stockage temporaire en mémoire (à remplacer par EF/BDD)
        private static List<OffresViewModel> _offres = new List<OffresViewModel>
        {
            new OffresViewModel { Id = 1, Intitule = "Développeur .NET", NiveauDiplomeRequis = "Master Informatique", NiveauHierarchique = "Cadre", MobiliteRequise = true },
            new OffresViewModel { Id = 2, Intitule = "Assistant RH", NiveauDiplomeRequis = "Licence Gestion", NiveauHierarchique = "Employé", MobiliteRequise = false }
        };

        // GET: Offre
        public ActionResult Index()
        {
            return View(_offres);
        }

        // POST: Offre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffresViewModel offre)
        {
            if (ModelState.IsValid)
            {
                offre.Id = _offres.Count + 1;
                _offres.Add(offre);
                return RedirectToAction("Index");
            }
            return View("Index", _offres);
        }
    }
}
