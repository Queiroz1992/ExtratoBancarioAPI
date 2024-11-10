using AppExtratoBancario.API.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace AppExtratoBancario.API.Services.ServiceGeraPdf
{
    public class ExtratoPdfService : IExtratoPdfService
    {
        public byte[] GerarPdf(IEnumerable<Transacao> transacoes)
        {
            using var memoryStream = new MemoryStream();

            var document = new Document(PageSize.A4, 10, 10, 10, 10);
            var writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var tituloFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            document.Add(new Paragraph("Extrato Bancário", tituloFont) { Alignment = Element.ALIGN_CENTER });
            document.Add(new Paragraph(" "));

            var table = new PdfPTable(3);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1, 2, 1 });

            var headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("Data", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Tipo da Transação", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
            table.AddCell(new PdfPCell(new Phrase("Quantia", headerFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

            var bodyFont = FontFactory.GetFont("Arial", 10);
            foreach (var transaction in transacoes)
            {
                table.AddCell(new PdfPCell(new Phrase(transaction.Data.ToString("dd/MM/yyyy"), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(transaction.TipoTransacao, bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                table.AddCell(new PdfPCell(new Phrase(transaction.Quantia.ToString("C2"), bodyFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
            }

            document.Add(table);
            document.Close();
            writer.Close();

            return memoryStream.ToArray();
        }
    }
}
