using System.ComponentModel.DataAnnotations;

namespace MindScopeHealthMonitorRepository.Models
{
    public class TableColumn
    {
        [Key]
        public string ColumnName { get; set; }
    }
}
