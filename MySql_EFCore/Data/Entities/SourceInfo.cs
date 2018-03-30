using System;
using System.Collections.Generic;

namespace MySql_EFCore.Data.Entities
{
    public class SourceInfo
    {
        public int SourceInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime MyProperty { get; set; }

        public IEnumerable<DataEventRecord> DataEventRecords { get; set; }
    }
}