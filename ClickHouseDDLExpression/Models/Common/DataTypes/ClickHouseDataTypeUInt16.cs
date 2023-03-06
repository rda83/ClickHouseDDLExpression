
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeUInt16 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "UInt16";
        }
    }

    public class ClickHouseDataTypeUInt16Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeUInt16();
        }
    }
}
