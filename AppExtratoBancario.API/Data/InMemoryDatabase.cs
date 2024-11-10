using AppExtratoBancario.API.Models;

namespace AppExtratoBancario.API.Data
{
    public class InMemoryDatabase
    {
        public List<Transacao> Transacoes { get; set; }

        public InMemoryDatabase()
        {
            Transacoes = new List<Transacao>
            {
                new Transacao { Id = 1, Data = DateTime.Now.AddDays(-1),  TipoTransacao = "Depósito", Quantia = 1000 },
                new Transacao { Id = 2, Data = DateTime.Now.AddDays(-2),  TipoTransacao = "Saque", Quantia = -200 },                
                new Transacao { Id = 3, Data = DateTime.Now.AddDays(-5),  TipoTransacao = "Pagamento", Quantia = -150 },
                new Transacao { Id = 4, Data = DateTime.Now.AddDays(-6),  TipoTransacao = "Depósito", Quantia = 500 },                
                new Transacao { Id = 5, Data = DateTime.Now.AddDays(-9),  TipoTransacao = "Transferência", Quantia = -300 },
                new Transacao { Id = 6, Data = DateTime.Now.AddDays(-10), TipoTransacao = "Depósito", Quantia = 700 },              
                new Transacao { Id = 7, Data = DateTime.Now.AddDays(-15), TipoTransacao = "Pagamento", Quantia = -100 },
                new Transacao { Id = 8, Data = DateTime.Now.AddDays(-18), TipoTransacao = "Transferência", Quantia = -250 },                
                new Transacao { Id = 9, Data = DateTime.Now.AddDays(-20), TipoTransacao = "Depósito", Quantia = 400 },
            };
        }
    }
}
