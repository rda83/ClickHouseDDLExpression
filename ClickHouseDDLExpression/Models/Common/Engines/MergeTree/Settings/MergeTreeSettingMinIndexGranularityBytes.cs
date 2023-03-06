
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{

    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMinIndexGranularityBytes : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingMinIndexGranularityBytes(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"min_index_granularity_bytes={_value}";
        }
    }

    public class MergeTreeSettingMinIndexGranularityBytesAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMinIndexGranularityBytesAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMinIndexGranularityBytes(Value);
        }
    }
}
