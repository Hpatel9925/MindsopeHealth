namespace MindScopeHealthMonitorRepository.Models
{
    public class DBFilerDataInfo
    {
        public int DBID { get; set; }
        public string tableName { get; set; }
        public string [] tableColumns { get; set; }
        public int filterDataId { get; set; }
    }
}
