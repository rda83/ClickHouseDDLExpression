
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeString : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "String";
        }
    }

    public class ClickHouseDataTypeStringAttribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeString();
        }
    }
}
