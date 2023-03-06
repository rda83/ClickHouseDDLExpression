
using ClickHouseDDLExpression.Models.Common.Engines;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.Common.SampleByExpr;
using System.Collections.Generic;

namespace ClickHouseDDLExpression.Models.CreateTable
{
    public class CreateTableCommand
    {
        public bool IfNotExists { get; set; }
        public string DbName { get; set; }
        public string TableName { get; set; }
        public List<ColumnDescription> ColumnDescriptions { get; set; }
        public List<IndexDescription> IndexDescriptions { get; set; }
        public PartitioningKeyValue? PartitioningKey { get; set; }
        public SampleByExpr? SampleByExpr { get; set; }
        public ITableEngine TableEngine { get; set; }
        public CreateTableCommand()
        {
            ColumnDescriptions = new List<ColumnDescription>();
            IndexDescriptions = new List<IndexDescription>();
        }
    }
}
