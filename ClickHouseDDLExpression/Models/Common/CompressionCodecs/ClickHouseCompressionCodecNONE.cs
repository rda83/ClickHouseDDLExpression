
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecNONE : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "NONE";
        }
    }

    public class ColumnCompressionCodecNONEAttribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecNONE();
        }
    }
}
