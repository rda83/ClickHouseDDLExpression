
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeUInt8 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "UInt8";
        }
    }

    public class ClickHouseDataTypeUInt8Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeUInt8();
        }
    }
}
