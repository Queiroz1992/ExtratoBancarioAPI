using AppExtratoBancario.API.Models;

namespace AppExtratoBancario.API.Services.ServiceGeraPdf
{
    public interface IExtratoPdfService
    {
        byte[] GerarPdf(IEnumerable<Transacao> transacoes);
    }
}
