using System;
using ClickHouseDDLExpression.Models.Common.CompressionCodecs;

namespace ClickHouseDDLExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ColumnCompressionCodecBaseAttribute : Attribute
    {
        public IClickHouseCompressionCodec GetCompressionCodec()
        {
            return GetCompressionCodecSpecified();
        }

        public virtual IClickHouseCompressionCodec GetCompressionCodecSpecified()
        {
            throw new NotImplementedException();
        }
    }
}
