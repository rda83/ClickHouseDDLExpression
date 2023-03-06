using System;

namespace ClickHouseDDLExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ClickHouseColumnAttribute : Attribute
    {
        public string? Name { get; set; }
        public bool NotNull { get; set; }
        public uint OrderBy { get; set; }
        public uint PrimaryKey { get; set; }
    }
}
