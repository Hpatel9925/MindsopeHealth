using System.ComponentModel.DataAnnotations;

namespace MindScopeHealthMonitorRepository.Models
{
    public class DBTable
    {
        [Key]
        public string TableName { get; set; }
    }
}
