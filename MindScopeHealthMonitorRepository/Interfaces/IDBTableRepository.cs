using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;

namespace MindScopeHealthMonitorRepository
{
    public interface IDBTableRepository
    {
        public List<DBTable> getDBTableByID(int id);
    }
}
