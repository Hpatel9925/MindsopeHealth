using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService;
using System;
using System.Collections.Generic;

namespace MindScopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TableColumnsController : ControllerBase
    {
        private readonly ITableColumnService _tableColumnService;
        public TableColumnsController(ITableColumnService tableColumnService)
        {
            _tableColumnService = tableColumnService;
        }
        [HttpGet]
        public List<TableColumn> getDataByID(string tableName, int DBID)
        {
            try
            {
                return _tableColumnService.getTableColumnByName(tableName, DBID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
