using OfficeOpenXml;
using System.IO;

namespace MindScopeHealthMonitorRepository
{
    public class ExcelSheetFile
    {
        public ExcelWorksheet getExcelSheetFile()
        {
            var package = new ExcelPackage(new FileStream(@"./ExcelFile/ConnectionString2.xlsx", FileMode.Open, FileAccess.Read));
            return package.Workbook.Worksheets[0];
        }
    }
}