using System.ComponentModel.DataAnnotations;

namespace MindScopeHealthMonitorRepository.Models
{
    public class Department
    {
        [Key]
        public string name { get; set; }
        public string address { get; set; }
    }
}
