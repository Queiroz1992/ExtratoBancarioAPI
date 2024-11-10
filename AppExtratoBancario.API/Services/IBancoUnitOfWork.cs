using AppExtratoBancario.API.Data.Repositories;

namespace AppExtratoBancario.API.Services
{
    public interface IBancoUnitOfWork
    {
        ITransacaoRepository Transacoes { get; }
    }
}
