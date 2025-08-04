using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.Services.Rental
{
    public class RentalCostCalculator : IRentalCostCalculator
    {
        private readonly Dictionary<int, decimal> _dailyRates = new()
        {
            { 7, 30.00m },
            { 15, 28.00m },
            { 30, 22.00m },
            { 45, 20.00m },
            { 50, 18.00m }
        };

        // taxas de penalidade por devolução antecipada
        private readonly Dictionary<int, decimal> _earlyReturnPenalties = new()
        {
            { 7, 0.20m },   // 20%
            { 15, 0.40m }   // 40%
        };

        private const decimal LateReturnFeePerDay = 50.00m; // Taxa fixa de R$50,00 por dia de atraso

        public decimal CalculatePlannedTotal(int plandays)
        {
            var dailyRate = GetDailyRate(plandays);
            return dailyRate * plandays;
        }

        public decimal CalculateTotalWithReturn(
            int planDays,
            DateTimeOffset expectedEndDate,
            DateTimeOffset actualEndDate
            )
        {
            var dailyRate = GetDailyRate(planDays);

            if (actualEndDate.Date < expectedEndDate)
            {
                var daysUsed = (actualEndDate.Date - expectedEndDate.Date).Days + planDays;
                var baseCost = daysUsed * dailyRate;

                var daysNotUsed = (expectedEndDate.Date - actualEndDate.Date).Days;
                var penaltyRate = GetPenaltyRate(planDays);
                var penalty = (daysNotUsed * dailyRate) * penaltyRate;

                return baseCost + penalty;

            }
            if (actualEndDate.Date > expectedEndDate.Date)
            {
                var extraDays = (actualEndDate.Date - expectedEndDate.Date).Days;
                var plannedTotal = planDays * dailyRate;
                var extraFee = extraDays * LateReturnFeePerDay;

                return plannedTotal + extraFee;
            }

            // Devolveu exatamente no prazo
            return planDays * dailyRate;
        }

        private decimal GetDailyRate(int planDays)
        {
            return _dailyRates.TryGetValue(planDays, out var rate)
                ? rate
                : throw new ErrorOnValidationException($"Plano de {planDays} dias não é válido.");
        }

        private decimal GetPenaltyRate(int planDays)
        {
            return _earlyReturnPenalties.TryGetValue(planDays, out var penalty)
                ? penalty
                : 0.0m; // Outros planos não têm multa definida
        }
    }
}
