using System;

namespace ClickHouseDDLExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public class ClickHouseTableAttribute : Attribute
    {
        public string? DbName { get; set; }
        public string? TableName { get; set; }
        public bool IsNotExists { get; set; }
        public string? PartitioningKey { get; set; }
    }
}
