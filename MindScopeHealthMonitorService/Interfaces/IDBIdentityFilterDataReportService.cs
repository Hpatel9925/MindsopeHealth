using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;


namespace MindScopeHealthMonitorService
{
    public interface IDBIdentityFilterDataReportService
    {
        List<DBIdentityReport1> getFilterDataReport(DBFilerDataInfo dbFilterDataInfo);
    }
}
