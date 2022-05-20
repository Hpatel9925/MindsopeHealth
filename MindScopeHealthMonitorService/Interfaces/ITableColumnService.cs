using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorService
{
    public interface ITableColumnService
    {
        public List<TableColumn> getTableColumnByName(string tableName, int DBID);
        
    }
}
