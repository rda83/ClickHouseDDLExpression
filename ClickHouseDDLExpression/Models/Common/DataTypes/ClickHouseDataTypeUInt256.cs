
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeUInt256 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "UInt256";
        }
    }

    public class ClickHouseDataTypeUInt256Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeUInt256();
        }
    }
}
