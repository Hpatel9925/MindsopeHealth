using MindScopeHealthMonitorRepository.Interfaces;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorService
{
    public class ExportDBIdentityReportService : IExportDBIdentityReportService
    {
        private readonly IExportDBIdentityReport _exportDBIdentityReport;

        public ExportDBIdentityReportService(IExportDBIdentityReport exportDBIdentityReport)
        {
            _exportDBIdentityReport = exportDBIdentityReport;
        }
        public void ExportDBIdentityReport(DBIdentityReport1 [] dBIdentityReport1)
        {
            _exportDBIdentityReport.exportDBIdentityReport(dBIdentityReport1);
        }
    }
}
