namespace RentalSystem.Domain.Dtos
{
    public class MotorcycleCreatedEvent
    {
        public string MotorcycleId { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
    }
}
