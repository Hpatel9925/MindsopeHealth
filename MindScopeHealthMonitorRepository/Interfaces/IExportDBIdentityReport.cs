using MindScopeHealthMonitorRepository.Models;

namespace MindScopeHealthMonitorRepository.Interfaces
{
    public interface IExportDBIdentityReport
    {
        public void exportDBIdentityReport(DBIdentityReport1 [] dBIdentityReport1);
    }
}
