
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMergeMaxBlockSize : EngineSettingBase
    {
        private readonly uint _value;
        public MergeTreeSettingMergeMaxBlockSize(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"merge_max_block_size={_value}";
        }
    }

    public class MergeTreeSettingMergeMaxBlockSizeAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMergeMaxBlockSizeAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMergeMaxBlockSize(Value);
        }
    }
}
