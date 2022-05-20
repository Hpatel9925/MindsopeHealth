using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;


namespace MindScopeHealthMonitorService
{
    public interface IDBIdentityReportService
    {
        List<DBIdentityReport1> getConfigByID(DBInfo dB);
    }
}
