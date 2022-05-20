using MindScopeHealthMonitorRepository;

namespace MindScopeeHealthMonitorRepository
{
    public class ConnectionString
    {
        private string serverName;
        private string databaseName;
        private string username;
        private string password;
        private int DatabaseID;
        public ConnectionString(int DatabasId)
        {
            DatabaseID = DatabasId;
        }
        public string getConnectionString()
        {
            ExcelSheetFile excelSheetFile = new ExcelSheetFile();

            var firstSheet = excelSheetFile.getExcelSheetFile();

            for (int SheetRow = 2; SheetRow <= firstSheet.Dimension.End.Row; SheetRow++)
            {
                    if((double)firstSheet.Cells[SheetRow, 1].Value == DatabaseID) // hear 1 is column number. [SheetRow, 1]
                    {
                        string server = (string)firstSheet.Cells[SheetRow, 2].Value;
                       
                        string database = (string)firstSheet.Cells[SheetRow, 3].Value;
                     
                        string username = (string)firstSheet.Cells[SheetRow, 4].Value;
                       
                        string password = (string)firstSheet.Cells[SheetRow, 5].Value;
                      
                        this.serverName = server;
                        this.databaseName = database;
                        this.username = username;
                        this.password = password;  
                    } 
            } 
            return "Server=" + this.serverName + "; Database=" + this.databaseName + "; User Id=" + this.username + "; Password=" + this.password;   
        }
    }
}



