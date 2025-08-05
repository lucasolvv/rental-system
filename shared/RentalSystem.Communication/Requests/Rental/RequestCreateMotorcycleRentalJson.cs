namespace RentalSystem.Communication.Requests.Rental
{
    public class RequestCreateMotorcycleRentalJson
    {
        public string Entregador_id { get; set; }
        public string Moto_id { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_termino { get; set; }
        public DateTime Data_previsao_termino { get; set; }
        public int Plano { get; set; }
    }
}
