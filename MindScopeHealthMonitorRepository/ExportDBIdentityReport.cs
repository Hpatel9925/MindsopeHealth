using MindScopeHealthMonitorRepository.Interfaces;
using MindScopeHealthMonitorRepository.Models;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System.Diagnostics;
using ClosedXML.Excel;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;

namespace MindScopeHealthMonitorRepository
{
    public class ExportDBIdentityReport : IExportDBIdentityReport
    {
        public void exportDBIdentityReport(DBIdentityReport1[] dBIdentityReport1)
        {
            Application xlApp = new Application();
            object misValue = System.Reflection.Missing.Value;
            var xlWorkbook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = xlWorkbook.Worksheets[1];
            xlWorkSheet.Cells(1, 1).Value = "Database Identity Report of Mindscope";
            xlWorkSheet.Range("A1:L1").Merge();
            var col = 3;
            for (int i = 0; i < dBIdentityReport1[0].listDBDetails.Count(); i++)
            {
                xlWorkSheet.Cells[2, col].Value = dBIdentityReport1[0].listDBDetails[i].strDBName;
                xlWorkSheet.Cells[col, col + 1].Merge();
                xlWorkSheet.Cells[3, col].Value = "IsKeyExists";
                xlWorkSheet.Cells[3, col + 1].Value = "IsValueExists";
                col = col + 2;
            }
            for (int i = 0; i < dBIdentityReport1[0].listOfTableColumn.Count(); i++)
            {
                xlWorkSheet.Cells[3, 1].Value = dBIdentityReport1[0].listOfTableColumn[0].ColumnName;
                xlWorkSheet.Cells[3, 2].Value = dBIdentityReport1[0].listOfTableColumn[1].ColumnName;
            }
            for (int row = 0; row < dBIdentityReport1.Count(); row++)
            {
                xlWorkSheet.Cells[row + 4, 1].Value = dBIdentityReport1[row].strKey;
                xlWorkSheet.Cells[row + 4, 2].Value = dBIdentityReport1[row].strValue;
                var column = 3;
                for (int i = 0; i < dBIdentityReport1[row].listDBDetails.Count(); i++)
                {
                    xlWorkSheet.Cells[row + 4, column].Value = dBIdentityReport1[row].listDBDetails[i].IsKeyExists;
                    xlWorkSheet.Cells[row + 4, column + 1].Value = dBIdentityReport1[row].listDBDetails[i].IsValueExists;
                    column = column + 2;
                }
            }
            xlWorkbook.SaveAs(@"D:\mySheet.xlsx");
            xlWorkbook.Close();
            xlApp.Quit();
        }

    }
}
