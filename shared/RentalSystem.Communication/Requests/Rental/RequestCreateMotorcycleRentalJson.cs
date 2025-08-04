namespace RentalSystem.Communication.Requests.Rental
{
    public class RequestCreateMotorcycleRentalJson
    {
        public string Entregador_id { get; set; }
        public string Moto_id { get; set; }
        public DateTimeOffset Data_inicio { get; set; }
        public DateTimeOffset Data_termino { get; set; }
        public DateTimeOffset Data_previsao_termino { get; set; }
        public int Plano { get; set; }
    }
}
