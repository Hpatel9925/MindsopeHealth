using Microsoft.Data.SqlClient;
using MindScopeeHealthMonitorRepository;
using MindScopeHealthMonitorRepository.Interfaces;
using MindScopeHealthMonitorRepository.Models;
using System.Diagnostics;

namespace MindScopeHealthMonitorRepository
{
    public class LoginRepository : ILoginRepository
    {
        private bool _isVelidUser;
        public bool verifyUser(Users users)
        {
            //ConnectionString connectionString = new ConnectionString(3); // here "3" is database id from Excel File
            SqlConnection conn = new SqlConnection(@"Server=WIN-CB2A0OK4E56\SQLEXPRESS; Database=MindScope; User Id=harshad.patel; Password=harshad@123");
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = '" + users.UserName + "' AND Password = '" + users.Password + "'", conn);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            _isVelidUser = reader.GetInt32(0) == 1 ? true : false;
            reader.Close();
            conn.Close();
            return _isVelidUser;
        }
    }
}
