using System;
using System.Collections.Generic;
using System.Web.Mvc;

using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class DiplomesController : Controller
    {
      
        private static List<DiplomeViewModel> _diplomes = new List<DiplomeViewModel>
        {
            // Données initiales en dur inspirées par votre entité Diplomes
            new DiplomeViewModel { IdDiplome = 1, NomDiplome = "Licence Informatique", NiveauDiplome = "Bac+3", Domaine = "IT" },
            new DiplomeViewModel { IdDiplome = 2, NomDiplome = "Master RH", NiveauDiplome = "Bac+5", Domaine = "Ressources Humaines" }
        };
        
        public ActionResult Index()
        {
            return View(_diplomes);
        }
        
        public ActionResult Create()
        {
          
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiplomeViewModel diplome)
        {
            if (ModelState.IsValid)
            {
                // Assignation d'un nouvel ID (simulant l'auto-incrément de la BDD)
                diplome.IdDiplome = _diplomes.Count > 0 ? _diplomes[_diplomes.Count - 1].IdDiplome + 1 : 1;

                // Ajout à la liste en mémoire
                _diplomes.Add(diplome);

                // Redirection vers l'affichage de la liste mise à jour
                return RedirectToAction("Index");
            }
            // En cas d'erreur de validation
            return View(diplome);
        }
    }
}