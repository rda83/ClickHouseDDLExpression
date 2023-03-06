
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecLZ4HC : ClickHouseCompressionCodecBase
    {
        private uint _level;

        public ClickHouseCompressionCodecLZ4HC(uint level)
        {
            _level = level;
        }

        public override string GetViewSpecified()
        {
            return $"LZ4HC({_level})";
        }
    }

    public class ColumnCompressionCodecLZ4HCAttribute : ColumnCompressionCodecBaseAttribute
    {
        private readonly uint _level;

        public ColumnCompressionCodecLZ4HCAttribute(uint level)
        {
            _level = level;
        }

        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecLZ4HC(_level);
        }
    }
}
