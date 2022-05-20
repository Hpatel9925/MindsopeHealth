using Microsoft.AspNetCore.Mvc;
using MindScopeHealthMonitorRepository.Interfaces;
using MindScopeHealthMonitorRepository.Models;
using System;
using System.Diagnostics;

namespace MindScopeHealthMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        
        [HttpPost]
        public bool verifyUser([FromBody] Users users)
        { 
            try
            {
                var user = _loginRepository.verifyUser(users);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
