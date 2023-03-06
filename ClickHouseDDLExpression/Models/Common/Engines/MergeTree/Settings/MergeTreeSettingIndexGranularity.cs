
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingIndexGranularity : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingIndexGranularity(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"index_granularity={_value}";
        }
    }

    public class MergeTreeSettingIndexGranularityAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingIndexGranularityAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingIndexGranularity(Value);
        }
    }
}
