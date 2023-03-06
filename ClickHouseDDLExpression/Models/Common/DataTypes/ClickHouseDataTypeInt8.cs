
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt8 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int8";
        }
    }

    public class ClickHouseDataTypeInt8Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt8();
        }
    }
}
