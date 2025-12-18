using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Services
{
    public class MatchingService
    {
        private readonly DistanceService _distanceService;

        public MatchingService(DistanceService distanceService)
        {
            _distanceService = distanceService;
        }

        // Règles : distance calculée, pas de rétrogradation (niveau offre >= niveau actuel), max +5 niveaux
        public List<PostesModel> MatchOffersForEmployee(
            ProfilEmploye profil,
            List<OffresEmploi> offres,
            List<Postes> postesReference)
        {
            var result = new List<PostesModel>();

            if (profil == null || offres == null || !offres.Any())
                return result;

            // Déterminer le niveau actuel
            string niveauActuel = profil.Postes?.NiveauHierarchique
                                  ?? postesReference.FirstOrDefault(p => p.IdPoste == profil.IdPosteActuel)?.NiveauHierarchique;

            var currentRank = GetHierarchyRank(niveauActuel);

            foreach (var offre in offres)
            {
                var offerRank = GetHierarchyRank(offre.NiveauPoste);

                // Règles métier
                if (offerRank < currentRank) continue;          // pas de rétrogradation
                if (offerRank > currentRank + 5) continue;      // max +5 niveaux

                // Distance sécurisée
                double distance = 0;
                if (!string.IsNullOrWhiteSpace(profil.Adresse) && !string.IsNullOrWhiteSpace(offre.Localisation))
                {
                    distance = _distanceService.CalculateDistanceKm(profil.Adresse, offre.Localisation);
                }

                result.Add(new PostesModel
                {
                    IdOffre = offre.IdOffreEmploi,
                    IntitulePoste = offre.IntitulePoste,
                    Localisation = offre.Localisation,
                    NiveauPoste = offre.NiveauPoste,
                    DistanceKm = Math.Round(distance, 1),
                    Salaire = (decimal)offre.SalairePropose,
                    TypeContrat = offre.TypeContrat,
                    TeletravailPossible = offre.TeletravailPossible
                });
            }

            // Trier : distance ascendante puis niveau
            return result
                .OrderBy(r => r.DistanceKm)
                .ThenByDescending(r => GetHierarchyRank(r.NiveauPoste))
                .ToList();
        }

        // Mapping simple de niveaux hiérarchiques en rangs entiers
        private int GetHierarchyRank(string niveau)
        {
            if (string.IsNullOrWhiteSpace(niveau)) return 0;

            if (int.TryParse(niveau, out var numeric)) return numeric;

            var s = niveau.ToLowerInvariant();
            if (s.Contains("stag") || s.Contains("junior") || s.Contains("assistant")) return 1;
            if (s.Contains("inter") || s.Contains("confirm") || s.Contains("associate")) return 2;
            if (s.Contains("senior") || s.Contains("expert")) return 3;
            if (s.Contains("lead") || s.Contains("chef")) return 4;
            if (s.Contains("manager") || s.Contains("responsable")) return 5;
            if (s.Contains("directeur") || s.Contains("director") || s.Contains("head")) return 6;
            if (s.Contains("vp") || s.Contains("vice")) return 7;
            if (s.Contains("cxo") || s.Contains("ceo") || s.Contains("cto")) return 8;

            var digits = new string(niveau.Where(char.IsDigit).ToArray());
            if (int.TryParse(digits, out var d)) return d;

            return 2; // valeur neutre par défaut
        }
    }
}
