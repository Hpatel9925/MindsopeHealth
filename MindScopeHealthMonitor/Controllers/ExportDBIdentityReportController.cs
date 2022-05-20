using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService.Interfaces;

namespace MindscopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportDBIdentityReportController : ControllerBase
    {
        private readonly IExportDBIdentityReportService _exportDBIdentityReport;

        public ExportDBIdentityReportController(IExportDBIdentityReportService exportDBIdentityReport)
        {
            _exportDBIdentityReport = exportDBIdentityReport;
        }

        [HttpPost]
        public void exportDBIdentityReport([FromBody] DBIdentityReport1 [] dBIdentityReport1)
        {
            _exportDBIdentityReport.ExportDBIdentityReport(dBIdentityReport1);
        }
    }
}
