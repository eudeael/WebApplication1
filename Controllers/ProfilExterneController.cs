using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProfilExterneController : Controller
    {
        // GET: ProfilExterne
        public ActionResult Index()
        {
            var candidats = new List<ProfilExterneViewModel>
            {
                new ProfilExterneViewModel
                {
                    Id = 1,
                    Nom = "Durand",
                    Prenom = "Alice",
                    Email = "alice.durand@example.com",
                    DateCandidature = DateTime.Now.AddDays(-10),
                    Diplome = "Master Informatique",
                    OffreEmploi = "Développeur .NET"
                },
                new ProfilExterneViewModel
                {
                    Id = 2,
                    Nom = "Martin",
                    Prenom = "Bob",
                    Email = "bob.martin@example.com",
                    DateCandidature = DateTime.Now.AddDays(-5),
                    Diplome = "Licence Gestion",
                    OffreEmploi = "Assistant RH"
                }
            };

            return View(candidats);
        }

        // GET: ProfilExterne/Details/5
        public ActionResult Details(int id)
        {
            var candidat = new ProfilExterneViewModel
            {
                Id = id,
                Nom = "Exemple",
                Prenom = "Test",
                Email = "test@example.com",
                DateCandidature = DateTime.Now,
                Diplome = "Diplôme fictif",
                OffreEmploi = "Poste fictif"
            };

            return View(candidat);
        }

        // GET: ProfilExterne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilExterne/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfilExterneViewModel candidat)
        {
            if (ModelState.IsValid)
            {
                // Sauvegarde en base à implémenter
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: ProfilExterne/Edit/5
        public ActionResult Edit(int id)
        {
            var candidat = new ProfilExterneViewModel
            {
                Id = id,
                Nom = "Exemple",
                Prenom = "Test",
                Email = "test@example.com",
                DateCandidature = DateTime.Now,
                Diplome = "Diplôme fictif",
                OffreEmploi = "Poste fictif"
            };

            return View(candidat);
        }

        // POST: ProfilExterne/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfilExterneViewModel candidat)
        {
            if (ModelState.IsValid)
            {
                // Mise à jour en base à implémenter
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: ProfilExterne/Delete/5
        public ActionResult Delete(int id)
        {
            var candidat = new ProfilExterneViewModel
            {
                Id = id,
                Nom = "Exemple",
                Prenom = "Test",
                Email = "test@example.com",
                DateCandidature = DateTime.Now,
                Diplome = "Diplôme fictif",
                OffreEmploi = "Poste fictif"
            };

            return View(candidat);
        }

        // POST: ProfilExterne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Suppression en base à implémenter
            return RedirectToAction("Index");
        }
    }
}
