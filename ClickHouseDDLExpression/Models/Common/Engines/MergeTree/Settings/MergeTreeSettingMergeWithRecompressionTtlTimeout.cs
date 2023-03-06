
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMergeWithRecompressionTtlTimeout : EngineSettingBase
    {
        private readonly uint _value;

        public MergeTreeSettingMergeWithRecompressionTtlTimeout(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"merge_with_recompression_ttl_timeout={_value}";
        }
    }

    public class MergeTreeSettingMergeWithRecompressionTtlTimeoutAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMergeWithRecompressionTtlTimeoutAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMergeWithRecompressionTtlTimeout(Value);
        }
    }
}
