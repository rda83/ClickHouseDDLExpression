
namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecBase : IClickHouseCompressionCodec
    {
        public string GetView()
        {
            return GetViewSpecified();
        }

        public virtual string GetViewSpecified()
        {
            return string.Empty;
        }                                     
    }
}
