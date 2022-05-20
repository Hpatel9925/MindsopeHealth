using MindscopeHealthMonitorRepository;
using MindScopeHealthMonitorRepository;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Diagnostics;

namespace MindScopeHealthMonitor.DBLists
{
    public class Database
    {
        public int Id { get; set; }
        public string DatabaseName { get; set; }
    }
    public class DatabaseList
    {
        private List<Database> databaseList = new List<Database>();
        public List<Database> getDatabseList()
        {
            ExcelSheetFile excelSheetFile = new ExcelSheetFile();

            var firstSheet = excelSheetFile.getExcelSheetFile();

            // Excel Sheet Column Number and Column name Database
            var ExcelSheetColumn = 3;
            
            for (int sheetRow = 2; sheetRow <= firstSheet.Dimension.End.Row; sheetRow++)
            {
                //select single database name from excel sheet...
                var databaseName = firstSheet.Cells[sheetRow, ExcelSheetColumn].Value;
                
                // add single database name and Id in databaseList 
                databaseList.Add(new Database { Id = sheetRow - 1,DatabaseName = databaseName.ToString() } );
            }
            return databaseList;
        }
         

    }
}
