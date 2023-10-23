namespace WebApi.Models
{
    public class Prodotto
    {
        public int ProdottoId {  get; set; }    
        public string Nome { get; set; }
        public string? UnitMisura { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
    }
}
