using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;
using WebApplication1.Models; // Contient Database1Entities4 et l'Entité HistoriqueEmploye

namespace WebApplication1.Controllers
{
    public class HistoriqueEmployeController : Controller
    {
        // 1. Initialisation du DbContext
        private Database1Entities4 db = new Database1Entities4();

        // ❌ SUPPRESSION de la liste statique _historiques

        // --- GET: HistoriqueEmploye/Index (Lecture BDD) ---
        public ActionResult Index()
        {
            // 1. Récupération des entités de la BDD
            // db.HistoriqueEmploye est la collection confirmée (DbSet)
            var historiquesEntites = db.HistoriqueEmploye.ToList();

            // 2. Mappage : Conversion des Entités BDD (plus complexes) vers le ViewModel (plus simple)
            var historiquesViewModel = historiquesEntites.Select(e => new HistoriqueEmployeViewModel
            {
                // Mappage de l'ID BDD vers le ViewModel (pour référence future)
                Id = e.IdHistoriqueEmploye,

                // ATTENTION : L'entité BDD n'a pas de champ 'EmployeNom'. 
                // Pour simuler, nous allons laisser la chaîne vide ou utiliser un Id si possible.
                // Dans un vrai projet, il faudrait charger le Nom via la navigation property 'ProfilEmploye'
                EmployeNom = e.IdEmploye.ToString(), // Utiliser l'Id de l'employé comme identifiant temporaire

                PosteOccupe = e.PosteOccupe,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Commentaire = e.CommentairesRH // Mappage du champ BDD 'CommentairesRH' vers le champ ViewModel 'Commentaire'

            }).ToList();

            return View(historiquesViewModel);
        }

        // --- POST: HistoriqueEmploye/Create (Écriture BDD) ---
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistoriqueEmployeViewModel historiqueViewModel)
        {
            if (ModelState.IsValid)
            {
                // 1. Mappage : Conversion du ViewModel (reçu du formulaire) en l'Entité BDD (pour la sauvegarde)
                var historiqueEntite = new HistoriqueEmploye
                {
                    // L'ID est géré par la BDD et n'est pas mappé ici.

                    // Il faudrait ici obtenir l'IdEmploye correct (une clé étrangère) à partir du Nom.
                    // Pour l'exemple, nous allons laisser la FK (IdEmploye) à 1. 
                    IdEmploye = 1, // <--- ATTENTION: Ceci doit être une valeur d'Id Employé valide de votre BDD

                    PosteOccupe = historiqueViewModel.PosteOccupe,
                    DateDebut = historiqueViewModel.DateDebut,
                    DateFin = historiqueViewModel.DateFin,
                    CommentairesRH = historiqueViewModel.Commentaire // Mappage du champ ViewModel 'Commentaire' vers le champ BDD 'CommentairesRH'

                    // Les autres champs BDD (Salaire, SuiviHierarchique, etc.) peuvent être null ou avoir des valeurs par défaut.
                };

                // 2. Ajout et Sauvegarde
                db.HistoriqueEmploye.Add(historiqueEntite);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // En cas d'erreur de validation, recharger et retourner la liste actuelle
            var historiquesViewModel = db.HistoriqueEmploye.ToList().Select(e => new HistoriqueEmployeViewModel
            {
                Id = e.IdHistoriqueEmploye,
                EmployeNom = e.IdEmploye.ToString(),
                PosteOccupe = e.PosteOccupe,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Commentaire = e.CommentairesRH
            }).ToList();

            return View("Index", historiquesViewModel);
        }

        // --- Nettoyage des Ressources (Obligatoire) ---
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}