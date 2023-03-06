using ClickHouseDDLExpression.Demo.Models;
using ClickHouseDDLExpression.Features.CreateTable;
using ClickHouseDDLExpression.Models.Common.CompressionCodecs;
using ClickHouseDDLExpression.Models.Common.DataTypes;
using ClickHouseDDLExpression.Models.Common.PartitioningKey;
using ClickHouseDDLExpression.Models.ExpressionBuilderParameters;

namespace ClickHouseDDLExpression.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new CreateTableBuilder();

            var e = builder.Build<Event>(new CreateExpressionParameters() { DataBaseName = "TestDB" });
            Console.WriteLine(e);
        }
    }
}