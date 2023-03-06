
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.CompressionCodecs
{
    public class ClickHouseCompressionCodecZSTD : ClickHouseCompressionCodecBase
    {
        private uint _level;

        public ClickHouseCompressionCodecZSTD(uint level)
        {
            _level = level;
        }

        public override string GetViewSpecified()
        {
            return $"ZSTD({_level})";
        }
    }

    public class ColumnCompressionCodecZSTDAttribute : ColumnCompressionCodecBaseAttribute
    {
        private readonly uint _level;

        public ColumnCompressionCodecZSTDAttribute(uint level)
        {
            _level = level;
        }

        public override IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            return new ClickHouseCompressionCodecZSTD(_level);
        }
    }
}
