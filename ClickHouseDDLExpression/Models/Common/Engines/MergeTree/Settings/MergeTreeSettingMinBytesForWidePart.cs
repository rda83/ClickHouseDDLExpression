
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMinBytesForWidePart : EngineSettingBase
    {
        private readonly ulong _value;
        public MergeTreeSettingMinBytesForWidePart(ulong value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"min_bytes_for_wide_part={_value}";
        }
    }

    public class MergeTreeSettingMinBytesForWidePartAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMinBytesForWidePartAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMinBytesForWidePart(Value);
        }
    }
}
