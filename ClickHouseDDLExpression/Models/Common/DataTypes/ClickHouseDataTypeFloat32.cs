
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeFloat32 : ClickHouseDataTypeBase
    {
        public override string GetViewSpecified()
        {
            return "Float32";
        }
    }

    public class ClickHouseDataTypeFloat32Attribute : ColumnDataTypeBaseAttribute
    {
        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeFloat32();
        }
    }
}
