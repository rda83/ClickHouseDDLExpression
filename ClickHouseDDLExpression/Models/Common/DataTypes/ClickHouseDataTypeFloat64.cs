
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeFloat64 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Float64";
        }
    }

    public class ClickHouseDataTypeFloat64Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeFloat64();
        }
    }
}
