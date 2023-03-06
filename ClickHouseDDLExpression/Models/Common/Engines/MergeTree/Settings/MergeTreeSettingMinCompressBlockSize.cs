
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{

    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMinCompressBlockSize : EngineSettingBase
    {
        private readonly ulong _value;
        public MergeTreeSettingMinCompressBlockSize(ulong value)
        {
            _value = value; 
        }

        public override string GetViewSpecified()
        {
            return $"min_compress_block_size={_value}";
        }
    }

    public class MergeTreeSettingMinCompressBlockSizeAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMinCompressBlockSizeAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMinCompressBlockSize(Value);
        }
    }
}
