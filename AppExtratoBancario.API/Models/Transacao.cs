namespace AppExtratoBancario.API.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string TipoTransacao { get; set; } = string.Empty;
        public decimal Quantia { get; set; } = 0;
    }
}
