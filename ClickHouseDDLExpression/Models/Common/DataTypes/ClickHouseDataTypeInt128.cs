
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeInt128 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Int128";
        }
    }

    public class ClickHouseDataTypeInt128Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeInt128();
        }
    }
}
