using AppExtratoBancario.API.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using AppExtratoBancario.API.Services;
using AppExtratoBancario.API.Services.ServiceGeraPdf;
using AppExtratoBancario.API.Services.ServicoDeValidacao;

namespace AppExtratoBancario.API.Controllers
{
    public class ExtratoBancarioController : Controller
    {
        private readonly IBancoUnitOfWork _bancoUnitOfWork;
        private readonly IExtratoPdfService _pdfService;
        private readonly IParametroValidador _parametroValidador;

        public ExtratoBancarioController(IBancoUnitOfWork bancoUnitOfWork, IExtratoPdfService pdfService, IParametroValidador parametroValidador)
        {
            _bancoUnitOfWork = bancoUnitOfWork;
            _pdfService = pdfService;
            _parametroValidador = parametroValidador;
        }

        [HttpGet("transacoes")]
        public async Task<IActionResult> GetTransacoes([FromQuery] string dias)
        {
            try
            {
                _parametroValidador.ValidarDias(dias);

                int diasInt = int.Parse(dias);

                var dataFinal = DateTime.Now.Date.AddDays(1).AddTicks(-1);
                var dataInicio = dataFinal.AddDays(-diasInt);
                var transacoes = await _bancoUnitOfWork.Transacoes.GetTransacoesAsync(dataInicio, dataFinal);

                return Ok(transacoes.Select(t => new
                {
                    Data = t.Data.ToString("dd/MM/yyyy"),
                    t.TipoTransacao,
                    t.Quantia
                }));
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("transacoes/pdf")]
        public async Task<IActionResult> GetTransacoesPdf([FromQuery] string dias)
        {
            try
            {
                _parametroValidador.ValidarDias(dias);

                int diasInt = int.Parse(dias);

                var dataFinal = DateTime.Now;
                var dataInicio = dataFinal.AddDays(-diasInt);
                var transacoes = await _bancoUnitOfWork.Transacoes.GetTransacoesAsync(dataInicio, dataFinal);

                byte[] pdfBytes = _pdfService.GerarPdf(transacoes);
                return File(pdfBytes, "application/pdf", "extrato.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

