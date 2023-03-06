using ClickHouseDDLExpression.Models.Common;
using ClickHouseDDLExpression.Models.Common.IndexExpr;
using ClickHouseDDLExpression.Models.Common.IndexTypes;
using System;
using System.Text;

namespace ClickHouseDDLExpression.Models.CreateTable
{
    public class IndexDescription : IExpressionElement
    {
        public String IndexName { get; set; }
        public IndexExpr Expression { get; set; }
        public IClickHouseIndexType IndexType { get; set; }
        public UInt16 Granularity { get; set; }

        #region IExpressionElementMembers
        public string GetView()
        {
            var result = new StringBuilder()
                .Append("INDEX ")
                .Append($"{this.IndexName} ")
                .Append($"{this.Expression.GetView()} ")
                .Append($"TYPE {this.IndexType.GetView()} ")
                .Append($"GRANULARITY {this.Granularity}")
                .ToString();

            return result;
        }
        #endregion
    }
}
