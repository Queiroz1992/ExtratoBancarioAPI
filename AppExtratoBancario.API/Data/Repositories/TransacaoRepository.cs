using AppExtratoBancario.API.Data;
using AppExtratoBancario.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppExtratoBancario.API.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {

        private readonly InMemoryDatabase _database;

        public TransacaoRepository(InMemoryDatabase database)
        {
            _database = database;
        }

        public Task<IEnumerable<Transacao>> GetTransacoesAsync(DateTime dataInicio, DateTime dataFinal)
        {
            var transacoes = _database.Transacoes
                .Where(t => t.Data.Date >= dataInicio.Date && t.Data.Date <= dataFinal.Date)
                .ToList();
            
            return Task.FromResult<IEnumerable<Transacao>>(transacoes);
        }
    }
}
