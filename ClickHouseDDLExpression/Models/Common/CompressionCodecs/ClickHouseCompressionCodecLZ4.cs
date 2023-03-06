
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecLZ4 : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "LZ4";
        }
    }

    public class ColumnCompressionCodecLZ4Attribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecLZ4();
        }
    }
}
