
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMinRowsForWidePart : EngineSettingBase
    {
        private readonly ulong _value;
        public MergeTreeSettingMinRowsForWidePart(ulong value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"min_rows_for_wide_part={_value}";
        }
    }

    public class MergeTreeSettingMinRowsForWidePartAttribute : EngineSettingBaseAttribute
    {
        private ulong Value { get; }

        public MergeTreeSettingMinRowsForWidePartAttribute(ulong value)
        {
                Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMinRowsForWidePart(Value);
        }
    }
}
