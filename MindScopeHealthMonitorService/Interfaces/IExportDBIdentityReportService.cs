using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorService.Interfaces
{
    public interface IExportDBIdentityReportService
    {
        public void ExportDBIdentityReport(DBIdentityReport1 [] dBIdentityReport1);
    }
}
