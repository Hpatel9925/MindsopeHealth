using System.ComponentModel.DataAnnotations;

namespace MindScopeHealthMonitorRepository.Models
{
    public class configtable
    { 
        [Key]
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }   
    }
}
