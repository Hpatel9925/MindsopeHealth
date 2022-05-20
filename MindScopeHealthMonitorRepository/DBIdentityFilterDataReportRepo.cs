using Microsoft.Data.SqlClient;
using MindScopeeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace MindScopeHealthMonitorRepository
{
    public class DBIdentityFilterDataReportRepo : IDBIdentityFilterDataReportRepo
    {
        private List<DBIdentityReport1> listDBIdentityReport = new List<DBIdentityReport1>();
        private List<DBIdentityReport1> listUnmatchDataReport = new List<DBIdentityReport1>();
        private List<databaseDetail> databaseDetail = new List<databaseDetail>();

        public List<DBIdentityReport1> getFilterDataDBIdentityReport(DBFilerDataInfo dbFilterDataInfo)
        {
            //get Connection String
            ConnectionString connectionString = new ConnectionString(dbFilterDataInfo.DBID);
            //Connection with database
            SqlConnection conn = new SqlConnection(connectionString.getConnectionString());
            conn.Open();
            SqlCommand command = new SqlCommand("select " + dbFilterDataInfo.tableColumns[0] + ", " + dbFilterDataInfo.tableColumns[1] + " from " + dbFilterDataInfo.tableName, conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    databaseDetail.Add(new databaseDetail
                    {
                        key = reader.GetString(0),
                        value = reader.IsDBNull(reader.GetOrdinal(dbFilterDataInfo.tableColumns[1])) ? null : (string)reader.GetString(1)
                    });
                }
                reader.Close();
            }
            conn.Close();

            for (int i = 0; i < databaseDetail.Count(); i++)
            {
                DBIdentityReport1 report = new DBIdentityReport1();

                // Get Selected Table Columns List 
                for (int j = 0; j < dbFilterDataInfo.tableColumns.Count(); j++)
                {
                    report.listOfTableColumn.Add(new TableColumn
                    {
                        ColumnName = dbFilterDataInfo.tableColumns[j]
                    });
                }

                report.strKey = (string)databaseDetail[i].key;
                report.strValue = (string)databaseDetail[i].value;

                //get excel sheet file
                ExcelSheetFile excelSheetFile = new ExcelSheetFile();
                var firstSheet = excelSheetFile.getExcelSheetFile();

                // find database name from excel sheet 
                for (int sheetRow = 2; sheetRow <= firstSheet.Dimension.End.Row; sheetRow++)
                {
                    var id = (double)firstSheet.Cells[sheetRow, 1].Value;
                    // Get Connection String
                    ConnectionString conString = new ConnectionString((int)id);
                    SqlConnection con = new SqlConnection(conString.getConnectionString());
                    con.Open();

                    // Find ConfigKey Exists or not in database 
                    SqlCommand cmd = new SqlCommand("select COUNT(*) from " + dbFilterDataInfo.tableName + " where " + dbFilterDataInfo.tableColumns[0] + " = '" + report.strKey + "'", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    var ConfigKey = reader.GetInt32(0) == 1 ? true : false;
                    reader.Close();

                    // Find particular Configkey value Exists or not in database
                    SqlCommand cmd1 = new SqlCommand("select COUNT(*) from " + dbFilterDataInfo.tableName + " where " + dbFilterDataInfo.tableColumns[0] + " = '" + report.strKey + "' and " + dbFilterDataInfo.tableColumns[1] + " = '" + report.strValue + "'", con);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Read();
                    var ConfigValue = reader1.GetInt32(0) == 1 ? true : false;
                    reader1.Close();

                    report.listDBDetails.Add(new DBDetail1
                    {
                        strDBName = firstSheet.Cells[sheetRow, 3].Value.ToString(),
                        IsKeyExists = ConfigKey,
                        IsValueExists = ConfigValue
                    });
                    con.Close();
                }
                listDBIdentityReport.Add(report);
            }

            // Get Applied Filter Data 
            // // Return Not Metch Data from All database
            if (dbFilterDataInfo.filterDataId == 1) 
            {
                for (int i = 0; i < databaseDetail.Count(); i++)
                {
                    if (databaseDetail[i].key == listDBIdentityReport[i].strKey && databaseDetail[i].value == listDBIdentityReport[i].strValue)
                    {
                        for (int j = 0; j < listDBIdentityReport[i].listDBDetails.Count(); j++)
                        {
                            if (listDBIdentityReport[i].listDBDetails[j].IsKeyExists == false || listDBIdentityReport[i].listDBDetails[j].IsValueExists == false)
                            {
                                listUnmatchDataReport.Add(listDBIdentityReport[i]);
                                break;
                            }
                        }
                    }
                }
                return listUnmatchDataReport;
            }
            
            // Return all data of Database Identity Report
            return listDBIdentityReport;
        }
    }
}
