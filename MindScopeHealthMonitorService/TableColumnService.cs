using MindScopeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorService
{
    
    public class TableColumnService : ITableColumnService
    {
        private ITableColumnRepository _tableColumnRepository;

        public TableColumnService(ITableColumnRepository tableColumnRepository)
        {
            _tableColumnRepository = tableColumnRepository;
        }

        public List<TableColumn> getTableColumnByName(string tableName, int DBID)
        {
            return _tableColumnRepository.getTableColumnByName(tableName,DBID);
        }
    }
}
