using MindScopeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;


namespace MindScopeHealthMonitorService
{
    public class DBTableService : IDBTableService
    {
        private IDBTableRepository dBTableRepository;

        public DBTableService(IDBTableRepository _dbTableRepository)
        {
            this.dBTableRepository = _dbTableRepository;
        }
        public List<DBTable> getDBTableByID(int id)
        {
            return dBTableRepository.getDBTableByID(id);
        }
    }
}
