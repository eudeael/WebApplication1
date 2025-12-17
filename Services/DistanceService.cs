using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Services
{
    // Service de distance « démo » déterministe (sans API externe).
    public class DistanceService
    {
        // Retourne une estimation en kilomètres entre deux adresses (démo fiable/déterministe).
        public double CalculateDistanceKm(string adresse1, string adresse2)
        {
            if (string.IsNullOrWhiteSpace(adresse1) || string.IsNullOrWhiteSpace(adresse2))
                return double.MaxValue;

            if (string.Equals(adresse1.Trim(), adresse2.Trim(), StringComparison.OrdinalIgnoreCase))
                return 0;

            // Déterministe : hash des chaînes -> valeur pseudo-distance (0..100)
            var hash1 = ComputeStableHash(adresse1);
            var hash2 = ComputeStableHash(adresse2);
            var diff = Math.Abs(hash1 - hash2);
            // Normaliser en km
            return Math.Round((diff % 10000) / 100.0 * 20.0, 1); // résultat approximatif 0..200km
        }

        private int ComputeStableHash(string s)
        {
            using (var sha = SHA256.Create())
            {
                var data = sha.ComputeHash(Encoding.UTF8.GetBytes(s.ToLowerInvariant()));
                // utiliser 4 octets pour un entier
                return BitConverter.ToInt32(data, 0) & 0x7FFFFFFF;
            }
        }
    }
}
