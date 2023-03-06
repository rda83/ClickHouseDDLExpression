
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMaxCompressBlockSize : EngineSettingBase
    {
        private readonly uint _value;
        public MergeTreeSettingMaxCompressBlockSize(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"max_compress_block_size={_value}";
        }
    }

    public class MergeTreeSettingMaxCompressBlockSizeAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMaxCompressBlockSizeAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMaxCompressBlockSize(Value);
        }
    }
}
