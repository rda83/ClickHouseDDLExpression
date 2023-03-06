
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecDoubleDelta : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "DoubleDelta";
        }
    }

    public class ColumnCompressionCodecDoubleDeltaAttribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecDoubleDelta();
        }
    }
}
