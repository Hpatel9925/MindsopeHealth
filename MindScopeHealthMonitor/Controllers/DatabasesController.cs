using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitor.DBLists;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Diagnostics;

namespace MindScopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabasesController : ControllerBase
    {
        private DatabaseList databaseList = new DatabaseList();
        
        [HttpGet]
        public List<Database> Get()
        { 
            return databaseList.getDatabseList();
        }
    }
}
