using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;

namespace MindScopeHealthMonitorRepository.Models
{
    public class DBIdentityReport1
    {
        public string strKey { get; set; }
        public string strValue { get; set; }
        public List<DBDetail1> listDBDetails { get; set; }
        public List<TableColumn> listOfTableColumn { get; set; }

        public DBIdentityReport1()
        {
            listDBDetails = new List<DBDetail1>();
            listOfTableColumn = new List<TableColumn>();
        }
    }
}
