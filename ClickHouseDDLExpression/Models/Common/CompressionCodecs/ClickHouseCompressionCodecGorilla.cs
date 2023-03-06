
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecGorilla : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "Gorilla";
        }
    }
    public class ColumnCompressionCodecGorillaAttribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecGorilla();
        }
    }
}
