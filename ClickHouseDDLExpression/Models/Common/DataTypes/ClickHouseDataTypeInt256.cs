
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt256 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int256";
        }
    }

    public class ClickHouseDataTypeInt256Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt256();
        }
    }
}
