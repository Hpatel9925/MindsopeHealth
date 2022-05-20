using MindScopeHealthMonitorRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindScopeHealthMonitorRepository.Interfaces
{
    public interface ILoginRepository
    {
        public bool verifyUser(Users users);
    }
}
