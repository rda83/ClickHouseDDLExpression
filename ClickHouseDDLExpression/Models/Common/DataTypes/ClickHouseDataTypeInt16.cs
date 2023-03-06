
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt16 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int16";
        }
    }

    public class ClickHouseDataTypeInt16Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt16();
        }
    }
}
