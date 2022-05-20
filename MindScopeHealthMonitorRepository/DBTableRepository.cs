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
    public class DBTableRepository:IDBTableRepository
    {
        private List<DBTable> DBTableList = new List<DBTable>();
        public List<DBTable> getDBTableByID(int id)
        {
            ConnectionString connectionString = new ConnectionString(id);
            SqlConnection conn = new SqlConnection(connectionString.getConnectionString());
            conn.Open();
            SqlCommand command = new SqlCommand("select TABLE_NAME from INFORMATION_SCHEMA.TABLES", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DBTableList.Add(new DBTable { TableName = reader[0].ToString() });
                }
            }
            return DBTableList;
        }
    }
}
