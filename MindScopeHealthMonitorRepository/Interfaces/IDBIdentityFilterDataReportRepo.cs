using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;


namespace MindScopeHealthMonitorRepository
{
    public interface IDBIdentityFilterDataReportRepo
    {
        List<DBIdentityReport1> getFilterDataDBIdentityReport(DBFilerDataInfo dbFilterDataInfo);
    }
}
