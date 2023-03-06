
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingIndexGranularityBytes : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingIndexGranularityBytes(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"index_granularity_bytes={_value}";
        }
    }

    public class MergeTreeSettingIndexGranularityBytesAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingIndexGranularityBytesAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingIndexGranularityBytes(Value);
        }
    }
}
