using ClosedXML.Excel;
using TAREA13_AaronCondori.Models;
using System.IO;

namespace TAREA13_AaronCondori.Services
{
    public class ExcelReportService
    {
        private readonly LinqexampleContext _context;

        public ExcelReportService(LinqexampleContext context)
        {
            _context = context;
        }

        public byte[] GenerarReporteProductos()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Productos");

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Precio";
                worksheet.Cell(1, 4).Value = "Descripción";

                // Datos desde la base de datos
                var productos = _context.Products.ToList();

                int fila = 2;
                foreach (var producto in productos)
                {
                    worksheet.Cell(fila, 1).Value = producto.ProductId;
                    worksheet.Cell(fila, 2).Value = producto.Name;
                    worksheet.Cell(fila, 3).Value = producto.Price;
                    worksheet.Cell(fila, 4).Value = producto.Description;
                    fila++;
                }

                worksheet.Columns().AdjustToContents();

                // Exportar a byte[]
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}