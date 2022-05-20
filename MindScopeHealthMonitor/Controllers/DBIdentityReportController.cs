using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService;
using System;
using System.Collections.Generic;

namespace MindscopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBIdentityReportController : ControllerBase
    {
        private readonly IDBIdentityReportService _configService;
        public DBIdentityReportController(IDBIdentityReportService configService)
        {
            _configService = configService;
        }

        [HttpPost]
        public List<DBIdentityReport1> GetConfigsByID([FromBody] DBInfo dB)
        {
            try
            {
                return _configService.getConfigByID(dB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
