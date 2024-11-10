using AppExtratoBancario.API.Models;

namespace AppExtratoBancario.API.Data.Repositories
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> GetTransacoesAsync(DateTime dataInicio, DateTime dataFinal);
    }
}
