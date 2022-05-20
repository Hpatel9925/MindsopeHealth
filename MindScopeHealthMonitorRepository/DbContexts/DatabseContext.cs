using Microsoft.EntityFrameworkCore;
using MindScopeHealthMonitorRepository.Models;

namespace MindscopeHealthMonitorRepository.DbContexts
{
    public class DatabseContext : DbContext
    {
        private readonly string _connectionString;
        public DatabseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_connectionString);
        //}
       
    }
}
