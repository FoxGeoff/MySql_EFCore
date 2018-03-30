using System;

namespace MySql_EFCore.Data.Entities
{
    public class DataEventRecord
    {
        public int DataEventRecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int SourceInfoId { get; set; }
    }
}