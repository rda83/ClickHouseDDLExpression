
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecDelta : ClickHouseCompressionCodecBase
    {
        private uint _deltaBytes;

        public ClickHouseCompressionCodecDelta(uint deltaBytes)
        {
            _deltaBytes = deltaBytes;
        }

        public override string GetViewSpecified()
        {
            return $"Delta({_deltaBytes})";
        }
    }

    public class ColumnCompressionCodecDeltaAttribute : ColumnCompressionCodecBaseAttribute
    {
        private readonly uint _deltaBytes;

        public ColumnCompressionCodecDeltaAttribute(uint deltaBytes)
        {
            _deltaBytes = deltaBytes;
        }

        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecDelta(_deltaBytes);
        }
    }
}
