
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt64 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int64";
        }
    }

    public class ClickHouseDataTypeInt64Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt64();
        }
    }
}
