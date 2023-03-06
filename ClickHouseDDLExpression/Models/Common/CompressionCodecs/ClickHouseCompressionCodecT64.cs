
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecT64 : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "T64";
        }
    }

    public class ColumnCompressionCodecT64Attribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecT64();
        }
    }
}
