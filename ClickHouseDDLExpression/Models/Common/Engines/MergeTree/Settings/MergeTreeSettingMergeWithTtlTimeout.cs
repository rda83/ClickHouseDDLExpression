
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{

    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMergeWithTtlTimeout : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingMergeWithTtlTimeout(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"merge_with_ttl_timeout={_value}";
        }
    }

    public class MergeTreeSettingMergeWithTtlTimeoutAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMergeWithTtlTimeoutAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMergeWithTtlTimeout(Value);
        }
    }
}
