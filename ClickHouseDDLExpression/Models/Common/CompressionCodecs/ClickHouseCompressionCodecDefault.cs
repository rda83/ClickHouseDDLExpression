
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecDefault : ClickHouseCompressionCodecBase
    {
        public override string GetViewSpecified()
        {
            return "Default";
        }
    }


    public class ColumnCompressionCodecDefaultAttribute : ColumnCompressionCodecBaseAttribute
    {
        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecDefault();
        }
    }
}
