using Domain.Interfaces;


namespace Infrastructure.Services
{
    internal class TaxCalculatorApi : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount)
        {
            //hear can be Calculation request to Tax Api
            return (amount * 20) / 100;
        }
    }
}
