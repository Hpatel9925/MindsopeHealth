using Microsoft.Data.SqlClient;
using MindScopeeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorRepository
{
    public class TableColumnRepository:ITableColumnRepository
    {
        private List<TableColumn> TableColumnList = new List<TableColumn>();
        public List<TableColumn> getTableColumnByName(string tableName, int DBID)
        {
            ConnectionString connectionString = new ConnectionString(DBID);
            SqlConnection conn = new SqlConnection(connectionString.getConnectionString());
            conn.Open();
            SqlCommand command = new SqlCommand("select name from sys.columns where object_id = OBJECT_ID('" + tableName + "')", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    TableColumnList.Add(new TableColumn { ColumnName = reader[0].ToString() });
                }
            }
            conn.Close();
            return TableColumnList;
        }
    }
}
