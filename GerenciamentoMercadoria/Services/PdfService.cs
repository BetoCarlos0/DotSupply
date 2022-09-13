using GerenciamentoMercadoria.Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using GerenciamentoMercadoria.Models;

namespace GerenciamentoMercadoria.Services
{
    public class PdfService : IPdfService
    {
        private readonly GerenciamentoMercadoriaContext _DbContext;

        public PdfService(GerenciamentoMercadoriaContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task GerarPdf()
        {
            //configura dados do pdf
            var nomeArquivo = $"Relatorio.{DateTime.Now.ToString("dd.MM.yyyy-HH.mm")}.pdf";
            var direc = Directory.CreateDirectory(Environment.CurrentDirectory + "/wwwroot/Relatorios");
            var caminho = Path.Combine(direc.FullName, nomeArquivo);
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var arquivo = new FileStream(caminho, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            pdf.Open();

            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            //adiciona título
            var fonteParagrafo = new iTextSharp.text.Font(fonteBase, 23, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório de entrada de mercadorias\n\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            titulo.SpacingAfter = 4;
            pdf.Add(titulo);

            //add tabela
            var tabela = new PdfPTable(4);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriaCelula(tabela, "Quantidade", PdfPCell.ALIGN_LEFT, true);
            CriaCelula(tabela, "Mercadoria", PdfPCell.ALIGN_CENTER, true);
            CriaCelula(tabela, "Data", PdfPCell.ALIGN_CENTER, true);
            CriaCelula(tabela, "Local", PdfPCell.ALIGN_CENTER, true);


            var entradaMercadoria = await _DbContext.EntradaMercadoria.Include(x => x.Mercadoria).ToListAsync();

            foreach (var item in entradaMercadoria)
            {
                CriaCelula(tabela, item.Quantidade.ToString(), PdfPCell.ALIGN_CENTER);
                CriaCelula(tabela, item.Mercadoria.Nome, PdfPCell.ALIGN_CENTER);
                CriaCelula(tabela, item.Data.ToString("dd/MM/yyyy HH:mm"), PdfPCell.ALIGN_CENTER);
                CriaCelula(tabela, item.Local, PdfPCell.ALIGN_RIGHT);
            }
            pdf.Add(tabela);


            pdf.NewPage();
            titulo = new Paragraph("Relatório de saída de mercadorias\n\n", fonteParagrafo);
            pdf.Add(titulo);

            var newTabela = new PdfPTable(4);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriaCelula(newTabela, "Quantidade", PdfPCell.ALIGN_LEFT, true);
            CriaCelula(newTabela, "Mercadoria", PdfPCell.ALIGN_CENTER, true);
            CriaCelula(newTabela, "Data", PdfPCell.ALIGN_CENTER, true);
            CriaCelula(newTabela, "Local", PdfPCell.ALIGN_CENTER, true);

            var saidaMercadoria = await _DbContext.SaidaMercadoria.Include(x => x.Mercadoria).ToListAsync();
            foreach (var item in saidaMercadoria)
            {
                CriaCelula(newTabela, item.Quantidade.ToString(), PdfPCell.ALIGN_CENTER);
                CriaCelula(newTabela, item.Mercadoria.Nome, PdfPCell.ALIGN_CENTER);
                CriaCelula(newTabela, item.Data.ToString("dd/MM/yyyy HH:mm"), PdfPCell.ALIGN_CENTER);
                CriaCelula(newTabela, item.Local, PdfPCell.ALIGN_RIGHT);
            }

            pdf.Add(newTabela);

            pdf.Close();
            arquivo.Close();

            var caminhoPdf = AddQuotesIfRequired(Path.Combine(direc.FullName, nomeArquivo));
            Process.Start(new ProcessStartInfo()
            {
                Arguments = $"/c start chrome {caminhoPdf}",
                FileName = "cmd.exe",
                CreateNoWindow = true
            });
        }

        private void CriaCelula(PdfPTable tabela, string texto,
            int alinhamento = PdfPCell.ALIGN_LEFT,
            bool negrito = false, bool italico = false,
            int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int estilo = iTextSharp.text.Font.NORMAL;
            if (negrito && italico)
            {
                estilo = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                estilo = iTextSharp.text.Font.ITALIC;
            }

            BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font fonte = new iTextSharp.text.Font(fonteBase, tamanhoFonte,
                estilo, iTextSharp.text.BaseColor.Black);

            //cor de fundo diferente para linhas pares e ímpares
            var bgColor = iTextSharp.text.BaseColor.White;
            if (tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95f, 0.95f, 0.95f);

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.PaddingBottom = 5; //pra alinhar melhor verticalmente
            celula.FixedHeight = alturaCelula;
            celula.BackgroundColor = bgColor;
            tabela.AddCell(celula);
        }

        private string AddQuotesIfRequired(string path)
        {
            return !string.IsNullOrWhiteSpace(path) ?
                path.Contains(" ") && (!path.StartsWith("\"") && !path.EndsWith("\"")) ?
                    "\"" + path + "\"" : path :
                    string.Empty;
        }
    }
}
