using AppExtratoBancario.API.Data;
using AppExtratoBancario.API.Data.Repositories;
using AppExtratoBancario.API.Models;
 


namespace AppExtratoBancario.API.Services
{
    public class UnitOfWork : IBancoUnitOfWork
    {
        public ITransacaoRepository Transacoes { get; }

        public UnitOfWork(ITransacaoRepository transacaoRepository)
        {
            Transacoes = transacaoRepository;
        }
    }
}
