using System.ComponentModel.DataAnnotations;

namespace FutureValue.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Monthly investment is required.")]
        [Range(1, 1_000_000, ErrorMessage = "Enter 1 to 1,000,000.")]
        public decimal MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Yearly interest rate is required.")]
        [Range(0.1, 100, ErrorMessage = "Enter 0.1 to 100 (%).")]
        public decimal YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Years is required.")]
        [Range(1, 50, ErrorMessage = "Enter 1 to 50 years.")]
        public int Years { get; set; }

        public decimal CalculateFutureValue()
        {
            var monthlyRate = YearlyInterestRate / 1200m;
            var months = Years * 12;
            decimal fv = 0m;
            for (int i = 0; i < months; i++)
                fv = (fv + MonthlyInvestment) * (1 + monthlyRate);
            return Math.Round(fv, 2);
        }
    }
}
