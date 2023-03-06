
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeUInt64: ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "UInt64";
        }
    }

    public class ClickHouseDataTypeUInt64Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeUInt64();
        }
    }
}
