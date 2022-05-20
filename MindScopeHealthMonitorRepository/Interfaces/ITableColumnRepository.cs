using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorRepository
{
    public interface ITableColumnRepository
    {
        public List<TableColumn> getTableColumnByName(string tableName, int DBID);
    }
}
