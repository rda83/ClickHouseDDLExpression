
using ClickHouseDDLExpression.Attributes;

namespace ClickHouseDDLExpression.Models.Common.Engines.MergeTree.Settings
{
    /// <summary>
    /// https://clickhouse.com/docs/ru/engines/table-engines/mergetree-family/mergetree#mergetree
    /// </summary>
    public class MergeTreeSettingMaxPartsInTotal : EngineSettingBase
    {
        private readonly uint _value;
        public MergeTreeSettingMaxPartsInTotal(uint value)
        {
            _value = value;
        }

        public override string GetViewSpecified()
        {
            return $"max_parts_in_total={_value}";
        }
    }

    public class MergeTreeSettingMaxPartsInTotalAttribute : EngineSettingBaseAttribute
    {
        private uint Value { get; }

        public MergeTreeSettingMaxPartsInTotalAttribute(uint value)
        {
            Value = value;
        }

        public override IEngineSetting GetSettingSpecified()
        {
            return new MergeTreeSettingMaxPartsInTotal(Value);
        }
    }
}
