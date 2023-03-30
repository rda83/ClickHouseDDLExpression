
using System;

namespace ClickHouseDDLExpression.Models.ExpressionBuilderParameters
{
    public class CreateExpressionParameters
    {
        public string? DataBaseName { get; set; }
        public string? TableName { get; set; }
        public Func<string>? PartitioningKey { get; set; }
    }
}