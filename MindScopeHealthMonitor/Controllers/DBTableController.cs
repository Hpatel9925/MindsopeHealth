using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Models;
using MindScopeHealthMonitorService;
using System.Collections.Generic;

namespace MindScopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DBTableController : ControllerBase
    {
        private IDBTableService dBTableService;

        public DBTableController(IDBTableService _dBTableService)
        {
            this.dBTableService = _dBTableService;
        }
        [HttpPost]
        public List<DBTable> GetDBTable([FromBody]int id)
        {
           return dBTableService.getDBTableByID(id);
        }
    }
}
