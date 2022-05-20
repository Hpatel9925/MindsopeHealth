using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService;
using System;
using System.Collections.Generic;

namespace MindscopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBIdentityFilterDataReportController : ControllerBase
    {
        private readonly IDBIdentityFilterDataReportService _dbIdentityReportService;
        public DBIdentityFilterDataReportController(IDBIdentityFilterDataReportService dbIdentityReportService)
        {
            _dbIdentityReportService = dbIdentityReportService;
        }

        [HttpPost]
        public List<DBIdentityReport1> GetFilterDataReport([FromBody] DBFilerDataInfo dbFilerDataInfo)
        {
            try
            {
                return _dbIdentityReportService.getFilterDataReport(dbFilerDataInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

