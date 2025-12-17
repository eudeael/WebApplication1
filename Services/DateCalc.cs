using System;

namespace WebApplication1.Services
{
    public class DateCalc
    {
        public int CalculateAge(DateTime dateNaissance)
        {
            var today = DateTime.Today;
            var age = today.Year - dateNaissance.Year;
            if (dateNaissance.Date > today.AddYears(-age)) age--;
            return age;
        }

        public string CalculateSeniorityString(DateTime dateEmbauche)
        {
            var today = DateTime.Today;
            var totalMonths = (today.Year - dateEmbauche.Year) * 12 + today.Month - dateEmbauche.Month;
            var years = totalMonths / 12;
            var months = totalMonths % 12;
            if (years <= 0) return $"{months} mois";
            return months == 0 ? $"{years} an(s)" : $"{years} an(s) {months} mois";
        }

        public double CalculateSeniorityYears(DateTime dateEmbauche)
        {
            var today = DateTime.Today;
            var totalDays = (today - dateEmbauche).TotalDays;
            return Math.Round(totalDays / 365.25, 2);
        }
    }
}
