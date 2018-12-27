using Contracts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateIvhunPdf(FinalIvhunSolution ivhun)
        {
            byte[] pdfBytes;
            using (var mem = new MemoryStream())
            {
                Document document = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, mem);
                document.Open();
                Paragraph p = new Paragraph("blablablabl");
                document.Add(p);
                document.Close();



                pdfBytes = mem.ToArray();
                //PdfDocument document = new PdfDocument();
                //PdfPage page = document.AddPage();
                //XGraphics gfx = XGraphics.FromPdfPage(page);
                //XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
                //gfx.DrawString("Hello, World!", font, XBrushes.Black,
                //    new XRect(0, 0, page.Width, page.Height),
                //    XStringFormats.Center);

            }
            return pdfBytes;
        }
    }
}
