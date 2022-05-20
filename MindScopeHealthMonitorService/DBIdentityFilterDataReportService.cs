using MindScopeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;


namespace MindScopeHealthMonitorService
{
    public class DBIdentityFilterDataReportService : IDBIdentityFilterDataReportService
    {
        private IDBIdentityFilterDataReportRepo _dBIdentityFilterDataReportRepo;

        public DBIdentityFilterDataReportService(IDBIdentityFilterDataReportRepo dBIdentityFilterDataReportRepo)
        {
            _dBIdentityFilterDataReportRepo = dBIdentityFilterDataReportRepo;
        }

        public List<DBIdentityReport1> getFilterDataReport(DBFilerDataInfo dbFilterDataInfo)
        {
            return _dBIdentityFilterDataReportRepo.getFilterDataDBIdentityReport(dbFilterDataInfo);
        }
    }
}
