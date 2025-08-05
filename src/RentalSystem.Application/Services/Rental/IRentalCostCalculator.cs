
namespace RentalSystem.Application.Services.Rental
{
    public interface IRentalCostCalculator
    {
        decimal CalculatePlannedTotal(int plandays);
        decimal CalculateTotalWithReturn(int planDays, DateTime expectedEndDate, DateTime actualEndDate);
    }
}