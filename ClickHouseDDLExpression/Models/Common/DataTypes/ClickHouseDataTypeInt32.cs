
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt32 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int32";
        }
    }

    public class ClickHouseDataTypeInt32Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt32();
        }
    }
}
