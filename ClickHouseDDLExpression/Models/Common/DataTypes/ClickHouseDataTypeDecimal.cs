
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.DataTypes
{
    public class ClickHouseDataTypeDecimal : ClickHouseDataTypeBase
    {
        private readonly uint _p;
        private readonly uint _s;

        public ClickHouseDataTypeDecimal(uint p, uint s)
        {
            _p = p;
            _s = s;
        }

        public override string GetViewSpecified()
        {
            return $"Decimal({_p}, {_s})";
        }
    }

    public class ClickHouseDataTypeDecimalAttribute : ColumnDataTypeBaseAttribute
    {
        private readonly uint _p;
        private readonly uint _s;

        public ClickHouseDataTypeDecimalAttribute(uint p, uint s)
        {
            _p = p;
            _s = s;
        }

        public override IClickHouseDataType GetDataTypeSpecified()
        {
            return new ClickHouseDataTypeDecimal(_p, _s);
        }
    }
}
