
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeUInt32 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "UInt32";
        }
    }

    public class ClickHouseDataTypeUInt32Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeUInt32();
        }
    }
}
