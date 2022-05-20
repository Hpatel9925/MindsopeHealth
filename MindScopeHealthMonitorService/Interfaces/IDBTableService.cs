using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;

namespace MindScopeHealthMonitorService
{
    public interface IDBTableService
    {
        public List<DBTable> getDBTableByID(int id);
    }
}
