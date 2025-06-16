using TAREA13_AaronCondori.Services;
using TAREA13_AaronCondori.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB13_AaronCondori.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly ExcelReportService _excelService;

        public ReportesController(ExcelReportService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet("productos")]
        public IActionResult DescargarReporteProductos()
        {
            var contenido = _excelService.GenerarReporteProductos();

            var nombreArchivo = "ReporteProductos.xlsx";
            return File(contenido, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo);
        }
    }
}

