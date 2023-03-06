
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeDateTime : ClickHouseDataTypeBase 
    {
        public override string GetViewSpecified()
        {
            return "DateTime";
        }
    }

    public class ClickHouseDataTypeDateTimeAttribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeDateTime();
        }
    }
}
