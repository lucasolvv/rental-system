using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Rentals.Validators.CreateRentalValidators
{
    public class RentalPlanValidator
    {
        private static readonly Dictionary<int, decimal> PlanRates = new()
        {
            { 7, 30.00m },
            { 15, 28.00m },
            { 30, 22.00m },
            { 45, 20.00m },
            { 50, 18.00m }
        };

        public void Validate(int planDays)
        {
            if (!PlanRates.ContainsKey(planDays))
                throw new ErrorOnValidationException($"Plano de {planDays} dias não é válido.");
        }

        public decimal GetDailyRate(int planDays)
        {
            return PlanRates.TryGetValue(planDays, out var rate)
                ? rate
                : throw new ErrorOnValidationException($"Plano de {planDays} dias não é válido.");
        }
    }
}
