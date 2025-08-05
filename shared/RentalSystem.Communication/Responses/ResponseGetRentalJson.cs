namespace RentalSystem.Communication.Responses
{
    public class ResponseGetRentalJson
    {
        public string Id { get; set; }
        public string Entregador_id { get; set; }
        public string Moto_id { get; set; }
        public DateTime Data_inicio { get; set; }
        public DateTime Data_termino { get; set; }
        public DateTime Data_previsao_permino { get; set; }
        public int Plano { get; set; }
        public decimal Valor_diaria { get; set; }
        public decimal? Valor_total { get; set; }
    }
}
