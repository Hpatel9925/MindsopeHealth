using MindScopeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorService
{
    public class DBIdentityReportService : IDBIdentityReportService
    {
        private IDBIdentityReportRepo _dBIdentityReportRepo;

        public DBIdentityReportService(IDBIdentityReportRepo dBIdentityReportRepo)
        {
            _dBIdentityReportRepo = dBIdentityReportRepo;
        }
        public List<DBIdentityReport1> getConfigByID(DBInfo dB)
        {
            return _dBIdentityReportRepo.getConfigByID(dB);
        }
    }
}
